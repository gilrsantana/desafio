using Livraria.Shared.Entities;

namespace Livraria.Domain.Entities;

public class Fine : BaseEntity
{
    public decimal Amount { get; private set; }
    public DateTime PaymentDate { get; private set; }
    public bool IsPaid { get; private set; }
    public Loan? Loan { get; private set; }
}
