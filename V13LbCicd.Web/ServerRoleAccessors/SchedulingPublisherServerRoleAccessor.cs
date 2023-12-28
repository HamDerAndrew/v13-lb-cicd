using Umbraco.Cms.Core.Sync;

namespace V13LbCicd.Web.ServerRoleAccessors;

public class SchedulingPublisherServerRoleAccessor : IServerRoleAccessor
{
    public ServerRole CurrentServerRole => ServerRole.SchedulingPublisher;
}
