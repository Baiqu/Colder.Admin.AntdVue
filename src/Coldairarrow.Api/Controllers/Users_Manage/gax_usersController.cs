using Coldairarrow.Business.Users_Manage;
using Coldairarrow.Entity.Users_Manage;
using Coldairarrow.Util;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Coldairarrow.Api.Controllers.Users_Manage
{
    [Route("/Users_Manage/[controller]/[action]")]
    public class gax_usersController : BaseApiController
    {
        #region DI

        public gax_usersController(Igax_usersBusiness gax_usersBus)
        {
            _gax_usersBus = gax_usersBus;
        }

        Igax_usersBusiness _gax_usersBus { get; }

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
        public async Task<AjaxResult<List<gax_users>>> GetDataList(Pagination pagination, string condition, string keyword)
        {
            var dataList = await _gax_usersBus.GetDataListAsync(pagination, condition, keyword);

            return DataTable(dataList, pagination);
        }

        /// <summary>
        /// 获取详情
        /// </summary>
        /// <param name="id">Id</param>
        /// <returns></returns>
        [HttpPost]
        public async Task<gax_users> GetTheData(string id)
        {
            return await _gax_usersBus.GetTheDataAsync(id);
        }

        #endregion

        #region 提交

        /// <summary>
        /// 保存
        /// </summary>
        /// <param name="data">保存的数据</param>
        [HttpPost]
        public async Task SaveData(gax_users data)
        {
            //这个ID是自动标识 
            //if (data.Id.IsNullOrEmpty())
            //{
            //    data.InitEntity();

            //    await _gax_usersBus.AddDataAsync(data);
            //}
            //else
            //{
            //    await _gax_usersBus.UpdateDataAsync(data);
            //}

            await _gax_usersBus.UpdateDataAsync(data);
        }

        /// <summary>
        /// 删除数据
        /// </summary>
        /// <param name="ids">id数组,JSON数组</param>
        [HttpPost]
        public async Task DeleteData(string ids)
        {
            await _gax_usersBus.DeleteDataAsync(ids.ToList<string>());
        }

        #endregion
    }
}