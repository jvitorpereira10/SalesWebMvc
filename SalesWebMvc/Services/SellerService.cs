using SalesWebMvc.Data;
using SalesWebMvc.Models;
using System.Collections.Generic;
using System.Linq;
using Microsoft.EntityFrameworkCore;
using SalesWebMvc.Services.Exceptions;

namespace SalesWebMvc.Services
{
  public class SellerService
  {
    private readonly SalesWebMvcContext _context;

    public SellerService(SalesWebMvcContext context)
    {
      _context = context;
    }

    public List<Seller> FindAll()
    {
      return _context.Seller.ToList();
    }

    public void Insert(Seller obj)
    {
      _context.Add(obj);
      _context.SaveChanges();
    }

    public Seller FindById(int id)
    {
      // Using eager loading "Include" to return all objets relateds with main object.
      // In this case, will return Department of respective Seller.
      return _context.Seller.Include(obj => obj.Department).FirstOrDefault(obj => obj.Id == id);
    }

    public void Remove(int id)
    {
      var obj = _context.Seller.Find(id);
      _context.Seller.Remove(obj);
      _context.SaveChanges();
    }

    public void Update(Seller seller)
    {
      if (!_context.Seller.Any(obj => obj.Id == seller.Id))
      {
        throw new NotFoundException("Id not found.");
      }
      try
      {
        _context.Update(seller);
        _context.SaveChanges();
      }
      catch (DbUpdateConcurrencyException e)
      {
        throw new DbConcurrencyException(e.Message);
      }

    }
  }
}