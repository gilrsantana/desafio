using Livraria.Shared.Entities;

namespace Livraria.Domain.Entities;

public class Loan : BaseEntity
{
    public User User { get; private set; } = null!;
    public DateTime LoanDate { get; private set; }
    public DateTime? ReturnDate { get; private set; }
    public int LoanPeriod { get; private set; }
    public Fine? Fine { get; private set; }
    public ICollection<Book>? Books { get; private set; }
}
