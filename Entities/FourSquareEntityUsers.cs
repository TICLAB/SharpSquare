using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace FourSquare.SharpSquare.Entities
{
    public class FourSquareEntityUsers : FourSquareEntity
    {
        public Int64 count
        {
            get;
            set;
        }

        public User user
        {
            get;
            set;
        }
    }
}
