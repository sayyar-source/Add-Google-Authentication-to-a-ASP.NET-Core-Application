# Add-Google-Authentication-to-a-ASP.NET-Core-Application
Configure and use ASP.NET Core Social Authentication without ASP.NET Core identity. In this post I am using Google Authentication provider, you can use Facebook or Twitter. Only the authentication provider and associated configuration only will change.
To use Google Authentication, you need to create a project in https://console.developers.google.com/. Once you create a project, click on the Credentials menu. And you need to create an OAuth 2.0 Client Id.
This sample uses Google authentication for authenticating users. Using Google authentication shifts many of the complexities of managing the sign-in process to Google.
So we have implemented the Google Authentication process - by default you will get following claims from Google.
The first thing we need to do is to add a Nuget package into our ASP.NET Core application. Open up Package Manager Console in Visual Studio and run the following command:

Install-Package Microsoft.AspNetCore.Authentication.Google
We now need to configure our ASP.NET Core application to set up Google authentication. In-order to do this, we need to make some changes to our Startup class.
services.AddAuthentication( option =>{ option.DefaultScheme = CookieAuthenticationDefaults.AuthenticationScheme;

       }).AddCookie(option=> 
       {
           option.LoginPath = "/account/google-login";
       }).AddGoogle(options =>
              {
                  options.ClientId = Configuration["Authentication:Google:ClientId"];
                  options.ClientSecret = Configuration["Authentication:Google:ClientSecret"];
              });
   and add: 
               app.UseAuthentication();
              app.UseAuthorization();
              
   AccountController:
   // AccountController.cs
[AllowAnonymous, Route("account")]
public class AccountController : Controller
{
    [Route("google-login")]
    public IActionResult GoogleLogin()
    {
        var properties = new AuthenticationProperties { RedirectUri = Url.Action("GoogleResponse") };
        return Challenge(properties, GoogleDefaults.AuthenticationScheme);
    }
 
    [Route("google-response")]
    public async Task<IActionResult> GoogleResponse()
    {
        var result = await HttpContext.AuthenticateAsync(CookieAuthenticationDefaults.AuthenticationScheme);
 
        var claims = result.Principal.Identities
            .FirstOrDefault().Claims.Select(claim => new
        {
            claim.Issuer,
            claim.OriginalIssuer,
            claim.Type,
            claim.Value
        });
 
        return Json(claims);
    }
}

and result is:
 
Nameidentifier - http://schemas.xmlsoap.org/ws/2005/05/identity/claims/nameidentifier
Name - http://schemas.xmlsoap.org/ws/2005/05/identity/claims/name
GivenName - http://schemas.xmlsoap.org/ws/2005/05/identity/claims/givenname
Surname - http://schemas.xmlsoap.org/ws/2005/05/identity/claims/surname
Email - http://schemas.xmlsoap.org/ws/2005/05/identity/claims/emailaddress
