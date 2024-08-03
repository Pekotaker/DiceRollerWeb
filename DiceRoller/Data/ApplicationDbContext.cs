using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using DiceRoller.Models;

namespace DiceRoller.Data
{
    public class ApplicationDbContext : IdentityDbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }
        public DbSet<DiceRoller.Models.ProbabilityObjectModel> ProbabilityObjectModel { get; set; } = default!;
    }
}
