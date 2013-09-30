using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace FourSquare.SharpSquare.Entities
{
    public class Photo : FourSquareEntity
    {
        /// <summary>
        /// A unique string identifier for this photo.
        /// </summary>
        public string id
        {
            get;
            set;
        }

        /// <summary>
        /// Seconds since epoch when this photo was created.
        /// </summary>
        public string createdAt
        {
            get;
            set;
        }

        /// <summary>
        /// Start of the URL for this photo.
        /// </summary>
        public string prefix
        {
            get;
            set;
        }

        /// <summary>
        /// Ending of the URL for this photo.
        /// To assemble a resolvable photo URL, take prefix + size + suffix, e.g. https://irs0.4sqi.net/img/general/300x500/2341723_vt1Kr-SfmRmdge-M7b4KNgX2_PHElyVbYL65pMnxEQw.jpg.
        /// size can be one of the following, where XX or YY is one of 36, 100, 300, or 500.
        /// - XXxYY
        /// - original: the original photo's size
        /// - capXX: cap the photo with a width or height of XX (whichever is larger). Scales the other, smaller dimension proportionally
        /// - widthXX: forces the width to be XX and scales the height proportionally
        /// - heightYY: forces the height to be YY and scales the width proportionally
        /// </summary>
        public string suffix
        {
            get;
            set;
        }

        /// <summary>
        /// The url for the original uploaded file.
        /// </summary>
        public string url
        {
            get;
            set;
        }

        /// <summary>
        /// The count of supported sizes, plus items, an array of supported sizes. Each size will have a string url and integer width and height parameters. The first item will be the original photo size, and the remaining items will be derived photo sizes. Just because a derived photo size (with url) is returned does not mean it is necessarily available at that url. 
        /// </summary>
        public FourSquareEntityItems<Dimension> sizes
        {
            get;
            set;
        }

        /// <summary>
        /// optional If present, the name and url for the application that created this photo.
        /// </summary>
        public Source source
        {
            get;
            set;
        }

        public string visibility
        {
            get;
            set;
        }

        /// <summary>
        ///  If the user is not clear from context, then a compact user is present.
        /// </summary>
        public User user
        {
            get;
            set;
        }

        /// <summary>
        /// If the venue is not clear from context, then a compact venue is present.
        /// </summary>
        public Venue venue
        {
            get;
            set;
        }

        /// <summary>
        ///  If the tip is not clear from context, then a compact tip is present.
        /// </summary>
        public Tip tip
        {
            get;
            set;
        }

        /// <summary>
        /// If the checkin is not clear from context, then a compact checkin is present.
        /// </summary>
        public Checkin checkin
        {
            get;
            set;
        }
    }   
}