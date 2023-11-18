

using Microsoft.EntityFrameworkCore;
using TODO_B.E.Models;

namespace TODO_B.E.Data
{

    public class AppDbContext:DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext>op ): base(op) 
        {

        }

        public DbSet<Notes> Note { get; set; }
    }
}
