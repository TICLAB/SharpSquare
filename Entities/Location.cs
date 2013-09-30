using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace FourSquare.SharpSquare.Entities
{
    public class Location : FourSquareEntity
    {
        public string address
        {
            get;
            set;
        }

        public string crossStreet
        {
            get;
            set;
        }

        public string city
        {
            get;
            set;
        }

        public string state
        {
            get;
            set;
        }

        public string postalCode
        {
            get;
            set;
        }

        public string country
        {
            get;
            set;
        }

        public double lat
        {
            get;
            set;
        }

        public double lng
        {
            get;
            set;
        }

        public int distance
        {
            get;
            set;
        }

        public string cc
        {
            get;
            set;
        }
    }
}