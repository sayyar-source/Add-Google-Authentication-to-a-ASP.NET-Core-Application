# Add-Google-Authentication-to-a-ASP.NET-Core-Application
Configure and use ASP.NET Core Social Authentication without ASP.NET Core identity. In this post I am using Google Authentication provider, you can use Facebook or Twitter. Only the authentication provider and associated configuration only will change.
To use Google Authentication, you need to create a project in https://console.developers.google.com/. Once you create a project, click on the Credentials menu. And you need to create an OAuth 2.0 Client Id.
This sample uses Google authentication for authenticating users. Using Google authentication shifts many of the complexities of managing the sign-in process to Google.
So we have implemented the Google Authentication process - by default you will get following claims from Google.

Nameidentifier - http://schemas.xmlsoap.org/ws/2005/05/identity/claims/nameidentifier
Name - http://schemas.xmlsoap.org/ws/2005/05/identity/claims/name
GivenName - http://schemas.xmlsoap.org/ws/2005/05/identity/claims/givenname
Surname - http://schemas.xmlsoap.org/ws/2005/05/identity/claims/surname
Email - http://schemas.xmlsoap.org/ws/2005/05/identity/claims/emailaddress
