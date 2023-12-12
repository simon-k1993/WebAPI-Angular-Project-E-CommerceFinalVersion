﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TheShop.DTOs
{
    public class OrderDto
    {
        public string BasketId { get; set; }
        public int DeliveryMethodId { get; set; }
        public AddressDto ShipToAddress { get; set; }
    }
}
