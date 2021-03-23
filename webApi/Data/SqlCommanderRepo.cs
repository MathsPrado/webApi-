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

        public IEnumerable<CommandReaderDto> GetAllCommands()
        {
            return _context.Commands.ToList();
        }

        public CommandReaderDto GetCommandById(int Id)
        {
            return _context.Commands.FirstOrDefault(p => p.Id == Id);
        }
    }
}
