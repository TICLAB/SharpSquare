using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace FourSquare.SharpSquare.Entities
{
    public class Open : FourSquareEntity
    {
        /// <summary>
        /// A localized string describing the time the venue us open.
        /// </summary>
        public string renderedTime
        {
            get;
            set;
        }
    }
}