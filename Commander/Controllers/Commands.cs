using AutoMapper;
using Commander.Data;
using Commander.Dtos;
using Commander.Models;
using Microsoft.AspNetCore.JsonPatch;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;

namespace Commander.Controllers
{
    [Route("api/commands")]
    [ApiController]
    public class CommandsController : ControllerBase
    {
        // Private readonly fields for Dependency Injection
        private readonly ICommanderRepo _repository;
        private readonly IMapper _mapper;

        // Constructor used with Dependency Injection. Injectin atribut to private variable.
        public CommandsController(ICommanderRepo repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }

        // private readonly MockCommanderRepo _repository = new MockCommanderRepo();
        // GET api/commands
        [HttpGet]
        public ActionResult<IEnumerable<Command>> GetAllCommands()
        {
            // Using data in internal format.
            var commandItems = _repository.GetAppComands();
            return Ok(commandItems);
        }

        // GET api/commands/{id}
        // Created name to use it in CreateCommand method.
        [HttpGet("{id}", Name = "GetCommandById")]
        public ActionResult<CommandReadDto> GetCommandById(int id)
        {
            var commandItem = _repository.GetCommandById(id);
            if (commandItem != null)
                // Using mapper, to return data in DTO format.
                return Ok(_mapper.Map<CommandReadDto>(commandItem));
            else
                // Instead of 204 No Content, returns 404 Not Found.
                return NotFound();
        }

        // It should show the created object, so <CommandReadDto> 
        // POST api/commands
        [HttpPost]
        public ActionResult<CommandReadDto> CreateCommand(CommandCreateDto commandCreateDto)
        {
            var commandModel = _mapper.Map<Command>(commandCreateDto);
            _repository.CreateCommand(commandModel);
            _repository.SaveChanges();
            // Placeholder to save file that has been created
            // Creates CommandReadDto object with data from commandModel using mapper.
            var commandReadDto = _mapper.Map<CommandReadDto>(commandModel);
            // Needs name of method that returns single object, argument of that method, and what has been created.
            // Part of REST architecture - location of created object has to be returned.
            return CreatedAtRoute(nameof(GetCommandById), new { Id = commandReadDto.Id }, commandReadDto);
        }

        // PUT api/commands/{id}
        [HttpPut("{id}")]
        public ActionResult UpdateCommand(int id, CommandUpdateDto commandUpdateDto)
        {
            var commandModelFromRepo = _repository.GetCommandById(id);
            if (commandModelFromRepo == null)
                return NotFound();
            // Both commandUpdateDto and commandModelFromRepo already have data.
            // Mapper inserts data from commandUpdateDto to commandModelFromRepo
            _mapper.Map(commandUpdateDto, commandModelFromRepo);
            _repository.UpdateCommand(commandModelFromRepo);
            _repository.SaveChanges();
            return NoContent();
        }

        // PATCH api/commands/{id}
        [HttpPatch("{id}")]
        public ActionResult PartialCommandUpdate(int id, JsonPatchDocument<CommandUpdateDto> patchDoc)
        {
            // Collects data from repository of object to update
            var commandModelFromRepo = _repository.GetCommandById(id);
            if (commandModelFromRepo == null)
                return NotFound();
            // Creates new object with data collected from repository.
            var commandToPatch = _mapper.Map<CommandUpdateDto>(commandModelFromRepo);
            // Adds data from json to created object.
            patchDoc.ApplyTo(commandToPatch, ModelState);
            if (!TryValidateModel(commandToPatch))
                return ValidationProblem(ModelState);
            // Pushes data to repository.
            _mapper.Map(commandToPatch, commandModelFromRepo);
            _repository.UpdateCommand(commandModelFromRepo);
            _repository.SaveChanges();
            return NoContent();
        }

        // DELETE api/commands/{id}
        [HttpDelete("{id}")]
        public ActionResult DeleteCommand(int id)
        {
            // Checked if object exists.
            var commandModelFromRepo = _repository.GetCommandById(id);
            if (commandModelFromRepo == null)
                return NotFound();
            // Object deleted and changes saved.
            _repository.DeleteCommand(commandModelFromRepo);
            _repository.SaveChanges();
            return NoContent();
        }
    }
}
