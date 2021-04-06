using System;
using System.Collections.Generic;
using System.Linq;
using webApi.Models;

namespace webApi.Data
{
    public class SqlCommanderRepo : IcommanderRepo
    {
        private readonly CommanderContext _context;

        public SqlCommanderRepo(CommanderContext context)
        {
            _context = context;
        }

        public void CreateCommand(Command cmd)
        {
            if(cmd == null)
            {
                throw new ArgumentNullException(nameof(cmd));
            }
            _context.Commands.Add(cmd);
        }

        public IEnumerable<Command> GetAllCommands()
        {
            return (IEnumerable<Command>)_context.Commands.ToList();
        }

        public Command GetCommandById(int Id)
        {
            return _context.Commands.FirstOrDefault(p => p.Id == Id);
        }

        public bool SaveChanges()
        {
           return(_context.SaveChanges() >= 0);
        }

        public void updateCommand(Command cmd)
        {
           //Nothing
        }
    }
}
