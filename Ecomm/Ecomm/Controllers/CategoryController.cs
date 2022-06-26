using Azure.Storage.Blobs;
using Ecomm.Data;
using Ecomm.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace Ecomm.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CategoryController : ControllerBase
    {
        private ApplicationDbContext _context;

        public CategoryController(ApplicationDbContext context)
        {
            _context = context;
        }
        // GET: api/<CategoryController>
        [HttpGet]
        public async Task<IActionResult> Get()
        {
            return Ok(await _context.Categories.ToListAsync());
        }

        // GET api/<CategoryController>/5
        [HttpGet("{id}")]
        public async Task<IActionResult> Get(int id)
        {
            return Ok(await _context.Categories.FirstOrDefaultAsync(x => x.Id == id));
        }

        //How to setup routing example
        // api/category/test/5
        [HttpGet("[action]/{id}")]
        public async Task<IActionResult> Test(int id)
        {
            return Ok(await _context.Categories.FirstOrDefaultAsync(x => x.Id == id));
        }

        // POST api/<CategoryController>
        //[HttpPost]
        //public async Task<IActionResult> Post([FromBody]Category category)
        //{
        //    await _context.Categories.AddAsync(category);
        //    await _context.SaveChangesAsync();
        //    return StatusCode(StatusCodes.Status201Created);
        //}


        [HttpPost]
        public async Task<IActionResult> Post([FromForm] Category category)
        {
            string connectionString = @"connectionString";
            string containerName = "containerName";
            BlobContainerClient containerClient = new BlobContainerClient(connectionString, containerName);
            BlobClient blobClient = containerClient.GetBlobClient(category.CategoryImage.FileName);
            MemoryStream ms = new MemoryStream();
            await category.CategoryImage.CopyToAsync(ms);
            ms.Position = 0;
            await blobClient.UploadAsync(ms);
            category.CategoryImagePath = blobClient.Uri.AbsoluteUri;

            await _context.Categories.AddAsync(category);
            await _context.SaveChangesAsync();
            return StatusCode(StatusCodes.Status201Created);
        }

        // PUT api/<CategoryController>/5
        [HttpPut("{id}")]
        public async Task<IActionResult> Put(int id, [FromBody] Category category)
        {
            var categoryfromDb = await _context.Categories.FindAsync(id);
            if (categoryfromDb == null)
            {
                return NotFound();
            }
            categoryfromDb.Title = category.Title;
            categoryfromDb.DisplayOrder = category.DisplayOrder;
            _context.Categories.Update(categoryfromDb);
            await _context.SaveChangesAsync();
            return Ok("Category Updated");
        }

        // DELETE api/<CategoryController>/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            var categoryfromDb = await _context.Categories.FindAsync(id);
            if(categoryfromDb == null)
            {
                return NotFound();
            }
            _context.Categories.Remove(categoryfromDb);
            await _context.SaveChangesAsync();
            return Ok("Category Deleted");
        }
    }
}
