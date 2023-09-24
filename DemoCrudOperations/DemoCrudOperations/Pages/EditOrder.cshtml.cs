using DemoCrudOperations.Data;
using DemoCrudOperations.Model;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace DemoCrudOperations.Pages
{
    public class EditOrderModel : PageModel
    {

        private readonly CustomerDbContext _customerDbContext;
        public EditOrderModel(CustomerDbContext customerDbContext)
        {
            _customerDbContext = customerDbContext;
        }
        [BindProperty]
        public Orders Order { get; set; }
        public void OnGet(int id)
        {
            if (id != null)
            {
                //var data = (from customer in _customerDbContext.CustomerTB
                //            where customer.CustomerID == id
                //            select customer).SingleOrDefault();

                //Customer = data;
                var result = _customerDbContext.Orders.Find(id);
                Order = result;
            }
        }
        public ActionResult OnPost()
        {
            var order = Order;
            if (!ModelState.IsValid)
            {
                return Page();
            }
            _customerDbContext.Update(order);
           // _customerDbContext.Entry(order).Property(x => x.Name).IsModified = true;
            //_customerDbContext.Entry(order).Property(x => x.Price).IsModified = true;
           // _customerDbContext.Entry(order).Property(x => x.Address).IsModified = true;
            
            _customerDbContext.SaveChanges();
            return RedirectToPage("GetOrders", new {id=Order.CustomerId});
        }
    }
}
 
