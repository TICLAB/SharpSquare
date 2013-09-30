using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace FourSquare.SharpSquare.Entities
{
    public class FourSquareEntityExoploreVenuesGroups<T> : FourSquareEntity where T : FourSquareEntity
    {
        public int suggestedRadius
        {
            get;
            set;
        }

        public string headerLocation
        {
            get;
            set;
        }

        public string headerFullLocation
        {
            get;
            set;
        }

        public string headerLocationGranularity
        {
            get;
            set;
        }

        public int totalResults
        {
            get;
            set;
        }

        public List<FourSquareEntityItems<T>> groups
        {
            get;
            set;
        }
    }
}