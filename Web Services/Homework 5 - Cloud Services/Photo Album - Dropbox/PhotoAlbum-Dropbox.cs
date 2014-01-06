using System;
using System.IO;
using System.Diagnostics;

using Spring.Social.OAuth1;
using Spring.Social.Dropbox.Api;
using Spring.Social.Dropbox.Connect;
using Spring.IO;

class PhotoAlbum_Dropbox
{
	// Register your own Dropbox app at https://www.dropbox.com/developers/apps
	// with "Full Dropbox" access level and set your app keys and app secret below
    private const string DropboxAppKey = "18cs******m7x54";
    private const string DropboxAppSecret = "6en5y******89e8";

	private const string OAuthTokenFileName = "OAuthTokenFileName.txt";

	static void Main()
	{
        if (DropboxAppKey.IndexOf('*') > 0 || DropboxAppSecret.IndexOf('*') > 0)
        {
            Console.WriteLine("Please setup your Dropbox Application Key and Secret into the code");
            return;
        }

		DropboxServiceProvider dropboxServiceProvider = 
			new DropboxServiceProvider(DropboxAppKey, DropboxAppSecret, AccessLevel.AppFolder);

        // Authenticate the application (if not authenticated) and load the OAuth token
		if (!File.Exists(OAuthTokenFileName))
		{
			AuthorizeAppOAuth(dropboxServiceProvider);
		}
		OAuthToken oauthAccessToken = LoadOAuthToken();

		// Login in Dropbox
		IDropbox dropbox = dropboxServiceProvider.GetApi(oauthAccessToken.Value, oauthAccessToken.Secret);

		// Create new folder
		string newFolderName = "Pictures_Folder_" + DateTime.Now.Ticks;
		Entry createFolderEntry = dropbox.CreateFolderAsync(newFolderName).Result;
		Console.WriteLine("Created folder: {0}", createFolderEntry.Path);

		// Upload pictures (get their path and name from text file)
        using (var sr = new StreamReader("../../PicturesList.txt"))
        {
            while (!sr.EndOfStream)
            {
                string filename = sr.ReadLine().Trim();
                if (filename.Length > 0)
                {
                    Entry uploadFileEntry = dropbox.UploadFileAsync(
                       new FileResource("../../" + filename),
                       "/" + newFolderName + "/" + filename).Result;
                    Console.WriteLine("Uploaded a file: {0}", uploadFileEntry.Path);
                }
            }
        }

        // Share a file
        DropboxLink sharedUrl = dropbox.GetShareableLinkAsync(createFolderEntry.Path).Result;
        Process.Start(sharedUrl.Url);
	}
  
	private static OAuthToken LoadOAuthToken()
	{
		string[] lines = File.ReadAllLines(OAuthTokenFileName);
		OAuthToken oauthAccessToken = new OAuthToken(lines[0], lines[1]);
		return oauthAccessToken;
	}
  
	private static void AuthorizeAppOAuth(DropboxServiceProvider dropboxServiceProvider)
	{
		// Authorization without callback url
		Console.Write("Getting request token...");
		OAuthToken oauthToken = dropboxServiceProvider.OAuthOperations.FetchRequestTokenAsync(null, null).Result;
		Console.WriteLine("Done.");

		OAuth1Parameters parameters = new OAuth1Parameters();
		string authenticateUrl = dropboxServiceProvider.OAuthOperations.BuildAuthorizeUrl(
			oauthToken.Value, parameters);
		Console.WriteLine("Redirect the user for authorization to {0}", authenticateUrl);
		Process.Start(authenticateUrl);
		Console.Write("Press [Enter] when authorization attempt has succeeded.");
		Console.ReadLine();

		Console.Write("Getting access token...");
		AuthorizedRequestToken requestToken = new AuthorizedRequestToken(oauthToken, null);
		OAuthToken oauthAccessToken =
			dropboxServiceProvider.OAuthOperations.ExchangeForAccessTokenAsync(requestToken, null).Result;
		Console.WriteLine("Done.");

		string[] oauthData = new string[] { oauthAccessToken.Value, oauthAccessToken.Secret };
		File.WriteAllLines(OAuthTokenFileName, oauthData);
	}
}
