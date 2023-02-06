using EOrderProject.Data.Base;
using Microsoft.Extensions.Hosting;
using System.ComponentModel.DataAnnotations;

namespace EOrderProject.Models
{
    public class Issues:IEntityBase
    {
        [Key]
        public int Id { get; set; }

        public string IssueDescription { get; set; }

     
    }
}
