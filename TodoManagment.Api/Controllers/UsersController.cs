using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.ActionConstraints;
using Microsoft.AspNetCore.Mvc.Infrastructure;
using TodoManagment.Api.Dtos;
using TodoManagment.Core.Interfaces;
using TodoManagment.Domain;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace TodoManagment.Api.Controllers
{
    [RequireHttps]
    [Route("api/v{version:apiVersion}/Users")]
    [ApiController]
    [ApiVersion("1.0")]
    [ApiVersion("2.0")]
    public class UsersController : ControllerBase
    {
        private readonly IUserService _userService;
        private readonly IMapper _mapper;

        public UsersController(IUserService user_service, IMapper mapper)
        {
            _userService=user_service;
            _mapper=mapper;
        }
        // GET: api/<UsersController>
        [HttpGet]
        [MapToApiVersion("1.0")]
        public async Task<IActionResult> Get()
        {
            var r = await _userService.GetUsers();
            var list =  _mapper.Map<List<UserDtoView>>(r);

            return Ok(list);
        }

        // GET api/<UsersController>/5
        [HttpGet("{id}")]
        [MapToApiVersion("1.0")]
        public async Task<IActionResult> Get(int id)
        {
            if(id==0)  return BadRequest();

            var r= await _userService.GetUser(id);

            if(r==null)   return NotFound();

            var user = _mapper.Map<UserDtoView>(r);

            return Ok(user);
        }

        // POST api/<UsersController>
        [HttpPost]
        [MapToApiVersion("1.0")]
        public async Task<IActionResult> Post([FromBody] UserDtoCreate value)
        {
            TryValidateModel(value);

            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            await _userService.AddUser(_mapper.Map<User>(value));

            return NoContent();
        }

        // PUT api/<UsersController>/5
        [HttpPut("{id}")]
        [MapToApiVersion("1.0")]
        public async Task<IActionResult> Put(int id, [FromBody] UserDtoCreate value)
        {
            TryValidateModel(value);

            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            var item=_mapper.Map<User>(value);
            item.Id = id;

            await _userService.UpdateUser(item);

            return NoContent();
        }

        // DELETE api/<UsersController>/5
        [HttpDelete("{id}")]
        [MapToApiVersion("1.0")]
        public async Task<IActionResult> Deletev1(int id)
        {
            await _userService.DeleteUser(id);

            return NoContent();
        }

        //// DELETE api/<UsersController>/5
        //[HttpDelete("{id}")]
        //[MapToApiVersion("2.0")]
        //public async Task<IActionResult> Deletev2(int id)
        //{
        //    await _userService.DeleteUser(id);

        //    return NoContent();
        //}
    }
}
