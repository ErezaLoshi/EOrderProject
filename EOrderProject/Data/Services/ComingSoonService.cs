using EOrderProject.Data.Base;
using EOrderProject.Models;
using Microsoft.EntityFrameworkCore;
using System;
namespace EOrderProject.Data.Services
{
    public class ComingSoonService : EntityBaseRepository<ComingSoon>, IComingSoonService
    {

        public ComingSoonService(ApplicationDbContext context) : base(context)
        {

        }

    }
}
