using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Coldairarrow.Entity.Ocelot_Manage
{
    /// <summary>
    /// OcelotReRoutes
    /// </summary>
    [Table("OcelotReRoutes")]
    public class OcelotReRoutes
    {

        /// <summary>
        /// Id
        /// </summary>
        public string Id { get; set; }

        /// <summary>
        /// OcelotGlobalConfigurationId
        /// </summary>
        public Int32 OcelotGlobalConfigurationId { get; set; }

        /// <summary>
        /// UpstreamPathTemplate
        /// </summary>
        public string UpstreamPathTemplate { get; set; }

        /// <summary>
        /// UpstreamHttpMethod
        /// </summary>
        public string UpstreamHttpMethod { get; set; }

        /// <summary>
        /// UpstreamHost
        /// </summary>
        public string UpstreamHost { get; set; }

        /// <summary>
        /// DownstreamScheme
        /// </summary>
        public string DownstreamScheme { get; set; }

        /// <summary>
        /// DownstreamPathTemplate
        /// </summary>
        public string DownstreamPathTemplate { get; set; }

        /// <summary>
        /// DownstreamHostAndPorts
        /// </summary>
        public string DownstreamHostAndPorts { get; set; }

        /// <summary>
        /// AuthenticationOptions
        /// </summary>
        public string AuthenticationOptions { get; set; }

        /// <summary>
        /// RequestIdKey
        /// </summary>
        public string RequestIdKey { get; set; }

        /// <summary>
        /// CacheOptions
        /// </summary>
        public string CacheOptions { get; set; }

        /// <summary>
        /// ServiceName
        /// </summary>
        public string ServiceName { get; set; }

        /// <summary>
        /// QoSOptions
        /// </summary>
        public string QoSOptions { get; set; }

        /// <summary>
        /// LoadBalancerOptions
        /// </summary>
        public string LoadBalancerOptions { get; set; }

        /// <summary>
        /// Key
        /// </summary>
        public string Key { get; set; }

        /// <summary>
        /// DelegatingHandlers
        /// </summary>
        public string DelegatingHandlers { get; set; }

        /// <summary>
        /// Priority
        /// </summary>
        public Int32? Priority { get; set; }

        /// <summary>
        /// Timeout
        /// </summary>
        public Int32? Timeout { get; set; }

        /// <summary>
        /// IsStatus
        /// </summary>
        public Int32 IsStatus { get; set; }

        /// <summary>
        /// AddTime
        /// </summary>
        public DateTime AddTime { get; set; }

        /// <summary>
        /// CreateTime
        /// </summary>
        public DateTime? CreateTime { get; set; }

        /// <summary>
        /// CreatorId
        /// </summary>
        public string CreatorId { get; set; }

    }
}