using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace FourSquare.SharpSquare.Entities
{
    public class Category : FourSquareEntity
    {
        /// <summary>
        /// A unique identifier for this category.
        /// </summary>
        public string id
        {
            get;
            set;
        }

        /// <summary>
        /// Name of the category.
        /// </summary>
        public string name
        {
            get;
            set;
        }

        /// <summary>
        /// Pluralized version of the category name.
        /// </summary>
        public string pluralName
        {
            get;
            set;
        }

        /// <summary>
        /// Shorter version of the category name.
        /// </summary>
        public string shortName
        {
            get;
            set;
        }

        /// <summary>
        /// Pieces needed to construct category icons at various sizes. 
        /// Combine prefix with a size (32, 44, 64, and 88 are available) and suffix, e.g. https://foursquare.com/img/categories/food/default_64.png. 
        /// To get an image with a gray background, use bg_ before the size, e.g. https://foursquare.com/img/categories_v2/food/icecream_bg_32.png.
        /// </summary>
        public Icon icon
        {
            get;
            set;
        }

        /// <summary>
        /// If this is the primary category for parent venue object.
        /// </summary>
        public List<string> parents
        {
            get;
            set;
        }

        /// <summary>
        /// If this is the primary category for parent venue object.
        /// </summary>
        public bool primary
        {
            get;
            set;
        }

        /// <summary>
        /// (only present in venues/categories response). A list of categories that are descendants of this category in the hierarchy.
        /// </summary>
        public List<Category> categories
        {
            get;
            set;
        }
    }
}