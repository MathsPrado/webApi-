using AutoMapper;
using Microsoft.AspNetCore.JsonPatch;
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
        public ActionResult <IEnumerable<CommandReadDto>> getAllCommands()
        {
            try
            {
                var commandItens = _repository.GetAllCommands();
                return Ok(_mapper.Map<IEnumerable<CommandReadDto>>(commandItens));

            } catch(Exception e)
            {
                return BadRequest(e);
            }

        }
        //GET api/commands{id}
        [HttpGet("{id}", Name="getCommandById")]
        public ActionResult <CommandReadDto> GetCommandById(int id)
        {

            var commandItens = _repository.GetCommandById(id);
            if(commandItens != null)
            {
                return Ok(_mapper.Map<CommandReadDto>(commandItens));
            }
            else
            {
                return NotFound();
            }
        }

        [HttpPost]
        public ActionResult <CommandReadDto> CreateCommand(CommandCreateDto commandCreateDto)
        {
            var commandModel = _mapper.Map<Command>(commandCreateDto);
            _repository.CreateCommand(commandModel);
            _repository.SaveChanges();

            var commnandReadDto = _mapper.Map<CommandReadDto>(commandModel);
            return CreatedAtRoute(nameof(GetCommandById), new { Id = commnandReadDto.Id }, commnandReadDto);

        }

        //PUT api/commands/{id}
        [HttpPut("{id}")]
        public ActionResult UpdateCommand(int id, CommandUpdateDto commandUpdateDto)
        {
            var commandModelFromRepo = _repository.GetCommandById(id);
            if(commandModelFromRepo == null)
            {
                return NotFound();
            }
            _mapper.Map(commandUpdateDto, commandModelFromRepo);
            _repository.updateCommand(commandModelFromRepo);
            _repository.SaveChanges();
            return NoContent();
        }

        [HttpPatch("{id}")]
        public ActionResult PartialCommandUpdate(int id, JsonPatchDocument<CommandUpdateDto> patchDoc)
        {
            var commandModelFromRepo = _repository.GetCommandById(id);
            if (commandModelFromRepo == null)
            {
                return NotFound();
            }

            var commandToPatch = _mapper.Map<CommandUpdateDto>(commandModelFromRepo);
            patchDoc.ApplyTo(commandToPatch, ModelState);

            if (!TryValidateModel(commandToPatch))
            {
                return ValidationProblem(ModelState);
            }

            _mapper.Map(commandToPatch, commandModelFromRepo);

            _repository.updateCommand(commandModelFromRepo);

            _repository.SaveChanges();

            return NoContent();
        }

        [HttpDelete("{id}")]
        public ActionResult DeleteCommand(int id)
        {
            var commandModelFromRepo = _repository.GetCommandById(id);
            if (commandModelFromRepo == null)
            {
                return NotFound();
            }
            _repository.DeleteCommand(commandModelFromRepo);
            _repository.SaveChanges();

            return NoContent();
        }


    }
}
