using Coldairarrow.Entity.Oper_Manage;
using Coldairarrow.Util;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Coldairarrow.Business.Oper_Manage
{
    public interface Igax_turntable_userprizeBusiness
    {
        Task<List<gax_turntable_userprize>> GetDataListAsync(Pagination pagination, string condition, string keyword);
        Task<gax_turntable_userprize> GetTheDataAsync(string id);
        Task AddDataAsync(gax_turntable_userprize data);
        Task UpdateDataAsync(gax_turntable_userprize data);
        Task DeleteDataAsync(List<string> ids);
    }
}