
using EOrderProject.Data.Base;
using EOrderProject.Models;
using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;

namespace EOrderProject.Data.Services
{
    public class StaffsService : EntityBaseRepository<Staff>, IStaffsService
    {

        public StaffsService(ApplicationDbContext context) : base(context) { }

        //    public Task AddAsync(Models.Staff entity)
        //    {
        //        throw new NotImplementedException();
        //    }

        //    public Task<IEnumerable<Models.Staff>> GetAllAsync(params Expression<Func<Models.Staff, object>>[] includeProperties)
        //    {
        //        throw new NotImplementedException();
        //    }

        //    public Task<Models.Staff> GetByIdAsync(int id, params Expression<Func<Models.Staff, object>>[] includeProperties)
        //    {
        //        throw new NotImplementedException();
        //    }

        //    public Task UpdateAsync(int id, Models.Staff entity)
        //    {
        //        throw new NotImplementedException();
        //    }

        //    Task<IEnumerable<Models.Staff>> IEntityBaseRepository<Models.Staff>.GetAllAsync()
        //    {
        //        throw new NotImplementedException();
        //    }

        //    Task<Models.Staff> IEntityBaseRepository<Models.Staff>.GetByIdAsync(int id)
        //    {
        //        throw new NotImplementedException();
        //    }

        //}
    }
}