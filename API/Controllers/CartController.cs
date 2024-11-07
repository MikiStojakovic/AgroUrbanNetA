using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Core.Entities;
using Core.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers
{
    public class CartController(ICartService cartService) : BaseApiController 
    {
        [HttpGet]
        public async Task<ActionResult<ShoppingCart>> GetCartById(Guid id)
        {
            var cart = await cartService.GetCartAsync(id.ToString());

            return Ok(cart ?? new ShoppingCart{Id = id});
        }

        [HttpPost]
        public async Task<ActionResult<ShoppingCart>> UpdateCart(ShoppingCart cart)
        {
            var updatedCart = await cartService.SetCartAsync(cart);

            if (updatedCart == null) return BadRequest("Problem with cart");

            return updatedCart;
        }

        [HttpDelete]
        public async Task<ActionResult> DeleteCart(Guid id)
        {
            var result = await cartService.DeleteCartAsync(id.ToString());

            if (!result) return BadRequest("Problem deleting cart");

            return Ok();
        }
    }
}