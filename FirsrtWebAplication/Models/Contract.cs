using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace FirsrtWebAplication.Models
{
    public class Contract
    {


        //int contractid;
        //string renterid;
        //string hiredid;
        //string propertyid;
        //string startdatetime;
        //string enddatetime;
        [Required]
        public int Contractid { set; get; }
        [Required]
        public int Renterid { set; get; }
        [Required]
        public int Hiredid { set; get; }
        [Required]
        public int Propertyid { set; get; }
        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}",ApplyFormatInEditMode = true)]
        public DateTime Startdatetime { set; get; }
        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}", ApplyFormatInEditMode = true)]
        public DateTime Enddatetime { set; get; }

        public Contract()
        {

        }
    }
}