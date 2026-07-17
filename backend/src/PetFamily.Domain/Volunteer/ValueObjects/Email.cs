using System.Text.RegularExpressions;
using CSharpFunctionalExtensions;

namespace PetFamily.Domain.Volunteer.ValueObjects;

public class Email : ValueObject
{
  private const string _pattern = @"^([\w\.\-]+)@([\w\-]+)((\.(\w){2,3})+)$";
  public string Value { get; }

  private Email(string value) => Value = value;

  public static Result<Email> Create(string value)
  {
    if ( string.IsNullOrWhiteSpace(value))
      return Result.Failure<Email>("Email cannot be empty");
    if (!Regex.IsMatch(value, _pattern))
      return Result.Failure<Email>("Invalid email format");

    return Result.Success<Email>(new Email(value));
  }

  protected override IEnumerable<object> GetEqualityComponents()
  {

    yield return Value;
  }
}