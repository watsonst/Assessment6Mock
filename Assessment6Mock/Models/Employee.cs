using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace Assessment6Mock.Models
{
    public class Employee
    {
       
        public int Id { get; set; }
        public string FirstName { get; set; }
        public int Age { get; set; }
        public decimal Salary { get; set; }
    }
}
