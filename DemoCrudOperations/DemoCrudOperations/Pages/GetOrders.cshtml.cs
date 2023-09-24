using DemoCrudOperations.Data;
using DemoCrudOperations.Model;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace DemoCrudOperations.Pages
{
    public class GetOrdersModel : PageModel
    {
        private readonly CustomerDbContext _db;
        public GetOrdersModel(CustomerDbContext db)
        {
            _db = db;
        }
        [BindProperty]
        public List<Orders> OrderList { get; set; }
        public void OnGet(int id)
        {
            OrderList = _db.Orders.Where(m => m.CustomerId == id).ToList();
           // OrderList = data;
        }
    
    public ActionResult OnGetDelete(int? id)
    {
        
        var orderData = _db.Orders.Find(id);
        if (orderData != null)
        {
            _db.Remove(orderData);
            _db.SaveChanges();
        }
        return RedirectToPage("GetOrders", new { id = orderData.CustomerId });
    }
}
}
