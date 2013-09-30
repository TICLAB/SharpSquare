using FourSquare.SharpSquare.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace FourSquare.SharpSquare.Entities
{
    public class Image : FourSquareEntity
    {
        public string prefix
        {
            get;
            set;
        }

        public List<string> sizes
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