using CSharpFunctionalExtensions;
using PetFamily.Domain.Species;
using PetFamily.Domain.Species.ValueObjects;
using PetFamily.Domain.Volunteer.Pets.ValueObjects;
using PetFamily.Domain.Volunteer.ValueObjects;

namespace PetFamily.Domain.Volunteer.Pets;

public class Pet : Entity<PetId>
{
  public string Name { get; private set; }
  public string Description { get; private set; }
  public string Color { get; private set; }
  public double Weight { get; private set; }
  public double Height { get; private set; }
  public string HealthInfo { get; private set; }
  public DateOnly Birthday { get; private set; }
  public bool IsVaccinated { get; private set; }
  public bool IsCastrated { get; private set; }
  public PhoneNumber OwnerPhoneNumber { get; private set; }
  public Address Address { get; private set; }
  
  public BreedId BreedId { get; private set; }
  public SpeciesId SpeciesId { get; private set; }
  
  public HelpStatus HelpStatus { get; private set; }
  public IReadOnlyList<RequisiteDetails> Requisites => _requisites;
  private readonly List<RequisiteDetails> _requisites = [];
  
  private Pet(
    PetId id,
    string name,
    string description,
    string color,
    double weight,
    double height,
    string healthInfo,
    DateOnly birthday,
    bool isVaccinated,
    bool isCastrated,
    PhoneNumber ownerPhoneNumber,
    Address address,
    BreedId breedId,
    SpeciesId speciesId,
    HelpStatus helpStatus) : base(id)
  {
    Name = name;
    Description = description;
    Color = color;
    Weight = weight;
    Height = height;
    HealthInfo = healthInfo;
    Birthday = birthday;
    IsVaccinated = isVaccinated;
    IsCastrated = isCastrated;
    OwnerPhoneNumber = ownerPhoneNumber;
    Address = address;
    BreedId = breedId;
    SpeciesId = speciesId;
    HelpStatus = helpStatus;
  }

  public static Result<Pet> Create(
    PetId id,
    string name,
    string description,
    string color,
    double weight,
    double height,
    string healthInfo,
    DateOnly birthday,
    bool isVaccinated,
    bool isCastrated,
    PhoneNumber ownerPhoneNumber,
    Address address,
    BreedId breedId,
    SpeciesId speciesId,
    HelpStatus helpStatus)
  {
    if (string.IsNullOrWhiteSpace(name))
      return Result.Failure<Pet>("Name cannot be empty");

    if (weight <= 0)
      return Result.Failure<Pet>("Weight must be positive");

    if (height <= 0)
      return Result.Failure<Pet>("Height must be positive");

    return Result.Success(new Pet(id, name, description, color, weight, height, healthInfo,
      birthday, isVaccinated, isCastrated, ownerPhoneNumber, address, breedId, speciesId, helpStatus));
  }
}