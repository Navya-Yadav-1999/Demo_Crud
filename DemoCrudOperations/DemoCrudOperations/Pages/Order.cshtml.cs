using DemoCrudOperations.Data;
using DemoCrudOperations.Model;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace DemoCrudOperations.Pages
{
    public class OrderModel : PageModel
    {
        private readonly CustomerDbContext _db;
        public OrderModel(CustomerDbContext db)
        {
            _db = db;
        }
        [BindProperty]
        public Orders Orders { get; set; }
        public void OnGet()
        {
        }
        public ActionResult OnPost(int id)
        {
            var order = Orders;
            order.CustomerId = id;
            if (!ModelState.IsValid)
            {
                return Page();
            }
            //order.OrderId = 0;
            var result = _db.Add(order);
            _db.SaveChanges();
            return RedirectToPage("GetOrders", new { id = order.CustomerId });
        }
    }
}
