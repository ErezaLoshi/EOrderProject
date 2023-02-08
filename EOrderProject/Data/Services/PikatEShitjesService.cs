using EOrderProject.Data.Base;
using EOrderProject.Models;

namespace EOrderProject.Data.Services
{
    public class PikatEShitjesService : EntityBaseRepository<PikatEShitjes>, IPikatEShitjesService
        {

            public PikatEShitjesService(ApplicationDbContext context) : base(context)
            {

            }

        }
    }

