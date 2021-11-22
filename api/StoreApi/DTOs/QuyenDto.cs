using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace StoreApi.Models
{
    public class QuyenDto
    {
        public int Id { get; set;}

        [Required(ErrorMessage = "Tên quyền bắt buộc")]
        
        public string name { get; set; }

        [Required(ErrorMessage = "Chi tiết quyền bắt buộc")]
        public string details { get; set; }

        public ICollection<NhanVien> NhanViens { get; set; }

    }
}