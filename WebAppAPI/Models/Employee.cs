using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebApplicationAPI.Models
{
    public class Employee
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Title { get; set; }
        public DateTime Birthday { get; set; }

        public DateTime Hiringdate { get; set; }
        public int Deprtment_Id { get; set; }



    }
}
