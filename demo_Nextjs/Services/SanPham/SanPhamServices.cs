using demo_Nextjs.Models;
using demo_Nextjs.Respositories.SanPham;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace demo_Nextjs.Services.SanPham
{
    public class SanPhamServices : ISanPhamServices
    {
        private readonly ISanPhamRespositories _sanPhamRepository;

        public SanPhamServices(ISanPhamRespositories sanPhamRepository)
        {
            _sanPhamRepository = sanPhamRepository;
        }

        public async Task<IEnumerable<SanPhamDTO>> GetAllSanPham()
        {
            return await _sanPhamRepository.GetAllSanPhamDTOs();
        }

        public async Task<int> AddSanPham(SanPhamDTO sanPham)
        {
            return await _sanPhamRepository.AddSanPham(sanPham);
        }

        public async Task<int> UpdateSanPham(SanPhamDTO sanPham)
        {
            return await _sanPhamRepository.UpdateSanPham(sanPham);
        }

        public async Task<int> DeleteSanPham(int id)
        {
            return await _sanPhamRepository.DeleteSanPham(id);
        }
    }
}
