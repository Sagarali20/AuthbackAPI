using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Nybsys.EntityModels
{
    public class EmployeeT
    {
        [Key]
        public int Id { get;set ; }
        public string Name { get;set ; }
        public string LastName { get;set ; }
        public string Email { get;set ; }
        public int Age { get;set ; }
        public DateTime Doj { get;set ; }
        public string Gender { get; set; }
        public int IsMarried { get; set ; }
        public int IsActive { get; set ; }
        public int DesignationId { get; set ; }
        [NotMapped]
        public string Designation { get; set; }


    }
}
