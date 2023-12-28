using Umbraco.Cms.Core.Sync;

namespace UmbracoProject.ServerRoleAccessors;

public class SubscriberServerRoleAccessor : IServerRoleAccessor
{
    public ServerRole CurrentServerRole => ServerRole.Subscriber;
}