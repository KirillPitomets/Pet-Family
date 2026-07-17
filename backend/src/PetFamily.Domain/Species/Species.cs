using CSharpFunctionalExtensions;
using PetFamily.Domain.Species.ValueObjects;

namespace PetFamily.Domain.Species;

public class SpeciesId : ComparableValueObject
{
  public Guid Value { get; }
  private SpeciesId(Guid value) => Value = value;
  public static SpeciesId NewId() => new(Guid.NewGuid());
  protected override IEnumerable<IComparable> GetComparableEqualityComponents()
  {
    yield return Value;
  }
}

public class Species : Entity<SpeciesId>
{
  public string Name { get; private set; }
  public IReadOnlyList<Breed> Breeds => _breeds;
  private readonly List<Breed> _breeds = [];
  
  public Species(SpeciesId id) : base(id) {}

  private Species(SpeciesId id, string name ) : base(id)
  {
    Name = name;
  }

  public void AddBreed(Breed breed) => _breeds.Add(breed);

}