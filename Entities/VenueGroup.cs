using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace FourSquare.SharpSquare.Entities
{
    public class VenueGroup : FourSquareEntity
    {
        /// <summary>
        ///  A unique identifier for this venue group.
        /// </summary>
        public string id
        {
            get;
            set;
        }

        /// <summary>
        /// The name of the venue group.
        /// </summary>
        public string name
        {
            get;
            set;
        }

        public FourSquareEntityItems<Venue> venues
        {
            get;
            set;
        }
    }
}