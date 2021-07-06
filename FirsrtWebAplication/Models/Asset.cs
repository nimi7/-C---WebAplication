using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace FirsrtWebAplication.Models
{
    public class Asset
    {

        [Required]
        public int AssetID { set; get; }
        [Required]
        public int Landlordid { set; get; }
        [Required]
        public int Cityid { set; get; }
        [DisplayName("Street")]
        [StringLength(30)]
        public string Street { set; get; }
        [StringLength(30)]
        [DisplayName("Nighorhood")]
        public string Neighborhood { set; get; }
        [StringLength(30)]
        [DisplayName("House Number")]
        public string HouseNumber { set; get; }
        [StringLength(30)]
        [DisplayName("Floor")]
        public string Floor { set; get; }
        [StringLength(30)]
        [DisplayName("Elevator")]
        public string Elevators { set; get; }
        [StringLength(30)]
        [DisplayName("Property tax")]
        public string Propertytax { set; get; }
        [StringLength(30)]
        [DisplayName("Rooms")]
        public string Rooms { set; get; }



        public Asset()
        {
        }

        public Asset(int assetID, int landlordid, int cityid, string street, string neighborhood, string houseNumber, string floor, string elevators, string propertytax, string rooms)
        {
            AssetID = assetID;
            Landlordid = landlordid;
            Cityid = cityid;
            Street = street;
            Neighborhood = neighborhood;
            HouseNumber = houseNumber;
            Floor = floor;
            Elevators = elevators;
            Propertytax = propertytax;
            Rooms = rooms;
        }

        public override string ToString()
        {
            string t = $"AssetID: {AssetID} Landlord: {Landlordid} CityID:{Cityid} Street:{Street} Neighborhood:{Neighborhood} " +
                $"HouseNumber: {HouseNumber} Floor: {Floor} Elevators: {Elevators} PropertyTax: {Propertytax} Rooms: {Rooms}  ";
            return t;
        }
    }
}