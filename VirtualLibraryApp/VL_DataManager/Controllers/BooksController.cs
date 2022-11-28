using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Services_Layer;
using Services_Layer.Models;
using System.Collections;
using VL_DataAccess.Models;
using VL_DataManager.Dtos;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace VL_DataManager.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BooksController : ControllerBase
    {
        // GET: api/<BooksController>
        readonly IBookService _bookService;
        readonly IBookReviewService _bookReviewService;

        readonly IMapper _mapper;

        public BooksController(IBookService bookService, IBookReviewService bookReviewService,
            IMapper mapper)
        {
            _bookService = bookService;
            _bookReviewService = bookReviewService;
            _mapper = mapper;
        }

        // GET: api/<BookController>
        [HttpGet]
        public async Task<IActionResult> Get([FromQuery] GetAllBooksQueryFilter queryFilter,int offset = 0, int limit = 50)
        {
            var filter = _mapper.Map<GetAllBooksFilter>(queryFilter);
            var result = await _bookService.GetAll(filter,offset,limit);
            var output = _mapper.Map<IEnumerable<BookDtoResponse>>(result);
            return Ok(output);

        }

        // GET api/<BookController>/5
        [HttpGet("{bookId}")]
        public string Get(Guid bookId)
        {
            return "value";
        }
        

        // PUT api/<BookController>/5
        [HttpPut("{bookId}")]
        public void Put(int id, [FromBody] string value)
        {
        }

        // DELETE api/<BookController>/5
        [HttpDelete("{bookId}")]
        public async Task<IActionResult> Delete(Guid bookId)
        {
            try
            {
                await _bookService.Delete(bookId);
                return Ok();
            }
            catch (Exception)
            {

                return StatusCode(StatusCodes.Status500InternalServerError,
                        "Error deleting data from the database");
            }
        }

        [HttpPost("{bookId}/reviews/from/users/{userId}")]
        public async Task<IActionResult> Post(string bookId, Guid userId,[FromBody] BookReviewDtoRequest bookReviewDto)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);


            }

            try
            {
                BookReview bookReview = _mapper.Map<BookReview>(bookReviewDto);
                var result = await _bookReviewService.Insert(bookId, userId, bookReview);
                return Ok(_mapper.Map<BookReviewDtoResponse>(result));
            }
            catch (Exception)
            {

                return StatusCode(StatusCodes.Status500InternalServerError,
                        "Error inserting data on the database");
            }


        }
    }
}
