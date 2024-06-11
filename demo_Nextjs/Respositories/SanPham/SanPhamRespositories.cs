using Dapper;
using demo_Nextjs.Models;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.Extensions.Configuration;

namespace demo_Nextjs.Respositories.SanPham
{
    public class SanPhamRespositories : ISanPhamRespositories
    {
        private readonly IConfiguration _configuration;
        private readonly string _connectionString;

        public SanPhamRespositories(IConfiguration configuration)
        {
            _configuration = configuration;
            _connectionString = _configuration.GetConnectionString("DefaultConnection");
        }

        public async Task<IEnumerable<SanPhamDTO>> GetAllSanPhamDTOs()
        {
            using (var connection = new SqlConnection(_connectionString))
            {
                var sql = "SELECT * FROM Products";
                return await connection.QueryAsync<SanPhamDTO>(sql);
            }
        }

        public async Task<int> AddSanPham(SanPhamDTO sanPham)
        {
            using (var connection = new SqlConnection(_connectionString))
            {
                var sql = @"
            INSERT INTO Products (Name, Description, Price, Image, OnSale) 
            VALUES (@Name, @Description, @Price, @Image, @OnSale)";
                return await connection.ExecuteAsync(sql, new
                {
                    Name = sanPham.Name,
                    Description = sanPham.Description,
                    Price = sanPham.Price,
                    Image = sanPham.Image,
                    OnSale = sanPham.OnSale
                });
            }
        }


        public async Task<int> UpdateSanPham(SanPhamDTO sanPham)
        {
            using (var connection = new SqlConnection(_connectionString))
            {
                var sql = @"
            UPDATE Products 
            SET Name = @Name, Description = @Description, Price = @Price, Image = @Image, OnSale = @OnSale 
            WHERE Id = @Id";
                return await connection.ExecuteAsync(sql, new
                {
                    Id = sanPham.Id,
                    Name = sanPham.Name,
                    Description = sanPham.Description,
                    Price = sanPham.Price,
                    Image = sanPham.Image,
                    OnSale = sanPham.OnSale
                });
            }
        }


        public async Task<int> DeleteSanPham(int id)
        {
            using (var connection = new SqlConnection(_connectionString))
            {
                var sql = "DELETE FROM Products WHERE Id = @Id";
                return await connection.ExecuteAsync(sql, new { Id = id });
            }
        }

    }
}
