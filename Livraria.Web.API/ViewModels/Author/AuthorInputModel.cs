using Flunt.Validations;
using Livraria.Domain.ValueObjects;
using Livraria.Shared.Messages;

namespace Livraria.Web.API.ViewModels.Author;

public class AuthorInputModel : BaseViewModel
{
    private Name _name;
    public Name Name
    {
        get => _name;
        set
        {
            _name = value;
            AddNotifications(new Contract<AuthorInputModel>()
                .Requires()
                .IsNotNull(_name, nameof(Name), Error.Author.EMPTY_NAME)
                .IsNotNullOrEmpty(_name.FirstName, nameof(Domain.ValueObjects.Name.FirstName), Error.Common.EMPTY_FIRST_NAME)
                .IsNotNullOrEmpty(_name.LastName, nameof(Domain.ValueObjects.Name.LastName), Error.Common.EMPTY_LAST_NAME)
                .IsGreaterOrEqualsThan(_name.FirstName, 3, nameof(Domain.ValueObjects.Name.FirstName)
                    , Error.Author.MIN_FIRSTNAME_LENGTH_3)
                .IsLowerOrEqualsThan(_name.FirstName, 80, nameof(Domain.ValueObjects.Name.FirstName)
                    , Error.Author.MAX_FIRSTNAME_LENGTH_80)
                .IsLowerOrEqualsThan(_name.LastName, 80, nameof(Domain.ValueObjects.Name.LastName)
                    , Error.Author.MAX_LASTNAME_LENGTH_80)
            );
        }
    }

    private DateTime _birthDate;
    public DateTime BirthDate
    {
        get => _birthDate;
        set
        {
            _birthDate = value;
            AddNotifications(new Contract<AuthorInputModel>()
                .Requires()
                .IsNotNull(_birthDate, nameof(BirthDate), Error.Author.BIRTHDATE_REQUIRED)
                .IsLowerOrEqualsThan(_birthDate, DateTime.Now, nameof(BirthDate), Error.Author.INVALID_BIRTHDATE)
            );
        }
    }

    private DateTime? _deathDate;
    public DateTime? DeathDate
    {
        get => _deathDate;
        set
        {
            _deathDate = value;

            if (_deathDate is null) return;

            AddNotifications(new Contract<AuthorInputModel>()
                .Requires()
                .IsLowerOrEqualsThan((DateTime)_deathDate, DateTime.Now, nameof(DeathDate), Error.Author.INVALID_BIRTHDATE)
                .IsGreaterThan((DateTime)_deathDate, _birthDate, nameof(DeathDate), Error.Author.INVALID_BIRTHDATE)
            );
        }
    }

    private string? _nationality;
    public string? Nationality
    {
        get => _nationality;
        set
        {
            _nationality = value;
            
            if (_nationality is null) return;

            AddNotifications(new Contract<AuthorInputModel>()
                .Requires()
                .IsLowerOrEqualsThan(_nationality.Length, 80, nameof(Nationality), Error.Author.MAX_NATIONALITY_LENGTH_80)
            );
        }
    }

    private string? _biography;
    public string? Biography
    {
        get => _biography;
        set
        {
            _biography = value;

            if (_biography is null) return;

            AddNotifications(new Contract<AuthorInputModel>()
                .Requires()
                .IsLowerOrEqualsThan(_biography.Length, 500, nameof(Biography), Error.Author.MAX_BIOGRAPHY_LENGTH_500)
            );
        }
    }
}
