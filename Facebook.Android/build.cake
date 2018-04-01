
#load "../common.cake"

var FB_NUGET_VERSION = "4.31.0";
var AN_NUGET_VERSION = "4.28.0";

var FB_VERSION = "4.31.0";
var FB_URL = "http://search.maven.org/remotecontent?filepath=com/facebook/android/{0}/{1}/{0}-{1}.aar";
var FB_DOCS_URL = "http://search.maven.org/remotecontent?filepath=com/facebook/android/{0}/{1}/{0}-{1}-javadoc.jar";

var AN_VERSION = "4.28.0";
var AN_URL = string.Format ("http://search.maven.org/remotecontent?filepath=com/facebook/android/audience-network-sdk/{0}/audience-network-sdk-{0}.aar", AN_VERSION);

var REQUIRED_PACKAGES = new []{
	"facebook-android-sdk",
	"facebook-core",
	"facebook-common",
	"facebook-login",
	"facebook-share",
	"facebook-places",
	"facebook-applinks",
	"facebook-messenger"
};

var TARGET = Argument ("t", Argument ("target", "Default"));

var buildSpec = new BuildSpec () {
	Libs = new [] {	
		new DefaultSolutionBuilder {
			AlwaysUseMSBuild = true,
			SolutionPath = "./Xamarin.Facebook.sln",
			BuildsOn = BuildPlatforms.Mac,
			OutputFiles = new [] { 
				new OutputFileCopy { FromFile = "./source/Xamarin.Facebook/bin/Release/Xamarin.Facebook.dll" },
				new OutputFileCopy { FromFile = "./source/Xamarin.Facebook.AudienceNetwork/bin/Release/Xamarin.Facebook.AudienceNetwork.dll" }
			}
		}
	},

	Samples = new [] {
		new DefaultSolutionBuilder { SolutionPath = "./samples/HelloFacebookSample.sln", AlwaysUseMSBuild = true },
		new DefaultSolutionBuilder { SolutionPath = "./samples/MessengerSendSample.sln", AlwaysUseMSBuild = true },
		new DefaultSolutionBuilder { SolutionPath = "./samples/AudienceNetworkSample.sln", AlwaysUseMSBuild = true },
	},

	NuGets = new [] {
		new NuGetInfo { NuSpec = "./nuget/Xamarin.Facebook.Android.nuspec", Version = FB_NUGET_VERSION },
		new NuGetInfo { NuSpec = "./nuget/Xamarin.Facebook.AudienceNetwork.Android.nuspec", Version = AN_NUGET_VERSION },
	},

	Components = new [] {
		new Component { ManifestDirectory = "./component" },
	},
};

Task ("externals")
	.WithCriteria (!FileExists ("./externals/facebook.aar"))
	.Does (() => 
{
	EnsureDirectoryExists ("./externals/");

	foreach(var packageName in REQUIRED_PACKAGES){
		// Download the FB aar
		DownloadFile (string.Format(FB_URL, packageName, FB_VERSION), string.Format("./externals/{0}.aar", packageName));
		// Download, and unzip the docs .jar
		DownloadFile (string.Format(FB_DOCS_URL, packageName, FB_VERSION), string.Format("./externals/{0}-docs.jar", packageName));
		EnsureDirectoryExists (string.Format("./externals/{0}-docs", packageName));
		Unzip (string.Format("./externals/{0}-docs.jar", packageName), string.Format("./externals/{0}-docs", packageName));
	}

	// Download the FB aar
	DownloadFile (AN_URL, "./externals/audiencenetwork.aar");
});


Task ("clean").IsDependentOn ("clean-base").Does (() => 
{
	if (DirectoryExists ("./externals/"))
		DeleteDirectory ("./externals", true);
});

SetupXamarinBuildTasks (buildSpec, Tasks, Task);

RunTarget (TARGET);
