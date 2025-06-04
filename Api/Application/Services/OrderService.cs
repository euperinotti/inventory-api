using Api.Domain.Dto.Request;
using Api.Domain.Repository;
using Api.Domain.UseCases.Order;

namespace Api.Application.Services;

public class OrderService
{
    private readonly IOrderRepository _repository;
    private readonly ISupplierRepository _supplierRepository;

    public OrderService(IOrderRepository repository, ISupplierRepository supplierRepository)
    {
        _repository = repository;
        _supplierRepository = supplierRepository;
    }

    public List<OrderDTO> FindAll()
    {
        FindOrder usecase = new FindOrder(_repository);

        return usecase.Execute();
    }

    public OrderDTO FindById(long id)
    {
        FindOrder usecase = new FindOrder(_repository);

        return usecase.Execute(id);
    }

    public OrderDTO Create(OrderDTO dto)
    {
        CreateOrder usecase = new CreateOrder(_repository, _supplierRepository);

        return usecase.Execute(dto);
    }

    public OrderDTO Update(OrderDTO dto)
    {
        UpdateOrder usecase = new UpdateOrder(_repository);

        return usecase.Execute(dto);
    }

    public void Delete(long id)
    {
        DeleteOrder usecase = new DeleteOrder(_repository);

        return usecase.Execute(id);
    }
}
