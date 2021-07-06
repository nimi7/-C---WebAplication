using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace FirsrtWebAplication.Models
{
    public class Users
    {
        [Required]
        public int UserID { set; get; }
        [Required, DataType (DataType.Text)]
        public string UserName { set; get; }
        [Required, DataType(DataType.Password)]
        public string Password { set; get; }
        [ScaffoldColumn(false)]
        public string FullName { set; get; }

        

        public string Email { set; get; }

        public int RoleName { get; set; }


        public Users()
        {

        }
    }
}