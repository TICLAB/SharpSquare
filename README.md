SharpSquare
===========

FourSquare SDK for .NET

The SharpSquare .NET library provides a quick access to the FourSquare API v2.
The library is built in C# and can therefore be used by all languages the .NET environment supports.

Beacuse of clean natural object oriented approach, the library is easy to use.
SharpSquare implements almost all the features offered by the FourSquare API and fully supports the oAuth protocol.

Each API call is mapped to a one-to-one method and each FourSquare entity is mapped to a class.


Code examples
=============
```
using FourSquare.SharpSquare.Core;
using FourSquare.SharpSquare.Entities;

string clientId = "CLIENT_ID";
string clientSecret = "CLIEND_SECRET";
string redirectUri = "REDIRECT_URI";
SharpSquare sharpSquare = new SharpSquare(clientId, clientSecret);
```

Authentication
==============
```
if (Request["code"] != null)
{
	sharpSquare.GetAccessToken(redirectUri, Request["code"]);
	// Here, you can do something
}
else
{
	HyperLink.NavigateUrl = sharpSquare.GetAuthenticateUrl(redirectUri);
}
```
Create a check-in
=================
```
Dictionary<string, string> parameters = new Dictionary<string, string>();
parameters.Add("venueId", "VENUE_ID");
parameters.Add("broadcast", "public");
Checkin checkin = sharpSquare.AddCheckin(parameters);
```
Authors
=======
<a href="https://twitter.com/MicheleBertoli" target=_blank title="Michele Bertoli">@MicheleBertoli</a>
<br>
<a href="https://twitter.com/ufranchini" target=_blank title="Umberto Franchini">@ufranchini</a>
