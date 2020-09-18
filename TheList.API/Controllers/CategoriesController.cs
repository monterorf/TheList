using System;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using TheList.API.Data;
using TheList.API.Models;

namespace TheList.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CategoriesController : ControllerBase
    {
        private readonly IListRepository _repo;
        public CategoriesController(IListRepository repo)
        {
            _repo = repo;
        }

        [HttpPost]
        public async Task<IActionResult> CreateCategory(Category category)
        {
            _repo.Add(category);
            if (await _repo.SaveAll())
            {                
                return Ok();
            }
            throw new Exception("Creating the new message failed on save");
        }

        [HttpGet]
        public async Task<IActionResult> GetCategories()
        {
            var categories = await _repo.GetCategories();
            return Ok(categories);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetCategory(int id)
        {
            var category = await _repo.GetCategory(id);
            return Ok(category);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> EditCategory(int Id, Category category)
        {
            var categoryFromRepo = await _repo.EditCategory(Id,category);

            if(await _repo.SaveAll())
                return NoContent();
            
            throw new Exception($"Updating category {Id} failed on save");            
        }
        
        [HttpDelete("{id}")]
         public async Task<IActionResult> DeleteCategory(int id)
        {
            _repo.Delete(id);
            if (await _repo.SaveAll())
            {                
                return Ok();
            }
            throw new Exception("Removing the category has failed on save changes");
        }
       

    }
}