using DemoCrudOperations.Data;
using DemoCrudOperations.Model;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;

namespace DemoCrudOperations.Pages
{
    public class EditModel : PageModel
    {

        private readonly CustomerDbContext _customerDbContext;
        public EditModel(CustomerDbContext customerDbContext)
        {
            _customerDbContext = customerDbContext;
        }
        [BindProperty]
        public Customer Customer { get; set; }
        public void OnGet(int id)
        {
            if (id != null)
            {
                var result = _customerDbContext.CustomerTB.Find(id);
                Customer = result;
            }
        }
        public ActionResult OnPost()
        {
            var customer = Customer;
            if (!ModelState.IsValid)
            {
                return Page();
            }
            _customerDbContext.Update(customer);
           //_customerDbContext.Entry(customer).Property(x => x.Name).IsModified = true;
           //_customerDbContext.Entry(customer).Property(x => x.Phoneno).IsModified = true;
           //_customerDbContext.Entry(customer).Property(x => x.Address).IsModified = true;
           //_customerDbContext.Entry(customer).Property(x => x.City).IsModified = true;
           //_customerDbContext.Entry(customer).Property(x => x.Country).IsModified = true;
           _customerDbContext.SaveChanges();
            return RedirectToPage("GetCustomers");
        }
    }
}
