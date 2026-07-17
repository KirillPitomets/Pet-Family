using CSharpFunctionalExtensions;

namespace PetFamily.Domain.Volunteer.ValueObjects;

public class SocialNetWorkList : ValueObject
{
  private readonly List<SocialNetWork> _socialNetWorks = [];
  public IReadOnlyList<SocialNetWork> Items => _socialNetWorks;

  private SocialNetWorkList(IEnumerable<SocialNetWork> networks) =>
    _socialNetWorks = networks.ToList();

  public static Result<SocialNetWorkList> Create(IEnumerable<SocialNetWork> networks) =>
    Result.Success<SocialNetWorkList>(new SocialNetWorkList(networks));


  protected override IEnumerable<object> GetEqualityComponents()
  {
    foreach (var item in _socialNetWorks) yield return item;
  }
}