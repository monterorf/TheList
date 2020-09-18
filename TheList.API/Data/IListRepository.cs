using System.Collections.Generic;
using System.Threading.Tasks;
using TheList.API.Models;

namespace TheList.API.Data
{
    public interface IListRepository
    {
         void Add<T>(T entity) where T: class;

         void Delete(int id);
         Task<bool> SaveAll();
         Task<List<Category>> GetCategories();
         Task<Category> GetCategory(int id);
         Task<Category> EditCategory(int Id, Category category);

    }
}