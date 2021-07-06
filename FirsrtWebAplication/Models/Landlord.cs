using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace FirsrtWebAplication.Models
{
    public class Landlord
    {
         
        //int landlordid;
        //string firstname;
        //string lastname;
        //string phone;
        [Required]       
        public int Landlordid { set; get; }

        [Required]
        [DisplayName("First Name")]
        [StringLength(20)]
        public string Firstname { set; get; }

        [Required]
        [DisplayName("Last Name")]
        [StringLength(20)]
        public string Lastname { set; get; }

        [Required]
        [DisplayName("Phone")]
        [StringLength(12)]
        public string Phone { set; get; }

        public Landlord()
        {

        }
        //public Landlord(string landlordid, string firstname, string lastname, string phone)
        //{
        //    Landlordid = this.landlordid;
        //    Firstname = this.firstname;
        //    Lastname = this.lastname;
        //    Phone = this.phone;

        //}

        public override string ToString()
        {
            string t = $"Landlord:{Landlordid} FirstName:{Firstname} LastName: {Lastname} Phone:{Phone}";
            return t;
        }

    }
}