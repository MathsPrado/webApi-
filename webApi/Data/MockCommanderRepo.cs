using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using webApi.Dtos;
using webApi.Models;

namespace webApi.Data
{
    public class MockCommanderRepo : IcommanderRepo
    {
        public void CreateCommand(CommanderContext cmd)
        {
            throw new NotImplementedException();
        }

        public void CreateCommand(Command cmd)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<Command> GetAllCommands()
        {
            var commands = new List<Command> {
               new Command { Id = 0, HowTo = "Boil an egg", Line = "Boil Water", Plataform = "Kettle & Pan" },
               new Command { Id = 1, HowTo = "Cut bread", Line = "Boil Knif", Plataform = "Knife & Chopping" },
               new Command { Id = 2, HowTo = "make Coffe", Line = "Hot Water", Plataform = "Nescafe" }
        };

            return commands;
    }

        public Command GetCommandById(int Id)
        {
            return new Command { Id = 0, HowTo = "Boil an egg", Line = "Boil Water", Plataform = "Kettle & Pan" };
        }

        public bool SaveChanges()
        {
            throw new NotImplementedException();
        }

        public void updateCommand(Command cmd)
        {
            throw new NotImplementedException();
        }
    }
}
