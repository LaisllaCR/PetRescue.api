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
        public virtual DbSet<Characteristics> Characteristics { get; set; }
        public virtual DbSet<Color> Color { get; set; }
        public virtual DbSet<Contact> Contact { get; set; }
        public virtual DbSet<ContactSocialMidia> ContactSocialMidia { get; set; }
        public virtual DbSet<Event> Event { get; set; }
        public virtual DbSet<EventStatus> EventStatus { get; set; }
        public virtual DbSet<EventType> EventType { get; set; }
        public virtual DbSet<Hair> Hair { get; set; }
        public virtual DbSet<LocationType> LocationType { get; set; }
        public virtual DbSet<Pet> Pet { get; set; }
        public virtual DbSet<PetCharacteristic> PetCharacteristic { get; set; }
        public virtual DbSet<PetColor> PetColor { get; set; }
        public virtual DbSet<PetPhoto> PetPhoto { get; set; }
        public virtual DbSet<Shelter> Shelter { get; set; }
        public virtual DbSet<ShelterPet> ShelterPet { get; set; }
        public virtual DbSet<Size> Size { get; set; }
        public virtual DbSet<SocialMidia> SocialMidia { get; set; }
        public virtual DbSet<Specie> Specie { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. See http://go.microsoft.com/fwlink/?LinkId=723263 for guidance on storing connection strings.
                optionsBuilder.UseNpgsql("Host=localhost;Database=pet_rescue;Username=postgres;Password=123456");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Age>(entity =>
            {
                entity.ToTable("age");

                entity.Property(e => e.AgeId)
                    .HasColumnName("age_id")
                    .HasDefaultValueSql("nextval('age_id_seq'::regclass)");

                entity.Property(e => e.Description)
                    .IsRequired()
                    .HasColumnName("description")
                    .HasColumnType("character varying");
            });

            modelBuilder.Entity<Breed>(entity =>
            {
                entity.ToTable("breed");

                entity.Property(e => e.BreedId)
                    .HasColumnName("breed_id")
                    .ValueGeneratedOnAdd();

                entity.Property(e => e.Description)
                    .IsRequired()
                    .HasColumnName("description")
                    .HasColumnType("character varying");

                entity.Property(e => e.SpecieId).HasColumnName("specie_id");

                entity.HasOne(d => d.BreedNavigation)
                    .WithOne(p => p.Breed)
                    .HasForeignKey<Breed>(d => d.BreedId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("specie_id");
            });

            modelBuilder.Entity<Characteristics>(entity =>
            {
                entity.HasKey(e => e.CharacteristicId)
                    .HasName("feature_pkey");

                entity.ToTable("characteristics");

                entity.Property(e => e.CharacteristicId)
                    .HasColumnName("characteristic_id")
                    .HasDefaultValueSql("nextval('feature_id_seq'::regclass)");

                entity.Property(e => e.Description)
                    .IsRequired()
                    .HasColumnName("description")
                    .HasColumnType("character varying");
            });

            modelBuilder.Entity<Color>(entity =>
            {
                entity.ToTable("color");

                entity.Property(e => e.ColorId)
                    .HasColumnName("color_id")
                    .HasDefaultValueSql("nextval('color_id_seq'::regclass)");

                entity.Property(e => e.Description)
                    .IsRequired()
                    .HasColumnName("description")
                    .HasColumnType("character varying");
            });

            modelBuilder.Entity<Contact>(entity =>
            {
                entity.ToTable("contact");

                entity.Property(e => e.ContactId)
                    .HasColumnName("contact_id")
                    .ValueGeneratedNever();

                entity.Property(e => e.Email)
                    .IsRequired()
                    .HasColumnName("email")
                    .HasColumnType("character varying");

                entity.Property(e => e.Name)
                    .IsRequired()
                    .HasColumnName("name")
                    .HasColumnType("character varying");

                entity.Property(e => e.PhoneMain)
                    .IsRequired()
                    .HasColumnName("phone_main")
                    .HasColumnType("character varying");

                entity.Property(e => e.PhoneSecondary)
                    .HasColumnName("phone_secondary")
                    .HasColumnType("character varying");
            });

            modelBuilder.Entity<ContactSocialMidia>(entity =>
            {
                entity.ToTable("contact_social_midia");

                entity.Property(e => e.ContactSocialMidiaId)
                    .HasColumnName("contact_social_midia_id")
                    .HasColumnType("character varying");

                entity.Property(e => e.ContactId).HasColumnName("contact_id");

                entity.Property(e => e.SocialMidiaId).HasColumnName("social_midia_id");

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
                entity.ToTable("event");

                entity.Property(e => e.EventId)
                    .HasColumnName("event_id")
                    .ValueGeneratedNever();

                entity.Property(e => e.CreationDate)
                    .HasColumnName("creation_date")
                    .HasColumnType("date");

                entity.Property(e => e.EventStatusId).HasColumnName("event_status_id");

                entity.Property(e => e.EventTypeId).HasColumnName("event_type_id");

                entity.Property(e => e.LocationTypeId).HasColumnName("location_type_id");

                entity.Property(e => e.PetId).HasColumnName("pet_id");

                entity.Property(e => e.Reward).HasColumnName("reward");

                entity.Property(e => e.What)
                    .IsRequired()
                    .HasColumnName("what")
                    .HasColumnType("character varying");

                entity.Property(e => e.When)
                    .HasColumnName("when")
                    .HasColumnType("date");

                entity.Property(e => e.Where)
                    .IsRequired()
                    .HasColumnName("where")
                    .HasColumnType("character varying");

                entity.HasOne(d => d.EventStatus)
                    .WithMany(p => p.Event)
                    .HasForeignKey(d => d.EventStatusId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("event_status");

                entity.HasOne(d => d.EventType)
                    .WithMany(p => p.Event)
                    .HasForeignKey(d => d.EventTypeId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("event_type");

                entity.HasOne(d => d.LocationType)
                    .WithMany(p => p.Event)
                    .HasForeignKey(d => d.LocationTypeId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("location_type_id");

                entity.HasOne(d => d.Pet)
                    .WithMany(p => p.Event)
                    .HasForeignKey(d => d.PetId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("pet_id");
            });

            modelBuilder.Entity<EventStatus>(entity =>
            {
                entity.HasKey(e => e.EventStatusTypeId)
                    .HasName("event_status_type_pkey");

                entity.ToTable("event_status");

                entity.Property(e => e.EventStatusTypeId)
                    .HasColumnName("event_status_type_id")
                    .ValueGeneratedNever();

                entity.Property(e => e.Description)
                    .IsRequired()
                    .HasColumnName("description")
                    .HasColumnType("character varying");
            });

            modelBuilder.Entity<EventType>(entity =>
            {
                entity.ToTable("event_type");

                entity.Property(e => e.EventTypeId)
                    .HasColumnName("event_type_id")
                    .ValueGeneratedNever();

                entity.Property(e => e.Description)
                    .IsRequired()
                    .HasColumnName("description")
                    .HasColumnType("character varying");
            });

            modelBuilder.Entity<Hair>(entity =>
            {
                entity.ToTable("hair");

                entity.Property(e => e.HairId)
                    .HasColumnName("hair_id")
                    .HasDefaultValueSql("nextval('hair_id_seq'::regclass)");

                entity.Property(e => e.Description)
                    .IsRequired()
                    .HasColumnName("description")
                    .HasColumnType("character varying");
            });

            modelBuilder.Entity<LocationType>(entity =>
            {
                entity.ToTable("location_type");

                entity.Property(e => e.LocationTypeId)
                    .HasColumnName("location_type_id")
                    .ValueGeneratedNever();

                entity.Property(e => e.Description)
                    .IsRequired()
                    .HasColumnName("description")
                    .HasColumnType("character varying");
            });

            modelBuilder.Entity<Pet>(entity =>
            {
                entity.ToTable("pet");

                entity.Property(e => e.PetId)
                    .HasColumnName("pet_id")
                    .HasDefaultValueSql("nextval('pet_id_seq'::regclass)");

                entity.Property(e => e.AgeId).HasColumnName("age_id");

                entity.Property(e => e.BreedId).HasColumnName("breed_id");

                entity.Property(e => e.Chip)
                    .IsRequired()
                    .HasColumnName("chip")
                    .HasColumnType("char");

                entity.Property(e => e.Gender)
                    .IsRequired()
                    .HasColumnName("gender")
                    .HasColumnType("char");

                entity.Property(e => e.HairId).HasColumnName("hair_id");

                entity.Property(e => e.Leash)
                    .IsRequired()
                    .HasColumnName("leash")
                    .HasColumnType("char");

                entity.Property(e => e.LeashDescription)
                    .HasColumnName("leash_description")
                    .HasColumnType("character varying");

                entity.Property(e => e.Name)
                    .IsRequired()
                    .HasColumnName("name")
                    .HasColumnType("character varying");

                entity.Property(e => e.Neuter)
                    .IsRequired()
                    .HasColumnName("neuter")
                    .HasColumnType("char");

                entity.Property(e => e.SizeId).HasColumnName("size_id");

                entity.Property(e => e.SpecialNeeds)
                    .IsRequired()
                    .HasColumnName("special_needs")
                    .HasColumnType("char");

                entity.Property(e => e.SpecieId).HasColumnName("specie_id");

                entity.Property(e => e.Story)
                    .HasColumnName("story")
                    .HasColumnType("character varying");

                entity.Property(e => e.Vaccine)
                    .IsRequired()
                    .HasColumnName("vaccine")
                    .HasColumnType("char");

                entity.Property(e => e.Weight)
                    .HasColumnName("weight")
                    .HasColumnType("character varying");

                entity.HasOne(d => d.Age)
                    .WithMany(p => p.Pet)
                    .HasForeignKey(d => d.AgeId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("age_id");

                entity.HasOne(d => d.Breed)
                    .WithMany(p => p.Pet)
                    .HasForeignKey(d => d.BreedId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("breed_id");

                entity.HasOne(d => d.Hair)
                    .WithMany(p => p.Pet)
                    .HasForeignKey(d => d.HairId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("hair_id");

                entity.HasOne(d => d.Size)
                    .WithMany(p => p.Pet)
                    .HasForeignKey(d => d.SizeId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("size_id");

                entity.HasOne(d => d.Specie)
                    .WithMany(p => p.Pet)
                    .HasForeignKey(d => d.SpecieId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("specie_id");
            });

            modelBuilder.Entity<PetCharacteristic>(entity =>
            {
                entity.HasKey(e => new { e.PetCharacteristicId, e.CharacteristicId })
                    .HasName("petCharacteristic_pkey");

                entity.ToTable("pet_characteristic");

                entity.Property(e => e.PetCharacteristicId).HasColumnName("pet_characteristic_id");

                entity.Property(e => e.CharacteristicId).HasColumnName("characteristic_id");

                entity.Property(e => e.PetId).HasColumnName("pet_id");

                entity.HasOne(d => d.Characteristic)
                    .WithMany(p => p.PetCharacteristic)
                    .HasForeignKey(d => d.CharacteristicId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("characteristic_id");

                entity.HasOne(d => d.Pet)
                    .WithMany(p => p.PetCharacteristic)
                    .HasForeignKey(d => d.PetId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("pet_id");
            });

            modelBuilder.Entity<PetColor>(entity =>
            {
                entity.ToTable("pet_color");

                entity.Property(e => e.PetColorId)
                    .HasColumnName("pet_color_id")
                    .ValueGeneratedNever();

                entity.Property(e => e.ColorId).HasColumnName("color_id");

                entity.Property(e => e.PetId).HasColumnName("pet_id");

                entity.HasOne(d => d.Color)
                    .WithMany(p => p.PetColor)
                    .HasForeignKey(d => d.ColorId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("color_id");

                entity.HasOne(d => d.Pet)
                    .WithMany(p => p.PetColor)
                    .HasForeignKey(d => d.PetId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("pet_id");
            });

            modelBuilder.Entity<PetPhoto>(entity =>
            {
                entity.ToTable("pet_photo");

                entity.Property(e => e.PetPhotoId)
                    .HasColumnName("pet_photo_id")
                    .ValueGeneratedNever();

                entity.Property(e => e.File)
                    .IsRequired()
                    .HasColumnName("file")
                    .HasColumnType("character varying");

                entity.Property(e => e.PetId).HasColumnName("pet_id");

                entity.HasOne(d => d.Pet)
                    .WithMany(p => p.PetPhoto)
                    .HasForeignKey(d => d.PetId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("pet_id");
            });

            modelBuilder.Entity<Shelter>(entity =>
            {
                entity.ToTable("shelter");

                entity.Property(e => e.ShelterId)
                    .HasColumnName("shelter_id")
                    .HasDefaultValueSql("nextval('shelter_id_seq'::regclass)");

                entity.Property(e => e.Description)
                    .IsRequired()
                    .HasColumnName("description")
                    .HasColumnType("character varying");

                entity.Property(e => e.Email)
                    .IsRequired()
                    .HasColumnName("email")
                    .HasColumnType("character varying");

                entity.Property(e => e.Facebook)
                    .HasColumnName("facebook")
                    .HasColumnType("character varying");

                entity.Property(e => e.Instagram)
                    .HasColumnName("instagram")
                    .HasColumnType("character varying");

                entity.Property(e => e.Phone)
                    .IsRequired()
                    .HasColumnName("phone")
                    .HasColumnType("character varying");

                entity.Property(e => e.Responsable)
                    .IsRequired()
                    .HasColumnName("responsable")
                    .HasColumnType("character varying");

                entity.Property(e => e.Twitter)
                    .HasColumnName("twitter")
                    .HasColumnType("character varying");

                entity.Property(e => e.Website)
                    .HasColumnName("website")
                    .HasColumnType("character varying");

                entity.Property(e => e.Youtube)
                    .HasColumnName("youtube")
                    .HasColumnType("character varying");
            });

            modelBuilder.Entity<ShelterPet>(entity =>
            {
                entity.ToTable("shelter_pet");

                entity.Property(e => e.ShelterPetId)
                    .HasColumnName("shelter_pet_id")
                    .ValueGeneratedNever();

                entity.Property(e => e.PetId).HasColumnName("pet_id");

                entity.Property(e => e.ShelterId).HasColumnName("shelter_id");

                entity.HasOne(d => d.Pet)
                    .WithMany(p => p.ShelterPet)
                    .HasForeignKey(d => d.PetId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("pet_id");

                entity.HasOne(d => d.Shelter)
                    .WithMany(p => p.ShelterPet)
                    .HasForeignKey(d => d.ShelterId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("shelter_id");
            });

            modelBuilder.Entity<Size>(entity =>
            {
                entity.ToTable("size");

                entity.Property(e => e.SizeId)
                    .HasColumnName("size_id")
                    .HasDefaultValueSql("nextval('size_id_seq'::regclass)");

                entity.Property(e => e.Description)
                    .IsRequired()
                    .HasColumnName("description")
                    .HasColumnType("character varying");
            });

            modelBuilder.Entity<SocialMidia>(entity =>
            {
                entity.ToTable("social_midia");

                entity.Property(e => e.SocialMidiaId)
                    .HasColumnName("social_midia_id")
                    .ValueGeneratedNever();

                entity.Property(e => e.Description)
                    .IsRequired()
                    .HasColumnName("description")
                    .HasColumnType("character varying");
            });

            modelBuilder.Entity<Specie>(entity =>
            {
                entity.ToTable("specie");

                entity.Property(e => e.SpecieId)
                    .HasColumnName("specie_id")
                    .HasDefaultValueSql("nextval('specie_id_seq'::regclass)");

                entity.Property(e => e.Description)
                    .IsRequired()
                    .HasColumnName("description")
                    .HasMaxLength(255);
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
