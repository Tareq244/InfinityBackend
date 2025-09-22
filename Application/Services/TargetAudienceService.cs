using InfinityBack.Application.Interface;
using InfinityBack.dataBase;
using InfinityBack.dataBase.Model;
using InfinityBack.DTO.UserDTO;
using Microsoft.EntityFrameworkCore;

namespace InfinityBack.Application.Services
{
    public class TargetAudienceService : ITargetAudienceService
    {
        #region Properties
        private readonly InfinityDBContext _dbContext;
        #endregion

        #region constructor
        public TargetAudienceService(InfinityDBContext dbContext)
        {
            _dbContext = dbContext;
        }
        #endregion

        #region GetAllUsersAsync
        public async Task<IEnumerable<TargetAudience>> GetAllAudienceAsync()
        {
            var target = await _dbContext.TargetAudiences.ToListAsync();

            return target;

        }
        #endregion
    }
}
