using Coldairarrow.Entity.Member_Manage;
using Coldairarrow.Util;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Coldairarrow.Business.Member_Manage
{
    public interface Igax_membercardBusiness
    {
        Task<List<gax_membercard>> GetDataListAsync(Pagination pagination, string condition, string keyword);
        Task<gax_membercard> GetTheDataAsync(string id);
        Task AddDataAsync(gax_membercard data);
        Task UpdateDataAsync(gax_membercard data);
        Task DeleteDataAsync(List<string> ids);
    }
}