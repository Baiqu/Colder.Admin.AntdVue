using Coldairarrow.Entity.Ocelot_Manage;
using Coldairarrow.Util;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Dynamic.Core;
using System.Threading.Tasks;

namespace Coldairarrow.Business.Ocelot_Manage
{
    public class OcelotReRoutesBusiness : BaseBusiness<OcelotReRoutes>, IOcelotReRoutesBusiness, IDependency
    {

        public OcelotReRoutesBusiness() : base("OcelotDb", DatabaseType.SqlServer)
        {

        }

        #region 外部接口

        public async Task<List<OcelotReRoutes>> GetDataListAsync(Pagination pagination, string condition, string keyword)
        {
            var q = GetIQueryable();
            var where = LinqHelper.True<OcelotReRoutes>();

            //筛选
            if (!condition.IsNullOrEmpty() && !keyword.IsNullOrEmpty())
            {
                var newWhere = DynamicExpressionParser.ParseLambda<OcelotReRoutes, bool>(
                    ParsingConfig.Default, false, $@"{condition}.Contains(@0)", keyword);
                where = where.And(newWhere);
            }

            return await q.Where(where).GetPagination(pagination).ToListAsync();
        }

        public async Task<OcelotReRoutes> GetTheDataAsync(string id)
        {
            return await GetEntityAsync(id);
        }

        public async Task AddDataAsync(OcelotReRoutes data)
        {
            await InsertAsync(data);
        }

        public async Task UpdateDataAsync(OcelotReRoutes data)
        {
            await UpdateAsync(data);
        }

        public async Task DeleteDataAsync(List<string> ids)
        {
            await DeleteAsync(ids);
        }

        #endregion

        #region 私有成员

        #endregion

        #region 数据模型

        #endregion
    }
}