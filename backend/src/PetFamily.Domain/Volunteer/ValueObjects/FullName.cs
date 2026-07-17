using CSharpFunctionalExtensions;

namespace PetFamily.Domain.Volunteer.ValueObjects;

public class FullName : ValueObject
{
  public string FirstName { get; }
  public string LastName { get; }
  public string? Patronymic { get; }

  private FullName(string firstName, string lastName, string? patronymic)
  {
    FirstName = firstName;
    LastName = lastName;
    Patronymic = patronymic;
  }

  public static Result<FullName> Create(string firstName, string lastName, string? patronymic)
  {
    if ( string.IsNullOrWhiteSpace(firstName) )
      return Result.Failure<FullName>("Fist name cannot bt empty");
    if ( string.IsNullOrWhiteSpace(lastName) )
      return Result.Failure<FullName>("Last name cannot bt empty");

    return Result.Success<FullName>(new FullName(firstName, lastName, patronymic));
  }

  protected override IEnumerable<object> GetEqualityComponents()
  {
    yield return FirstName;
    yield return LastName;
    yield return Patronymic ?? string.Empty;
  }
}