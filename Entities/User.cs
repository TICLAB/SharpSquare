using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace FourSquare.SharpSquare.Entities
{
    public class User : FourSquareEntity
    {
        /// <summary>
        /// A unique identifier for this user.
        /// </summary>
        public string id
        {
            get;
            set;
        }

        /// <summary>
        /// A user's first name.
        /// </summary>
        public string firstName
        {
            get;
            set;
        }

        /// <summary>
        /// A user's last name.
        /// </summary>
        public string lastName
        {
            get;
            set;
        }

        /// <summary>
        /// male or female
        /// </summary>
        public string gender
        {
            get;
            set;
        }

        /// <summary>
        /// URL of a profile picture for this user.
        /// </summary>
        public Icon photo
        {
            get;
            set;
        }

        /// <summary>
        /// 	Contains count of friends for this user and groups of users who are friends. Right now will only contain a group where type is friends, but it's subject to change. Groups are omitted when viewing self The full set of friends is at users/XXX/friends. 
        /// </summary>
        public FourSquareEntityGroups<User> friends
        {
            get;
            set;
        }

        /// <summary>
        /// Contains the count of tips from this user. May contain an array of selected tips as items, which may or may not be empty. Full set of items at users/XXX/tips
        /// </summary>
        public FourSquareEntityItems<Tip> tips
        {
            get;
            set;
        }

        /// <summary>
        /// User's home city
        /// </summary>
        public string homeCity
        {
            get;
            set;
        }

        /// <summary>
        /// A short bio for the user.
        /// </summary>
        public string bio
        {
            get;
            set;
        }

        /// <summary>
        /// An object containing none, some, or all of twitter, facebook, email, and phone. Both are strings.
        /// </summary>
        public Contact contact
        {
            get;
            set;
        }

        /// <summary>
        /// Optional. Whether we receive pings from this user, if we have a relationship.
        /// </summary>
        public bool pings
        {
            get;
            set;
        }

        /// <summary>
        /// One of brand, celebrity, or user. Users can establish following relationships with celebrities.
        /// </summary>
        public string type
        {
            get;
            set;
        }

        /// <summary>
        /// Contains the count of badges for this user. May eventually contain some selected badges. Use user/XX/badges to get the list of badges. 
        /// </summary>
        public FourSquareEntityItems<Badge> badges
        {
            get;
            set;
        }

        /// <summary>
        /// optional The relationship of the acting user (me) to this user (them). One of self, friend, pendingMe (user has sent a friend request that acting user has not accepted), pendingThem (acting user has sent a friend request to the user but they have not accepted), or followingThem (acting user is following a celebrity or brand). If there is no relationship or pending request between the two users, the node is absent. If the acting user is a celebrity, does not indicate whether the user is following them.
        /// If pendingme, applications will want to the acting user to an approve/ignore action. If pendingthem, applications will want to show the acting user a "pending" message. 
        /// </summary>
        public string relationship
        {
            get;
            set;
        }

        /// <summary>
        /// Contains the count of checkins by this user. May contain the most recent checkin as an array items containing a single element, if the user is a friend. 
        /// </summary>
        public FourSquareEntityItems<Checkin> checkins
        {
            get;
            set;
        }

        /// <summary>
        /// Contains the count of mayorships for this user. If there are any mayorships, may contain an array of selected mayorships as items, which may or may not be empty. 
        /// </summary>
        public FourSquareEntityItems<Venue> mayorships
        {
            get;
            set;
        }

        /// <summary>
        /// Contains the count of todos this user has. May contain an array of selected todos as items, full set of items at users/XXX/todos, but only visible to friends. 
        /// </summary>
        public FourSquareEntityItems<Todo> todos
        {
            get;
            set;
        }

        public FourSquareEntityItems<User> following
        {
           get;
           set;
        }

        /// <summary>
        /// Contains count of followers for this user, if they are a brand or celebrity. 
        /// </summary>
        public FourSquareEntityItems<User> followers
        {
            get;
            set;
        }

        /// <summary>
        /// Contains count of pending friend requests for this user. 
        /// </summary>
        public FourSquareEntityItems<User> request
        {
            get;
            set;
        }

        public Score scores
        {
            get;
            set;
        }
    }
}