using EOrderProject.Data.Base;
using EOrderProject.Models;
using System.Linq.Expressions;

namespace EOrderProject.Data.Services
{
    public class MenusService : EntityBaseRepository<Menu>, IMenusService
    {
        //private readonly ApplicationDbContext _context;

        public MenusService(ApplicationDbContext context):base(context) { }
        //public void Add(Menu menu)
        //{
        //    throw new NotImplementedException();
        //}

        //public Task AddAsync(Menu entity)
        //{
        //    throw new NotImplementedException();
        //}

        //public void Delete(int Id)
        //{
        //    throw new NotImplementedException();
        //}

        //public Task DeleteAsync(int id)
        //{
        //    throw new NotImplementedException();
        //}

        //public async Task<IEnumerable<Menu>> GetAll()
        //{
        //    throw new NotImplementedException();
        //}

        //public Task<IEnumerable<Menu>> GetAllAsync()
        //{
        //    throw new NotImplementedException();
        //}
       

        //public Task<IEnumerable<Menu>> GetAllAsync(params Expression<Func<Menu, object>>[] includeProperties)
        //{
        //    throw new NotImplementedException();
        //}

        //public Menu GetById(int id)
        //{
        //    throw new NotImplementedException();
        //}

        //public Task<Menu> GetByIdAsync(int id)
        //{
        //    throw new NotImplementedException();
        //}

        //public Task<Menu> GetByIdAsync(int id, params Expression<Func<Menu, object>>[] includeProperties)
        //{
        //    throw new NotImplementedException();
        //}

        //public Menu Update(int Id)
        //{
        //    throw new NotImplementedException();
        //}

        //public Task UpdateAsync(int id, Menu entity)
        //{
        //    throw new NotImplementedException();
        //}
    }
}
