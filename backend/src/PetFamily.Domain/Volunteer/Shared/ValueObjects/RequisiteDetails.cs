using CSharpFunctionalExtensions;

namespace PetFamily.Domain.Volunteer.ValueObjects;

public class RequisiteDetails : ValueObject
{
  public string Name { get; }
  public string Description { get; }


  private RequisiteDetails(string name, string description)
  {
    Name = name;
    Description = description;
  }

  public static Result<RequisiteDetails> Create(string name, string description)
  {
    if (string.IsNullOrWhiteSpace(name))
      return Result.Failure<RequisiteDetails>("Name cannot be empty");
    if (string.IsNullOrWhiteSpace(description))
      return Result.Failure<RequisiteDetails>("Description cannot be empty");

    return Result.Success<RequisiteDetails>(new RequisiteDetails(name, description));
  }

  protected override IEnumerable<object> GetEqualityComponents()
  {
    yield return Name;
    yield return Description;
  }
}
