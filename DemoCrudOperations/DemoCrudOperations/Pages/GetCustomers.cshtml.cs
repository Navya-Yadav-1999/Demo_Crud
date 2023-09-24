using DemoCrudOperations.Data;
using DemoCrudOperations.Model;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;

namespace DemoCrudOperations.Pages
{
    public class GetCustomersModel : PageModel
    {
        private readonly CustomerDbContext _db;
        public GetCustomersModel(CustomerDbContext db)
        {
            _db = db;
        }
        public List<Customer> CustomerList { get; set; }
        public string CurrentFilter { get; set; }
        public async Task OnGet(string searchString)
        {
            var data = _db.CustomerTB.ToList();
            //var orderData = _db.Orders.ToList();

            CustomerList = data;
            CurrentFilter = searchString;

            IQueryable<Customer> customers = from s in _db.CustomerTB
                                             select s; 
            if (!String.IsNullOrEmpty(searchString))
            {
                customers = customers.Where(s => s.Name.Contains(searchString)
                                       || s.Address.Contains(searchString));
            }
            CustomerList = await customers.AsNoTracking().ToListAsync();

        }
        //public async Task OnGetAsync(string searchString)
        //{
        //    CurrentFilter = searchString;

        //    IQueryable<Customer> customers = from s in _db.CustomerTB
        //                                     select s; ;
        //    if (!String.IsNullOrEmpty(searchString))
        //    {
        //        customers = customers.Where(s => s.Name.Contains(searchString)
        //                               || s.Address.Contains(searchString));
        //    }
        //    CustomerList = await customers.AsNoTracking().ToListAsync();
        //}
            public ActionResult OnGetDelete(int? id)
        {
            var ordersData = _db.Orders.Where(m => m.CustomerId == id).ToList();
            if (ordersData != null)
            {
                foreach(var item in ordersData)
                {
                    _db.Remove(item);
                    _db.SaveChanges();
                }
               
            }
            var customerData = _db.CustomerTB.Find(id);
            if (customerData != null)
            {   _db.Remove(customerData);
                _db.SaveChanges();
            }
            return RedirectToPage("GetCustomers");
        }

    }
}
