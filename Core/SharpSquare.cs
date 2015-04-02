using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Net;
using System.Text;
using System.IO;
using FourSquare.SharpSquare.Entities;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

namespace FourSquare.SharpSquare.Core
{
    public class SharpSquare
    {
        private enum HttpMethod
        {
            GET,
            POST
        }

        private class AccessToken
        {
            public string access_token;
        }

        private string clientId = null;
        private string clientSecret = null;
        private string accessToken = null;
        private string authenticateUrl = "https://foursquare.com/oauth2/authenticate";
        private string accessTokenUrl = "https://foursquare.com/oauth2/access_token";
        private string apiUrl = "https://api.foursquare.com/v2";
        private string apiVersion = "20140101";

        public SharpSquare(string clientId, string clientSecret)
        {
            this.clientId = clientId;
            this.clientSecret = clientSecret;
        }

        public SharpSquare(string clientId, string clientSecret, string accessToken)
        {
            this.clientId = clientId;
            this.clientSecret = clientSecret;
            this.accessToken = accessToken;
        }

        private string Request(string url, HttpMethod httpMethod)
        {
            return Request(url, httpMethod, null);
        }

        private string Request(string url, HttpMethod httpMethod, string data)
        {
            string result = string.Empty;
            HttpWebRequest httpWebRequest = (HttpWebRequest)WebRequest.Create(url);
            httpWebRequest.Method = httpMethod.ToString();

            if (data != null)
            {
                byte[] bytes = UTF8Encoding.UTF8.GetBytes(data.ToString());
                httpWebRequest.ContentLength = bytes.Length;
                Stream stream = httpWebRequest.GetRequestStream();
                stream.Write(bytes, 0, bytes.Length);
                stream.Dispose();
            }

            HttpWebResponse httpWebResponse = (HttpWebResponse)httpWebRequest.GetResponse();
            StreamReader reader = new StreamReader(httpWebResponse.GetResponseStream());
            result = reader.ReadToEnd();
            reader.Dispose();

            return result;
        }

        private string SerializeDictionary(Dictionary<string, string> dictionary)
        {
            StringBuilder parameters = new StringBuilder();
            foreach (KeyValuePair<string, string> keyValuePair in dictionary)
            {
                parameters.Append(keyValuePair.Key + "=" + keyValuePair.Value + "&");
            }
            return parameters.Remove(parameters.Length - 1, 1).ToString();
        }

        private FourSquareSingleResponse<T> GetSingle<T>(string endpoint) where T : FourSquareEntity
        {
            return GetSingle<T>(endpoint, null, false);
        }

        private FourSquareSingleResponse<T> GetSingle<T>(string endpoint, bool unauthenticated) where T : FourSquareEntity
        {
            return GetSingle<T>(endpoint, null, unauthenticated);
        }

        private FourSquareSingleResponse<T> GetSingle<T>(string endpoint, Dictionary<string, string> parameters) where T : FourSquareEntity
        {
            return GetSingle<T>(endpoint, parameters, false);
        }

        private FourSquareSingleResponse<T> GetSingle<T>(string endpoint, Dictionary<string, string> parameters, bool unauthenticated) where T : FourSquareEntity
        {
            string serializedParameters = "";
            if (parameters != null)
            {
                serializedParameters = "&" + SerializeDictionary(parameters);
            }

            string oauthToken = "";
            if (unauthenticated)
            {
                oauthToken = string.Format("client_id={0}&client_secret={1}", clientId, clientSecret);
            }
            else
            {
                oauthToken = string.Format("oauth_token={0}", accessToken);
            }

            string json = Request(string.Format("{0}{1}?{2}{3}&v={4}", apiUrl, endpoint, oauthToken, serializedParameters, apiVersion), HttpMethod.GET);
            FourSquareSingleResponse<T> fourSquareResponse = JsonConvert.DeserializeObject<FourSquareSingleResponse<T>>(json);
            return fourSquareResponse;
        }

        private FourSquareMultipleResponse<T> GetMultiple<T>(string endpoint) where T : FourSquareEntity
        {
            return GetMultiple<T>(endpoint, null, false);
        }

        private FourSquareMultipleResponse<T> GetMultiple<T>(string endpoint, bool unauthenticated) where T : FourSquareEntity
        {
            return GetMultiple<T>(endpoint, null, unauthenticated);
        }

        private FourSquareMultipleResponse<T> GetMultiple<T>(string endpoint, Dictionary<string, string> parameters) where T : FourSquareEntity
        {
            return GetMultiple<T>(endpoint, parameters, false);
        }

        private FourSquareMultipleResponse<T> GetMultiple<T>(string endpoint, Dictionary<string, string> parameters, bool unauthenticated) where T : FourSquareEntity
        {
            string serializedParameters = "";
            if (parameters != null)
            {
                serializedParameters = "&" + SerializeDictionary(parameters);
            }

            string oauthToken = "";
            if (unauthenticated)
            {
                oauthToken = string.Format("client_id={0}&client_secret={1}", clientId, clientSecret);
            }
            else
            {
                oauthToken = string.Format("oauth_token={0}", accessToken);
            }

            string json = Request(string.Format("{0}{1}?{2}{3}&v={4}", apiUrl, endpoint, oauthToken, serializedParameters, apiVersion), HttpMethod.GET);
            FourSquareMultipleResponse<T> fourSquareResponse = JsonConvert.DeserializeObject<FourSquareMultipleResponse<T>>(json);
            return fourSquareResponse;
        }

        #region CustomCode

        //note@ismail -> SearchVenues throws exception beacuse Foursquare response contains "List<Venue>" and "Geocode" but it is not handled in SharpSquare code.
        //todo@ismail -> Update nuget package when this issue fixed on github https://github.com/TICLAB/SharpSquare/issues/18

        private FourSquareMultipleVenuesResponse<T> GetMultipleVenues<T>(string endpoint) where T : FourSquareEntity
        {
            return GetMultipleVenues<T>(endpoint, null, false);
        }

        private FourSquareMultipleVenuesResponse<T> GetMultipleVenues<T>(string endpoint, bool unauthenticated) where T : FourSquareEntity
        {
            return GetMultipleVenues<T>(endpoint, null, unauthenticated);
        }

        private FourSquareMultipleVenuesResponse<T> GetMultipleVenues<T>(string endpoint, Dictionary<string, string> parameters) where T : FourSquareEntity
        {
            return GetMultipleVenues<T>(endpoint, parameters, false);
        }

        private FourSquareMultipleVenuesResponse<T> GetMultipleVenues<T>(string endpoint, Dictionary<string, string> parameters, bool unauthenticated) where T : FourSquareEntity
        {
            string serializedParameters = "";
            if (parameters != null)
            {
                serializedParameters = "&" + SerializeDictionary(parameters);
            }

            string oauthToken = "";
            if (unauthenticated)
            {
                oauthToken = string.Format("client_id={0}&client_secret={1}", clientId, clientSecret);
            }
            else
            {
                oauthToken = string.Format("oauth_token={0}", accessToken);
            }

            string json = Request(string.Format("{0}{1}?{2}{3}&v={4}", apiUrl, endpoint, oauthToken, serializedParameters, apiVersion), HttpMethod.GET);
            var fourSquareResponse = JsonConvert.DeserializeObject<FourSquareMultipleVenuesResponse<T>>(json);
            return fourSquareResponse;
        }

        #endregion

        private void Post(string endpoint)
        {
            Post(endpoint, null);
        }

        private void Post(string endpoint, Dictionary<string, string> parameters)
        {
            string serializedParameters = "";
            if (parameters != null)
            {
                serializedParameters = "&" + SerializeDictionary(parameters);
            }

            string json = Request(string.Format("{0}{1}?oauth_token={2}{3}&v={4}", apiUrl, endpoint, accessToken, serializedParameters, apiVersion), HttpMethod.POST);
        }

        private FourSquareSingleResponse<T> Post<T>(string endpoint) where T : FourSquareEntity
        {
            string serializedParameters = "";

            string json = Request(string.Format("{0}{1}?oauth_token={2}{3}&v={4}", apiUrl, endpoint, accessToken, serializedParameters, apiVersion), HttpMethod.POST);
            FourSquareSingleResponse<T> fourSquareResponse = JsonConvert.DeserializeObject<FourSquareSingleResponse<T>>(json);
            return fourSquareResponse;
        }

        private FourSquareSingleResponse<T> Post<T>(string endpoint, Dictionary<string, string> parameters) where T : FourSquareEntity
        {
            string serializedParameters = "";
            if (parameters != null)
            {
                serializedParameters = "&" + SerializeDictionary(parameters);
            }

            string json = Request(string.Format("{0}{1}?oauth_token={2}{3}&v={4}", apiUrl, endpoint, accessToken, serializedParameters, apiVersion), HttpMethod.POST);
            FourSquareSingleResponse<T> fourSquareResponse = JsonConvert.DeserializeObject<FourSquareSingleResponse<T>>(json);
            return fourSquareResponse;
        }

        private JObject PostJObject(string endpoint, Dictionary<string, string> parameters)
        {
            string serializedParameters = "";
            if (parameters != null)
            {
                serializedParameters = "&" + SerializeDictionary(parameters);
            }

            string json = Request(string.Format("{0}{1}?oauth_token={2}{3}&v={4}", apiUrl, endpoint, accessToken, serializedParameters, apiVersion), HttpMethod.POST);
            return JObject.Parse(json);
        }

        public string GetAuthenticateUrl(string redirectUri)
        {
            return string.Format("{0}?client_id={1}&response_type=code&redirect_uri={2}", authenticateUrl, clientId, redirectUri);
        }

        public string GetAccessToken(string redirectUri, string code)
        {
            string url = string.Format("{0}?client_id={1}&client_secret={2}&grant_type=authorization_code&redirect_uri={3}&code={4}", accessTokenUrl, clientId, clientSecret, redirectUri, code);
            string json = Request(url, HttpMethod.GET);
            AccessToken accessToken = JsonConvert.DeserializeObject<AccessToken>(json);
            SetAccessToken(accessToken.access_token);
            return accessToken.access_token;
        }

        public void SetAccessToken(string accessToken)
        {
            this.accessToken = accessToken;
        }

        #region User
        // User
        /// <summary>
        /// https://api.foursquare.com/v2/users/USER_ID
        /// Returns profile information for a given user, including selected badges and mayorships.
        /// If the user is a friend, contact information, Facebook ID, and Twitter handle and the user's last checkin may also be present.
        /// In addition, the pings field will indicate whether checkins from this user will trigger a ping (notifications to mobile devices). This setting can be changed via setpings. Note that this setting is overriden if pings is false in settings (no pings will be sent, even if this user is set to true). 
        /// </summary>
        public User GetUser(string userId)
        {
            return GetSingle<User>("/users/" + userId).response["user"];
        }

        /// <summary>
        /// https://api.foursquare.com/v2/users/search
        /// Returns an array of compact users's profiles.
        /// </summary>
        public List<User> SearchUsers(Dictionary<string, string> parameters)
        {
            return GetMultiple<User>("/users/search", parameters).response["results"];
        }

        /// <summary>
        /// https://api.foursquare.com/v2/users/requests
        /// Shows a user the list of users with whom they have a pending friend request (i.e., someone tried to add the acting user as a friend, but the acting user has not accepted). 
        /// </summary>
        public List<User> GetUserRequests()
        {
            return GetMultiple<User>("/users/requests").response["requests"];
        }

        // TODO
        /*
        public List<Badge> GetBadges(string userId)
        {
            return GetMultiple<Badge>("/users/" + userId + "/badges").response["badges"];
        }
        */

        /// <summary>
        /// https://api.foursquare.com/v2/users/USER_ID/checkins
        /// Returns a history of checkins for the authenticated user.
        /// </summary>
        public List<Checkin> GetUserCheckins(string userId)
        {
            return GetUserCheckins(userId, null);
        }

        public List<Checkin> GetUserCheckins(string userId, Dictionary<string, string> parameters)
        {
            FourSquareEntityItems<Checkin> checkins = GetSingle<FourSquareEntityItems<Checkin>>("/users/" + userId + "/checkins", parameters).response["checkins"];
            return checkins.items;
        }

        /// <summary>
        /// https://api.foursquare.com/v2/users/USER_ID/friends
        /// Returns an array of a user's friends.
        /// </summary>
        public List<User> GetUserFriends(string userId)
        {
            return GetUserFriends(userId, null);
        }

        public List<User> GetUserFriends(string userId, Dictionary<string, string> parameters)
        {
            FourSquareEntityItems<User> friends = GetSingle<FourSquareEntityItems<User>>("/users/" + userId + "/friends", parameters).response["friends"];
            return friends.items;
        }

        /// <summary>
        /// https://api.foursquare.com/v2/users/USER_ID/tips
        /// Returns tips from a user.
        /// </summary>
        public List<Tip> GetUserTips(string userId)
        {
            return GetUserTips(userId, null);
        }

        public List<Tip> GetUserTips(string userId, Dictionary<string, string> parameters)
        {
            FourSquareEntityItems<Tip> tips = GetSingle<FourSquareEntityItems<Tip>>("/users/" + userId + "/tips", parameters).response["tips"];

            return tips.items;
        }

        /*/// <summary>
        /// https://api.foursquare.com/v2/users/USER_ID/todos
        /// Returns todos from a user. 
        /// </summary>
        public List<Todo> GetUserTodos(string userId)
        {
            return GetUserTodos(userId, null);
        }

        public List<Todo> GetUserTodos(string userId, Dictionary<string, string> parameters)
        {
            FourSquareEntityItems<Todo> todos = GetSingle<FourSquareEntityItems<Todo>>("/users/" + userId + "/todos", parameters).response["todos"];
           
            return todos.items;
        }*/

        /// <summary>
        /// https://api.foursquare.com/v2/users/USER_ID/venuehistory
        /// Returns a list of all venues visited by the specified user, along with how many visits and when they were last there.
        /// This is an experimental API. We're excited about the innovation we think it enables as a much more efficient version of fetching all of a user's checkins, but we're also still learning if this right approach. Please give it a shot and provide feedback on the mailing list. Note that although the venuehistory endpoint currently returns all of the user's data, we expect to return only the last 6 months, requiring callers to page backwards as needed. We may also remove the lastHereAt value. Additionally, for anomalous users, we'll cap out at 500 unique venues. 
        /// </summary>
        public List<VenueHistory> GetUserVenueHistory()
        {
            return GetUserVenueHistory(null);
        }

        public List<VenueHistory> GetUserVenueHistory(Dictionary<string, string> parameters)
        {
            FourSquareEntityItems<VenueHistory> venues = GetSingle<FourSquareEntityItems<VenueHistory>>("/users/self/venuehistory").response["venues"];

            return venues.items;
        }

        /// <summary>
        /// https://api.foursquare.com/v2/users/USER_ID/request
        /// Sends a friend request to another user.
        /// </summary>
        public User SendUserRequest(string userId)
        {
            return Post<User>("/users/" + userId + "/request").response["user"];
        }

        /// <summary>
        /// https://api.foursquare.com/v2/users/USER_ID/unfriend
        /// Cancels any relationship between the acting user and the specified user.
        /// Removes a friend, unfollows a celebrity, or cancels a pending friend request. 
        /// </summary>
        public User SendUserUnfriend(string userId)
        {
            return Post<User>("/users/" + userId + "/unfriend").response["user"];
        }

        /// <summary>
        /// https://api.foursquare.com/v2/users/USER_ID/approve
        /// Approves a pending friend request from another user.
        /// </summary>
        public User SendUserApprove(string userId)
        {
            return Post<User>("/users/" + userId + "/approve").response["user"];
        }

        /// <summary>
        /// https://api.foursquare.com/v2/users/USER_ID/deny
        /// Denies a pending friend request from another user.
        /// </summary>
        public User SendUserDeny(string userId)
        {
            return Post<User>("/users/" + userId + "/deny").response["user"];
        }

        /// <summary>
        /// https://api.foursquare.com/v2/users/USER_ID/setpings
        /// Changes whether the acting user will receive pings (phone notifications) when the specified user checks in.
        /// </summary>
        public User SetUserPings(string userId, string value)
        {
            Dictionary<string, string> parameters = new Dictionary<string, string>();

            parameters.Add("value", value);

            return Post<User>("/users/" + userId + "/setpings", parameters).response["user"];
        }

        #endregion

        //Venue
        /// <summary>
        /// https://api.foursquare.com/v2/venues/VENUE_ID
        /// Gives details about a venue, including location, mayorship, tags, tips, specials, and category.
        /// Authenticated users will also receive information about who is here now.
        /// If the venue ID given is one that has been merged into another "master" venue, the response will show data about the "master" instead of giving you an error. 
        /// </summary>
        public Venue GetVenue(string venueId)
        {
            return GetSingle<Venue>("/venues/" + venueId, true).response["venue"];
        }

        /// <summary>
        /// https://api.foursquare.com/v2/venues/add
        /// Allows users to add a new venue.
        /// If this method returns an error, give the user the option to edit her inputs. The method may return an HTTP 409 error if the new venue looks like a duplicate of an existing venue. This response will include two useful values: candidateDuplicateVenues and ignoreDuplicatesKey. In this situation we recommend you try these two options: 1) use one of the candidateDuplicateVenues included in the response of the 409 error, or 2) ignore duplicates and force the addition of a new venue by resubmitting the same venue add request with two additional parameters: ignoreDuplicates set to true and ignoreDuplicatesKey set to the value from the earlier error response.
        /// In addition to this, give users the ability to say "never mind, check-in here anyway" and perform a manual ("venueless") checkin by specifying just the venue name
        /// All fields are optional, but one of either a valid address or a geolat/geolong pair must be provided. We recommend that developers provide a geolat/geolong pair in every case.
        /// Caller may also, optionally, pass in a category (primarycategoryid) to which you want this venue assigned. You can browse a full list of categories using the /categories method. On adding venue, we recommend that applications show the user this hierarchy and allow them to choose something suitable. 
        /// </summary>
        public Venue AddVenue(Dictionary<string, string> parameters)
        {
            return Post<Venue>("/venues/add", parameters).response["venue"];
        }

        /// <summary>
        /// https://api.foursquare.com/v2/venues/categories
        /// Returns a hierarchical list of categories applied to venues. 
        /// When designing client applications, please download this list only once per session, but also avoid caching this data for longer than a week to avoid stale information. 
        /// This endpoint is part of the venues API (https://developer.foursquare.com/overview/venues.html). 
        /// </summary>
        public List<Category> GetVenueCategories()
        {
            return GetMultiple<Category>("/venues/categories", true).response["categories"];
        }

        /// <summary>
        /// https://api.foursquare.com/v2/venues/explore
        /// Returns a list of recommended venues near the current location. 
        /// If authenticated, the method will potentially personalize the ranking based on you and your friends. If you do not authenticate, you will not get this personalization. 
        /// This endpoint is part of the venues API (https://developer.foursquare.com/overview/venues.html). 
        /// </summary>
        /*  
        public List<VenueExplore> ExploreVenues(Dictionary<string, string> parameters)
        {
           return GetSingle<FourSquareEntityExoploreVenuesGroups<VenueExplore>>("/venues/explore", parameters, true).response["groups"];

           return venues.items;
        }
        */

        /// <summary>
        /// https://api.foursquare.com/v2/venues/managed
        /// Get a list of venues the current user manages. 
        /// </summary>
        public List<Venue> GetManagedVenues()
        {
            return GetManagedVenues(null);
        }

        /// <summary>
        /// https://api.foursquare.com/v2/venues/managed
        /// Get a list of venues the current user manages. 
        /// </summary>
        public List<Venue> GetManagedVenues(Dictionary<string, string> parameters)
        {
            return GetMultiple<Venue>("/venues/managed", parameters, false).response["venues"];
        }

        /// <summary>
        /// https://api.foursquare.com/v2/venues/search
        /// Returns a list of venues near the current location, optionally matching the search term.
        /// To ensure the best possible results, pay attention to the intent parameter below. And if you're looking for "top" venues or recommended venues, use the explore endpoint instead. 
        /// If lat and long is provided, each venue includes a distance. If authenticated, the method will return venue metadata related to you and your friends. If you do not authenticate, you will not get this data.
        /// Note that most of the fields returned inside venue can be optional. The user may create a venue that has no address, city or state (the venue is created instead at the geolat/geolong specified). Your client should handle these conditions safely.
        /// You'll also notice a stats block that reveals some count data about the venue. herenow shows the number of people currently there (this value can be 0). 
        /// This endpoint is part of the venues API (https://developer.foursquare.com/overview/venues.html). 
        /// </summary>
        public List<Venue> SearchVenues(Dictionary<string, string> parameters)
        {
            return GetMultipleVenues<Venue>("/venues/search", parameters, true).response.venues;
        }

        /// <summary>
        /// https://api.foursquare.com/v2/venues/timeseries
        /// Get daily venue stats for a list of venues over a time range.  
        /// </summary>
        public List<VenueTimeSerie> GetVenueTimeSeriesData(Dictionary<string, string> parameters)
        {
            return GetMultiple<VenueTimeSerie>("/venues/timeseries", parameters, true).response["timeseries"];
        }

        /// <summary>
        /// https://api.foursquare.com/v2/venues/suggestcompletion
        /// Returns a list of mini-venues partially matching the search term, near the location. 
        /// </summary>
        public List<Venue> GetSuggestCompletionVenues(Dictionary<string, string> parameters)
        {
            return GetMultiple<Venue>("/venues/suggestcompletion", parameters, true).response["minivenues"];
        }

        /// <summary>
        /// https://api.foursquare.com/v2/venues/trending
        /// Returns a list of venues near the current location with the most people currently checked in.
        /// This endpoint is part of the venues API (https://developer.foursquare.com/overview/venues.html). 
        /// </summary>
        public List<Venue> GetTrendingVenues(Dictionary<string, string> parameters)
        {
            return GetMultiple<Venue>("/venues/trending", parameters, true).response["venues"];
        }

        /// <summary>
        /// https://api.foursquare.com/v2/venues/VENUE_ID/herenow
        /// Provides a count of how many people are at a given venue, plus the first page of the users there, friends-first, and if the current user is authenticated.
        /// This is an experimental API. We're excited about the innovation we think it enables as a much more efficient version of fetching all data about a venue, but we're also still learning if this right approach. Please give it a shot and provide feedback on the mailing list. 
        /// </summary>
        public List<Checkin> GetVenueHereNow(string venueId)
        {
            return GetVenueHereNow(venueId, null);
        }

        public List<Checkin> GetVenueHereNow(string venueId, Dictionary<string, string> parameters)
        {
            FourSquareEntityItems<Checkin> checkins = GetSingle<FourSquareEntityItems<Checkin>>("/venues/" + venueId + "/herenow", parameters, true).response["hereNow"];

            return checkins.items;
        }

        /// <summary>
        /// https://api.foursquare.com/v2/venues/VENUE_ID/tips
        /// Returns tips for a venue.
        /// </summary>
        public List<Tip> GetVenueTips(string venueId)
        {
            return GetVenueTips(venueId, null);
        }

        public List<Tip> GetVenueTips(string venueId, Dictionary<string, string> parameters)
        {
            FourSquareEntityItems<Tip> tips = GetSingle<FourSquareEntityItems<Tip>>("/venues/" + venueId + "/tips", parameters, true).response["tips"];

            return tips.items;
        }

        /// <summary>
        /// https://api.foursquare.com/v2/venues/VENUE_ID/photos
        /// Returns photos for a venue. 
        /// </summary>
        public List<Photo> GetVenuePhotos(string venueId, Dictionary<string, string> parameters)
        {
            FourSquareEntityItems<Photo> photos = GetSingle<FourSquareEntityItems<Photo>>("/venues/" + venueId + "/photos", parameters, true).response["photos"];
            return photos.items;
        }

        /// <summary>
        /// https://api.foursquare.com/v2/venues/VENUE_ID/links
        /// Returns URLs or identifiers from third parties that have been applied to this venue, such as how the New York Times refers to this venue and a URL for additional information from nytimes.com. This is part of the foursquare Venue Map.
        /// This is an experimental endpoint and very much subject to change. Please provide us feedback in the forum.
        /// </summary>
        public List<Link> GetVenueLinks(string venueId)
        {
            FourSquareEntityItems<Link> links = GetSingle<FourSquareEntityItems<Link>>("/venues/" + venueId + "/links", true).response["links"];

            return links.items;
        }

        /// <summary>
        /// https://api.foursquare.com/v2/venues/VENUE_ID/marktodo
        /// Allows you to mark a venue to-do, with optional text.
        /// </summary>
        public Todo SetVenueToDo(string venueId, string text)
        {
            Dictionary<string, string> parameters = new Dictionary<string, string>();

            parameters.Add("text", text);

            return Post<Todo>("/venues/" + venueId + "/marktodo", parameters).response["todo"];
        }

        /// <summary>
        /// https://api.foursquare.com/v2/venues/VENUE_ID/flag
        /// Allows users to indicate a venue is incorrect in some way.
        /// Flags are pushed into a moderation queue. If a closed flag is approved, the venue will no longer show up in search results. Moderators will attempt to correct cases of mislocated or duplicate venues as appropriate. If the user has the correct address for a mislocated venue, use proposeedit instead. 
        /// </summary>
        public void SetVenueFlag(string venueId, string problem)
        {
            Dictionary<string, string> parameters = new Dictionary<string, string>();

            parameters.Add("problem", problem);

            Post("/venues/" + venueId + "/flag", parameters);
        }

        /// <summary>
        /// https://api.foursquare.com/v2/venues/VENUE_ID/proposeedit
        /// Allows you to propose a change to a venue.
        /// If the user knows a correct address, use this method to save it. Otherwise, use flag to flag the venue instead (you need not specify a new address or geolat/geolong in that case). 
        /// </summary>
        public void SetVenueProposeEdit(string venueId)
        {
            Post("/venues/" + venueId + "/proposeedit");
        }

        public void SetVenueProposeEdit(string venueId, Dictionary<string, string> parameters)
        {
            Post("/venues/" + venueId + "/proposeedit", parameters);
        }

        //Checkin
        /// <summary>
        /// https://api.foursquare.com/v2/checkins/CHECKIN_ID
        /// Get details of a checkin.
        /// </summary>
        public Checkin GetCheckin(string checkinId)
        {
            return GetSingle<Checkin>("/checkins/" + checkinId).response["checkin"];
        }

        /// <summary>
        /// https://api.foursquare.com/v2/checkins/add
        /// Allows you to check in to a place. 
        /// Checkins will always have notifications included.
        /// </summary>
        public Checkin AddCheckin(Dictionary<string, string> parameters)
        {
            JObject jObject = PostJObject("/checkins/add", parameters);
            return JsonConvert.DeserializeObject<Checkin>(jObject["response"]["checkin"].ToString());
        }

        /// <summary>
        /// https://api.foursquare.com/v2/checkins/recent
        /// Returns a list of recent checkins from friends.
        /// </summary>
        public List<Checkin> GetRecentCheckin()
        {
            return GetRecentCheckin(null);
        }

        public List<Checkin> GetRecentCheckin(Dictionary<string, string> parameters)
        {
            return GetMultiple<Checkin>("/checkins/recent", parameters).response["recent"];
        }

        /// <summary>
        /// https://api.foursquare.com/v2/checkins/CHECKIN_ID/addcomment
        /// Comment on a checkin-in.
        /// </summary>
        public void AddChekinComment(string checkinId, string text)
        {
            Dictionary<string, string> parameters = new Dictionary<string, string>();

            parameters.Add("text", text);

            Post("/checkins/" + checkinId + "/addcomment", parameters);
        }

        /// <summary>
        /// https://api.foursquare.com/v2/checkins/CHECKIN_ID/deletecomment
        /// Remove a comment from a checkin, if the acting user is the author or the owner of the checkin.
        /// </summary>
        public void DeleteChekinComment(string checkinId, string commentId)
        {
            Dictionary<string, string> parameters = new Dictionary<string, string>();

            parameters.Add("commentId", commentId);

            Post("/checkins/" + checkinId + "/deletecomment", parameters);
        }

        //Tips
        /// <summary>
        /// https://api.foursquare.com/v2/tips/TIP_ID
        /// Gives details about a tip, including which users (especially friends) have marked the tip to-do or done.
        /// </summary>
        public Tip GetTip(string tipId)
        {
            return GetSingle<Tip>("/tips/" + tipId, true).response["tip"];
        }

        /// <summary>
        /// https://api.foursquare.com/v2/tips/add
        /// Allows you to add a new tip at a venue.
        /// </summary>
        public Tip AddTip(Dictionary<string, string> parameters)
        {
            return Post<Tip>("/tips/add", parameters).response["tip"];
        }

        /// <summary>
        /// https://api.foursquare.com/v2/tips/search
        /// Returns a list of tips near the area specified.
        /// </summary>
        public List<Tip> SearchTips(Dictionary<string, string> parameters)
        {
            return GetMultiple<Tip>("/tips/search", parameters, true).response["tips"];
        }

        /// <summary>
        /// https://api.foursquare.com/v2/tips/TIP_ID/marktodo
        /// Allows you to mark a tip to-do.
        /// </summary>
        public Todo SetTipToDo(string tipId)
        {
            return Post<Todo>("/tips/" + tipId + "/marktodo").response["todo"];
        }

        /// <summary>
        /// https://api.foursquare.com/v2/tips/TIP_ID/markdone
        /// Allows the acting user to mark a tip done.
        /// </summary>
        public void SetTipDone(string tipId)
        {
            Post("/tips/" + tipId + "/markdone");
        }

        /// <summary>
        /// https://api.foursquare.com/v2/tip/TIP_ID/unmark
        /// Allows you to remove a tip from your to-do list or done list.
        /// </summary>
        public void SetTipUnMark(string tipId)
        {
            Post("/tips/" + tipId + "/unmark");
        }

        //Photo
        /// <summary>
        /// https://api.foursquare.com/v2/photos/PHOTO_ID
        /// Get details of a photo.
        /// </summary>
        public Photo GetPhoto(string photoId)
        {
            return GetSingle<Photo>("/photos/" + photoId).response["photo"];
        }

        /// <summary>
        /// https://api.foursquare.com/v2/photos/add
        /// Allows users to add a new photo to a checkin, tip, or a venue in general.
        /// All fields are optional, but exactly one of the id fields (checkinId, tipId, venueId) must be passed in. 
        /// In addition, the image file data must be posted. The photo should be uploaded as a jpeg and the Content-Type should be set to "image/jpeg". 
        /// Attaching a photo to a tip or a venue makes it visible to anybody, while attaching a photo to a checkin makes it visible only to the people who can see the checkin (the user's friends, unless the checkin has been sent to Twitter or Facebook.). 
        /// Multiple photos can be attached to a checkin or venue, but there can only be one photo per tip. 
        /// To avoid double-tweeting, if you are sending a checkin that will be immediately followed by a photo, do not set broadcast=twitter on the checkin, and just set it on the photo.
        /// </summary>
        public Photo AddPhoto(Dictionary<string, string> parameters)
        {
            return Post<Photo>("/photos/add", parameters).response["photo"];
        }

        //Settings
        /// <summary>
        /// https://api.foursquare.com/v2/settings/all
        /// Returns a setting for the acting user.
        /// </summary>
        public Setting GetSettings()
        {
            return GetSingle<Setting>("/settings/all").response["settings"];
        }

        /*NEXT Version
         public Setting GetAllSetting(Dictionary<string, string> parameters)
        {
            return GetSingle<Setting>("/settings/all", parameters).response["settings"];
        }*/

        /// <summary>
        /// https://api.foursquare.com/v2/settings/SETTING_ID/set
        /// Change a setting for the given user.
        /// </summary>
        public void SetSetting(string settingId, string value)
        {
            Dictionary<string, string> parameters = new Dictionary<string, string>();

            parameters.Add("value", value);

            Post("/settings/" + settingId + "/set", parameters);
        }

        //Special
        /// <summary>
        /// https://api.foursquare.com/v2/specials/SPECIAL_ID
        /// Gives details about a special, including text and unlock rules.
        /// </summary>
        public Special GetSpecial(string specialId)
        {
            return GetSingle<Special>("/specials/" + specialId, true).response["special"];
        }

        /// <summary>
        /// https://api.foursquare.com/v2/specials/search
        /// Returns a list of specials near the current location.
        /// This is an experimental API. We'd love your feedback as we solidify it over the next few weeks. 
        /// </summary>
        public List<Special> SearchSpecials(Dictionary<string, string> parameters)
        {
            FourSquareEntityItems<Special> specials = GetSingle<FourSquareEntityItems<Special>>("/specials/search", parameters).response["specials"];

            return specials.items;
        }
    }
}
