using Coldairarrow.Business.Oper_Manage;
using Coldairarrow.Entity.Oper_Manage;
using Coldairarrow.Util;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Coldairarrow.Api.Controllers.Oper_Manage
{
    [Route("/Oper_Manage/[controller]/[action]")]
    public class gax_notifyController : BaseApiController
    {
        #region DI

        public gax_notifyController(Igax_notifyBusiness gax_notifyBus)
        {
            _gax_notifyBus = gax_notifyBus;
        }

        Igax_notifyBusiness _gax_notifyBus { get; }

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
        public async Task<AjaxResult<List<gax_notify>>> GetDataList(Pagination pagination, string condition, string keyword)
        {
            var dataList = await _gax_notifyBus.GetDataListAsync(pagination, condition, keyword);

            return DataTable(dataList, pagination);
        }

        /// <summary>
        /// 获取详情
        /// </summary>
        /// <param name="id">Id</param>
        /// <returns></returns>
        [HttpPost]
        public async Task<gax_notify> GetTheData(string id)
        {
            return await _gax_notifyBus.GetTheDataAsync(id);
        }

        #endregion

        #region 提交

        /// <summary>
        /// 保存
        /// </summary>
        /// <param name="data">保存的数据</param>
        [HttpPost]
        public async Task SaveData(gax_notify data)
        {
            if (data.Id.IsNullOrEmpty())
            {
                data.InitEntity();

                await _gax_notifyBus.AddDataAsync(data);
            }
            else
            {
                await _gax_notifyBus.UpdateDataAsync(data);
            }
        }

        /// <summary>
        /// 删除数据
        /// </summary>
        /// <param name="ids">id数组,JSON数组</param>
        [HttpPost]
        public async Task DeleteData(string ids)
        {
            await _gax_notifyBus.DeleteDataAsync(ids.ToList<string>());
        }

        #endregion
    }
}