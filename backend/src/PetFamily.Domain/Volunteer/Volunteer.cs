using CSharpFunctionalExtensions;
using PetFamily.Domain.Volunteer.Pets;
using PetFamily.Domain.Volunteer.ValueObjects;

namespace PetFamily.Domain.Volunteer;

public class Volunteer : Entity<VolunteerId>
{
  public FullName FullName { get; private set; }
  public Email Email { get; private set; }
  public string? Description { get; private set; }
  public int ExperienceYears { get; private set; }
  public PhoneNumber PhoneNumber { get; private set; }
  public SocialNetWorkList SocialNetWorkList { get; private set; }

  public IReadOnlyList<RequisiteDetails> RequisiteDetails => _requisites;
  private readonly List<RequisiteDetails> _requisites = [];

  
  public IReadOnlyList<Pet> Pets => _pets;
  private readonly List<Pet> _pets = [];
  
  private Volunteer(VolunteerId id) : base(id) {}

  private Volunteer(VolunteerId id, FullName fullName, Email email, string? description, int experienceYears,
    PhoneNumber phoneNumber ) : base(id)
  {
    FullName = fullName;
    Email = email;
    Description = description;
    ExperienceYears = experienceYears;
    PhoneNumber = phoneNumber;
    SocialNetWorkList = SocialNetWorkList.Create([]).Value;
  }
  
  public static Result<Volunteer> Create(VolunteerId id, FullName fullName, Email email, string? description, int experienceYears,
    PhoneNumber phoneNumber)
  {
    if (experienceYears < 0)
      return Result.Failure<Volunteer>("Experience years cannot be negative");

    return Result.Success<Volunteer>(new Volunteer(id, fullName, email, description, experienceYears, phoneNumber));
  }
}