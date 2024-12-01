using inventory_api.Domain.Entities;

namespace inventory_api.Domain.Repository;

public interface ISupplierRepository
{
    public IEnumerable<SupplierBO> FindAll();
    public SupplierBO? FindById(int id);
    public SupplierBO Create(SupplierBO supplier);
    public SupplierBO? Update(SupplierBO supplier);
    public void Delete(SupplierBO supplier);
    public void Delete(int? id);
}