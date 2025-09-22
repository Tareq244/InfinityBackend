

using InfinityBack.dataBase.Model;

namespace InfinityBack.Application.Interface
{
    public interface IColorService
    {
        Task<IEnumerable<Color>> GetAllColorsAsync();
    }
}
