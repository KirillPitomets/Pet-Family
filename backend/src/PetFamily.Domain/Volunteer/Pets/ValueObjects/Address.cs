using CSharpFunctionalExtensions;

namespace PetFamily.Domain.Volunteer.Pets.ValueObjects;
public class Address : ValueObject
{
  public string City { get; }
  public string Street { get; }
  public string? House { get; }
  public string? Apartment { get; }
  public string? PostalCode { get; }

  private Address(string city, string street, string? house, string? apartment, string? postalCode)
  {
    City = city;
    Street = street;
    House = house;
    Apartment = apartment;
    PostalCode = postalCode;
  }

  public static Result<Address> Create(string city, string street, string? house, string? apartment, string? postalCode)
  {
    if (string.IsNullOrWhiteSpace(city))
      return Result.Failure<Address>("City cannot be empty");
    if (string.IsNullOrWhiteSpace(street))
      return Result.Failure<Address>("Street cannot be empty");

    return Result.Success(new Address(city, street, house, apartment, postalCode));
  }

  protected override IEnumerable<object> GetEqualityComponents()
  {
    yield return City;
    yield return Street;
    yield return House ?? string.Empty;
    yield return Apartment ?? string.Empty;
    yield return PostalCode ?? string.Empty;
  }
}