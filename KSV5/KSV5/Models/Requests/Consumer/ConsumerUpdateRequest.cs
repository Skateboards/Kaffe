using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace KSV5.Models.Requests.Consumer
{
    public class ConsumerUpdateRequest : ConsumerAddRequest
    {
        [Required]
        public int Id { get; set; }
    }
}