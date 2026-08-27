using e_commerce_project.Models;

namespace e_commerce_project.Services
{
    public interface ISupplierService
    {
        List<Supplier> GetAll();
        Supplier GetById(int id);
        Supplier Add(Supplier newSupplier);
        bool Update(int id, Supplier updatedSupplier);
        bool Delete(int id);
    }
}
