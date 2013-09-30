using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace FourSquare.SharpSquare.Entities
{
    public class Stat : FourSquareEntity
    {
        /// <summary>
        /// Total checkins ever here.
        /// </summary>
        public Int64 checkinsCount
        {
            get;
            set;
        }

        /// <summary>
        /// Total users who have ever checked in here.
        /// </summary>
        public Int64 usersCount
        {
            get;
            set;
        }

        /// <summary>
        /// Number of tips here.
        /// </summary>
        public Int64
            tipCount
        {
            get;
            set;
        }
	}
}