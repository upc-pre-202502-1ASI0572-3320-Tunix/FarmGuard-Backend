using FarmGuard_Backend.IAM.Application.Internal.OutboundServices;
using FarmGuard_Backend.IAM.Domain.Model.Queries;
using FarmGuard_Backend.IAM.Domain.Services;
using FarmGuard_Backend.IAM.Infrastructure.Pipeline.Middleware.Attributes;
using System.Net;

namespace FarmGuard_Backend.IAM.Infrastructure.Pipeline.Middleware.Components;

/**
 * RequestAuthorizationMiddleware is a custom middleware.
 * This middleware is used to authorize requests.
 * It validates a token is included in the request header and that the token is valid.
 * If the token is valid then it sets the user in HttpContext.Items["User"].
 */
public class RequestAuthorizationMiddleware(RequestDelegate next)
{
    /**
     * InvokeAsync is called by the ASP.NET Core runtime.
     * It is used to authorize requests.
     * It validates a token is included in the request header and that the token is valid.
     * If the token is valid then it sets the user in HttpContext.Items["User"].
     */
    public async Task InvokeAsync(
        HttpContext context,
        IUserQueryService userQueryService,
        ITokenService tokenService)
    {
        Console.WriteLine("Entering InvokeAsync");
        
        // Skip authorization for OPTIONS requests (CORS preflight)
        if (context.Request.Method == HttpMethods.Options)
        {
            Console.WriteLine("Skipping authorization for OPTIONS request");
            await next(context);
            return;
        }

        // skip authorization if endpoint is decorated with [AllowAnonymous] attribute
        var endpoint = context.Request.HttpContext.GetEndpoint();
        if (endpoint != null)
        {
            var allowAnonymous = endpoint.Metadata.Any(m => m.GetType() == typeof(AllowAnonymousAttribute));
            Console.WriteLine($"Allow Anonymous is {allowAnonymous}");
            if (allowAnonymous)
            {
                Console.WriteLine("Skipping authorization");
                await next(context);
                return;
            }
        }

        Console.WriteLine("Entering authorization");
        // get token from request header
        var token = context.Request.Headers["Authorization"].FirstOrDefault()?.Split(" ").Last();

        // if token is null then return 401
        if (string.IsNullOrWhiteSpace(token))
        {
            Console.WriteLine("Token is null or empty - returning 401");
            context.Response.StatusCode = (int)HttpStatusCode.Unauthorized;
            await context.Response.WriteAsJsonAsync(new { message = "Authorization token is required" });
            return;
        }

        try
        {
            // validate token
            var userId = await tokenService.ValidateToken(token);

            // if token is invalid then return 401
            if (userId == null)
            {
                Console.WriteLine("Token validation failed - returning 401");
                context.Response.StatusCode = (int)HttpStatusCode.Unauthorized;
                await context.Response.WriteAsJsonAsync(new { message = "Invalid or expired token" });
                return;
            }

            // get user by id
            var getUserByIdQuery = new GetUserByIdQuery(userId.Value);
            var user = await userQueryService.Handle(getUserByIdQuery);

            if (user == null)
            {
                Console.WriteLine("User not found - returning 401");
                context.Response.StatusCode = (int)HttpStatusCode.Unauthorized;
                await context.Response.WriteAsJsonAsync(new { message = "User not found" });
                return;
            }

            Console.WriteLine("Successful authorization. Updating Context...");
            context.Items["User"] = user;
            Console.WriteLine("Continuing with Middleware Pipeline");
            
            // call next middleware
            await next(context);
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Authorization error: {ex.Message}");
            context.Response.StatusCode = (int)HttpStatusCode.Unauthorized;
            await context.Response.WriteAsJsonAsync(new { message = "Authorization failed", error = ex.Message });
        }
    }
}