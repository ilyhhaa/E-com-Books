using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace BookShoppingCartMvcUI.Controllers
{
    [Authorize]
    public class CartController : Controller
    {
        private readonly ICartRepository _cartRepo;

        public CartController(ICartRepository cartRepo)
        {
            _cartRepo = cartRepo;
        }

        public async Task<IActionResult> AddItem(int bookId,int qty=1,int redirect=0)
        {
            var cartCount = await _cartRepo.AddItem(bookId, qty);
            if (redirect==0)
            return Ok(cartCount);

            return RedirectToAction("GetUserCart");
        }
        
        public async Task <IActionResult> RemoveItem(int bookId)
        {
           var cartCount = await _cartRepo.RemoveItem(bookId);

            return RedirectToAction("GetUserCart");
        }

        public async Task<IActionResult> GetUserCart()
        {
            var cart = _cartRepo.GetUserCart();
            return View(cart);
        }

        public async Task<IActionResult> GetTotalItemInCart()
        {
            int cartItem = await _cartRepo.GetCartItemCount();
            return Ok(cartItem);
        }

        public IActionResult Check()
        {
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> Check(CheckoutModel model)
        {
            if (!ModelState.IsValid)
                return View(model);
           bool isChecked = await _cartRepo.DoCheck(model);

            if (!isChecked)
                return RedirectToAction(nameof(OrderFailure));
            return RedirectToAction(nameof(OrderSuccess));

        }

        public IActionResult OrderSuccess()
        {
            return View();
        }

        public IActionResult OrderFailure()
        {
            return View();
        }
    }
}
