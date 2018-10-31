using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MistrzowieWynajmu.Model.Interfaces
{
    public interface IPropertyRepository
    {
        List<Property> GetAllProperties();
        Property GetProperty(int propertyId);
        int AddProperty(Property property, Address address, Owner onwer);
        int EditProperty(Property property);
        void DeleteProperty(Property property, Address address, Owner onwer);
    }
}
