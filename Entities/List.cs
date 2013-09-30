using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace FourSquare.SharpSquare.Entities
{
    public class List : FourSquareEntity
    {
        /// <summary>
        /// A unique string identifier for this photo.
        /// </summary>
        public string id
        {
            get;
            set;
        }

        /// <summary>
        /// The user-entered name for this list.
        /// </summary>
        public string name
        {
            get;
            set;
        }

        /// <summary>
        /// The user-entered list description.
        /// </summary>
        public string description
        {
            get;
            set;
        }

        /// <summary>
        /// The compact user who created this list.
        /// </summary>
        public User user
        {
            get;
            set;
        }

        /// <summary>
        /// Boolean indicating whether the acting user is following this list. Absent if there is no acting user.
        /// </summary>
        public bool following
        {
            get;
            set;
        }

        /// <summary>
        /// Count and items of users who follow this list. All items may not be present.
        /// </summary>
        public FourSquareEntityItems<User> followers
        {
            get;
            set;
        }

        /// <summary>
        /// Boolean indicating whether the acting user can edit this list. Absent if there is no acting user.
        /// </summary>
        public bool editable
        {
            get;
            set;
        }

        /// <summary>
        /// Boolean indicating whether this list is editable by the owner's friends.
        /// </summary>
        public bool collaborative
        {
            get;
            set;
        }

        /// <summary>
        ///  Count and items of users who have edited this list. All items may not be present.
        /// </summary>
        public FourSquareEntityItems<User> collaborators
        {
            get;
            set;
        }

        /// <summary>
        /// The canonical URL for this list, e.g. https://foursquare.com/dens/list/a-brief-history-of-foursquare
        /// </summary>
        public string canonicalUrl
        {
            get;
            set;
        }

        /// <summary>
        /// A photo for this list.
        /// </summary>
        public Photo photo
        {
            get;
            set;
        }

        /// <summary>
        /// The number of unique venues on the list.
        /// </summary>
        public Int64 venueCount
        {
            get;
            set;
        }
        /// <summary>
        /// The number of venues on the list visited by the acting user. Absent if there is no acting user.
        /// </summary>
        public Int64 visitedCount
        {
            get;
            set;
        }

        /// <summary>
        /// Count and items of list items on this list.
        /// </summary>
        public FourSquareEntityItems<Item> listItems
        {
            get;
            set;
        }

    }
}
