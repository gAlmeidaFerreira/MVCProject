using WebApplicationMVC.Data;
using WebApplicationMVC.Models;

namespace WebApplicationMVC.Services
{
    public class DepartmentService
    {
        private readonly WebApplicationMVCContext _context;

        public DepartmentService(WebApplicationMVCContext context)
        {
            _context = context;
        }

        public List<Department> FindAll()
        {
            return _context.Department.OrderBy(x => x.Name).ToList();
        }

    }
}
