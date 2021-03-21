using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using webApi.Data;
using webApi.Models;

namespace webApi.Controllers
{
    //api/commands
    [Route("api/commands")]
    [ApiController]
    public class CommandController : ControllerBase
    {
        private readonly IcommanderRepo _repository;

        public CommandController(IcommanderRepo repository)
        {
            _repository = repository;
        }

        //private readonly MockCommanderRepo _repository = new MockCommanderRepo();

        [HttpGet]
        public ActionResult <IEnumerable<Command>> getAllCommands()
        {
            try
            {
                var commandItens = _repository.GetAppCommands();
                return Ok(commandItens);

            } catch(Exception e)
            {
                return BadRequest(e);
            }

        }

        [HttpGet("{id}")]
        public ActionResult <Command> GetCommandById(int id)
        {

            var commandItens = _repository.GetCommandById(id);
            return Ok(commandItens);

        }
        
    }
}
