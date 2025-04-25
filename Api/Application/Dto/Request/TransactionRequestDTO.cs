using Api.Domain.Enums;

namespace Api.Domain.Dto.Request;

public class TransactionRequestDTO
{
    public long? Id { get; set; }
    public DateTime Date { get; set; }
    public TransactionType Type { get; set; }
    public decimal Value { get; set; }
    public long ProductId { get; set; }
    public long OrderId { get; set; }
}