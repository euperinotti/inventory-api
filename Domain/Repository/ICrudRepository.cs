namespace inventory_api.Domain.Repository;
public interface ICrudRepository<T, K>
{
  IEnumerable<T> FindAll();
  T? FindById(K id);
  T Create(T supplier);
  T? Update(T supplier);
  void Delete(T supplier);
  void Delete(K? id);
}