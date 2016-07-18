namespace FourSquare.SharpSquare.Entities
{
    public class Setting : FourSquareEntity
    {
        public string receivePings
        {
            get;
            set;
        }

        public string receiveCommentPings
        {
            get;
            set;
        }

        public string sendToTwitter
        {
            get;
            set;
        }

        public string sendToFacebook
        {
            get;
            set;
        }

        public string foreignConsent
        {
            get;
            set;
        }
    }
}