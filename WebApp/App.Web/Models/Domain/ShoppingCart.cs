using App.Web.Models.Identity;
using System;
using System.Collections;
using System.Collections.Generic;

namespace App.Web.Models.Domain
{
    public class ShoppingCart
    {
        public Guid Id { get; set; }
        public string OwnerId { get; set; }
        public WebAppUser Owner { get; set; }  
        public virtual ICollection<ProductInShoppingCart> ProductInShoppingCarts { get; set; }  
    }
}
