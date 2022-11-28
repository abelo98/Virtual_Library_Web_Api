using AutoMapper;
using Microsoft.AspNetCore.JsonPatch;
using Microsoft.AspNetCore.Mvc;
using Services_Layer;
using VL_DataAccess.Models;
using VL_DataManager.Dtos;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace VL_DataManager.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthorsController : ControllerBase
    {
        readonly IAuthorService _authorService;
        readonly IBookService _bookService;
        readonly IMapper _mapper;

        public AuthorsController(IAuthorService authorService,IBookService bookService, IMapper mapper)
        {
            _bookService = bookService;
            _authorService = authorService;
            _mapper = mapper;
        }

        // GET: api/<AuthorController>
        [HttpGet]
        public IEnumerable<string> Get()
        {
            return new string[] { "value1", "value2" };
        }

        // GET api/<AuthorController>/5
        [HttpGet("{authorId}")]
        public string Get(Guid authorId)
        {
            return "value";
        }

        // POST api/<AuthorController>
        [HttpPost]
        public async Task<IActionResult> Post([FromBody] AuthorDtoRequest authorDto)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            try
            {
                Author author = _mapper.Map<Author>(authorDto);
                var result = await _authorService.Insert(author);
                return Ok(_mapper.Map<AuthorDtoResponse>(result));
            }
            catch (Exception)
            {

                return StatusCode(StatusCodes.Status500InternalServerError,
                        "Error inserting data on the database");
            }


        }

        // PUT api/<AuthorController>/5
        [HttpPut("{authorId}")]
        public void Put(int id, [FromBody] string value)
        {
        }

        // DELETE api/<AuthorController>/5
        [HttpDelete("{authorId}")]
        public async Task<IActionResult> Delete(Guid authorId)
        {
            try
            {
                await _authorService.Delete(authorId);
                return Ok();
            }
            catch (Exception)
            {

                return StatusCode(StatusCodes.Status500InternalServerError,
                        "Error deleting data from the database");
            }
        }

        // POST api/<AuthorController>
        [HttpPost("{id}/books")]
        public async Task<IActionResult> Post(Guid id,[FromBody] BookDtoRequest bookDto)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            try
            {
                Book book = _mapper.Map<Book>(bookDto);
                var result = await _authorService.Insert(book);
                return Ok(_mapper.Map<AuthorDtoResponse>(result));
            }
            catch (Exception)
            {

                return StatusCode(StatusCodes.Status500InternalServerError,
                        "Error inserting data on the database");
            }


        }
    }
}
