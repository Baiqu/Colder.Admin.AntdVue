using Coldairarrow.Entity.Users_Manage;
using Coldairarrow.Util;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Coldairarrow.Business.Users_Manage
{
    public interface Igax_usersBusiness
    {
        Task<List<gax_users>> GetDataListAsync(Pagination pagination, string condition, string keyword);
        Task<gax_users> GetTheDataAsync(string id);
        Task AddDataAsync(gax_users data);
        Task UpdateDataAsync(gax_users data);
        Task DeleteDataAsync(List<string> ids);
    }
}