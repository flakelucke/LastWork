using LastWork.Models.Instructions;
using LastWork.Models.InstructionSteps;
using LastWork.Models.Users;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace LastWork.Models
{
    public class DataContext : IdentityDbContext<User>
    {
        public DataContext(DbContextOptions<DataContext> opts)
            : base(opts) {}
        public DbSet<Instruction> Instructions { get; set; }
        public DbSet<InstructionStep> Steps { get; set; }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.Entity<Instruction>().HasMany<InstructionStep>(x => x.Steps)
                .WithOne().OnDelete(DeleteBehavior.Cascade);
        }
    }
}