using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using UJTUT.Models;

namespace UJTUT.Data
{
    public class ApplicationDbContext : IdentityDbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }
        public DbSet<Tutor> Tutor { get; set; }
        public DbSet<ArticlesComment> ArticlesCommentss { get; set; }
    }
}
