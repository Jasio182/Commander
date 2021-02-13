using Commander.Models;
using Microsoft.EntityFrameworkCore;

namespace Commander.Data
{
    public class CommanderContext : DbContext
    {
        // Constructor using constructor from a DbContext thanks to base keyword.
        public CommanderContext(DbContextOptions<CommanderContext> opt) : base(opt)
        {
               
        }
        /* Representation of a command model in database.
           Without it model won't be mapped to database.
           Need to be created for all models.
           The name of method is name of table created via migration.*/
        public DbSet<Command> Commands { get; set; }

    }
}
