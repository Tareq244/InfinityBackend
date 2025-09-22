using InfinityBack.dataBase.Model;

namespace InfinityBack.Application.Interface
{
    public interface ITargetAudienceService
    {
        Task<IEnumerable<TargetAudience>> GetAllAudienceAsync();
    }
}
