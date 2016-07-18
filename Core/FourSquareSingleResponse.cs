using System.Collections.Generic;
using FourSquare.SharpSquare.Entities;

namespace FourSquare.SharpSquare.Core
{
    public class FourSquareSingleResponse<T> : FourSquareResponse where T : FourSquareEntity
    {
        public Dictionary<string, T> response
        {
            get;
            set;
        }
    }
}