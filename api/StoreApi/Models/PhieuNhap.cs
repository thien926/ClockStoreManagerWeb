using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace StoreApi.Models
{
    public class PhieuNhap
    {
        public int Id{get; set;}

        [Required(ErrorMessage = "Mã nhà cung cấp là bắt buộc")]
        public int nccId {get; set;}

        [Required(ErrorMessage = "Mã nhân viên bắt buộc")]
        [StringLength(maximumLength:25, MinimumLength = 3, ErrorMessage = "Mã nhân viên từ 3 đến 25 kí tự")]
        [RegularExpression(pattern: @"^[a-zA-Z][\w]{1,}", ErrorMessage="Mã nhân viên phải bắt đầu bằng chữ")]
        public string NVuser { get; set;}

        [Required(ErrorMessage = "Số điện thoại là bắt buộc")]
        [RegularExpression(pattern: @"^(09|03|07|08|05)+([0-9]{8})")]
        [StringLength(10, ErrorMessage = "Số điện thoại có 10 kí tự")] 
        public string phone{get; set;}

        [Required(ErrorMessage = "Địa chỉ là bắt buộc")]
        public string address { get; set; }

        [Required(ErrorMessage = "Ngày nhận là bắt buộc")]
        [DataType(DataType.Date)]
        public DateTime date_receice{get; set;}

        [Required(ErrorMessage = "Tổng là bắt buộc")]
        public long total { get; set;}

        [Required(ErrorMessage = "Trạng thái là bắt buộc")]
        public int status { get; set;}

        public virtual NCC ncc { get; set;}
        public virtual NhanVien NV { get; set; }
        public ICollection<ChiTietPN> chitietPNs {get; set;}

        public PhieuNhap (){
            total = 0;
            status = 1;
            this.chitietPNs = new HashSet<ChiTietPN>();
        }
    }
}