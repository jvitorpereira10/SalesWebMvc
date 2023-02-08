using SalesWebMvc.Data;
using SalesWebMvc.Models;
using System.Collections.Generic;
using System.Linq;

namespace SalesWebMvc.Services
{
  public class DepartmentService
  {
    private readonly SalesWebMvcContext _context;

    public DepartmentService(SalesWebMvcContext context)
    {
      _context = context;
    }

    public List<Department> FindAll()
    {
      // Returns list of departments ordened by name.
      return _context.Department.OrderBy(d => d.Name).ToList();
    }
  }
}
