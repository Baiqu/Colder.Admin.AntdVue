using Coldairarrow.Entity.Oper_Manage;
using Coldairarrow.Util;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Dynamic.Core;
using System.Threading.Tasks;

namespace Coldairarrow.Business.Oper_Manage
{
    public class gax_turntable_itemBusiness : BaseBusiness<gax_turntable_item>, Igax_turntable_itemBusiness, IDependency
    {

        public gax_turntable_itemBusiness() : base("GaxDb")
        {

        }

        #region 外部接口

        public async Task<List<gax_turntable_item>> GetDataListAsync(Pagination pagination, string condition, string keyword)
        {
            var q = GetIQueryable();
            var where = LinqHelper.True<gax_turntable_item>();

            //筛选
            if (!condition.IsNullOrEmpty() && !keyword.IsNullOrEmpty())
            {
                var newWhere = DynamicExpressionParser.ParseLambda<gax_turntable_item, bool>(
                    ParsingConfig.Default, false, $@"{condition}.Contains(@0)", keyword);
                where = where.And(newWhere);
            }

            return await q.Where(where).GetPagination(pagination).ToListAsync();
        }

        public async Task<gax_turntable_item> GetTheDataAsync(string id)
        {
            return await GetEntityAsync(id);
        }

        public async Task AddDataAsync(gax_turntable_item data)
        {
            await InsertAsync(data);
        }

        public async Task UpdateDataAsync(gax_turntable_item data)
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