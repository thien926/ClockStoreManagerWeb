using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace StoreApi.Models
{
    public class KieuMayDto
    {
        public int Id { get; set; }

        [Required(ErrorMessage = "Tên Kiểu Máy là bắt Buộc")]
        public string name { get; set; }
        public ICollection<SanPham> SanPhams { get; set; }
    }
}