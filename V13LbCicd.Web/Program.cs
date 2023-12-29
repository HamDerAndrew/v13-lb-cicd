using Hangfire;
using Umbraco.Cms.Infrastructure.DependencyInjection;
using V13LbCicd.Web;
using V13LbCicd.Web.ServerRoleAccessors;

WebApplicationBuilder builder = WebApplication.CreateBuilder(args);

var umbracoBuilder = builder.CreateUmbracoBuilder()
    .AddBackOffice()
    .AddWebsite()
    .AddDeliveryApi()
    .AddComposers();

if (builder.Environment.EnvironmentName.Equals("Subscriber"))
{
    umbracoBuilder.SetServerRegistrar<SubscriberServerRoleAccessor>()
        .AddAzureBlobMediaFileSystem()
        .AddAzureBlobImageSharpCache();
}
else if (builder.Environment.IsProduction())
{
    umbracoBuilder.SetServerRegistrar<SchedulingPublisherServerRoleAccessor>();
}
else
{
    umbracoBuilder.SetServerRegistrar<SingleServerRoleAccessor>();
}

umbracoBuilder.Build();

WebApplication app = builder.Build();

await app.BootUmbracoAsync();

if (builder.Environment.IsProduction())
{
    RecurringJob.AddOrUpdate<TvMazeUtility>("MoveTvShowsFromTvMazeToUmbraco", x => x.MoveTvShowsFromTvMazeToUmbraco(), Cron.Monthly);
}

app.UseHttpsRedirection();

app.UseUmbraco()
    .WithMiddleware(u =>
    {
        u.UseBackOffice();
        u.UseWebsite();
    })
    .WithEndpoints(u =>
    {
        u.UseInstallerEndpoints();
        u.UseBackOfficeEndpoints();
        u.UseWebsiteEndpoints();
    });

await app.RunAsync();
