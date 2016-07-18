using System.Collections.Generic;
using FourSquare.SharpSquare.Entities;

namespace FourSquare.SharpSquare.Core
{
    public class FourSquareMultipleResponse<T> : FourSquareResponse where T : FourSquareEntity
    {
        public Dictionary<string, List<T>> response
        {
            get;
            set;
        }
    }
}