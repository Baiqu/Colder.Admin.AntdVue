using Coldairarrow.Entity.Configur_Manage;
using Coldairarrow.Util;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Coldairarrow.Business.Configur_Manage
{
    public interface Igax_configBusiness
    {
        Task<List<gax_config>> GetDataListAsync(Pagination pagination, string condition, string keyword);
        Task<gax_config> GetTheDataAsync(string id);
        Task AddDataAsync(gax_config data);
        Task UpdateDataAsync(gax_config data);
        Task DeleteDataAsync(List<string> ids);
    }
}