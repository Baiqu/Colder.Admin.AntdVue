using Coldairarrow.Entity.Ocelot_Manage;
using Coldairarrow.Util;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Coldairarrow.Business.Ocelot_Manage
{
    public interface IOcelotReRoutesBusiness
    {
        Task<List<OcelotReRoutes>> GetDataListAsync(Pagination pagination, string condition, string keyword);
        Task<OcelotReRoutes> GetTheDataAsync(string id);
        Task AddDataAsync(OcelotReRoutes data);
        Task UpdateDataAsync(OcelotReRoutes data);
        Task DeleteDataAsync(List<string> ids);
    }
}