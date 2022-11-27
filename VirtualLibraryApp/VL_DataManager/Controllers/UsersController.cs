using AutoMapper;
using Microsoft.AspNetCore.JsonPatch;
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
        readonly ILibraryUserService _libraryUserService;
        readonly IMapper _mapper;


        public UsersController(ILibraryUserService libraryUserService , IMapper mapper)
        {
            _libraryUserService = libraryUserService;
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
        public async Task<IActionResult> Post([FromBody] UserDto libraryUserDto)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            try
            {
                LibraryUser libraryUser = _mapper.Map<LibraryUser>(libraryUserDto);
                await _libraryUserService.Insert(libraryUser);
                return Ok(libraryUserDto);
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

        [HttpPatch("{id}")]
        public async Task<IActionResult> JsonPatchWithModelStateAsync(Guid id,[FromBody] JsonPatchDocument<UserDto> libraryUserDto)
        {

            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            try
            {
                var libraryUser = _mapper.Map<JsonPatchDocument<LibraryUser>>(libraryUserDto);
                LibraryUser updatedEmployee = await _libraryUserService.PartialUpdate(id, libraryUser);
                var response = _mapper.Map<UserDto>(updatedEmployee);

                return Ok(response);
            }
            catch (Exception)
            {

                return StatusCode(StatusCodes.Status500InternalServerError,
                        "Error inserting data on the database");
            }
        }

        // DELETE api/<UserController>/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
