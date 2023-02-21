using Microsoft.EntityFrameworkCore;
using SalesWebMvc.Data;
using SalesWebMvc.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SalesWebMvc.Services
{
    public class SalesRecordService
    {
        private readonly SalesWebMvcContext _context;

        public SalesRecordService(SalesWebMvcContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<SalesRecord>> SearchByPeriodAsync(DateTime? initial, DateTime? final)
        {
            // Returns sales records by period.
            return await _context.SalesRecord
                .Where(x => x.Date >= initial && x.Date <= final)
                .Include(x => x.Seller)
                .Include(x => x.Seller.Department)
                .OrderByDescending(x => x.Date)
                .ToListAsync();
        }
        public async Task<IEnumerable<IGrouping<Department,SalesRecord>>> SearchByPeriodGroupingDepartmentAsync(DateTime? initial, DateTime? final)
        {
            // Returns sales records by period.
            return await _context.SalesRecord
                .Where(x => x.Date >= initial && x.Date <= final)
                .Include(x => x.Seller)
                .Include(x => x.Seller.Department)                
                .OrderByDescending(x => x.Date)
                .GroupBy(x => x.Seller.Department)
                .ToListAsync();
        }

        public async Task<IEnumerable<IGrouping<Seller, SalesRecord>>> SearchByPeriodGroupingSellerAsync(DateTime? initial, DateTime? final)
        {
            // Returns sales records by period.
            return await _context.SalesRecord
                .Where(x => x.Date >= initial && x.Date <= final)
                .Include(x => x.Seller)
                .Include(x => x.Seller.Department)
                .OrderByDescending(x => x.Date)
                .GroupBy(x => x.Seller)
                .ToListAsync();
        }
    }
}
