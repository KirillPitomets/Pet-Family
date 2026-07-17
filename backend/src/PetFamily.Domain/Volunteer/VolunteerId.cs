using CSharpFunctionalExtensions;

namespace PetFamily.Domain.Volunteer;

public class VolunteerId : ComparableValueObject
{
  public Guid Value { get; }
  private VolunteerId(Guid value) => Value = value;
  public static VolunteerId NewId() => new(Guid.NewGuid());
  public static VolunteerId Create(Guid id) => new(id);

  protected override IEnumerable<IComparable> GetComparableEqualityComponents()
  {
    yield return Value;
  }
}