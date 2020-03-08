using Coldairarrow.Business.Ocelot_Manage;
using Coldairarrow.Entity.Ocelot_Manage;
using Coldairarrow.Util;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Coldairarrow.Api.Controllers.Ocelot_Manage
{
    [Route("/Ocelot_Manage/[controller]/[action]")]
    public class OcelotReRoutesController : BaseApiController
    {
        #region DI

        public OcelotReRoutesController(IOcelotReRoutesBusiness ocelotReRoutesBus)
        {
            _ocelotReRoutesBus = ocelotReRoutesBus;
        }

        IOcelotReRoutesBusiness _ocelotReRoutesBus { get; }

        #endregion

        #region 获取

        /// <summary>
        /// 获取列表
        /// </summary>
        /// <param name="pagination">分页参数</param>
        /// <param name="condition">查询字段</param>
        /// <param name="keyword">关键字</param>
        /// <returns></returns>
        [HttpPost]
        public async Task<AjaxResult<List<OcelotReRoutes>>> GetDataList(Pagination pagination, string condition, string keyword)
        {
            var dataList = await _ocelotReRoutesBus.GetDataListAsync(pagination, condition, keyword);

            return DataTable(dataList, pagination);
        }

        /// <summary>
        /// 获取详情
        /// </summary>
        /// <param name="id">Id</param>
        /// <returns></returns>
        [HttpPost]
        public async Task<OcelotReRoutes> GetTheData(string id)
        {
            return await _ocelotReRoutesBus.GetTheDataAsync(id);
        }

        #endregion

        #region 提交

        /// <summary>
        /// 保存
        /// </summary>
        /// <param name="data">保存的数据</param>
        [HttpPost]
        public async Task SaveData(OcelotReRoutes data)
        {
            if (data.Id.IsNullOrEmpty())
            {
                data.InitEntity();

                await _ocelotReRoutesBus.AddDataAsync(data);
            }
            else
            {
                await _ocelotReRoutesBus.UpdateDataAsync(data);
            }
        }

        /// <summary>
        /// 删除数据
        /// </summary>
        /// <param name="ids">id数组,JSON数组</param>
        [HttpPost]
        public async Task DeleteData(string ids)
        {
            await _ocelotReRoutesBus.DeleteDataAsync(ids.ToList<string>());
        }

        #endregion
    }
}