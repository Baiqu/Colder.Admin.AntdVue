using Coldairarrow.Entity.Oper_Manage;
using Coldairarrow.Util;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Coldairarrow.Business.Oper_Manage
{
    public interface Igax_notifyBusiness
    {
        Task<List<gax_notify>> GetDataListAsync(Pagination pagination, string condition, string keyword);
        Task<gax_notify> GetTheDataAsync(string id);
        Task AddDataAsync(gax_notify data);
        Task UpdateDataAsync(gax_notify data);
        Task DeleteDataAsync(List<string> ids);
    }
}