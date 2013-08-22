# ServiceStack Quick Start

This quick guide will get you started with ServiceStack and ServiceStack.Razor.

## Project Setup

1. Create a new "ASP.NET Empty Web Application"
2. Add NuGet references to `ServiceStack` and `ServiceStack.Razor`

## Ceremony & Configuration

1. Add the following sections to the `<configuration>` tag of your `web.config` file.

		<system.web>
			<compilation debug="true" targetFramework="4.0">
			  <assemblies>
				<add assembly="System.Web.WebPages.Razor, Version=1.0.0.0, Culture=neutral, PublicKeyToken=31BF3856AD364E35" />
			  </assemblies>
			  <buildProviders>
				<add extension=".cshtml" type="ServiceStack.Razor.CSharpRazorBuildProvider, ServiceStack.Razor" />
			  </buildProviders>
			</compilation>
		</system.web>
		<system.webServer>
			<handlers>
			  <add path="*" name="ServiceStack.Factory" type="ServiceStack.WebHost.Endpoints.ServiceStackHttpHandlerFactory, ServiceStack" verb="*" preCondition="integratedMode" resourceType="Unspecified" allowPathInfo="true" />
			</handlers>
		</system.webServer>
		<appSettings>
			<add key="webPages:Enabled" value="false" />
		</appSettings>

2. Add a new "Global Application Class" to the web project.
3. Create a new `AppHost` class within the web project within its own `.cs` file or within the Global.asax.cs file.
4. The `AppHost` class must inherit from `AppHostBase` (`ServiceStack.WebHost.Endpoints.AppHostBase`)
5. Add a constructor and override the Configure method as in the following example:

		public class AppHost : AppHostBase
		{
			public AppHost() : base("Your Service Name", typeof(AppHost).Assembly) { }

			public override void Configure(Funq.Container container) {
				Plugins.Add(new RazorFormat());
			}
		}

6. Initialize the `AppHost` in the `Application_Start` method of `Global` as in the following example:

		protected void Application_Start(object sender, EventArgs e) {
			new AppHost().Init();
		}

At this point ServiceStack and ServiceStack.Razor are ready to go!