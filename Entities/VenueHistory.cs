using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace FourSquare.SharpSquare.Entities
{
    public class VenueHistory : FourSquareEntity
    {
        public string beenHere
        {
            get;
            set;
        }

        public string lastHereAt
        {
            get;
            set;
        }

        public Venue venue
        {
            get;
            set;
        }
	}
}