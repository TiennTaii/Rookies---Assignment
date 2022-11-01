using Assignment_one.Models;

namespace Assignment_one.Services
{
    public interface IPersonService
    {
        List<PersonModel> GetAll();
        PersonModel? GetOne(Guid id);
        PersonModel Create(PersonModel model);
        PersonModel? Update(Guid id, PersonModel model);
        PersonModel? Delete(Guid id);
        List<PersonModel> FilterList(string firstName, string lastName, string gender, string birthPlace);
    }
}