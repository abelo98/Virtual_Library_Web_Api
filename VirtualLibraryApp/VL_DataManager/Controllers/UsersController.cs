using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Services_Layer;
using VL_DataAccess.Models;
using VL_DataManager.Dtos;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace VL_DataManager.Controllers
{
    [Route("api/v1.0/library/[controller]")]
    [ApiController]
    public class UsersController : ControllerBase
    {
        readonly IUserService _userService;
        readonly IMapper _mapper;


        public UsersController(IUserService userService , IMapper mapper)
        {
            _userService = userService;
            _mapper = mapper;
        }
        // GET: api/<UserController>
        [HttpGet]
        public IEnumerable<string> Get()
        {
            return new string[] { "value1", "value2" };
        }

        // GET api/<UserController>/5
        [HttpGet("{id}")]
        public string Get(int id)
        {
            return "value";
        }

        // POST api/<UserController>
        [HttpPost]
        public async Task<IActionResult> Post([FromBody] UserDto userDto)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            try
            {
                LibraryUser libraryUser = _mapper.Map<LibraryUser>(userDto);
                await _userService.Insert(libraryUser);
                return Ok(userDto);
            }
            catch (Exception)
            {

                return StatusCode(StatusCodes.Status500InternalServerError,
                        "Error inserting data on the database");
            }

           
        }

        // PUT api/<UserController>/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
        }

        // DELETE api/<UserController>/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
