using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace FourSquare.SharpSquare.Entities
{
    public class Todo : FourSquareEntity
    {
        public string id
        {
            get;
            set;
        }

        public string createdAt
        {
            get;
            set;
        }

        public string tip
        {
            get;
            set;
        }
    }
}