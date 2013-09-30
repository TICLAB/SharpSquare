using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace FourSquare.SharpSquare.Entities
{
    public class Score : FourSquareEntity
    {
        public string recent
        {
            get;
            set;
        }

        public string max
        {
            get;
            set;
        }

        public string goal
        {
            get;
            set;
        }

        public string checkinsCount
        {
            get;
            set;
        }
	}
}