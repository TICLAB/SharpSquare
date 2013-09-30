using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace FourSquare.SharpSquare.Entities
{
    public class Link : FourSquareEntity
    {
        /// <summary>
        /// For now just contains an id of a provider, e.g. nymag.
        /// </summary>
        public string provider
        {
            get;
            set;
        }

        /// <summary>
        /// optional If present, a URL for additional information about this venue from this provider.
        /// </summary>
        public string url
        {
            get;
            set;
        }

        /// <summary>
        /// optional If present, the identifer used by this provider to identify this venue.
        /// </summary>
        public string linkedId
        {
            get;
            set;
        }
    }
}