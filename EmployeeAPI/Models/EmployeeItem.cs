using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EmployeeAPI.Models
{
    public class EmployeeItem
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Lastn { get; set; }
        public int Age { get; set; }
        public string EntryDate { get; set; }
        public string Area { get; set; }
        public string Role { get; set; }

    }
}