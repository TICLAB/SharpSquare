using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace FourSquare.SharpSquare.Entities
{
    public class Menu : FourSquareEntity
    {
        /// <summary>
        /// A name for this menu.
        /// </summary>
        public string name
        {
            get;
            set;
        }

        /// <summary>
        /// A unique string identifier for this menu.
        /// </summary>
        public string menuId
        {
            get;
            set;
        }

        /// <summary>
        /// More information describing this menu.
        /// </summary>
        public string description
        {
            get;
            set;
        }

        public string type
        {
            get;
            set;
        }
        
        public string label
        {
            get;
            set;
        }

        public string anchor
        {
            get;
            set;
        }

        public string url
        {
            get;
            set;
        }

        public string mobileUrl
        {
            get;
            set;
        }
    }
}