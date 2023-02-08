using EOrderProject.Data.Base;
using EOrderProject.Models;

namespace EOrderProject.Data.Services
{
    public class IssueService : EntityBaseRepository<Issue>, IIssueService
    {
        public IssueService(ApplicationDbContext context) : base(context)
        { }

    }
}