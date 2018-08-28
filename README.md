# twilio-sms-dotnet-tutorial

Check out the full article on the Telerik bog associated with this video:  

https://www.telerik.com/blogs/why-you-should-use-view-components-not-partial-views-aspnet-core


Author: Peter Kellner ( http://peterkellner.net )

Video Explaining This Repo:  https://youtu.be/HcJJ6OVGaVE

Why use View Components and not Partial Views? The biggest reason is that when inserting a Partial View into a Razor page, all the ViewData associated with the calling View is automatically associated with the Partial View. This means that a Partial View may behave very differently on one Razor page than on another. With View Components, you control what gets shared to your View Components.
