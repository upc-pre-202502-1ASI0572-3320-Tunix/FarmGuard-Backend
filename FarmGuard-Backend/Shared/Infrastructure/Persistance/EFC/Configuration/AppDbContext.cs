using System.Diagnostics;
using EntityFrameworkCore.CreatedUpdatedDate.Extensions;
using FarmGuard_Backend.Animals.Domain.Model.Aggregates;
using FarmGuard_Backend.IAM.Domain.Model.Aggregates;
using FarmGuard_Backend.MedicHistory.Domain.Model.Aggregates;
using FarmGuard_Backend.MedicHistory.Domain.Model.Entities;
using FarmGuard_Backend.Notifications.Domain.Model.Aggregates;
using FarmGuard_Backend.profile.Domain.Model.Aggregate;
using FarmGuard_Backend.Shared.Infrastructure.Persistance.EFC.Configuration.Extensions.Extensions;
using Microsoft.EntityFrameworkCore;

namespace FarmGuard_Backend.Shared.Infrastructure.Persistance.EFC.Configuration;

public class AppDbContext(DbContextOptions options):DbContext(options)
{
    protected override void OnConfiguring(DbContextOptionsBuilder builder)
    {
        builder.AddCreatedUpdatedInterceptor();
        base.OnConfiguring(builder);
    }

    protected override void OnModelCreating(ModelBuilder builder)
    {
        base.OnModelCreating(builder);
        /*Aqui mapeas las entidades y defines si se requiere o se
         genere un campo en bd. Ademas de agregar las relaciones*/
        
        /*Animal Bounded Context*/
        builder.Entity<Animal>().HasKey(p => p.Id);
        builder.Entity<Animal>().Property(p => p.Id)
            .IsRequired().ValueGeneratedOnAdd();
        //Ejemplo de como mapear una valueobject en dbcontext
        builder.Entity<Animal>().OwnsOne(t => t.SerialNumber, n =>
        {
            n.WithOwner().HasForeignKey("id");
            n.Property(a => a.Number).HasColumnName("id_animal");
        });
        builder.Entity<Animal>().Property(p => p.Name).IsRequired();
        builder.Entity<Animal>().Property(p => p.Specie).IsRequired();
        builder.Entity<Animal>().Property(p => p.urlPhoto).IsRequired();
        builder.Entity<Animal>().Property(p => p.urlIot).IsRequired();
        builder.Entity<Animal>().Property(p => p.Location).IsRequired();
        builder.Entity<Animal>().Property(p => p.Temperature).IsRequired().HasColumnType("decimal(18,2)");
        builder.Entity<Animal>().Property(p => p.HearRate).IsRequired().HasColumnType("decimal(18,2)");
        
        builder.Entity<Section>().HasKey(i=>i.Id);
        builder.Entity<Section>().Property(i => i.Id).IsRequired().ValueGeneratedOnAdd();
        builder.Entity<Section>().Property(i => i.Name).IsRequired();
        
        
        
        /*MedicalHistory Bounded Context*/
        /*Vacuna*/
        builder.Entity<Vaccine>().HasKey(v => v.Id);
        builder.Entity<Vaccine>().Property(v => v.Id)
            .IsRequired().ValueGeneratedOnAdd();
        builder.Entity<Vaccine>().Property(v => v.Name).IsRequired();
        builder.Entity<Vaccine>().Property(v => v.Manufacturer ).IsRequired();
        builder.Entity<Vaccine>().Property(v => v.Schema ).IsRequired();
        /*Historia Medica*/
        builder.Entity<MedicalHistory>().HasKey(m => m.Id);
        builder.Entity<MedicalHistory>().Property(m => m.Id)
            .IsRequired().ValueGeneratedOnAdd();
        /*Diagnostico Enfermedad*/
        builder.Entity<DiseaseDiagnosis>().HasKey(d => d.Id);
        builder.Entity<DiseaseDiagnosis>().Property(d => d.Id)
            .IsRequired().ValueGeneratedOnAdd();
        builder.Entity<DiseaseDiagnosis>().Property(d => d.Severity).IsRequired();
        builder.Entity<DiseaseDiagnosis>().Property(d => d.Notes).IsRequired();
        builder.Entity<DiseaseDiagnosis>().Property(d => d.DiagnosedAt).IsRequired();
        /*Enfermedad*/
        builder.Entity<Disease>().HasKey(d => d.Id);
        builder.Entity<Disease>().Property(d => d.Id)
            .IsRequired().ValueGeneratedOnAdd();
        builder.Entity<Disease>().Property(d => d.Name).IsRequired();
        builder.Entity<Disease>().Property(d => d.Code).IsRequired();
        
        /*tratamiento*/
        builder.Entity<Treatment>().HasKey(t =>t.Id);
        builder.Entity<Treatment>().Property(t => t.Id)
            .IsRequired().ValueGeneratedOnAdd();
        builder.Entity<Treatment>().Property(t => t.Title).IsRequired();
        builder.Entity<Treatment>().Property(t => t.Notes).IsRequired();
        builder.Entity<Treatment>().Property(t => t.StartDate).IsRequired();
        builder.Entity<Treatment>().Property(t => t.Status).IsRequired();
        
        /*Medicacion*/
        builder.Entity<Medication>().HasKey(m => m.Id);
        builder.Entity<Medication>().Property(m => m.Id)
            .IsRequired().ValueGeneratedOnAdd();
        builder.Entity<Medication>().Property(m => m.Name).IsRequired();
        builder.Entity<Medication>().Property(m => m.DoseDefault).IsRequired();
        builder.Entity<Medication>().Property(m => m.ActiveIngredient).IsRequired();
        builder.Entity<Medication>().Property(m => m.RouteOfAdministration).IsRequired();
        
        
        /*Profile Bounded Context*/
        builder.Entity<Profile>().HasKey(p=>p.Id);
        builder.Entity<Profile>().Property(p=>p.Id)
            .IsRequired().ValueGeneratedOnAdd();
        builder.Entity<Profile>().Property(p => p.UrlPhoto).IsRequired();
        builder.Entity<Profile>().OwnsOne(p => p.Email, email =>
        {
            email.WithOwner().HasForeignKey("id");
            email.Property(a => a.EAddress).IsRequired();

        });
        builder.Entity<Profile>().OwnsOne(p => p.Name, personName =>
        {
            personName.WithOwner().HasForeignKey("id");
            personName.Property(pn => pn.FirstName).IsRequired();
            personName.Property(pn => pn.LastName).IsRequired();

        });
        
        /*Relaciones*/
        
        builder.Entity<MedicalHistory>()
            .HasOne(m => m.Animal)
            .WithOne(a => a.medicalHistory)
            .HasForeignKey<MedicalHistory>(m => m.AnimalId)
            .OnDelete(DeleteBehavior.Cascade);
        
        builder.Entity<MedicalHistory>()
            .HasMany( m => m.Vaccines )
            .WithOne( v => v.MedicalHistory)
            .HasForeignKey( v => v.MedicalHistoryId )
            .HasPrincipalKey( m => m.Id );
        
        builder.Entity<MedicalHistory>()
            .HasMany(m => m.Treatments)
            .WithOne(t => t.MedicalHistory)
            .HasForeignKey(t => t.MedicalHistoryId)
            .HasPrincipalKey(m => m.Id);
        
        builder.Entity<MedicalHistory>()
            .HasMany(m => m.DiseaseDiagnoses)
            .WithOne(d => d.MedicalHistory)
            .HasForeignKey(d => d.MedicalHistoryId)
            .HasPrincipalKey(m => m.Id);
        
        builder.Entity<Disease>()
            .HasOne(d => d.DiseaseDiagnosis)
            .WithMany(dd => dd.Diseases)
            .HasForeignKey(d => d.DiseaseDiagnosisId)
            .OnDelete(DeleteBehavior.Cascade);
        
        builder.Entity<Medication>()
            .HasOne(m => m.Treatment)
            .WithMany(t => t.Medications)
            .HasForeignKey(m => m.TreatmentId)
            .OnDelete(DeleteBehavior.Cascade);
            
        

        builder.Entity<Section>()
            .HasMany(i => i.Animals)
            .WithOne(a => a.section)
            .HasForeignKey(a => a.SectionId)
            .HasPrincipalKey(i => i.Id);

        builder.Entity<Profile>()
            .HasOne(p => p.section)
            .WithOne(i =>i.Profile)
            .HasForeignKey<Profile>(p => p.InventoryId)
            .OnDelete(DeleteBehavior.Cascade);;
            

        builder.Entity<Section>()
            .HasOne(i => i.Profile)
            .WithOne(p => p.section)
            .HasForeignKey<Section>(i=>i.ProfileId)
            .OnDelete(DeleteBehavior.Cascade);

        builder.Entity<Section>()
            .HasMany(i => i.Notifications)
            .WithOne(n => n.section)
            .HasForeignKey(n => n.InventoryId)
            .HasPrincipalKey(i => i.Id);

        builder.Entity<User>()
            .HasOne(u => u.Profile)
            .WithOne(p => p.User)
            .HasForeignKey<User>(u => u.IdProfile);

        builder.Entity<Profile>()
            .HasOne(p => p.User)
            .WithOne(u => u.Profile)
            .HasForeignKey<Profile>(p => p.UserId);
            
            

        /*Notifications Bounded Context*/
        builder.Entity<Notification>().HasKey(n => n.Id);
        builder.Entity<Notification>().Property(n => n.Id)
            .IsRequired().ValueGeneratedOnAdd();
        builder.Entity<Notification>().Property(n => n.Title).IsRequired();
        builder.Entity<Notification>().Property(n => n.Description).IsRequired();
        builder.Entity<Notification>().Property(n => n.State).IsRequired();
        
        // IAM Context
        
        builder.Entity<User>().HasKey(u => u.Id);
        builder.Entity<User>().Property(u => u.Id).IsRequired().ValueGeneratedOnAdd();
        builder.Entity<User>().Property(u => u.Username).IsRequired();
        builder.Entity<User>().Property(u => u.PasswordHash).IsRequired();
        builder.Entity<User>().Property(u => u.IdProfile).IsRequired();
        
        //=======================================================
        builder.UseSnakeCaseWithPluralizedTableNamingConvention();
    }
}