using Umbraco.Cms.Core.Sync;

namespace UmbracoProject.ServerRoleAccessors;

public class SingleServerRoleAccessor : IServerRoleAccessor
{
    public ServerRole CurrentServerRole => ServerRole.Single;
}