using Microsoft.EntityFrameworkCore;
using webApi.Models;

namespace webApi.Data
{
    public class CommanderContext : DbContext
    {
        public CommanderContext(DbContextOptions<CommanderContext> opt ) : base(opt)
        {

        }

        public DbSet<CommandReaderDto> Commands { get; set; }

    }
}
