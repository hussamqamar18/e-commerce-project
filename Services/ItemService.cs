using Microsoft.EntityFrameworkCore;
using e_commerce_project.Data;
using e_commerce_project.Models;

namespace e_commerce_project.Services
{
    public class ItemService : IItemService
    {
        private readonly AppDbContext _context;

        public ItemService(AppDbContext context)
        {
            _context = context;
        }

        public List<Items> GetAll()
        {
            return _context.Items.ToList();
        }

        public Items GetById(int id)
        {
            return _context.Items.FirstOrDefault(i => i.Id == id);
        }

        public Items Add(Items newItem)
        {
            _context.Items.Add(newItem);
            _context.SaveChanges();
            return newItem;
        }

        public bool Update(int id, Items updatedItem)
        {
            var existingItem = _context.Items.FirstOrDefault(i => i.Id == id);
            if (existingItem == null)
            {
                return false;
            }

            existingItem.Name = updatedItem.Name;
            existingItem.Price = updatedItem.Price;
            existingItem.Stock = updatedItem.Stock;
            existingItem.SupplierId = updatedItem.SupplierId;

            _context.SaveChanges();
            return true;
        }

        public bool Delete(int id)
        {
            var existingItem = _context.Items.FirstOrDefault(i => i.Id == id);
            if (existingItem == null)
            {
                return false;
            }

            _context.Items.Remove(existingItem);
            _context.SaveChanges();
            return true;
        }
    }
}