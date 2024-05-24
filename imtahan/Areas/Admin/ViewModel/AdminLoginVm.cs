using System.ComponentModel.DataAnnotations;

namespace imtahan.Areas.Admin.ViewModel
{
    public class AdminLoginVm
    {


        [Required]
        [MaxLength(20)]
        [MinLength(5)]

        public string Login { get; set; }


        [Required]
        [MaxLength(20)]
        [MinLength(6)]
        [DataType(DataType.Password)]

        public string Password { get; set; }






    }
}
