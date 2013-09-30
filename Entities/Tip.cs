using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace FourSquare.SharpSquare.Entities
{
    public class Tip : FourSquareEntity
    {
        /// <summary>
        /// A unique identifier for this tip.
        /// </summary>
        public string id
        {
            get;
            set;
        }

        /// <summary>
        /// The actual tip.
        /// </summary>
        public string text
        {
            get;
            set;
        }

        /// <summary>
        /// Seconds since epoch when their tip was created.
        /// </summary>
        public string createdAt
        {
            get;
            set;
        }

        public string canonicalUrl
        {
            get;
            set;
        }

        public string photoUrl
        {
            get;
            set;
        }

        /// <summary>
        /// optionalOne of todo or done, depending on the user's relationship to the tip. Absent if there is no relationship. 
        /// </summary>
        public string status
        {
            get;
            set;
        }

        /// <summary>
        /// optional If there is a photo for this tip and the tip is not already container inside of a photo element, details about the photo. 
        /// </summary>
        public Photo photo
        {
            get;
            set;
        }

        /// <summary>
        /// optional If the context allows tips from multiple users, the compact user that created this tip. 
        /// </summary>
        public User user
        {
            get;
            set;
        }

        /// <summary>
        /// optional If the context allows tips from multiple venues, the compact venue for this tip.
        /// </summary>
        public Venue venue
        {
            get;
            set;
        }

        /// <summary>
        /// The count of users who have marked this tip todo, and groups containing any friends who have marked it to-do. The groups included are subject to change. (Note that to-dos are only visible to friends!) 
        /// </summary>
        public FourSquareEntityItems<User> todo
        {
            get;
            set;
        }

        /// <summary>
        /// The count of users who have done this tip todo, and groups containing any friends and others who have marked it done. The groups included are subject to change. 
        /// </summary>
        public FourSquareEntityItems<Todo> done
        {
            get;
            set;
        }

        /// <summary>
        ///  The count of users who have liked this tip, and groups containing any friends and others who have liked it. The groups included are subject to change. 
        /// </summary>
        public FourSquareEntityGroups<User> likes
        {
            get;
            set;
        }
    }
}