using System.Collections.Generic;

namespace FourSquare.SharpSquare.Core
{
    public class VenueResponse<T>
    {
        public Dictionary<string, object> geocoded
        {
            get;
            set;
        }
        public List<T> venues
        {
            get;
            set;
        }
    }
}