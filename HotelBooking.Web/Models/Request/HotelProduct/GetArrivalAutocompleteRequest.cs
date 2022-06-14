using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HotelBooking.Web.Models.Request.HotelProduct
{
    public class GetArrivalAutocompleteRequest
    {
        public int ProductType { get; set; }
        public string Query { get; set; }
        public string Culture { get; set; }
    }
}
