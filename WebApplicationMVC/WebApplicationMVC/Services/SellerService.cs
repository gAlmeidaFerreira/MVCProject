using WebApplicationMVC.Data;
using WebApplicationMVC.Models;

namespace WebApplicationMVC.Services
{
    public class SellerService
    {
        private readonly WebApplicationMVCContext _context;

        public SellerService(WebApplicationMVCContext context)
        {
            _context = context;
        }

        public List<Seller> FindAll()
        {
            return _context.Seller.ToList();
        }
    }
}
