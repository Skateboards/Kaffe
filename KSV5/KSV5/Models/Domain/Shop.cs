using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace KSV5.Models.Domain
{
    public class Shop
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string AddressLineOne { get; set; }
        public string AddressLineTwo { get; set; }
        public string City { get; set; }
        public string State { get; set; }
        public string PostalCode { get; set; }
        public string PhotoURL { get; set; }
        public string Website { get; set; }
        public string InstagramHandle { get; set; }
        public string Description { get; set; }
        public string TimeOpen { get; set; }
        public string TimeClose { get; set; }
        public double Lat { get; set; }
        public double Lng { get; set; }
        public int UserId { get; set; }
        public DateTime DateCreated { get; set; }
        public DateTime DateModified { get; set; }
    }
}