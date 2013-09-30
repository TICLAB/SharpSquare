using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace FourSquare.SharpSquare.Entities
{
    public class Contact : FourSquareEntity
    {
        public string phone
        {
            get;
            set;
        }

        public string formattedPhone
        {
            get;
            set;
        }

        public string email
        {
            get;
            set;
        }

        public string twitter
        {
            get;
            set;
        }

        public string facebook
        {
            get;
            set;
        }

        public string twitterSource
        {
            get;
            set;
        }

        public string fbid
        {
            get;
            set;
        }

        public string name
        {
            get;
            set;
        }
    }
}