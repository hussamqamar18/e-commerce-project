using e_commerce_project.Models;
namespace e_commerce_project.Services
{
    public class ItemService : IItemService
    {
       private readonly List<Items> _items = new List<Items>();
        private int _nextId = 1;
        public List<Items> GetAll()
        {
            return _items;
        }
        public Items GetById(int id)
        {
            return _items.FirstOrDefault(i => i.Id == id); // LINQ Method
        }
        public Items Add(Items newitem)
        {
          newitem.Id = _nextId;
            _nextId++;
                _items.Add(newitem);
                return newitem;
        }
        public bool Update(int id, Items updateitem)
        {
            var existingItem = _items.FirstOrDefault(i => i.Id == id);
            if (existingItem == null) { return false; }
            existingItem.Name = updateitem.Name;
            existingItem.Price = updateitem.Price;
            existingItem.Stock = updateitem.Stock;
            existingItem.SupplierId = updateitem.SupplierId;
          
            return true;
        }
        public bool Delete(int id)
        {
            var existingItem = _items.FirstOrDefault(i => i.Id == id);
            if (existingItem == null) { return false; }

            _items.Remove(existingItem);
            return true;
        }




    }
}
