using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;
namespace StoreApi.DTOs
{
    public class NCCDto
    {
        public int Id {get; set;}

        [Required(ErrorMessage = "Tên nhà cung cấp là bắt buộc")]
        [StringLength(maximumLength:200, MinimumLength = 3, ErrorMessage = "Tên nhà cung cấp từ 3 đến 200 kí tự")]
        public string name { get; set;}

        [Required(ErrorMessage = "Địa chỉ là bắt buộc")]
        public string address { get; set; }
        
        [Required(ErrorMessage = "Số điện thoại là bắt buộc")]
        [StringLength(10, ErrorMessage = "Số điện thoại có 10 kí tự")] 
        public string phone{get; set;}
        public string fax { get; set; }
    }
}