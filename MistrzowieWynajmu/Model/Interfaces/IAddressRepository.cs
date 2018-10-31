﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MistrzowieWynajmu.Model.Interfaces
{
    public interface IAddressRepository
    {
        List<Address> GetAllAddresses();
        Address GetAddress(int addressId);
        int AddAddress(Address address);
    }
}