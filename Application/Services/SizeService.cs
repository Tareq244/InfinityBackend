using InfinityBack.Application.Interface;
using InfinityBack.dataBase;
using InfinityBack.dataBase.Model;
using Microsoft.EntityFrameworkCore;
using System;
namespace InfinityBack.Application.Services
{
    public class SizeService : ISizeService
    {
        #region Properties
        private readonly InfinityDBContext _dBContext;
        #endregion
        #region constructor
        public SizeService(InfinityDBContext dBContext)
        {
            _dBContext = dBContext;
        }
        #endregion
        #region GetAllSizes
        public async Task<IEnumerable<Size>> GetAllSizesAsync()
        {
            var sizes = await _dBContext.Sizes.ToListAsync();
            return sizes;
        }
        #endregion
    }
}
