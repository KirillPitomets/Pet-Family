using CSharpFunctionalExtensions;
namespace PetFamily.Domain.Volunteer.ValueObjects;

public class SocialNetWork : ValueObject
{
  public string Name { get; }
  public string Url { get; }

  private SocialNetWork(string name, string url)
  {
    Name = name;
    Url = url;
  }

  public static Result<SocialNetWork> Create(string name, string url)
  {
    if (string.IsNullOrWhiteSpace(name))
      return Result.Failure<SocialNetWork>("Name cannot be empty");
    if (string.IsNullOrWhiteSpace(url))
      return Result.Failure<SocialNetWork>("Url cannot be empty");

    return Result.Success<SocialNetWork>(new SocialNetWork(name, url));
  }

  protected override IEnumerable<object> GetEqualityComponents()
  {
    yield return Name;
    yield return Url;
  }
}