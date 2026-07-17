using CSharpFunctionalExtensions;

namespace PetFamily.Domain.Species.ValueObjects;

public class BreedId : ComparableValueObject
{
  public Guid Value { get; }
  public BreedId(Guid value) => Value = value;
  private static BreedId newId() => new(Guid.NewGuid());
  protected override IEnumerable<IComparable> GetComparableEqualityComponents()
  {
    yield return Value;
  }
}


public class Breed : Entity<BreedId>
{
  public string Name { get; private set; }
  
  private Breed(BreedId id) : base(id) {}

  public Breed(BreedId id, string name) : base(id)
  {
    Name = name;
  }
}