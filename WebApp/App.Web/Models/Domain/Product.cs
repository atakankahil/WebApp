using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace App.Web.Models.Domain
{
    public class Product
    {
        public Guid Id { get; set; }
        [Required]
        public string Name { get; set; }
        public string Description { get; set; }
        public double Price { get; set; }
        public Guid CategoryId { get; set; }
        public IEnumerable<Category> Categories { get; set; }
        public virtual ICollection<ProductInShoppingCart> ProductInShoppingCarts { get; set; }
    }
}
