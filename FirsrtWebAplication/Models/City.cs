using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace FirsrtWebAplication.Models
{
    public class City
    {
       
        [Required]
        public int Cityid { get; set; }
        [Required]
        [StringLength(15)]
        [DisplayName("City")]
        public string CityName { get; set; }

        public City()
        {

        }

        public City(int cityid, string cityName)
        {
            Cityid = cityid;
            CityName = cityName;
        }
    }
}