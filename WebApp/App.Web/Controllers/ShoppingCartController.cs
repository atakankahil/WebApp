using App.Web.Data;
using App.Web.Models.Domain.DTO;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Data;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;

namespace App.Web.Controllers
{
    public class ShoppingCartController : Controller
    {
        private readonly ApplicationDbContext _context;

        public ShoppingCartController(ApplicationDbContext context)
        {
            _context = context;
        }
        public async Task<IActionResult> Index()
        {
            string userId = User.FindFirstValue(ClaimTypes.NameIdentifier);

            var loggedInUser = await _context.Users.Where(x => x.Id == userId)
                .Include("UserCart")
                .Include("UserCart.ProductInShoppingCarts")
                 .Include("UserCart.ProductInShoppingCarts.Product")
                .FirstOrDefaultAsync();

            var userShoppingCart = loggedInUser.UserCart;
            var AllProducts = userShoppingCart.ProductInShoppingCarts.ToList();
            var allProductsPrice = AllProducts.Select(x => new
            {
                ProductPrice = x.Product.Price,
                Quantity = x.Quantity
            }).ToList();

            var totalPrice = 0.0;

            foreach (var product in allProductsPrice)
            {
               
                totalPrice += product.Quantity * product.ProductPrice;
                if(product.Quantity > 1)
                {
                    totalPrice = totalPrice - ((totalPrice / product.Quantity) * 0.05);
                }
            }

            ShoppingCartDto scDto = new ShoppingCartDto
            {
                Products = AllProducts,
                TotalPrice = totalPrice
            };
            return View(scDto);
        }

        public async Task<IActionResult> DeleteFromShoppingCart(Guid id)
        {

            string userId = User.FindFirstValue(ClaimTypes.NameIdentifier);

            if (!string.IsNullOrEmpty(userId) && id != null)
            {
                var loggedInUser = await _context.Users.Where(x => x.Id == userId)
                .Include("UserCart")
                .Include("UserCart.ProductInShoppingCarts")
                .Include("UserCart.ProductInShoppingCarts.Product")
                .FirstOrDefaultAsync();

                var userShoppingCart = loggedInUser.UserCart;
                var itemToDelete = userShoppingCart.ProductInShoppingCarts.Where(x => x.ProductId.Equals(id)).FirstOrDefault();

                userShoppingCart.ProductInShoppingCarts.Remove(itemToDelete);
                _context.Update(userShoppingCart);
                await _context.SaveChangesAsync();
            }
            return RedirectToAction("Index", "ShoppingCart");
        }

    }
}
