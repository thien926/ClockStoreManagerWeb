using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace StoreApi.Models
{
    public class KhachHangDto
    {
        // public int Id { get; set; }

        [Required(ErrorMessage = "Tài khoản bắt buộc")]

        public string user{get; set;}

        [Required(ErrorMessage = "Mật khẩu là bắt buộc")]
        // [StringLength(maximumLength:25, MinimumLength = 4, ErrorMessage = "Mật khẩu từ 4 đến 25 kí tự")]
        public string password{get; set;}

        [Required(ErrorMessage = "Họ tên là bắt buộc")]

        public string name{ get; set; }

        [Required(ErrorMessage = "Số điện thoại là bắt buộc")]

        public string phone{get; set;}

        [Required(ErrorMessage = "Thư điện tử là bắt buộc")]

        public string mail{get; set;}

        [Required(ErrorMessage = "Địa chỉ là bắt buộc")]
        public string address { get; set; }

        [Required(ErrorMessage = "Giới tính là bắt buộc")]

        public string gender { get; set; }

        [Required(ErrorMessage = "Ngày sinh là bắt buộc")]

        public DateTime dateborn{get; set;}

        [Required(ErrorMessage = "Trạng thái là bắt buộc")]

        public int status{get; set;}

        public ICollection<HoaDon> hoadons {get; set;}

    }
}