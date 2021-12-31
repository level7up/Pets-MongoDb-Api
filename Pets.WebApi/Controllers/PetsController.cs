using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Pets.Core;

namespace Pets.WebApi.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class PetsController : ControllerBase
    {

        private readonly IPetServices _petServices;
        public PetsController(IPetServices petServices)
        {
            _petServices = petServices;
        }
        [HttpGet]
        public IActionResult GetPets()
        {
            return Ok(_petServices.GetPets());
        }
        [HttpPost]
        public IActionResult AddPet(Pet pet)
        {
            _petServices.AddPet(pet);
            return CreatedAtRoute("GetPet", new { id = pet.Id }, pet);
        }
        [HttpGet("{id}", Name = "GetPet")]
        public IActionResult GetPet(string id)
        {
            _petServices.GetPet(id);
            return Ok(_petServices.GetPet(id));
        }
        [HttpDelete("{id}")]
        public IActionResult DeletePet(string id)
        {
            _petServices.DeletePet(id);
            return NoContent();
        }

        [HttpPut]
        public IActionResult UpdateBook(Pet pet)
        {
            return Ok(_petServices.UpdatePet(pet));
        }

    }
}
