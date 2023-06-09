using BookStoreWebapiWithMongoDB.Data.Model;
using BookStoreWebapiWithMongoDB.Data.ServiceInterfaces;
using Microsoft.AspNetCore.Mvc;


namespace BookStoreWebapiWithMongoDB.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BooksController : ControllerBase
    {
        private IBookService _IbookService;

        public BooksController(IBookService ibookService)
        {
            _IbookService = ibookService;
        }


        // POST api/<BooksController>
        [HttpPost]
        public ActionResult AddBooks([FromBody] BooksModel model)
        {
            bool result = _IbookService.AddBooks(model);
            if (result)
            {
                return CreatedAtAction(nameof(GetBook), new { id = model.Id }, model);
            }

            return BadRequest();
        }

        // GET: api/<BooksController>
        [HttpGet]
        public ActionResult GetBooks()
        {
            var model = _IbookService.GetBooks();
            if(model is null)
            {
                return NotFound();
            }

            return Ok(model);
        }

        // GET api/<BooksController>/5
        [HttpGet("GetBook/{id}")]
        public ActionResult GetBook(string id)
        {
            var model = _IbookService.GetBook(id);
            if (model is null)
            {
                return NotFound();
            }

            return Ok(model);

        }

       

        // PUT api/<BooksController>/5
        [HttpPut("UpdateBooks/{id}")]
        public ActionResult UpdateBooks(string id, [FromBody] BooksModel model) 
        {
            bool result = _IbookService.UpdateBooks(model);
            if (result)
            {
                return CreatedAtAction(nameof(GetBook), new { id = model.Id }, model);
            }

            return BadRequest();
        }

        // DELETE api/<BooksController>/5
        [HttpDelete("Deletebook/{id}")]
        public ActionResult Deletebook(string id) 
        {
            var model = _IbookService.GetBook(id);
            if (model is null)
            {
                return NotFound();
            }
            bool result = _IbookService.DeleteBooks(id);
            if (result)
            {
                return Ok(new { message = "Book successfully deleted" });
            }

            return BadRequest();
        }

        [HttpGet("GetNumberOfBooks")]
        public ActionResult GetNumberOfBooks() 
        {
            var model = _IbookService.GetNumberOfBooks();
            return Ok(new {message = $"The number of books is {model}"});
        }

    }
}
