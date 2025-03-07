using Microsoft.EntityFrameworkCore;

namespace apief
{
    public class DataContext : DbContext
    {
        private readonly IConfiguration _config;

        public DataContext(IConfiguration config)
        {
            _config = config;
        }

        public DbSet<User> Users { get; set; }
        public DbSet<Password> Passwords { get; set; }
        public DbSet<AdditionalField> AdditionalFields { get; set; }
        public DbSet<Note> Notes { get; set; }
        public DbSet<BankAccount> BankAccounts { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                string? connectionString = _config.GetConnectionString("DefaultConnection");
                optionsBuilder.UseSqlServer(connectionString);
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.HasDefaultSchema("Dbo");
            modelBuilder.Entity<BankAccount>(entity =>
         {
        entity.ToTable("BankAccounts");
        entity.HasKey(b => b.bankAccountId); 
          });

            modelBuilder.Entity<User>()
                .ToTable("User", "Dbo")
                .HasKey(u => u.id);

            modelBuilder.Entity<Note>()
                .ToTable("Note", "Dbo")
                .HasKey(n => n.noteId);

            modelBuilder.Entity<Password>()
         .ToTable("Password", "Dbo")
         .HasKey(p => p.passwordId);

            modelBuilder.Entity<AdditionalField>()
                .ToTable("AdditionalFields", "Dbo")
                .HasKey(a => a.additionalId);


            modelBuilder.Entity<Password>()
                .HasMany(p => p.additionalFields)
                .WithOne()
                .HasForeignKey(a => a.passwordId)
                .OnDelete(DeleteBehavior.Cascade);
        }
    }
}