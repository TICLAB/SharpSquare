using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace FourSquare.SharpSquare.Entities
{
    public class Price : FourSquareEntity
	{
        public string tier
        {
            get;
            set;
        }

        public string message
        {
            get;
            set;
        }
	}
}