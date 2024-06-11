using demo_Nextjs.Models;
using demo_Nextjs.Services.SanPham;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.IO;
using System.Threading.Tasks;

namespace demo_Nextjs.Controllers
{
    [Route("api/sanpham")]
    [ApiController]
    public class SanPhamController : ControllerBase
    {
        private readonly ISanPhamServices _productService;

        public SanPhamController(ISanPhamServices productService)
        {
            _productService = productService;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<SanPhamDTO>>> GetProducts()
        {
            return Ok(await _productService.GetAllSanPham());
        }

        [HttpPost("add")]
        public async Task<ActionResult> AddProduct(SanPhamDTO sanPham)
        {
            await _productService.AddSanPham(sanPham);
            return CreatedAtAction(nameof(GetProducts), new { id = sanPham.Id }, sanPham);
        }

        [HttpPut("update{id}")]
        public async Task<ActionResult> UpdateProduct(int id, SanPhamDTO sanPham)
        {
            if (id != sanPham.Id)
            {
                return BadRequest();
            }
            await _productService.UpdateSanPham(sanPham);
            return NoContent();
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult> DeleteProduct(int id)
        {
            await _productService.DeleteSanPham(id);
            return NoContent();
        }
        [HttpPost]
        [Route("upload")]
        public async Task<IActionResult> UploadFile(IFormFile file)
        {
            if (file == null || file.Length == 0)
                return BadRequest("No file uploaded.");

            var path = Path.Combine("D:\\Intern Đại Phát\\quanlydienthoai\\Vuejs\\public\\images", file.FileName);

            using (var stream = new FileStream(path, FileMode.Create))
            {
                await file.CopyToAsync(stream);
            }

            return Ok(new { file.FileName, path });
        }
    }
}
