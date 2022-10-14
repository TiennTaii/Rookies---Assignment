using Assignment_one.Models;

namespace Assignment_one.Services
{
    public interface IPersonService
    {
        List<PersonModel> GetAll();
        PersonModel? GetOne(int index);
        PersonModel Create(PersonModel model);
        PersonModel? Update(int index, PersonModel model);
        PersonModel? Delete(int index);
    }
}