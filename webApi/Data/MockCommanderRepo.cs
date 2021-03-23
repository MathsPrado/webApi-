using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using webApi.Models;

namespace webApi.Data
{
    public class MockCommanderRepo : IcommanderRepo
    {
        public IEnumerable<CommandReaderDto> GetAllCommands()
        {
            var commands = new List<CommandReaderDto> {
               new CommandReaderDto { Id = 0, HowTo = "Boil an egg", Line = "Boil Water", Plataform = "Kettle & Pan" },
               new CommandReaderDto { Id = 1, HowTo = "Cut bread", Line = "Boil Knif", Plataform = "Knife & Chopping" },
               new CommandReaderDto { Id = 2, HowTo = "make Coffe", Line = "Hot Water", Plataform = "Nescafe" }
        };

            return commands;
    }

        public CommandReaderDto GetCommandById(int Id)
        {
            return new CommandReaderDto { Id = 0, HowTo = "Boil an egg", Line = "Boil Water", Plataform = "Kettle & Pan" };
        }
    }
}
