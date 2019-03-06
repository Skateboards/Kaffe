using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace KSV5.Models.Requests.Consumer
{
    public class ConsumerAddRequest
    {
        public string FirstName { get; set; }

        public string LastName { get; set; }

        [Required]
        public string UserName { get; set; }

        [Required]
        public string Email { get; set; }

        public string City { get; set; }

        public string State { get; set; }

        [Required]
        public bool ShopOwner { get; set; }

        public string Headline { get; set; }
    }
}