using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;

namespace App.Web.Models.Domain.DTO
{
    public class ShoppingCartDto
    {
        public List<ProductInShoppingCart> Products { get; set; }

        public double TotalPrice { get; set; }
    }
}
