using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pets.Core
{
    public interface IPetServices
    {
        List<Pet> GetPets();
        Pet AddPet(Pet pet);

        Pet GetPet(string id);

        void DeletePet(string id);
        Pet UpdatePet(Pet pet);
    }
}
