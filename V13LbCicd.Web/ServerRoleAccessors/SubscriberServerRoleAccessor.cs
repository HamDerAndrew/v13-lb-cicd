using Umbraco.Cms.Core.Sync;

namespace V13LbCicd.Web.ServerRoleAccessors;

public class SubscriberServerRoleAccessor : IServerRoleAccessor
{
    public ServerRole CurrentServerRole => ServerRole.Subscriber;
}
