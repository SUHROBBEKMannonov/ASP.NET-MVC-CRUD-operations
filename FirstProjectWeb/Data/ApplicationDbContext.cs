using FirstProjectWeb.Models;
using Microsoft.EntityFrameworkCore;

namespace FirstProjectWeb.Data
{
    public class ApplicationDbContext:DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options): base(options)  
        {

        }
        public DbSet<FirstModel> DataUsers { get; set; }    


    }
}
