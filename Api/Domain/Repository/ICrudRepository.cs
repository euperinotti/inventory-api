namespace InventoryApi.Domain.Repository;
public interface ICrudRepository<TEntity, TKey>
{
  IEnumerable<TEntity> FindAll();
  TEntity? FindById(TKey id);
  TEntity Create(TEntity supplier);
  TEntity Update(TEntity supplier);
  void Delete(TEntity supplier);
  void Delete(TKey? id);
}
