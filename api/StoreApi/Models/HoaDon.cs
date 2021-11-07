using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace StoreApi.Models
{
    public class HoaDon
    {
        public int Id{get; set;}

        [Required(ErrorMessage = "Mã khách hàng là bắt buộc")]
        [StringLength(maximumLength:25, MinimumLength = 3, ErrorMessage = "Mã khách hàng từ 3 đến 25 kí tự")]
        [RegularExpression(pattern: @"^[a-zA-Z][\w]{1,}", ErrorMessage="Mã khách hàng phải bắt đầu bằng chữ")]
        public string KHuser {get; set;}
        public string NVuser { get; set;}

        [Required(ErrorMessage = "Số điện thoại là bắt buộc")]
        [RegularExpression(pattern: "^([\\d]{10,11})", ErrorMessage="Số điện thoại phải là số và dài từ 10 đến 11")]
        public string phone{get; set;}

        [Required(ErrorMessage = "Địa chỉ là bắt buộc")]
        public string address {get; set;}

        [DataType(DataType.Date)]
        public DateTime? date_receice{get; set;}

        [Required(ErrorMessage = "Ngày đặt là bắt buộc")]
        [DataType(DataType.Date)]
        public DateTime date_order{get; set;}

        public long total { get; set;}

        public int status { get; set;}

        public virtual KhachHang KH { get; set;}
        public virtual NhanVien NV { get; set; }
        public ICollection<ChiTietHD> chitietHDs {get; set;}

        public HoaDon (){
            total = 0;
            status = 1;
            this.chitietHDs = new HashSet<ChiTietHD>();
        }
    }
}