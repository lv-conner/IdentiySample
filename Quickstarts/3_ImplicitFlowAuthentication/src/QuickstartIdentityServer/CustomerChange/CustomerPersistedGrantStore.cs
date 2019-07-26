using IdentityServer4.Models;
using IdentityServer4.Stores;
using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace QuickstartIdentityServer.CustomerChange
{
    /// <summary>
    /// IPersistedGrantStore授权持久化，当用户选择记住此次选择的时候。
    /// 持久化授权应添加过期事件，以便重新授权。
    /// </summary>
    public class CustomerPersistedGrantStore : IPersistedGrantStore
    {
        private readonly ConcurrentDictionary<string, PersistedGrant> _repository = new ConcurrentDictionary<string, PersistedGrant>();

        public CustomerPersistedGrantStore()
        {

        }
        /// <summary>
        /// 获取此Id下的所有授权。
        /// </summary>
        /// <param name="subjectId"></param>
        /// <returns></returns>
        public Task<IEnumerable<PersistedGrant>> GetAllAsync(string subjectId)
        {
            
            throw new NotImplementedException();
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="key"></param>
        /// <returns></returns>
        public Task<PersistedGrant> GetAsync(string key)
        {

            throw new NotImplementedException();
        }

        public Task RemoveAllAsync(string subjectId, string clientId)
        {
            throw new NotImplementedException();
        }
        /// <summary>
        /// 去除该Id,该客户端下的该授权类型下的持久化授权
        /// </summary>
        /// <param name="subjectId">Id</param>
        /// <param name="clientId">客户端Id</param>
        /// <param name="type">授权类型</param>
        /// <returns></returns>
        public Task RemoveAllAsync(string subjectId, string clientId, string type)
        {
            _repository.Where(p => p.Value.SubjectId == subjectId && p.Value.ClientId == clientId && p.Value.Type == type);
            throw new NotImplementedException();
        }

        public Task RemoveAsync(string key)
        {
            
            throw new NotImplementedException();
        }

        public Task StoreAsync(PersistedGrant grant)
        {
            throw new NotImplementedException();
        }
    }
}
