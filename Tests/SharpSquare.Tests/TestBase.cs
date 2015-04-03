namespace SharpSquare.Tests
{
    public class TestBase
    {
        private const string clientId = "BWVOT3CVKFPWHYN3VE23GIYE0KAMMC1HU3WZVLJEU1L0OKYB";
        private const string clientSecret = "0LRAHA4ND2DSQA0OL3SKLTGNX2NTOBL2S3D52A01SK4MBCM4";

        protected FourSquare.SharpSquare.Core.SharpSquare client;

        public TestBase()
        {
            client = new FourSquare.SharpSquare.Core.SharpSquare(clientId, clientSecret);
        }
    }
}