﻿using Coldairarrow.Entity.Oper_Manage;
using Coldairarrow.Util;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Dynamic.Core;
using System.Threading.Tasks;

namespace Coldairarrow.Business.Oper_Manage
{
    public class gax_turntable_userprizeBusiness : BaseBusiness<gax_turntable_userprize>, Igax_turntable_userprizeBusiness, IDependency
    {

        public gax_turntable_userprizeBusiness() : base("GaxDb")
        {

        }

        #region 外部接口

        public async Task<List<gax_turntable_userprize>> GetDataListAsync(Pagination pagination, string condition, string keyword)
        {
            var q = GetIQueryable();
            var where = LinqHelper.True<gax_turntable_userprize>();

            //筛选
            if (!condition.IsNullOrEmpty() && !keyword.IsNullOrEmpty())
            {
                var newWhere = DynamicExpressionParser.ParseLambda<gax_turntable_userprize, bool>(
                    ParsingConfig.Default, false, $@"{condition}.Contains(@0)", keyword);
                where = where.And(newWhere);
            }

            return await q.Where(where).GetPagination(pagination).ToListAsync();
        }

        public async Task<gax_turntable_userprize> GetTheDataAsync(string id)
        {
            return await GetEntityAsync(id);
        }

        public async Task AddDataAsync(gax_turntable_userprize data)
        {
            await InsertAsync(data);
        }

        public async Task UpdateDataAsync(gax_turntable_userprize data)
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