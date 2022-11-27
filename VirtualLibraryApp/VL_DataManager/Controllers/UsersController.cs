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
        readonly ISubscriptionService _subscriptionService;

        readonly IMapper _mapper;


        public UsersController(ILibraryUserService libraryUserService ,ISubscriptionService subscriptionService,
            IMapper mapper)
        {
            _libraryUserService = libraryUserService;
            _subscriptionService = subscriptionService;
            _mapper = mapper;
        }
        // GET: api/<UserController>
        [HttpGet]
        public IEnumerable<string> Get()
        {
            return new string[] { "value1", "value2" };
        }

        // GET api/<UserController>/5
        [HttpGet("{userId}")]
        public string Get(int id)
        {
            return "value";
        }

        // POST api/<UserController>
        [HttpPost]
        public async Task<IActionResult> Post([FromBody] LibraryUserDto libraryUserDto)
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
        [HttpPut("{userId}")]
        public void Put(int id, [FromBody] string value)
        {
        }

        [HttpPatch("{userId}")]
        public async Task<IActionResult> Patch(Guid id,[FromBody] JsonPatchDocument<LibraryUserDto> libraryUserDto)
        {

            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            try
            {
                var libraryUser = _mapper.Map<JsonPatchDocument<LibraryUser>>(libraryUserDto);
                LibraryUser updatedEmployee = await _libraryUserService.PartialUpdate(id, libraryUser);
                var response = _mapper.Map<LibraryUserDto>(updatedEmployee);

                return Ok(response);
            }
            catch (Exception)
            {

                return StatusCode(StatusCodes.Status500InternalServerError,
                        "Error inserting data on the database");
            }
        }

        // DELETE api/<UserController>/5
        [HttpDelete("{userId}")]
        public async Task<IActionResult> DeleteAsync(Guid id)
        {
            try
            {
                await _libraryUserService.Delete(id);
                return Ok();
            }
            catch (Exception)
            {

                return StatusCode(StatusCodes.Status500InternalServerError,
                        "Error deleting data from the database");
            }
        }

        [HttpPost("{userId}/subscribe-to-author/{authorId}")]
        public async Task<IActionResult> SubscribeToAuthor(Guid userId, Guid authorId)
        {

            try
            {
                Subscription subscription = new Subscription() { LibraryUserId = userId, AuthorId = authorId };    
                await _subscriptionService.Insert(subscription);
                return Ok();
            }
            catch (Exception)
            {

                return StatusCode(StatusCodes.Status500InternalServerError,
                        "Error inserting data on the database");
            }


        }
    }
}
