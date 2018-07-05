using System;
using System.Collections.Generic;
using System.Text;
using CollectDataApp.Interfaces;

namespace CollectDataApp.Entities
{
    class Address : IEndpoint
    {
        public int Id { get; set; }
        public int UserId { get; set; }
        public string Country { get; set; }
        public string City { get; set; }
        public string Street { get; set; }
        public string Zip { get; set; }
    }
}
