using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace KSV5.Models.Requests.Shops
{
    public class ShopAddRequest
    {
        [Required]
        public string Name { get; set; }

        [Required]
        public string AddressLineOne { get; set; }

        public string AddressLineTwo { get; set; }

        [Required]
        public string City { get; set; }

        [Required]
        public string State { get; set; }

        [Required]
        public string PostalCode { get; set; }

        public string PhotoURL { get; set; }

        public string Website { get; set; }

        public string InstagramHandle { get; set; }

        [Required]
        public string Description { get; set; }

        public string TimeOpen { get; set; }

        public string TimeClose { get; set; }

        public double Lat { get; set; }

        public double Lng { get; set; }

        public int UserId { get; set; }
    }
}