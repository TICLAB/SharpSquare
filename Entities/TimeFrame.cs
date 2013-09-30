using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace FourSquare.SharpSquare.Entities
{
    public class TimeFrame : FourSquareEntity
    {
        /// <summary>
        /// Localized list of day names
        /// </summary>
        public string days
        {
            get;
            set;
        }

        /// <summary>
        /// An array of times the venue is open on days within the timeframe.
        /// </summary>
        public bool includesToday
        {
            get;
            set;
        }

        /// <summary>
        /// An array of times the venue is open on days within the timeframe.
        /// </summary>
        public List<Open> open
        {
            get;
            set;
        }
    }
}