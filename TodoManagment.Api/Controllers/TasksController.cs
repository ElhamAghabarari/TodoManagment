using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using TodoManagment.Api.Dtos;
using TodoManagment.Core.Interfaces;
using TodoManagment.Domain;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace TodoManagment.Api.Controllers
{
    [Route("api/v{version:apiVersion}/Tasks")]
    [ApiController]
    [ApiVersion("1.0")]
    public class TasksController : ControllerBase
    {
        private readonly IMapper _mapper;
        private readonly ITaskService _service;
        public TasksController(IMapper mapper, ITaskService service)
        {
            _mapper = mapper;
            _service = service;
        }
        // GET: api/<TasksController>
        [HttpGet]
        public async Task<IActionResult> Gets([FromQuery]int user_id)
        {
            var list = await _service.GetTasks(user_id);
            return Ok(_mapper.Map<List<TaskDtoView>>(list));
        }

        // GET api/<TasksController>/5
        [HttpGet("{id}")]
        public async Task<IActionResult> Get(int id)
        {
            var item=await _service.GetTask(id);
            return Ok(_mapper.Map<TaskDtoView>(item));
        }

        // POST api/<TasksController>
        [HttpPost]
        public async Task Post([FromBody] TaskDtoCreate value, [FromQuery] int user_id)
        {
            var task = _mapper.Map<TodoTask>(value);
            task.UserId = user_id;
            await _service.AddTask(task);
        }

        // PUT api/<TasksController>/5
        [HttpPut("{id}")]
        public async Task Put(int id, [FromBody] TaskDtoCreate value)
        {
            var task = _mapper.Map<TodoTask>(value);
            task.Id = id;
            await _service.UpdateTask(task);
        }

        // PUT api/<TasksController>/5
        [HttpPatch("{id}")]
        public async Task Patch(int id, [FromBody] int status)
        {
            await _service.UpdateTaskStatus(id, status);
        }

        // DELETE api/<TasksController>/5
        [HttpDelete("{id}")]
        public async Task Delete(int id)
        {
            await _service.DeleteTask(id);
        }
    }
}
