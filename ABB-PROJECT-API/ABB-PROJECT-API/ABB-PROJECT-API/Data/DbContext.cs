using ABB_PROJECT_API.Controllers;
using ABB_PROJECT_API.Models;
using Microsoft.EntityFrameworkCore;

namespace ABB_PROJECT_API.Data
{
    public class DbProjContext : DbContext
    {
        public DbProjContext(DbContextOptions<DbProjContext> options) : base(options)
        {

        }

        public DbSet<User> TblUser { get; set; }
    }
}
