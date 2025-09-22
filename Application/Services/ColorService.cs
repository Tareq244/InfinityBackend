using InfinityBack.Application.Interface;
using InfinityBack.dataBase;
using InfinityBack.dataBase.Model;
using Microsoft.EntityFrameworkCore;

namespace InfinityBack.Application.Services
{
    public class ColorService : IColorService
    {
        #region Properties
        private readonly InfinityDBContext _dBContext;
        #endregion
        #region constructor
        public ColorService(InfinityDBContext dBContext)
        {
            _dBContext = dBContext;
        }
        #endregion
        #region GetAllColors
        public async Task<IEnumerable<Color>> GetAllColorsAsync()
        {
            var colors = await _dBContext.Colors.ToListAsync();
            return colors;
        }
        #endregion

    }
}
