using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using Store.DataAccess.Repository.DBConf;

namespace Store.DataAccess.Repository.Entities
{
    public partial class StoreContext : DbContext
    {
        IAccessConnectionString _accessConnectionString;
        ILogger<StoreContext> _log;
        public StoreContext()
        {
        }

        public StoreContext(DbContextOptions<StoreContext> options)
            : base(options)
        {
        }
  
        public StoreContext(IAccessConnectionString accessConnectionString, ILogger<StoreContext> log)
        {
            _accessConnectionString = accessConnectionString;
            _log = log;
        }
        public virtual DbSet<AppRole> AppRole { get; set; }
        public virtual DbSet<AppUser> AppUser { get; set; }
        public virtual DbSet<EstimationLogs> EstimationLogs { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                _log.LogInformation("Database Connection  Started");
                var database = _accessConnectionString.ComposeDbConnection();

                _log.LogInformation("Database Connection In Progress");

                optionsBuilder.UseSqlServer(@database);
                _log.LogInformation("Database Connection Established");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<AppRole>(entity =>
            {
                entity.Property(e => e.Code)
                    .IsRequired()
                    .HasMaxLength(100);

                entity.Property(e => e.CreatedDate).HasColumnType("datetime");

                entity.Property(e => e.Description).HasMaxLength(300);

                entity.Property(e => e.UpdatedDate).HasColumnType("datetime");
            });

            modelBuilder.Entity<AppUser>(entity =>
            {
                entity.HasIndex(e => e.EmailId)
                    .HasName("UQ__AppUser__7ED91ACEDAB87437")
                    .IsUnique();

                entity.HasIndex(e => e.LoginName)
                    .HasName("UQ__AppUser__DB8464FFC495D375")
                    .IsUnique();

                entity.Property(e => e.Contact).HasMaxLength(15);

                entity.Property(e => e.CreatedDate).HasColumnType("datetime");

                entity.Property(e => e.EmailId).HasMaxLength(200);

                entity.Property(e => e.LoginName)
                    .IsRequired()
                    .HasMaxLength(100);

                entity.Property(e => e.Password)
                    .IsRequired()
                    .HasMaxLength(500);

                entity.Property(e => e.RoleId).HasColumnName("Role_Id");

                entity.Property(e => e.UpdatedDate).HasColumnType("datetime");

                entity.Property(e => e.UserName).HasMaxLength(500);

                entity.HasOne(d => d.Role)
                    .WithMany(p => p.AppUser)
                    .HasForeignKey(d => d.RoleId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__AppUser__Role_Id__145C0A3F");
            });

            modelBuilder.Entity<EstimationLogs>(entity =>
            {
                entity.Property(e => e.AppUserId).HasColumnName("AppUser_Id");

                entity.Property(e => e.CreatedDate).HasColumnType("datetime");

                entity.Property(e => e.Discount)
                    .IsRequired()
                    .HasMaxLength(300);

                entity.Property(e => e.UpdatedDate).HasColumnType("datetime");

                entity.Property(e => e.Weight).HasColumnType("decimal(18, 0)");

                entity.HasOne(d => d.AppUser)
                    .WithMany(p => p.EstimationLogs)
                    .HasForeignKey(d => d.AppUserId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__Estimatio__AppUs__173876EA");
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
