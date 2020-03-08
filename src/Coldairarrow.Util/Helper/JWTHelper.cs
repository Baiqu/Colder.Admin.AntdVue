using Coldairarrow.Util.Helper;
using Newtonsoft.Json.Linq;

namespace Coldairarrow.Util
{
    public static class JWTHelper
    {
        private static readonly string _headerBase64Url = "{\"alg\":\"HS256\",\"typ\":\"JWT\"}".Base64UrlEncode();
        public static readonly string JWTSecret = ConfigHelper.GetValue("JWTSecret");

        /// <summary>
        /// 生成Token
        /// </summary>
        /// <param name="payloadJsonStr">数据JSON字符串</param>
        /// <param name="secret">密钥</param>
        /// <returns></returns>
        public static string GetToken(string payloadJsonStr, string secret)
        {
            string payloadBase64Url = payloadJsonStr.Base64UrlEncode();
            string sign = $"{_headerBase64Url}.{payloadBase64Url}".ToHMACSHA256String(secret);

            return $"{_headerBase64Url}.{payloadBase64Url}.{sign}";
        }

        /// <summary>
        /// 获取Token中的数据
        /// </summary>
        /// <param name="token">token</param>
        /// <returns></returns>
        public static JObject GetPayload(string token)
        {
            return token.Split('.')[1].Base64UrlDecode().ToJObject();
        }

        /// <summary>
        /// 获取Token中的数据
        /// </summary>
        /// <typeparam name="T">泛型</typeparam>
        /// <param name="token">token</param>
        /// <returns></returns>
        public static T GetPayload<T>(string token)
        {
            var payloadString = token.Split('.')[1].Base64UrlDecode();
            var listString = payloadString.Split(',');
            if (listString.Length == 2)
            {
                return token.Split('.')[1].Base64UrlDecode().ToObject<T>();
            }

            //以下是Gax生成的Token
            var expString = listString[2].Split(':')[1];
            var expdate = DatetimeHelper.ConvertLongToDateTime(long.Parse(expString));

            var userId = listString[1].Split(':')[2].ToObject<string>();
            //{"http://schemas.xmlsoap.org/ws/2005/05/identity/claims/name":"+85269955818","http://schemas.xmlsoap.org/ws/2005/05/identity/claims/nameidentifier":"8e3a213e-125c-4597-b43c-3a58cc96ac6e","exp":1583633484,"iss":"AssetsChain_GAX_APP","aud":"https://api.assetschain.co"}

            var result = Newtonsoft.Json.JsonConvert.SerializeObject(new JWTPayload
            {
                Expire = expdate,
                UserId = userId
            });

            return result.ToObject<T>();

            
        }

        /// <summary>
        /// 校验Token
        /// </summary>
        /// <param name="token">token</param>
        /// <param name="secret">密钥</param>
        /// <returns></returns>
        public static bool CheckToken(string token, string secret)
        {
            var items = token.Split('.');
            var oldSign = items[2];
            string newSign = $"{items[0]}.{items[1]}".ToHMACSHA256String(secret);

            return oldSign == newSign;
        }
    }
}
