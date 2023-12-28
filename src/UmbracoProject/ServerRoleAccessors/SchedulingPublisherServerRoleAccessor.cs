using Umbraco.Cms.Core.Sync;

namespace UmbracoProject.ServerRoleAccessors;

public class SchedulingPublisherServerRoleAccessor : IServerRoleAccessor
{
    public ServerRole CurrentServerRole => ServerRole.SchedulingPublisher;
}