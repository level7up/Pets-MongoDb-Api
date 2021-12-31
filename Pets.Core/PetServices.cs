using MongoDB.Driver;
using System;
using System.Collections.Generic;

namespace Pets.Core
{
    public class PetServices : IPetServices
    {
        private readonly IMongoCollection<Pet> _pets;
        public PetServices(IDbClient dbClient)
        {
           _pets = dbClient.GetPetsCollection();
        }

        public Pet AddPet(Pet pet)
        {
            _pets.InsertOne(pet);
            return pet;
        }

        public void DeletePet(string id)
        {
            _pets.DeleteOne(pet => pet.Id == id);
        }

        public Pet GetPet(string id)
        {
            return _pets.Find(pet => pet.Id == id).First();
        }

        public List<Pet> GetPets()
        {
            return _pets.Find(pet => true).ToList();
        }

        public Pet UpdatePet(Pet pet)
        {
            GetPet(pet.Id);
            _pets.ReplaceOne(p => p.Id == pet.Id, pet);
            return pet;
        }
    }
}
