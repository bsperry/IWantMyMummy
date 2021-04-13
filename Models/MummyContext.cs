using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

// Code scaffolded by EF Core assumes nullable reference types (NRTs) are not used or disabled.
// If you have enabled NRTs for your project, then un-comment the following line:
// #nullable disable

namespace IWantMyMummy.Models
{
    public partial class MummyContext : DbContext
    {        
        public MummyContext(DbContextOptions<MummyContext> options): base(options)
        {
        }
        public MummyContext()
        {
        }
        public static MummyContext Create() //Add this change
        {
            return new MummyContext();
        }


        public virtual DbSet<Burial> Burial { get; set; }
        public virtual DbSet<BurialQuadrant> BurialQuadrant { get; set; }
        public virtual DbSet<BurialSquare> BurialSquare { get; set; }
        public virtual DbSet<CranialSample> CranialSample { get; set; }
        public virtual DbSet<Image> Image { get; set; }
        public virtual DbSet<RackSample> RackSample { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. See http://go.microsoft.com/fwlink/?LinkId=723263 for guidance on storing connection strings.
                optionsBuilder.UseSqlServer("Server=.\\SQLExpress;AttachDbFilename=C:\\Program Files\\Microsoft SQL Server\\MSSQL14.SQLEXPRESS\\MSSQL\\DATA\\Mummy.mdf;Database=Mummy;Trusted_Connection=Yes;");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Burial>(entity =>
            {
                entity.Property(e => e.BurialId).HasColumnName("burial_id");

                entity.Property(e => e.AgeAtDeath)
                    .HasColumnName("age_at_death")
                    .HasMaxLength(1)
                    .IsUnicode(false);

                entity.Property(e => e.AgeMethodSkull).HasColumnName("age_method_skull");

                entity.Property(e => e.ArtifactFound).HasColumnName("artifact_found");

                entity.Property(e => e.ArtifactsDescription)
                    .HasColumnName("artifacts_description")
                    .HasMaxLength(5000)
                    .IsUnicode(false);

                entity.Property(e => e.BasilarSuture).HasColumnName("basilar_suture");

                entity.Property(e => e.BasionBregmaHeight).HasColumnName("basion_bregma_height");

                entity.Property(e => e.BasionNasion).HasColumnName("basion_nasion");

                entity.Property(e => e.BasionProsthionLength).HasColumnName("basion_prosthion_length");

                entity.Property(e => e.BizygomaticDiameter).HasColumnName("bizygomatic_diameter");

                entity.Property(e => e.BoneTaken).HasColumnName("bone_taken");

                entity.Property(e => e.BurialAdult).HasColumnName("burial_adult");

                entity.Property(e => e.BurialDepth).HasColumnName("burial_depth");

                entity.Property(e => e.BurialNumber).HasColumnName("burial_number");

                entity.Property(e => e.BurialSituation)
                    .HasColumnName("burial_situation")
                    .HasMaxLength(5000)
                    .IsUnicode(false);

                entity.Property(e => e.BurialSquareId)
                    .HasColumnName("burial_square_id")
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.BurialSubplot)
                    .HasColumnName("burial_subplot")
                    .HasMaxLength(2)
                    .IsUnicode(false);

                entity.Property(e => e.BurialWrapping)
                    .IsRequired()
                    .HasColumnName("burial_wrapping")
                    .HasMaxLength(1)
                    .IsUnicode(false);

                entity.Property(e => e.BurialWrappingMaterial)
                    .HasColumnName("burial_wrapping_material")
                    .HasMaxLength(200)
                    .IsUnicode(false);

                entity.Property(e => e.CranialSuture)
                    .HasColumnName("cranial_suture")
                    .HasMaxLength(13)
                    .IsUnicode(false);

                entity.Property(e => e.DateFound)
                    .HasColumnName("date_found")
                    .HasColumnType("datetime");

                entity.Property(e => e.DescriptionOfTaken)
                    .HasColumnName("description_of_taken")
                    .HasMaxLength(5000)
                    .IsUnicode(false);

                entity.Property(e => e.DorsalPitting).HasColumnName("dorsal_pitting");

                entity.Property(e => e.EpiphysealUnion).HasColumnName("epiphyseal_union");

                entity.Property(e => e.EstimateAge).HasColumnName("estimate_age");

                entity.Property(e => e.EstimateLivingStature).HasColumnName("estimate_living_stature");

                entity.Property(e => e.FemurHead).HasColumnName("femur_head");

                entity.Property(e => e.FemurLength).HasColumnName("femur_length");

                entity.Property(e => e.ForemanMagnum).HasColumnName("foreman_magnum");

                entity.Property(e => e.GeFunctionTotal).HasColumnName("GE_function_total");

                entity.Property(e => e.GenderBodyCol)
                    .HasColumnName("gender_body_col")
                    .HasMaxLength(1)
                    .IsUnicode(false);

                entity.Property(e => e.GenderGe)
                    .IsRequired()
                    .HasColumnName("gender_GE")
                    .HasMaxLength(1)
                    .IsUnicode(false);

                entity.Property(e => e.Gonian).HasColumnName("gonian");

                entity.Property(e => e.HairColor)
                    .HasColumnName("hair_color")
                    .HasMaxLength(15)
                    .IsUnicode(false);

                entity.Property(e => e.HairTaken).HasColumnName("hair_taken");

                entity.Property(e => e.HeadDirection)
                    .HasColumnName("head_direction")
                    .HasMaxLength(1)
                    .IsUnicode(false);

                entity.Property(e => e.HumerusHead).HasColumnName("humerus_head");

                entity.Property(e => e.HumerusLength).HasColumnName("humerus_length");

                entity.Property(e => e.InterorbitalBreadth).HasColumnName("interorbital_breadth");

                entity.Property(e => e.LengthOfRemains).HasColumnName("length_of_remains");

                entity.Property(e => e.MaximumCranialBreadth).HasColumnName("maximum_cranial_breadth");

                entity.Property(e => e.MaximumCranialLength).HasColumnName("maximum_cranial_length");

                entity.Property(e => e.MaximumNasalBreadth).HasColumnName("maximum_nasal_breadth");

                entity.Property(e => e.MedialIpRamus).HasColumnName("medial_IP_ramus");

                entity.Property(e => e.NasionProsthion).HasColumnName("nasion_prosthion");

                entity.Property(e => e.NuchalCrest).HasColumnName("nuchal_crest");

                entity.Property(e => e.OrbitEdge).HasColumnName("orbit_edge");

                entity.Property(e => e.Osteophytosis).HasColumnName("osteophytosis");

                entity.Property(e => e.ParietalBossing).HasColumnName("parietal_bossing");

                entity.Property(e => e.PathologyAnomalies)
                    .HasColumnName("pathology_anomalies")
                    .HasMaxLength(5000)
                    .IsUnicode(false);

                entity.Property(e => e.PreaurSulcus).HasColumnName("preaur_sulcus");

                entity.Property(e => e.PreservationIndex).HasColumnName("preservation_index");

                entity.Property(e => e.PubicBone).HasColumnName("pubic_bone");

                entity.Property(e => e.PubicSymphysis).HasColumnName("pubic_symphysis");

                entity.Property(e => e.Robust).HasColumnName("robust");

                entity.Property(e => e.SampleNumber).HasColumnName("sample_number");

                entity.Property(e => e.SciaticNotch).HasColumnName("sciatic_notch");

                entity.Property(e => e.SexMethodSkull).HasColumnName("sex_method_skull");

                entity.Property(e => e.SoftTissueTaken).HasColumnName("soft_tissue_taken");

                entity.Property(e => e.SouthToFeet).HasColumnName("south_to_feet");

                entity.Property(e => e.SouthToHead).HasColumnName("south_to_head");

                entity.Property(e => e.SubpubicAngle).HasColumnName("subpubic_angle");

                entity.Property(e => e.SupraorbitalRidges).HasColumnName("supraorbital_ridges");

                entity.Property(e => e.TextileTaken).HasColumnName("textile_taken");

                entity.Property(e => e.TibiaLength).HasColumnName("tibia_length");

                entity.Property(e => e.ToothAttrition).HasColumnName("tooth_attrition");

                entity.Property(e => e.ToothEruption)
                    .HasColumnName("tooth_eruption")
                    .HasMaxLength(5000)
                    .IsUnicode(false);

                entity.Property(e => e.ToothTaken).HasColumnName("tooth_taken");

                entity.Property(e => e.VentralArc).HasColumnName("ventral_arc");

                entity.Property(e => e.WestToFeet).HasColumnName("west_to_feet");

                entity.Property(e => e.WestToHead).HasColumnName("west_to_head");

                entity.Property(e => e.ZygomaticCrest).HasColumnName("zygomatic_crest");

                entity.HasOne(d => d.BurialSquare)
                    .WithMany(p => p.Burial)
                    .HasForeignKey(d => d.BurialSquareId)
                    .HasConstraintName("FK__Burial__burial_s__5070F446");

                entity.HasOne(d => d.BurialS)
                    .WithMany(p => p.Burial)
                    .HasForeignKey(d => new { d.BurialSubplot, d.BurialSquareId })
                    .HasConstraintName("FK_QUADRANT");
            });

            modelBuilder.Entity<BurialQuadrant>(entity =>
            {
                entity.HasKey(e => new { e.BurialSubplot, e.BurialSquareId })
                    .HasName("PK_QUADRANT");

                entity.ToTable("Burial_Quadrant");

                entity.Property(e => e.BurialSubplot)
                    .HasColumnName("burial_subplot")
                    .HasMaxLength(2)
                    .IsUnicode(false);

                entity.Property(e => e.BurialSquareId)
                    .HasColumnName("burial_square_id")
                    .HasMaxLength(50)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<BurialSquare>(entity =>
            {
                entity.ToTable("Burial_Square");

                entity.Property(e => e.BurialSquareId)
                    .HasColumnName("burial_square_id")
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.BurialLocationEw)
                    .IsRequired()
                    .HasColumnName("burial_location_EW")
                    .HasMaxLength(1)
                    .IsUnicode(false);

                entity.Property(e => e.BurialLocationNs)
                    .IsRequired()
                    .HasColumnName("burial_location_NS")
                    .HasMaxLength(1)
                    .IsUnicode(false);

                entity.Property(e => e.HighPairEw).HasColumnName("high_pair_EW");

                entity.Property(e => e.HighPairNs).HasColumnName("high_pair_NS");

                entity.Property(e => e.LowPairEw).HasColumnName("low_pair_EW");

                entity.Property(e => e.LowPairNs).HasColumnName("low_pair_NS");
            });

            modelBuilder.Entity<CranialSample>(entity =>
            {
                entity.HasKey(e => e.CranialId)
                    .HasName("PK__Cranial___88D8C19A8797E05D");

                entity.ToTable("Cranial_Sample");

                entity.Property(e => e.CranialId).HasColumnName("cranial_id");

                entity.Property(e => e.BasionBregmaHeight).HasColumnName("basion_bregma_height");

                entity.Property(e => e.BasionNasion).HasColumnName("basion_nasion");

                entity.Property(e => e.BasionProsthionLength).HasColumnName("basion_prosthion_length");

                entity.Property(e => e.BizgomaticDiameter).HasColumnName("bizgomatic_diameter");

                entity.Property(e => e.BurialId).HasColumnName("burial_id");

                entity.Property(e => e.InterobitalBreadth).HasColumnName("interobital_breadth");

                entity.Property(e => e.MaxCranialBreadth).HasColumnName("max_cranial_breadth");

                entity.Property(e => e.MaxCranialLength).HasColumnName("max_cranial_length");

                entity.Property(e => e.MaxNasalBreadth).HasColumnName("max_nasal_breadth");

                entity.Property(e => e.NasionProsthion).HasColumnName("nasion_prosthion");

                entity.Property(e => e.RackNumber)
                    .HasColumnName("rack_number")
                    .HasMaxLength(3)
                    .IsUnicode(false);

                entity.Property(e => e.RackShelf)
                    .HasColumnName("rack_shelf")
                    .HasMaxLength(2)
                    .IsUnicode(false);

                entity.Property(e => e.SampleNumber).HasColumnName("sample_number");

                entity.HasOne(d => d.Burial)
                    .WithMany(p => p.CranialSample)
                    .HasForeignKey(d => d.BurialId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_BURIAL2");

                entity.HasOne(d => d.Rack)
                    .WithMany(p => p.CranialSample)
                    .HasForeignKey(d => new { d.RackShelf, d.RackNumber })
                    .HasConstraintName("FK_RACK");
            });

            modelBuilder.Entity<Image>(entity =>
            {
                entity.Property(e => e.ImageId).HasColumnName("image_id");

                entity.Property(e => e.BurialId).HasColumnName("burial_id");

                entity.Property(e => e.BurialSquareId)
                    .HasColumnName("burial_square_id")
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.BurialSubplot)
                    .HasColumnName("burial_subplot")
                    .HasMaxLength(2)
                    .IsUnicode(false);

                entity.Property(e => e.CranialId).HasColumnName("cranial_id");

                entity.Property(e => e.Image1)
                    .HasColumnName("image")
                    .HasColumnType("image");

                entity.Property(e => e.ImageDescription)
                    .HasColumnName("image_description")
                    .HasMaxLength(5000)
                    .IsUnicode(false);

                entity.HasOne(d => d.Burial)
                    .WithMany(p => p.Image)
                    .HasForeignKey(d => d.BurialId)
                    .HasConstraintName("FK_BURIAL3");

                entity.HasOne(d => d.BurialSquare)
                    .WithMany(p => p.Image)
                    .HasForeignKey(d => d.BurialSquareId)
                    .HasConstraintName("FK_SQUARE");

                entity.HasOne(d => d.Cranial)
                    .WithMany(p => p.Image)
                    .HasForeignKey(d => d.CranialId)
                    .HasConstraintName("FK_CRANIAL");

                entity.HasOne(d => d.BurialS)
                    .WithMany(p => p.Image)
                    .HasForeignKey(d => new { d.BurialSubplot, d.BurialSquareId })
                    .HasConstraintName("FK_QUADRANT2");
            });

            modelBuilder.Entity<RackSample>(entity =>
            {
                entity.HasKey(e => new { e.RackShelf, e.RackNumber })
                    .HasName("PK_RACK");

                entity.ToTable("Rack_Sample");

                entity.Property(e => e.RackShelf)
                    .HasColumnName("rack_shelf")
                    .HasMaxLength(2)
                    .IsUnicode(false);

                entity.Property(e => e.RackNumber)
                    .HasColumnName("rack_number")
                    .HasMaxLength(3)
                    .IsUnicode(false);

                entity.Property(e => e.BurialId).HasColumnName("burial_id");

                entity.Property(e => e.Calibrated95CalendarDateAvg)
                    .HasColumnName("calibrated_95_calendar_date_AVG")
                    .HasMaxLength(30)
                    .IsUnicode(false);

                entity.Property(e => e.Calibrated95CalendarDateMax).HasColumnName("calibrated_95_calendar_date_MAX");

                entity.Property(e => e.Calibrated95CalendarDateMin).HasColumnName("calibrated_95_calendar_date_MIN");

                entity.Property(e => e.Calibrated95CalendarDateSpan)
                    .HasColumnName("calibrated_95_calendar_date_SPAN")
                    .HasComputedColumnSql("(abs([calibrated_95_calendar_date_MAX]-[calibrated_95_calendar_date_MIN]))");

                entity.Property(e => e.Category)
                    .IsRequired()
                    .HasColumnName("category")
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.Conventional14cAgeBp).HasColumnName("conventional_14c_age_BP");

                entity.Property(e => e.Foci).HasColumnName("foci");

                entity.Property(e => e.IsBag).HasColumnName("is_bag");

                entity.Property(e => e.LocationNotes)
                    .HasColumnName("location_notes")
                    .HasMaxLength(2000)
                    .IsUnicode(false);

                entity.Property(e => e.MlSize).HasColumnName("ml_size");

                entity.Property(e => e.Notes)
                    .HasColumnName("notes")
                    .HasMaxLength(2000)
                    .IsUnicode(false);

                entity.Property(e => e.Questions)
                    .HasColumnName("questions")
                    .HasMaxLength(2000)
                    .IsUnicode(false);

                entity.Property(e => e.RankDescription)
                    .HasColumnName("rank_description")
                    .HasMaxLength(5000)
                    .IsUnicode(false);

                entity.Property(e => e.TubeNumber).HasColumnName("tube_number");

                entity.Property(e => e._14cCalendarDay).HasColumnName("14c_calendar_day");

                entity.HasOne(d => d.Burial)
                    .WithMany(p => p.RackSample)
                    .HasForeignKey(d => d.BurialId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_BURIAL");
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
