using InfinityBack.dataBase.Model;

namespace InfinityBack.Application.Interface
{
    public interface ISizeService
    {
        Task<IEnumerable<Size>> GetAllSizesAsync();
    }
}
