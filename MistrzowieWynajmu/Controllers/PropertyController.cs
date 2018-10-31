﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using MistrzowieWynajmu.Model;
using MistrzowieWynajmu.Model.Interfaces;

namespace MistrzowieWynajmu.Controllers
{
    [Produces("application/json")]
    [Route("api/Property")]
    public class PropertyController : Controller
    {
        private readonly IPropertyRepository _propertyRepository;
        private readonly IOwnerRepository _ownerRepository;
        private readonly IAddressRepository _addressRepository;

        public PropertyController(IPropertyRepository propertyRepository, IOwnerRepository ownerRepository, IAddressRepository addressRepository)
        {
            _propertyRepository = propertyRepository;
            _addressRepository = addressRepository;
            _ownerRepository = ownerRepository;
        }

        [HttpGet("[action]")]
        public IActionResult GetAllProperties()
        {
            return new JsonResult(_propertyRepository.GetAllProperties());
        }

        [HttpPost("[action]")]
        public IActionResult AddProperty([FromBody]Property property)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var owner = _ownerRepository.GetOwner(property.OwnerId);
            if(owner == null)
            {
                return NotFound("Cannot find owner with provided ownerId");
            }

            var address = _addressRepository.GetAddress(property.AddressId);
            if (address == null)
            {
                return NotFound("Cannot find address with provided addressId");
            }
            _propertyRepository.AddProperty(property, address, owner);

            return new JsonResult(property.Id);
        }

        [HttpGet("[action]")]
        public IActionResult GetProperty(int propertyId)
        {
            if(propertyId <= 0)
            {
                return BadRequest("Id cannot be less than 0.");
            }

            return new JsonResult(_propertyRepository.GetProperty(propertyId));
        }

        [HttpPost("[action]")]
        public IActionResult UpdateProperty([FromBody]Property property)
        {
            if(!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            _propertyRepository.EditProperty(property);
            return new JsonResult(property.Id);
        }

        [HttpGet("[action]")]
        public IActionResult DeleteProperty(int propertyId)
        {
            if(propertyId <= 0)
            {
                return BadRequest("Id cannot be less than 0.");
            }

            var property = _propertyRepository.GetProperty(propertyId);
            if (property == null)
            {
                return NotFound("Cannot find property with provided propertyId");
            }

            var owner = _ownerRepository.GetOwner(property.OwnerId);
            if (owner == null)
            {
                return NotFound("Cannot find owner with provided ownerId");
            }

            var address = _addressRepository.GetAddress(property.AddressId);
            if (address == null)
            {
                return NotFound("Cannot find address with provided addressId");
            }
            _propertyRepository.DeleteProperty(property, address, owner);

            return new JsonResult(property.Id);
        }
    }
}