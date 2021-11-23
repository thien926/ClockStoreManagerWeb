using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace StoreApi.Models
{
    public class NCC
    {
        public int Id {get; set;}

        [Required(ErrorMessage = "Tên nhà cung cấp là bắt buộc")]
        [StringLength(maximumLength:200, MinimumLength = 3, ErrorMessage = "Tên nhà cung cấp từ 3 đến 200 kí tự")]
        public string name { get; set;}

        [Required(ErrorMessage = "Địa chỉ là bắt buộc")]
        public string address { get; set; }
        
        [Required(ErrorMessage = "Số điện thoại là bắt buộc")]
        [RegularExpression(pattern: @"^(09|03|07|08|05)+([0-9]{8})")]
        [StringLength(10, ErrorMessage = "Số điện thoại có 10 kí tự")] 
        public string phone{get; set;}
        public string fax { get; set; }
        public ICollection<SanPham> SanPhams { get; set; }
        public ICollection<PhieuNhap> phieuNhaps { get; set; }
        public NCC(){
            SanPhams = new HashSet<SanPham>();
            phieuNhaps = new HashSet<PhieuNhap>();
        }
    }
}