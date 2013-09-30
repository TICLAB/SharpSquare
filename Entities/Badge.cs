using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace FourSquare.SharpSquare.Entities
{
    public class Badge : FourSquareEntity
    {
        /// <summary>
        /// A unique identifier for this badge, if locked, or this user's specific unlock of this badge, if unlocked.
        /// </summary>
        public string id
        {
            get;
            set;
        }

        /// <summary>
        /// optional A canonical ID for this badge.
        /// </summary>
        public Int64 badgeld
        {
            get;
            set;
        }

        /// <summary>
        /// The name of the badge.
        /// </summary>
        public string name
        {
            get;
            set;
        }

        /// <summary>
        /// Additional text about the badge.
        /// </summary>
        public string description
        {
            get;
            set;
        }

        /// <summary>
        /// Pieces needed to construct badge image at various sizes. Combine prefix with one of the sizes and a name, e.g. http://foursquare.com/img/badge/57/newbie.png. For locked badges, this will point to the locked badge image.
        /// </summary>
        public Image image
        {
            get;
            set;
        }

        /// <summary>
        /// optional If present, an array of unlock data. Array contains checkins, which is an array of checkins. Currently both arrays will only contain 1 element.
        /// </summary>
        public List<Checkin> unlocks
        {
            get;
            set;
        }
    }
}