using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace FourSquare.SharpSquare.Entities
{
    public class Dimension : FourSquareEntity
    {
        public string url
        {
            get;
            set;
        }

        public string width
        {
            get;
            set;
        }

        public string height
        {
            get;
            set;
        }
	}
}