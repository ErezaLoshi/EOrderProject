using EOrderProject.Data.Base;
using EOrderProject.Models;

namespace EOrderProject.Data.Services
{
    public interface IIssuesService:IEntityBaseRepository<Issues>
    {
        //Task<List<Staff>> GetStaffsByUserIdAndRoleAsync(string userId, string userRole);

    }
}
