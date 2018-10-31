using MistrzowieWynajmu.Model.Database;
using MistrzowieWynajmu.Model.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MistrzowieWynajmu.Model.Repositories
{
    public class OwnerRepository : IOwnerRepository
    {
        private readonly DatabaseContext _databaseContext;

        public OwnerRepository(DatabaseContext databaseContext)
        {
            _databaseContext = databaseContext;
        }

        public int AddOwner(Owner owner)
        {
            if (owner == null)
            {
                throw new Exception("Owner object cannot be null.");
            }

            _databaseContext.Owners.Add(owner);
            _databaseContext.SaveChanges();

            return owner.Id;
        }

        public List<Owner> GetAllOwners()
        {
            return _databaseContext.Owners.ToList();
        }

        public Owner GetOwner(int ownerId)
        {
            if (ownerId <= 0)
            {
                throw new Exception("Id cannot be less than 0.");
            }
            return _databaseContext.Owners.FirstOrDefault(x => x.Id == ownerId);
        }
    }
}
