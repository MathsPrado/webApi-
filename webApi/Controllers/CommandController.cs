using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using webApi.Data;
using webApi.Dtos;
using webApi.Models;

namespace webApi.Controllers
{
    //api/commands
    [Route("api/commands")]
    [ApiController]
    public class CommandController : ControllerBase
    {
        private readonly IcommanderRepo _repository;
        private IMapper _mapper;

        public CommandController(IcommanderRepo repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }

        //private readonly MockCommanderRepo _repository = new MockCommanderRepo();

        [HttpGet]
        public ActionResult <IEnumerable<CommandReaderDto>> getAllCommands()
        {
            try
            {
                var commandItens = _repository.GetAllCommands();
                return Ok(_mapper.Map<IEnumerable<CommandReaderDto>>(commandItens));

            } catch(Exception e)
            {
                return BadRequest(e);
            }

        }

        [HttpGet("{id}")]
        public ActionResult <CommandReaderDto> GetCommandById(int id)
        {

            var commandItens = _repository.GetCommandById(id);
            if(commandItens != null)
            {
                return Ok(_mapper.Map<CommandReaderDto>(commandItens));
            }
            else
            {
                return NotFound();
            }
        }

        [HttpPost]
        public ActionResult <CommandReadDto CreateCommand(CommandCreateDto commandCreateDto)
        {

        }
        
    }
}
