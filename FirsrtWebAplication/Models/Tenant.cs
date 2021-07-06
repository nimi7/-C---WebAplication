using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace FirsrtWebAplication.Models
{
    public class Tenant
    {
               
        [Required]
        public int Tenantid { get; set; }
        [Required]
        [DisplayName("First Name:")]
        [StringLength(20)]
        public string FirstName { get; set; }
        [Required]
        [DisplayName("Last Name:")]
        [StringLength(20)]
        public string LastName { get; set; }
        [Required]
        [DisplayName("Phone:")]
        [StringLength(111)]
        public string Phone { get; set; }

        //public Tennant(int Tenantid, string Firstname, string LastName, string Phone)
        //{
        //    Tenantid = this.tenantid;
        //    FirstName = this.firstname;
        //    LastName = this.lastname;
        //    Phone = this.phone;


        //}

        public Tenant()
        {
        }

        public override string ToString()
        {
            string t = $"TenantID:{Tenantid} FirstName:{FirstName}LastName:{LastName}Phone:{Phone}";
            return t;
        }
    }
}