using EOrderProject.Data.Base;
using EOrderProject.Models;
using Microsoft.EntityFrameworkCore;
using System;

namespace EOrderProject.Data.Services
{
    public class IssuesService:EntityBaseRepository<Issues>, IIssuesService
    {
        //private readonly ApplicationDbContext _context;
        public IssuesService(ApplicationDbContext context): base(context)
       {
        //    _context = context;
        }

        //public async Task<List<Staff>> GetStaffsByUserIdAndRoleAsync(string userId, string userRole)
        //{
        //    var issues = await _context.Issues.Include(n => n.Staffs);

        //    if (userRole != "Admin")
        //    {
        //        issues = issues.Where(n => n.UserId == userId).ToList();
        //    }
        //    return issues;
        //}
    }
}
