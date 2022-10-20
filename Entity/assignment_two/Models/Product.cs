using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace assignment_two.Models
{
    public class Product
    {
        public Category? Category { get; set; }
        public int Id { get; set; }
        public string? Name { get; set; }
        public string? Manufacture { get; set; }
        public int CategoryId { get; set; }
    }
}