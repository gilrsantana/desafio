using Livraria.Domain.Entities;
using Livraria.Service.Interfaces;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace Livraria.Web.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthorController : ControllerBase
    {
        private readonly IAuthorService _authorService;
        public AuthorController(IAuthorService authorService)
        {
            _authorService = authorService;
        }
        // GET: api/<AuthorController>
        [HttpGet]
        public IActionResult GetAllAuthorsAsync(int skip=0, int take=25)
        {
            var authors = _authorService.GetAllAuthorsAsync(skip, take);
            return authors == null ? NotFound() : Ok(authors);
        }

        // GET api/<AuthorController>/5
        [HttpGet("{id}")]
        public string Get(int id)
        {
            return "value";
        }

        // POST api/<AuthorController>
        [HttpPost]
        public IActionResult AddAuthorAsync(Author author)
        {
            var result = _authorService.InsertAuthorAsync(author);
            return result ? Ok() : BadRequest();
        }

        // PUT api/<AuthorController>/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
        }

        // DELETE api/<AuthorController>/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
