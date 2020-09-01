using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Test.Models
{
    public partial class Product
    {
        [Key]
        public int ArticleNo { get; set; }
        public string ArticleName { get; set; }
        public string Description { get; set; }
        public decimal? Price { get; set; }
        public int? CategoryId { get; set; }

        public Category Category { get; set; }
    }
}
