using System.Text.RegularExpressions;
using CSharpFunctionalExtensions;

namespace PetFamily.Domain.Volunteer.ValueObjects;

public class PhoneNumber : ValueObject
{
  private const string _pattern =  @"^\+?[1-9]\d{7,14}$";
  public string Number { get; }

  private PhoneNumber(string number) => Number = number;

  public static Result<PhoneNumber> Create(string number)
  {
    if (!Regex.IsMatch(number, _pattern))
      return Result.Failure<PhoneNumber>("Invalid phone number format");

    return Result.Success<PhoneNumber>(new PhoneNumber(number));
  }

  protected override IEnumerable<object> GetEqualityComponents()
  {
    yield return Number;
  }
}