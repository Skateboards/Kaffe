using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace KSV5.Models.Domain
{
    public class Consumer
    {
        public int Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string UserName { get; set; }
        public string Email { get; set; }
        public string City { get; set; }
        public string State { get; set; }
        public bool ShopOwner { get; set; }
        public string Headline { get; set; }
        public DateTime DateCreated { get; set; }
        public DateTime DateModified { get; set; }
    }
}