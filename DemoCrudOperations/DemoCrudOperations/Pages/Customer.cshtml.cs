using DemoCrudOperations.Data;
using DemoCrudOperations.Model;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace DemoCrudOperations.Pages
{
    [Authorize]
    public class CustomerModel : PageModel
    {
        // public string WelcomeMessage { get; set; }
       CustomerDbContext _customerDbContext;
        public CustomerModel(CustomerDbContext customerDbContext)
        {
            _customerDbContext = customerDbContext;
        }
        [BindProperty]
       public Customer Customer { get; set; }

        public ActionResult OnPost()
        {
            var customer = Customer;
            if(!ModelState.IsValid)
            {
                return Page();
            }
            customer.CustomerID = 0;
            var result = _customerDbContext.Add(customer);
            _customerDbContext.SaveChanges();
            return RedirectToPage("GetCustomers");
        }
    }
}
