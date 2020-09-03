using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace PetRescue.api.Models
{
    public partial class dbContext : DbContext
    {
        public dbContext()
        {
        }

        public dbContext(DbContextOptions<dbContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Age> Age { get; set; }
        public virtual DbSet<Breed> Breed { get; set; }
        public virtual DbSet<Characteristic> Characteristic { get; set; }
        public virtual DbSet<Color> Color { get; set; }
        public virtual DbSet<Contact> Contact { get; set; }
        public virtual DbSet<ContactSocialMidia> ContactSocialMidia { get; set; }
        public virtual DbSet<Event> Event { get; set; }
        public virtual DbSet<EventStatus> EventStatus { get; set; }
        public virtual DbSet<EventType> EventType { get; set; }
        public virtual DbSet<LocationType> LocationType { get; set; }
        public virtual DbSet<Pelage> Pelage { get; set; }
        public virtual DbSet<Pet> Pet { get; set; }
        public virtual DbSet<PetCharacteristic> PetCharacteristic { get; set; }
        public virtual DbSet<PetColor> PetColor { get; set; }
        public virtual DbSet<PetPhoto> PetPhoto { get; set; }
        public virtual DbSet<Shelter> Shelter { get; set; }
        public virtual DbSet<ShelterContact> ShelterContact { get; set; }
        public virtual DbSet<ShelterPet> ShelterPet { get; set; }
        public virtual DbSet<ShelterSocialMidia> ShelterSocialMidia { get; set; }
        public virtual DbSet<Size> Size { get; set; }
        public virtual DbSet<SocialMidia> SocialMidia { get; set; }
        public virtual DbSet<Specie> Specie { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. See http://go.microsoft.com/fwlink/?LinkId=723263 for guidance on storing connection strings.
                optionsBuilder.UseNpgsql("Host=localhost;Port=5432;Username=postgres;Password=123456;Database=pet_rescue_api;");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Age>(entity =>
            {
                entity.ToTable("age", "pet");

                entity.Property(e => e.AgeId).HasColumnName("age_id");

                entity.Property(e => e.Description)
                    .IsRequired()
                    .HasColumnName("description")
                    .HasMaxLength(50);
            });

            modelBuilder.Entity<Breed>(entity =>
            {
                entity.ToTable("breed", "pet");

                entity.Property(e => e.BreedId)
                    .HasColumnName("breed_id")
                    .ValueGeneratedOnAdd();

                entity.Property(e => e.Description)
                    .IsRequired()
                    .HasColumnName("description")
                    .HasMaxLength(200);

                entity.Property(e => e.SpecieId).HasColumnName("specie_id");

                entity.HasOne(d => d.BreedNavigation)
                    .WithOne(p => p.Breed)
                    .HasForeignKey<Breed>(d => d.BreedId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("specie_id");
            });

            modelBuilder.Entity<Characteristic>(entity =>
            {
                entity.ToTable("characteristic", "pet");

                entity.Property(e => e.CharacteristicId).HasColumnName("characteristic_id");

                entity.Property(e => e.Description)
                    .IsRequired()
                    .HasColumnName("description")
                    .HasMaxLength(50);
            });

            modelBuilder.Entity<Color>(entity =>
            {
                entity.ToTable("color", "pet");

                entity.Property(e => e.ColorId).HasColumnName("color_id");

                entity.Property(e => e.Description)
                    .IsRequired()
                    .HasColumnName("description")
                    .HasMaxLength(50);
            });

            modelBuilder.Entity<Contact>(entity =>
            {
                entity.ToTable("contact", "pet");

                entity.Property(e => e.ContactId).HasColumnName("contact_id");

                entity.Property(e => e.Email)
                    .IsRequired()
                    .HasColumnName("email")
                    .HasMaxLength(100);

                entity.Property(e => e.EmailSecondary)
                    .HasColumnName("email_secondary")
                    .HasMaxLength(100);

                entity.Property(e => e.Name)
                    .IsRequired()
                    .HasColumnName("name")
                    .HasMaxLength(100);

                entity.Property(e => e.Phone)
                    .IsRequired()
                    .HasColumnName("phone")
                    .HasMaxLength(50);

                entity.Property(e => e.PhoneSecondary)
                    .HasColumnName("phone_secondary")
                    .HasMaxLength(50);
            });

            modelBuilder.Entity<ContactSocialMidia>(entity =>
            {
                entity.ToTable("contact_social_midia", "pet");

                entity.Property(e => e.ContactSocialMidiaId).HasColumnName("contact_social_midia_id");

                entity.Property(e => e.ContactId).HasColumnName("contact_id");

                entity.Property(e => e.SocialMidiaId).HasColumnName("social_midia_id");

                entity.Property(e => e.Url)
                    .IsRequired()
                    .HasColumnName("url")
                    .HasMaxLength(255);

                entity.HasOne(d => d.Contact)
                    .WithMany(p => p.ContactSocialMidia)
                    .HasForeignKey(d => d.ContactId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("contact_id");

                entity.HasOne(d => d.SocialMidia)
                    .WithMany(p => p.ContactSocialMidia)
                    .HasForeignKey(d => d.SocialMidiaId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("social_midia_id");
            });

            modelBuilder.Entity<Event>(entity =>
            {
                entity.ToTable("event", "pet");

                entity.Property(e => e.EventId).HasColumnName("event_id");

                entity.Property(e => e.CreationDate).HasColumnName("creation_date");

                entity.Property(e => e.Date).HasColumnName("date");

                entity.Property(e => e.Description)
                    .IsRequired()
                    .HasColumnName("description")
                    .HasMaxLength(255);

                entity.Property(e => e.EventStatusId).HasColumnName("event_status_id");

                entity.Property(e => e.EventTypeId).HasColumnName("event_type_id");

                entity.Property(e => e.Location)
                    .IsRequired()
                    .HasColumnName("location")
                    .HasMaxLength(100);

                entity.Property(e => e.LocationTypeId).HasColumnName("location_type_id");

                entity.Property(e => e.PetId).HasColumnName("pet_id");

                entity.Property(e => e.Reward).HasColumnName("reward");

                entity.HasOne(d => d.EventStatus)
                    .WithMany(p => p.Event)
                    .HasForeignKey(d => d.EventStatusId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("event_event_status_id_fkey");

                entity.HasOne(d => d.EventType)
                    .WithMany(p => p.Event)
                    .HasForeignKey(d => d.EventTypeId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("event_event_type_id_fkey");

                entity.HasOne(d => d.LocationType)
                    .WithMany(p => p.Event)
                    .HasForeignKey(d => d.LocationTypeId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("event_location_type_id_fkey");

                entity.HasOne(d => d.Pet)
                    .WithMany(p => p.Event)
                    .HasForeignKey(d => d.PetId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("event_pet_id_fkey");
            });

            modelBuilder.Entity<EventStatus>(entity =>
            {
                entity.ToTable("event_status", "pet");

                entity.Property(e => e.EventStatusId).HasColumnName("event_status_id");

                entity.Property(e => e.Description)
                    .IsRequired()
                    .HasColumnName("description")
                    .HasMaxLength(255);
            });

            modelBuilder.Entity<EventType>(entity =>
            {
                entity.ToTable("event_type", "pet");

                entity.Property(e => e.EventTypeId).HasColumnName("event_type_id");

                entity.Property(e => e.Description)
                    .IsRequired()
                    .HasColumnName("description")
                    .HasMaxLength(255);
            });

            modelBuilder.Entity<LocationType>(entity =>
            {
                entity.ToTable("location_type", "pet");

                entity.Property(e => e.LocationTypeId).HasColumnName("location_type_id");

                entity.Property(e => e.Description)
                    .IsRequired()
                    .HasColumnName("description")
                    .HasMaxLength(255);
            });

            modelBuilder.Entity<Pelage>(entity =>
            {
                entity.ToTable("pelage", "pet");

                entity.Property(e => e.PelageId).HasColumnName("pelage_id");

                entity.Property(e => e.Description)
                    .IsRequired()
                    .HasColumnName("description")
                    .HasMaxLength(255);
            });

            modelBuilder.Entity<Pet>(entity =>
            {
                entity.ToTable("pet", "pet");

                entity.Property(e => e.PetId).HasColumnName("pet_id");

                entity.Property(e => e.AgeId).HasColumnName("age_id");

                entity.Property(e => e.BreedId).HasColumnName("breed_id");

                entity.Property(e => e.Chip).HasColumnName("chip");

                entity.Property(e => e.Gender).HasColumnName("gender");

                entity.Property(e => e.Leash).HasColumnName("leash");

                entity.Property(e => e.LeashDescription)
                    .HasColumnName("leash_description")
                    .HasMaxLength(255);

                entity.Property(e => e.Name)
                    .IsRequired()
                    .HasColumnName("name")
                    .HasMaxLength(255);

                entity.Property(e => e.Neuter).HasColumnName("neuter");

                entity.Property(e => e.PelageId).HasColumnName("pelage_id");

                entity.Property(e => e.SizeId).HasColumnName("size_id");

                entity.Property(e => e.SpecialNeeds).HasColumnName("special_needs");

                entity.Property(e => e.SpecialNeedsDescription).HasColumnName("special_needs_description");

                entity.Property(e => e.Story)
                    .IsRequired()
                    .HasColumnName("story");

                entity.Property(e => e.Vacine).HasColumnName("vacine");

                entity.Property(e => e.Weight)
                    .IsRequired()
                    .HasColumnName("weight")
                    .HasMaxLength(20);

                entity.HasOne(d => d.Age)
                    .WithMany(p => p.Pet)
                    .HasForeignKey(d => d.AgeId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("pet_age_id_fkey");

                entity.HasOne(d => d.Breed)
                    .WithMany(p => p.Pet)
                    .HasForeignKey(d => d.BreedId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("pet_breed_id_fkey");

                entity.HasOne(d => d.Pelage)
                    .WithMany(p => p.Pet)
                    .HasForeignKey(d => d.PelageId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("pet_pelage_id_fkey");

                entity.HasOne(d => d.Size)
                    .WithMany(p => p.Pet)
                    .HasForeignKey(d => d.SizeId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("pet_size_id_fkey");
            });

            modelBuilder.Entity<PetCharacteristic>(entity =>
            {
                entity.ToTable("pet_characteristic", "pet");

                entity.Property(e => e.PetCharacteristicId).HasColumnName("pet_characteristic_id");

                entity.Property(e => e.CharacteristicId).HasColumnName("characteristic_id");

                entity.Property(e => e.PetId).HasColumnName("pet_id");

                entity.HasOne(d => d.Characteristic)
                    .WithMany(p => p.PetCharacteristic)
                    .HasForeignKey(d => d.CharacteristicId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("pet_characteristic_characteristic_id_fkey");

                entity.HasOne(d => d.Pet)
                    .WithMany(p => p.PetCharacteristic)
                    .HasForeignKey(d => d.PetId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("pet_characteristic_pet_id_fkey");
            });

            modelBuilder.Entity<PetColor>(entity =>
            {
                entity.ToTable("pet_color", "pet");

                entity.Property(e => e.PetColorId).HasColumnName("pet_color_id");

                entity.Property(e => e.ColorId).HasColumnName("color_id");

                entity.Property(e => e.PetId).HasColumnName("pet_id");

                entity.HasOne(d => d.Color)
                    .WithMany(p => p.PetColor)
                    .HasForeignKey(d => d.ColorId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("pet_color_color_id_fkey");

                entity.HasOne(d => d.Pet)
                    .WithMany(p => p.PetColor)
                    .HasForeignKey(d => d.PetId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("pet_color_pet_id_fkey");
            });

            modelBuilder.Entity<PetPhoto>(entity =>
            {
                entity.ToTable("pet_photo", "pet");

                entity.Property(e => e.PetPhotoId).HasColumnName("pet_photo_id");

                entity.Property(e => e.Description)
                    .HasColumnName("description")
                    .HasMaxLength(255);

                entity.Property(e => e.FileExtension)
                    .IsRequired()
                    .HasColumnName("file_extension")
                    .HasMaxLength(20);

                entity.Property(e => e.FileUrl)
                    .IsRequired()
                    .HasColumnName("file_url")
                    .HasMaxLength(255);

                entity.Property(e => e.PetId).HasColumnName("pet_id");

                entity.HasOne(d => d.Pet)
                    .WithMany(p => p.PetPhoto)
                    .HasForeignKey(d => d.PetId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("pet_photo_pet_id_fkey");
            });

            modelBuilder.Entity<Shelter>(entity =>
            {
                entity.ToTable("shelter", "pet");

                entity.Property(e => e.ShelterId).HasColumnName("shelter_id");

                entity.Property(e => e.Description)
                    .IsRequired()
                    .HasColumnName("description");

                entity.Property(e => e.Email)
                    .IsRequired()
                    .HasColumnName("email")
                    .HasMaxLength(100);

                entity.Property(e => e.EmailSecondary)
                    .HasColumnName("email_secondary")
                    .HasMaxLength(100);

                entity.Property(e => e.Name)
                    .IsRequired()
                    .HasColumnName("name")
                    .HasMaxLength(255);

                entity.Property(e => e.Phone)
                    .IsRequired()
                    .HasColumnName("phone")
                    .HasMaxLength(30);

                entity.Property(e => e.PhoneSecondary)
                    .HasColumnName("phone_secondary")
                    .HasMaxLength(30);

                entity.Property(e => e.UrlWebsite)
                    .IsRequired()
                    .HasColumnName("url_website")
                    .HasMaxLength(255);
            });

            modelBuilder.Entity<ShelterContact>(entity =>
            {
                entity.ToTable("shelter_contact", "pet");

                entity.Property(e => e.ShelterContactId).HasColumnName("shelter_contact_id");

                entity.Property(e => e.ContactId).HasColumnName("contact_id");

                entity.Property(e => e.Description).HasColumnName("description");

                entity.Property(e => e.ShelterId).HasColumnName("shelter_id");

                entity.HasOne(d => d.Contact)
                    .WithMany(p => p.ShelterContact)
                    .HasForeignKey(d => d.ContactId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("shelter_contact_contact_id_fkey");

                entity.HasOne(d => d.Shelter)
                    .WithMany(p => p.ShelterContact)
                    .HasForeignKey(d => d.ShelterId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("shelter_contact_shelter_id_fkey");
            });

            modelBuilder.Entity<ShelterPet>(entity =>
            {
                entity.ToTable("shelter_pet", "pet");

                entity.Property(e => e.ShelterPetId).HasColumnName("shelter_pet_id");

                entity.Property(e => e.PetId).HasColumnName("pet_id");

                entity.Property(e => e.ShelterId).HasColumnName("shelter_id");

                entity.HasOne(d => d.Pet)
                    .WithMany(p => p.ShelterPet)
                    .HasForeignKey(d => d.PetId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("shelter_pet_pet_id_fkey");

                entity.HasOne(d => d.Shelter)
                    .WithMany(p => p.ShelterPet)
                    .HasForeignKey(d => d.ShelterId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("shelter_pet_shelter_id_fkey");
            });

            modelBuilder.Entity<ShelterSocialMidia>(entity =>
            {
                entity.ToTable("shelter_social_midia", "pet");

                entity.Property(e => e.ShelterSocialMidiaId).HasColumnName("shelter_social_midia_id");

                entity.Property(e => e.ShelterId).HasColumnName("shelter_id");

                entity.Property(e => e.SocialMidiaId).HasColumnName("social_midia_id");

                entity.HasOne(d => d.Shelter)
                    .WithMany(p => p.ShelterSocialMidia)
                    .HasForeignKey(d => d.ShelterId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("shelter_social_midia_shelter_id_fkey");

                entity.HasOne(d => d.SocialMidia)
                    .WithMany(p => p.ShelterSocialMidia)
                    .HasForeignKey(d => d.SocialMidiaId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("shelter_social_midia_social_midia_id_fkey");
            });

            modelBuilder.Entity<Size>(entity =>
            {
                entity.ToTable("size", "pet");

                entity.Property(e => e.SizeId).HasColumnName("size_id");

                entity.Property(e => e.Description)
                    .IsRequired()
                    .HasColumnName("description")
                    .HasMaxLength(100);
            });

            modelBuilder.Entity<SocialMidia>(entity =>
            {
                entity.ToTable("social_midia", "pet");

                entity.Property(e => e.SocialMidiaId).HasColumnName("social_midia_id");

                entity.Property(e => e.Description)
                    .IsRequired()
                    .HasColumnName("description")
                    .HasMaxLength(100);
            });

            modelBuilder.Entity<Specie>(entity =>
            {
                entity.ToTable("specie", "pet");

                entity.Property(e => e.SpecieId).HasColumnName("specie_id");

                entity.Property(e => e.Description)
                    .IsRequired()
                    .HasColumnName("description")
                    .HasMaxLength(100);
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
