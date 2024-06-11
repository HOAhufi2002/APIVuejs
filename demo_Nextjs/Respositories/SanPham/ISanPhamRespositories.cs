using demo_Nextjs.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace demo_Nextjs.Respositories.SanPham
{
    public interface ISanPhamRespositories
    {
        Task<IEnumerable<SanPhamDTO>> GetAllSanPhamDTOs();
        Task<int> AddSanPham(SanPhamDTO sanPham);
        Task<int> UpdateSanPham(SanPhamDTO sanPham);
        Task<int> DeleteSanPham(int id);
    }
}
