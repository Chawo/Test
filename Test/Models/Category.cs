using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Test.Models
{
    public partial class Category
    {
        public Category()
        {
            Product = new HashSet<Product>();
        }

        [Key]
        public int Id { get; set; }
        public string Name { get; set; }

        public ICollection<Product> Product { get; set; }
    }
}
