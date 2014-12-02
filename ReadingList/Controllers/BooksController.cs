using BookService.Models;
using ReadingList.Models;
using System.Collections;
using System.Net;
using System.Threading.Tasks;
using System.Web.Http;
using System.Web.Http.Description;

namespace ReadingList.Controllers
{
    public class BooksController : ApiController
    {
        public IBookRepository repository = new EFBookRepository();
   
        // GET: api/Books
        public IEnumerable GetBooks()
        {
            return repository.GetAll();
        }

        // GET api/Books/5
        [ResponseType(typeof(BookDetailDTO))]
        public async Task<IHttpActionResult> GetBook(int id)
        {
            var book = await repository.Get(id);
            if (book == null)
            {
                return NotFound();
            }

            return Ok(book);
        } 

        // PUT: api/Books/5
        [ResponseType(typeof(void))]
        public async Task<IHttpActionResult> PutBook(int id, Book book)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != book.Id)
            {
                return BadRequest();
            }

 
            if(await repository.Put(id, book))
            {
            return StatusCode(HttpStatusCode.NoContent);
            } else 
            {
             return BadRequest();
            }
        }

        // POST: api/Books
        [ResponseType(typeof(Book))]
        public async Task<IHttpActionResult> PostBook(Book book)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            await repository.Post(book);

            var dto = new BookDTO()
            {
                Id = book.Id,
                Title = book.Title,
                AuthorName = book.Author.Name
            };

            return CreatedAtRoute("DefaultApi", new { id = book.Id }, dto);

        }

        // DELETE: api/Books/5
        [ResponseType(typeof(Book))]
        public async Task<IHttpActionResult> DeleteBook(int id)
        {
            if (await repository.Delete(id)) 
            {
                return Ok();
            }else 
            {  
                return NotFound();
            }
        }

        //protected override void Dispose(bool disposing)
        //{
        //    if (disposing)
        //    {
        //        db.Dispose();
        //    }
        //    base.Dispose(disposing);
        //}

       
    }
}