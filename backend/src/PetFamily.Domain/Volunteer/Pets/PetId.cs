using CSharpFunctionalExtensions;

namespace PetFamily.Domain.Volunteer.Pets;

public class PetId : ComparableValueObject
{
  public Guid Value { get; }
  private PetId(Guid value) => Value = value;
  public PetId NewId() => new(Guid.NewGuid());
  public static PetId Create(Guid id) => new(id);

  protected override IEnumerable<IComparable> GetComparableEqualityComponents()
  {
    yield return Value;
  }
}