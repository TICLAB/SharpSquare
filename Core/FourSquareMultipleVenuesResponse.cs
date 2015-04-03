using FourSquare.SharpSquare.Entities;

namespace FourSquare.SharpSquare.Core
{
    public class FourSquareMultipleVenuesResponse<T> : FourSquareResponse where T : FourSquareEntity
    {
        public VenueResponse<T> response
        {
            get;
            set;
        }
    }
}