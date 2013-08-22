using ServiceStack.Razor;
using ServiceStack.Text;
using ServiceStack.WebHost.Endpoints;

namespace BookIndex
{
    public class AppHost : AppHostBase
    {
        public AppHost() : base("Apples", typeof(AppHost).Assembly) { }

        public override void Configure(Funq.Container container) {
            JsConfig.EmitCamelCaseNames = true;
            Plugins.Add(new RazorFormat()); // add razor and .md functionality

            container.Register(_ => new Library());
        }
    }
}