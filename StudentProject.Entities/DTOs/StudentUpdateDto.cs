using StudentProject.Shared.Utilities.Results.Abstract;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StudentProject.Entities.DTOs
{
    public class StudentUpdateDto : DtoGetBase
    {
        [Required]
        public int Id { get; set; }
        
        [DisplayName("Öğrenci Adı")]
        [Required(ErrorMessage = "{0} Boş Geçilmemelidir.")]
        [MaxLength(50, ErrorMessage = "{0} {1} karakterden büyük olmamalıdır.")]
        [MinLength(3, ErrorMessage = "{0} {1} karakterden küçük olmamalıdır.")]
        public string Name { get; set; }
        
        [DisplayName("Öğrenci Soyadı")]
        [Required(ErrorMessage = "{0} Boş Geçilmemelidir.")]
        [MaxLength(50, ErrorMessage = "{0} {1} karakterden büyük olmamalıdır.")]
        [MinLength(3, ErrorMessage = "{0} {1} karakterden küçük olmamalıdır.")]
        public string LastName { get; set; }
        
        [DisplayName("Öğrenci Numarası")]
        [MaxLength(25, ErrorMessage = "{0} {1} karakterden büyük olmamalıdır.")]
        [MinLength(3, ErrorMessage = "{0} {1} karakterden küçük olmamalıdır.")]
        public string Number { get; set; }
        
        [DisplayName("Öğrenci Özel Not Alanı")]
        [MaxLength(500, ErrorMessage = "{0} {1} karakterden büyük olmamalıdır.")]
        [MinLength(3, ErrorMessage = "{0} {1} karakterden küçük olmamalıdır.")]
        public string Note { get; set; }
        
        [DisplayName("Aktif Mi?")]
        [Required(ErrorMessage = "{0} Boş Geçilmemelidir.")]
        public bool IsActive { get; set; }
        
        [DisplayName("Silindi Mi?")]
        [Required(ErrorMessage = "{0} Boş Geçilmemelidir.")]
        public bool IsDeleted { get; set; }
    }
}
