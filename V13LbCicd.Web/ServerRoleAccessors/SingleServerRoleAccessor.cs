using Umbraco.Cms.Core.Sync;

namespace V13LbCicd.Web.ServerRoleAccessors;

public class SingleServerRoleAccessor : IServerRoleAccessor
{
    public ServerRole CurrentServerRole => ServerRole.Single;
}
