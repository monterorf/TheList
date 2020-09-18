using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using TheList.API.Models;

namespace TheList.API.Data
{
    public class ListRepository : IListRepository
    {
        private readonly DataContext _context;
        public ListRepository(DataContext context)
        {
            _context = context;

        }

        public void Add<T>(T entity) where T : class
        {
            _context.Add(entity);
        }

        public void Delete(int id)
        {
            var catFromRepo = _context.Categories.FirstOrDefault(x => x.Id == id);
            _context.Remove(catFromRepo);
        }

        public async Task<Category> EditCategory(int Id, Category category)
        {
            var catFromRepo = _context.Categories.FirstOrDefault(x => x.Id == Id);
            if (catFromRepo != null)
                catFromRepo.Name = category.Name;
                
            return await Task.FromResult(catFromRepo);    
        }

        public async Task<List<Category>> GetCategories()
        {
            return await _context.Categories.ToListAsync();
        }

        public async Task<Category> GetCategory(int id)
        {
            return await _context.Categories.FirstOrDefaultAsync(x => x.Id == id);
        }

        public async Task<bool> SaveAll()
        {
            return await _context.SaveChangesAsync() > 0;
        }

    }
}