using MistrzowieWynajmu.Model.Database;
using MistrzowieWynajmu.Model.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MistrzowieWynajmu.Model.Repositories
{
    public class AddressRepository : IAddressRepository
    {
        private readonly DatabaseContext _databaseContext;

        public AddressRepository(DatabaseContext databaseContext)
        {
            _databaseContext = databaseContext;
        }

        public int AddAddress(Address address)
        {
            if (address == null)
            {
                throw new Exception("Address object cannot be null.");
            }

            _databaseContext.Addresses.Add(address);
            _databaseContext.SaveChanges();

            return address.Id;
        }

        public Address GetAddress(int addressId)
        {
            if (addressId <= 0)
            {
                throw new Exception("Id cannot be less than 0.");
            }
            return _databaseContext.Addresses.FirstOrDefault(x => x.Id == addressId);
        }

        public List<Address> GetAllAddresses()
        {
            return _databaseContext.Addresses.ToList();
        }
    }
}
