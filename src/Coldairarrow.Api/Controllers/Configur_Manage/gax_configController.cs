using Coldairarrow.Business.Configur_Manage;
using Coldairarrow.Entity.Configur_Manage;
using Coldairarrow.Util;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Coldairarrow.Api.Controllers.Configur_Manage
{
    [Route("/Configur_Manage/[controller]/[action]")]
    public class gax_configController : BaseApiController
    {
        #region DI

        public gax_configController(Igax_configBusiness gax_configBus)
        {
            _gax_configBus = gax_configBus;
        }

        Igax_configBusiness _gax_configBus { get; }

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
        public async Task<AjaxResult<List<gax_config>>> GetDataList(Pagination pagination, string condition, string keyword)
        {
            var dataList = await _gax_configBus.GetDataListAsync(pagination, condition, keyword);

            return DataTable(dataList, pagination);
        }

        /// <summary>
        /// 获取详情
        /// </summary>
        /// <param name="id">Id</param>
        /// <returns></returns>
        [HttpPost]
        public async Task<gax_config> GetTheData(string id)
        {
            return await _gax_configBus.GetTheDataAsync(id);
        }

        #endregion

        #region 提交

        /// <summary>
        /// 保存
        /// </summary>
        /// <param name="data">保存的数据</param>
        [HttpPost]
        public async Task SaveData(gax_config data)
        {
            if (data.Id.IsNullOrEmpty())
            {
                data.InitEntity();

                await _gax_configBus.AddDataAsync(data);
            }
            else
            {
                await _gax_configBus.UpdateDataAsync(data);
            }
        }

        /// <summary>
        /// 删除数据
        /// </summary>
        /// <param name="ids">id数组,JSON数组</param>
        [HttpPost]
        public async Task DeleteData(string ids)
        {
            await _gax_configBus.DeleteDataAsync(ids.ToList<string>());
        }

        #endregion
    }
}