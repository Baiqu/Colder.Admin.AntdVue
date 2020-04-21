using Coldairarrow.Entity.Member_Manage;
using Coldairarrow.Util;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Coldairarrow.Business.Member_Manage
{
    public interface Igax_memberpricelistBusiness
    {
        Task<List<gax_memberpricelist>> GetDataListAsync(Pagination pagination, string condition, string keyword);
        Task<gax_memberpricelist> GetTheDataAsync(string id);
        Task AddDataAsync(gax_memberpricelist data);
        Task UpdateDataAsync(gax_memberpricelist data);
        Task DeleteDataAsync(List<string> ids);
    }
}