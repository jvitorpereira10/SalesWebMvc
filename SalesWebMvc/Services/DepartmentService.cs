using Microsoft.EntityFrameworkCore;
using SalesWebMvc.Data;
using SalesWebMvc.Models;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SalesWebMvc.Services
{
  public class DepartmentService
  {
    private readonly SalesWebMvcContext _context;

    public DepartmentService(SalesWebMvcContext context)
    {
      _context = context;
    }

    public async Task<List<Department>> FindAllAsync()
    {
      // Returns list of departments ordened by name.
      return await _context.Department.OrderBy(d => d.Name).ToListAsync();
    }
  }
}
