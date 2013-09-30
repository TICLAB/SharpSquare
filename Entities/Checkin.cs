using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace FourSquare.SharpSquare.Entities
{
    public class Checkin : FourSquareEntity
    {
        /// <summary>
        /// A unique identifier for this checkin.
        /// </summary>
        public string id
        {
            get;
            set;
        }

        /// <summary>
        /// Seconds since epoch when this checkin was created.
        /// </summary>
        public string createdAt
        {
            get;
            set;
        }

        /// <summary>
        /// One of checkin, shout, or venueless.
        /// </summary>
        public string type
        {
            get;
            set;
        }

        public string isMayor
        {
            get;
            set;
        }

        /// <summary>
        /// optional String representation of the time zone where this check-in occurred.
        /// </summary>
        public string timeZone
        {
            get;
            set;
        }

        /// <summary>
        /// optional If the user is not clear from context, then a compact user is present.
        /// </summary>
        public User user
        {
            get;
            set;
        }

        /// <summary>
        /// optional If the venue is not clear from context, and this checkin was at a venue, then a compact venue is present.
        /// </summary>
        public Venue venue
        {
            get;
            set;
        }

        /// <summary>
        /// optionalIf the type of this checkin is shout or venueless, this field may be present and may contains a lat, lng pair and/or a name, providing unstructured information about the user's current location.
        /// </summary>
        public Location location
        {
            get;
            set;
        }

        public Category categories
        {
            get;
            set;
        }

        public string verified
        {
            get;
            set;
        }

        public Stat stats
        {
            get;
            set;
        }

        public FourSquareEntityItems<Todo> todos
        {
            get;
            set;
        }

        /// <summary>
        /// optional If present, the name and url for the application that created this checkin.
        /// </summary>
        public Source source
        {
            get;
            set;
        }

        public string distance
        {
            get;
            set;
        }

        /// <summary>
        /// count and items for photos on this checkin. All items may not be present.
        /// </summary>
        public FourSquareEntityItems<Photo> photos
        {
            get;
            set;
        }

        /// <summary>
        /// count and items for comments on this checkin. All items may not be present.
        /// </summary>
        public FourSquareEntityItems<Comment> comments
        {
            get;
            set;
        }

        /// <summary>
        /// optional Message from check-in, if present and visible to the acting user.
        /// </summary>
        public string shout
        {
            get;
            set;
        }
    }
}