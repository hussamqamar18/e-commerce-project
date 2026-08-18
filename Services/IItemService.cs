using e_commerce_project.Models;
namespace e_commerce_project.Services

{
    public interface IItemService
    {
        List<Items> GetAll();
        Items GetById(int id);
        Items Add(Items newitem);
        bool Update(int id, Items updateitem);
        bool Delete(int id);


    }
}
