using Coldairarrow.Business.Member_Manage;
using Coldairarrow.Entity.Member_Manage;
using Coldairarrow.Util;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Coldairarrow.Api.Controllers.Member_Manage
{
    [Route("/Member_Manage/[controller]/[action]")]
    public class gax_membercardController : BaseApiController
    {
        #region DI

        public gax_membercardController(Igax_membercardBusiness gax_membercardBus)
        {
            _gax_membercardBus = gax_membercardBus;
        }

        Igax_membercardBusiness _gax_membercardBus { get; }

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
        public async Task<AjaxResult<List<gax_membercard>>> GetDataList(Pagination pagination, string condition, string keyword)
        {
            var dataList = await _gax_membercardBus.GetDataListAsync(pagination, condition, keyword);

            return DataTable(dataList, pagination);
        }

        /// <summary>
        /// 获取详情
        /// </summary>
        /// <param name="id">Id</param>
        /// <returns></returns>
        [HttpPost]
        public async Task<gax_membercard> GetTheData(string id)
        {
            return await _gax_membercardBus.GetTheDataAsync(id);
        }

        #endregion

        #region 提交

        /// <summary>
        /// 保存
        /// </summary>
        /// <param name="data">保存的数据</param>
        [HttpPost]
        public async Task SaveData(gax_membercard data)
        {
            if (data.Id.IsNullOrEmpty())
            {
                data.InitEntity();

                await _gax_membercardBus.AddDataAsync(data);
            }
            else
            {
                await _gax_membercardBus.UpdateDataAsync(data);
            }
        }

        /// <summary>
        /// 删除数据
        /// </summary>
        /// <param name="ids">id数组,JSON数组</param>
        [HttpPost]
        public async Task DeleteData(string ids)
        {
            await _gax_membercardBus.DeleteDataAsync(ids.ToList<string>());
        }

        #endregion
    }
}