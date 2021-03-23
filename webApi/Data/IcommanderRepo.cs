using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using webApi.Models;

namespace webApi.Data
{
    public interface IcommanderRepo
    {
        IEnumerable<CommandReaderDto> GetAllCommands();
        CommandReaderDto GetCommandById(int Id);
    }
}
