using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace CRUD_Entity_Framework.Models
{
    public class EmpRegistration
    {
        [Key]
        public int Empid { set; get; }
        public string Empname { set; get; }
        public string Email { set; get; }
        public int Salary { set; get; }
    }
}
