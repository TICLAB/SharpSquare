using System.Collections.Generic;
using Shouldly;
using Xunit;

namespace SharpSquare.Tests
{
    public class VenueTests : TestBase
    {
        [Fact]
        public void SearchVenues()
        {
            var venues = client.SearchVenues(new Dictionary<string, string>
            {
                    { "near","istanbul" },
                    { "query","yapı kredi" }
            });

            venues.Count.ShouldBeGreaterThan(0);
        }
    }
}
