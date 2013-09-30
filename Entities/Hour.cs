using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace FourSquare.SharpSquare.Entities
{
    public class Hour : FourSquareEntity
    {
        public string status
        {
            get;
            set;
        }

        public bool isOpen
        {
            get;
            set;
        }

        public List<TimeFrame> timeframes
        {
            get;
            set;
        }

        public List<Segment> segments
        {
            get;
            set;
        }
    }
}