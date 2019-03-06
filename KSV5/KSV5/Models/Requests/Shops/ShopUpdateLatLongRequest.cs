using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace KSV5.Models.Requests.Shops
{
    public class ShopUpdateLatLongRequest
    {
        public int Id { get; set; }

        public float Lat { get; set; }

        public float Lng { get; set; }
    }
}