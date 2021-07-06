using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FirsrtWebAplication;
using System.Configuration;
using FirsrtWebAplication.Models;
using System.Web.Mvc;
using Microsoft.VisualBasic.ApplicationServices;
using Users = FirsrtWebAplication.Models.Users;
using FirsrtWebAplication.Controllers;

namespace FirsrtWebAplication
{
    public class BLL//a
    {

        static string newConnectString = ConfigurationManager.ConnectionStrings["SQL_AsseManagement"].ConnectionString;

        //public IDataReader Search(string TableName, string obj)
        //{
        //    DAl l = new DAl(newConnectString);

        //    string ID = obj;
        //    string TableID = TableName + "ID";

        //    IDataReader data = l.ExecuteReader1("Select * from " + TableName + " where " + TableID + " = " + ID + "");


        //    //while (data.Read())
        //    //{
        //    //    obj = (

        //    //      TextBoxLord.Text += data.GetInt32(0),
        //    //     TextBoxLord.Text += "- " + data.GetString(1),
        //    //     TextBoxLord.Text += " - " + data.GetString(2),
        //    //     TextBoxLord.Text += "- " + data.GetString(3));

        //    //}

        //    return data;

        //}
        //public void SearchByID(string TableName, string obj, string text)
        //{
        //    DAl l = new DAl(newConnectString);

        //    string ID = obj;
        //    string TableID = TableName + "ID";

        //    IDataReader data = l.ExecuteReader1("Select * from " + TableName + " where " + TableID + " = " + ID + "");


        //    data.Read();
        //    for (int i = 0; i < data.FieldCount; i++)
        //    {

        //        if ((data[i].GetType() == ID.GetType()))
        //        {
        //            text += "- " + data.GetString(i);
        //        }
        //        else
        //        {
        //            text += "-" + data.GetInt32(i);
        //        }
        //    }

        //}

        //public string Print(IDataReader data)
        //{
        //    string text = null;
        //    string ID = "";
        //    for (int i = 0; i < data.FieldCount; i++)
        //    {

        //        if (data[i].GetType() == ID.GetType())
        //        {
        //            text += " - " + data.GetString(i);
        //        }
        //        else
        //        {
        //            text += " - " + data.GetInt32(i);
        //        }
        //    }
        //    return text;
        //}
        public List<Tenant> SesrchAllTenant()
        {
            List<Tenant> tenants = new List<Tenant>();
            DAL l = new DAL(newConnectString);
            IDbConnection connection;

            List<IDbDataParameter> parmters = new List<IDbDataParameter>();

            string sql = "select * from Hired";

            IDataReader data = l.EndExecuteReader(sql, out connection, parmters);
            while (data.Read())
            {
                Tenant tenants1 = new Tenant();

                tenants1.Tenantid = data.GetInt32(0);
                tenants1.FirstName = data.GetString(1);
                tenants1.LastName = data.GetString(2);
                tenants1.Phone = data.GetString(3);

                tenants.Add(tenants1);
            }
            l.Close(connection);
            return tenants;
        }
        public List<Tenant> SearchTenant(string id)
        {
            List<Tenant> tenants1 = new List<Tenant>();
            DAL l = new DAL(newConnectString);
            IDbConnection connection;

            List<IDbDataParameter> parmters = new List<IDbDataParameter>();
            parmters.Add(l.CreateParamter("@Id", DbType.Int32, id));

            string sql = "select * from Hired where HiredID=@Id";

            IDataReader data = l.EndExecuteReader(sql, out connection, parmters);


            while (data.Read())
            {
                Tenant tenants = new Tenant();

                tenants.Tenantid = data.GetInt32(0);
                tenants.FirstName = data.GetString(1);
                tenants.LastName = data.GetString(2);
                tenants.Phone = data.GetString(3);

                tenants1.Add(tenants);
            }
            l.Close(connection);
            return tenants1;
        }

        public List<Landlord> SearchAllLandlord()
        {
            List<Landlord> tenants = new List<Landlord>();
            DAL l = new DAL(newConnectString);
            IDbConnection connection;

            List<IDbDataParameter> parmters = new List<IDbDataParameter>();

            string sql = "select * from Renter";

            IDataReader data = l.EndExecuteReader(sql, out connection, parmters);
            while (data.Read())
            {
                Landlord tenants1 = new Landlord();

                tenants1.Landlordid = data.GetInt32(0);
                tenants1.Firstname = data.GetString(1);
                tenants1.Lastname = data.GetString(2);
                tenants1.Phone = data.GetString(3);

                tenants.Add(tenants1);
            }
            l.Close(connection);
            return tenants;
        }
        public List<Landlord> SearchLandlord(string id)
        {
            List<Landlord> land = new List<Landlord>();
            DAL l = new DAL(newConnectString);
            IDbConnection connection;

            List<IDbDataParameter> parmters = new List<IDbDataParameter>();
            parmters.Add(l.CreateParamter("@Id", DbType.Int32, id));

            string sql = "select * from Renter where RenterID = @Id";

            IDataReader data = l.EndExecuteReader(sql, out connection, parmters);


            while (data.Read())
            {
                Landlord landlord = new Landlord();

                landlord.Landlordid = data.GetInt32(0);
                landlord.Firstname = data.GetString(1);
                landlord.Lastname = data.GetString(2);
                landlord.Phone = data.GetString(3);

                land.Add(landlord);
            }
            l.Close(connection);
            return land;
        }

        public List<Asset> searchAsset(string id)
        {
            List<Asset> asset = new List<Asset>();
            DAL l = new DAL(newConnectString);
            IDbConnection connection;

            List<IDbDataParameter> parmters = new List<IDbDataParameter>();
            parmters.Add(l.CreateParamter("@Id", DbType.Int32, id));

            string sql = "select * from Property where PropertyID=@Id";

            IDataReader data = l.EndExecuteReader(sql, out connection, parmters);


            while (data.Read())
            {
                Asset assets = new Asset();

                assets.AssetID = data.GetInt32(0);
                assets.Landlordid = data.GetInt32(1);
                assets.Cityid = data.GetInt32(2);
                assets.Street = data.GetString(3);
                assets.Neighborhood = data.GetString(4);
                assets.HouseNumber = data.GetString(5);
                assets.Floor = data.GetString(6);
                assets.Elevators = data.GetString(7);
                assets.Propertytax = data.GetString(8);
                assets.Rooms = data.GetString(9);

                asset.Add(assets);
            }
            l.Close(connection);
            return asset;
        }

        public List<Asset> SearchAllAsset()
        {
            List<Asset> assets = new List<Asset>();
            DAL l = new DAL(newConnectString);
            IDbConnection connection;

            List<IDbDataParameter> parmters = new List<IDbDataParameter>();

            string sql = "select * from Property";

            IDataReader data = l.EndExecuteReader(sql, out connection, parmters);
            while (data.Read())
            {
                Asset asset = new Asset();

                asset.AssetID = data.GetInt32(0);
                asset.Landlordid = data.GetInt32(1);
                asset.Cityid = data.GetInt32(2);
                asset.Street = data.GetString(3);
                asset.Neighborhood = data.GetString(4);
                asset.HouseNumber = data.GetString(5);
                asset.Floor = data.GetString(6);
                asset.Elevators = data.GetString(7);
                asset.Propertytax = data.GetString(8);
                asset.Rooms = data.GetString(9);



                assets.Add(asset);
            }
            l.Close(connection);
            return assets;
        }
        public void CreatAsset(Asset ass)
        {
            DAL l = new DAL(newConnectString);
            List<IDbDataParameter> parameters = new List<IDbDataParameter>();
            string Query = "INSERT INTO Property(PropertyID,RenterID,CityID,Street,Neighborhood,HouseNumber,Floor,Elevators,Propertytax,Rooms) " +
                "VaLUES(@PropertyID,@RenterID,@CityID,@Street,@Neighborhood,@HouseNumber,@Floor,@Elevators,@Propertytax,@Rooms)";
            parameters.Add(l.CreateParamter("@PropertyID", DbType.Int32, ass.AssetID));
            parameters.Add(l.CreateParamter("@RenterID", DbType.Int32, ass.Landlordid));
            parameters.Add(l.CreateParamter("@CityID", DbType.Int32, ass.Cityid));
            parameters.Add(l.CreateParamter("@Street", DbType.String, ass.Street));
            parameters.Add(l.CreateParamter("@Neighborhood", DbType.String, ass.Neighborhood));
            parameters.Add(l.CreateParamter("@HouseNumber", DbType.String, ass.HouseNumber));
            parameters.Add(l.CreateParamter("@Floor", DbType.String, ass.Floor));
            parameters.Add(l.CreateParamter("@Elevators", DbType.String, ass.Elevators));
            parameters.Add(l.CreateParamter("@Propertytax", DbType.String, ass.Propertytax));
            parameters.Add(l.CreateParamter("@Rooms", DbType.String, ass.Rooms));

            l.ExecuteNonQuery(Query, parameters);
            if (parameters != null)
            {

                //  MessageBox.Show("Creat Asset Sucsses ^_^");
            }


        }

        public void CreatTenant(Tenant T)
        {
            DAL l = new DAL(newConnectString);
            List<IDbDataParameter> parameters = new List<IDbDataParameter>();

            string Query = "INSERT INTO Hired(HiredID,FirstName,LastName,Phone)" +
                "VALUES(@HiredID,@FirstName,@LastName,@Phone)";
            parameters.Add(l.CreateParamter("@HiredID", DbType.Int32, T.Tenantid));
            parameters.Add(l.CreateParamter("@FirstName", DbType.String, T.FirstName));
            parameters.Add(l.CreateParamter("@LastName", DbType.String, T.LastName));
            parameters.Add(l.CreateParamter("@Phone", DbType.String, T.Phone));
            l.ExecuteNonQuery(Query, parameters);
            if (parameters != null)
            {

                // MessageBox.Show("Creat Tenant Sucsses ^_^");
            }


        }

        public void CreatLandlord(Landlord land)
        {
            DAL l = new DAL(newConnectString);
            List<IDbDataParameter> parameters = new List<IDbDataParameter>();

            string Query = "INSERT INTO Renter(RenterID,FirstName,LastName,Phone)" +
                "VALUES(@RenterID,@FirstName,@LastName,@Phone)";
            parameters.Add(l.CreateParamter("@RenterID", DbType.Int32, land.Landlordid));
            parameters.Add(l.CreateParamter("@FirstName", DbType.String, land.Firstname));
            parameters.Add(l.CreateParamter("@LastName", DbType.String, land.Lastname));
            parameters.Add(l.CreateParamter("@Phone", DbType.String, land.Phone));
            l.ExecuteNonQuery(Query, parameters);
            if (parameters != null)
            {

                // MessageBox.Show("Creat Landlord Sucsses ^_^");
            }

        }
        public void AssetUpDate(Asset ass)
        {
            DAL l = new DAL(newConnectString);
            List<IDbDataParameter> parameters = new List<IDbDataParameter>();
            string Query = "UPDATE  Property SET RenterID = @RenterID ,CityID = @CityID,Street = @Street," +
                "Neighborhood = @Neighborhood,HouseNumber = @HouseNumber,Floor = @Floor,Elevators = @Elevators,Propertytax = @Propertytax,Rooms = @Rooms " +
                "WHERE PropertyID = @propertyID ";
            parameters.Add(l.CreateParamter("@PropertyID", DbType.Int32, ass.AssetID));
            parameters.Add(l.CreateParamter("@RenterID", DbType.Int32, ass.Landlordid));
            parameters.Add(l.CreateParamter("@CityID", DbType.Int32, ass.Cityid));
            parameters.Add(l.CreateParamter("@Street", DbType.String, ass.Street));
            parameters.Add(l.CreateParamter("@Neighborhood", DbType.String, ass.Neighborhood));
            parameters.Add(l.CreateParamter("@HouseNumber", DbType.String, ass.HouseNumber));
            parameters.Add(l.CreateParamter("@Floor", DbType.String, ass.Floor));
            parameters.Add(l.CreateParamter("@Elevators", DbType.String, ass.Elevators));
            parameters.Add(l.CreateParamter("@Propertytax", DbType.String, ass.Propertytax));
            parameters.Add(l.CreateParamter("@Rooms", DbType.String, ass.Rooms));

            l.ExecuteNonQuery(Query, parameters);
        }
        public void ContractUpDate(Contract con)
        {
            DAL D = new DAL(newConnectString);
            List<IDbDataParameter> parameters = new List<IDbDataParameter>();
            string Query = "UPDATE Contract set  RenterID =@RenterID," +
                " HiredID = @HiredID, PropertyID = @PropertyID,StartDateTime = @StartDateTime ,EndDateTime=@EndDateTime " +
                "where ContractID = @ContractID ";
            parameters.Add(D.CreateParamter("@ContractID", DbType.Int32, con.Contractid));
            parameters.Add(D.CreateParamter("@RenterID", DbType.Int32, con.Renterid));
            parameters.Add(D.CreateParamter("@HiredID", DbType.Int32, con.Hiredid));
            parameters.Add(D.CreateParamter("@PropertyID", DbType.Int32, con.Propertyid));
            parameters.Add(D.CreateParamter("@StartDateTime", DbType.String, con.Startdatetime));
            parameters.Add(D.CreateParamter("@EndDateTime", DbType.String, con.Enddatetime));

            D.ExecuteNonQuery(Query, parameters);
        }

        public void CreateContract(Contract con)
        {
            DAL D = new DAL(newConnectString);
            List<IDbDataParameter> parameters = new List<IDbDataParameter>();
            parameters.Add(D.CreateParamter("@ContractID", DbType.Int32, con.Contractid));
            parameters.Add(D.CreateParamter("@RenterID", DbType.Int32, con.Renterid));
            parameters.Add(D.CreateParamter("@HiredID", DbType.Int32, con.Hiredid));
            parameters.Add(D.CreateParamter("@PropertyID", DbType.Int32, con.Propertyid));
            parameters.Add(D.CreateParamter("@StartDateTime", DbType.DateTime, con.Startdatetime));
            parameters.Add(D.CreateParamter("@EndDateTime", DbType.DateTime, con.Enddatetime));

            string sql = "INSERT INTO Contract(ContractID,RenterID,HiredID,PropertyID,StartDateTime,EndDateTime) " +
                "Values (@ContractID,@RenterID,@HiredID,@PropertyID,@StartDateTime,@EndDateTime)";

            int afctdet = D.ExecuteNonQuery(sql, parameters);
            if (afctdet > 0)
            {
                // MessageBox.Show("Lease has Save");
            }
            else
            {
                //  MessageBox.Show("Insert Fild");
            }
        }

        public List<City> SesrchAllCity()
        {
            List<City> city = new List<City>();
            DAL l = new DAL(newConnectString);
            IDbConnection connection;

            List<IDbDataParameter> parmters = new List<IDbDataParameter>();

            string sql = "select * from CityTable";

            IDataReader data = l.EndExecuteReader(sql, out connection, parmters);
            while (data.Read())
            {
                City c = new City();


                c.Cityid = data.GetInt32(0);
                c.CityName = data.GetString(1);
                city.Add(c);
            }
            l.Close(connection);
            return city;
        }

        public void CreatCity(City city)
        {
            DAL l = new DAL(newConnectString);
            List<IDbDataParameter> parameters = new List<IDbDataParameter>();

            string Query = "INSERT INTO CityTable(CityID,City)" +
                "VALUES(@CityID,@City)";
            parameters.Add(l.CreateParamter("@CityID", DbType.Int32, city.Cityid));
            parameters.Add(l.CreateParamter("@City", DbType.String, city.CityName));

            l.ExecuteNonQuery(Query, parameters);
            if (parameters != null)
            {

                // MessageBox.Show("Creat Tenant Sucsses ^_^");
            }


        }

        public List<Contract> SesrchAllContract()
        {
            List<Contract> city = new List<Contract>();
            DAL l = new DAL(newConnectString);
            IDbConnection connection;

            List<IDbDataParameter> parmters = new List<IDbDataParameter>();

            string sql = "select * from Contract";

            IDataReader data = l.EndExecuteReader(sql, out connection, parmters);
            while (data.Read())
            {
                Contract c = new Contract();


                c.Contractid = data.GetInt32(0);
                c.Renterid = data.GetInt32(1);
                c.Hiredid = data.GetInt32(2);
                c.Propertyid = data.GetInt32(3);
                c.Startdatetime = data.GetDateTime(4);
                c.Enddatetime = data.GetDateTime(5);
                city.Add(c);
            }
            l.Close(connection);
            return city;
        }
        public void CityUpDate(City city)
        {
            DAL l = new DAL(newConnectString);
            List<IDbDataParameter> parameters = new List<IDbDataParameter>();

            string Query = "UPDATE CityTable set City = @City where CityID = @CityID";

            parameters.Add(l.CreateParamter("@CityID", DbType.Int32, city.Cityid));
            parameters.Add(l.CreateParamter("@City", DbType.String, city.CityName));

            l.ExecuteNonQuery(Query, parameters);
            if (parameters != null) { }


        }

        public void LandlordUpDate(Landlord land)
        {

            DAL l = new DAL(newConnectString);
            List<IDbDataParameter> parameters = new List<IDbDataParameter>();

            string Query = "UPDATE Renter SET FirstName = @FirstName,LastName = @LastName,Phone = @Phone " +
                "WHERE RenterID = @RenterID";
            parameters.Add(l.CreateParamter("@RenterID", DbType.Int32, land.Landlordid));
            parameters.Add(l.CreateParamter("@FirstName", DbType.String, land.Firstname));
            parameters.Add(l.CreateParamter("@LastName", DbType.String, land.Lastname));
            parameters.Add(l.CreateParamter("@Phone", DbType.String, land.Phone));
            l.ExecuteNonQuery(Query, parameters);

        }

        public void TenantUpDate(Tenant tenant)
        {

            DAL l = new DAL(newConnectString);
            List<IDbDataParameter> parameters = new List<IDbDataParameter>();

            string Query = "UPDATE Hired SET FirstName = @FirstName,LastName = @LastName,Phone = @Phone " +
                "WHERE HiredID = @HiredID";
            parameters.Add(l.CreateParamter("@HiredID", DbType.Int32, tenant.Tenantid));
            parameters.Add(l.CreateParamter("@FirstName", DbType.String, tenant.FirstName));
            parameters.Add(l.CreateParamter("@LastName", DbType.String, tenant.LastName));
            parameters.Add(l.CreateParamter("@Phone", DbType.String, tenant.Phone));
            l.ExecuteNonQuery(Query, parameters);

        }

        public SelectList CityList(List<City> cities)
        {
            List<SelectListItem> list = new List<SelectListItem>();
            foreach (City city in cities)
            {
                list.Add(new SelectListItem()
                {
                    Text = city.CityName,
                    Value = city.Cityid.ToString()
                });
            }
            return new SelectList(list, "Value", "Text");


        }

        public SelectList TenantList(List<Tenant> tenants)
        {
            List<SelectListItem> list = new List<SelectListItem>();
            foreach (Tenant tenant in tenants)
            {
                list.Add(new SelectListItem()
                {
                    Text = tenant.FirstName,
                    Value = tenant.Tenantid.ToString()
                });
            }
            return new SelectList(list, "Value", "Text");

        }
        public SelectList LandlordList(List<Landlord> landlords)
        {
            List<SelectListItem> list = new List<SelectListItem>();
            foreach (Landlord land in landlords)
            {
                list.Add(new SelectListItem()
                {
                    Text = land.Firstname,
                    Value = land.Landlordid.ToString()
                });
            }
            return new SelectList(list, "Value", "Text");

        }
        public SelectList AssetList(List<Asset> ass)
        {
            List<SelectListItem> list = new List<SelectListItem>();
            foreach (Asset asset in ass)
            {
                list.Add(new SelectListItem()
                {
                    Text = asset.AssetID.ToString(),
                    Value = asset.AssetID.ToString()
                });
            }
            return new SelectList(list, "Value", "Text");

        }
        public List<Users> SesrchAllUsers()
        {
            List<Users> users = new List<Users>();
            DAL l = new DAL(newConnectString);
            IDbConnection connection;

            List<IDbDataParameter> parmters = new List<IDbDataParameter>();

            string sql = "select Users.UserID , UserName, Paswword,FullName, Email,RoleName" +
             " from Users " +
             " inner Join UserRole on Users.UserID = UserRole.UserID " +
              " inner join Roles on Roles.RoleID = UserRole.RoleID";

            IDataReader data = l.EndExecuteReader(sql, out connection, parmters);
            while (data.Read())
            {
                Users use = new Users();


                use.UserID = data.GetInt32(0);
                use.UserName = data.GetString(1);
                use.Password = data.GetString(2);
                use.FullName = data.GetString(3);
                use.Email = data.GetString(4);
               // use.RoleName = data.GetInt32(5);

                users.Add(use);
            }
            l.Close(connection);
            return users;
        }

        public void CreatUser(Users users)
        {
            DAL l = new DAL(newConnectString);
            List<IDbDataParameter> parameters = new List<IDbDataParameter>();

            string Query = "INSERT INTO Users(UserID,UserName,Paswword,FullName,Email,RoleName)" +
                "VALUES(@UserID,@UserName,@Paswword,@FullName,@Email,@RoleName)";
            parameters.Add(l.CreateParamter("@UserID", DbType.Int32, users.UserID));
            parameters.Add(l.CreateParamter("@UserName", DbType.String, users.UserName));
            parameters.Add(l.CreateParamter("@Paswword", DbType.String, users.Password));
            parameters.Add(l.CreateParamter("@FullName", DbType.String, users.FullName));
            parameters.Add(l.CreateParamter("@Email", DbType.String, users.Email));
            parameters.Add(l.CreateParamter("@RoleName", DbType.String, users.RoleName));

            l.ExecuteNonQuery(Query, parameters);
            if (parameters != null)
            {

                // MessageBox.Show("Creat Tenant Sucsses ^_^");
            }


        }

        public List<Roles> SesrchAllRoles()
        {
            List<Roles> city = new List<Roles>();
            DAL l = new DAL(newConnectString);
            IDbConnection connection;

            List<IDbDataParameter> parmters = new List<IDbDataParameter>();

            string sql = "select * from Roles";

            IDataReader data = l.EndExecuteReader(sql, out connection, parmters);
            while (data.Read())
            {
                Roles c = new Roles();


                c.RoleID = data.GetInt32(0);
                c.RoleName = data.GetString(1);
                city.Add(c);
            }
            l.Close(connection);
            return city;
        }

        public SelectList RolesList(List<Roles> ass)
        {
            List<SelectListItem> list = new List<SelectListItem>();
            foreach (Roles asset in ass)
            {
                list.Add(new SelectListItem()
                {
                    Text = asset.RoleName,
                    Value = asset.RoleID.ToString()
                }) ; 
            }
            return new SelectList(list, "Value", "Text");

        }


        public List<UserRole> SesrchAllUserRole()
        {
            List<UserRole> role = new List<UserRole>();
            DAL l = new DAL(newConnectString);
            IDbConnection connection;

            List<IDbDataParameter> parmters = new List<IDbDataParameter>();

            string sql = "select * from UserRole";

            IDataReader data = l.EndExecuteReader(sql, out connection, parmters);
            while (data.Read())
            {
                UserRole c = new UserRole();


                c.UserRolesID = data.GetInt32(0);
                c.UserID = data.GetInt32(1);
                c.RoleID = data.GetInt32(2);
                role.Add(c);
            }
            l.Close(connection);
            return role;
        }
        public SelectList UserRoleList(List<UserRole> ass)
        {
            List<SelectListItem> list = new List<SelectListItem>();
            foreach (UserRole asset in ass)
            {
                list.Add(new SelectListItem()
                {
                    Text = asset.UserRolesID.ToString(),
                    Value = asset.UserRolesID.ToString()
                });
            }
            return new SelectList(list, "Value", "Text");

        }

        public int CreatUsertest(Users users)
        {
            DAL l = new DAL(newConnectString);
            List<IDbDataParameter> parameters = new List<IDbDataParameter>();

            string Query = "INSERT INTO Users(UserID,UserName,Paswword,FullName,Email,RoleName)" +
                "VALUES(@UserID,@UserName,@Paswword,@FullName,@Email,@RoleName)";
            parameters.Add(l.CreateParamter("@UserID", DbType.Int32, users.UserID));
            parameters.Add(l.CreateParamter("@UserName", DbType.String, users.UserName));
            parameters.Add(l.CreateParamter("@Paswword", DbType.String, users.Password));
            parameters.Add(l.CreateParamter("@FullName", DbType.String, users.FullName));
            parameters.Add(l.CreateParamter("@Email", DbType.String, users.Email));
            parameters.Add(l.CreateParamter("@RoleName", DbType.String, users.RoleName));

            l.ExecuteNonQuery(Query, parameters);
            if (parameters != null)
            {

                // MessageBox.Show("Creat Tenant Sucsses ^_^");
            }

            return users.UserID;
        }

        public int CreatRoles(Roles roles)
        {
            DAL l = new DAL(newConnectString);
            List<IDbDataParameter> parameters = new List<IDbDataParameter>();

            string Query = "INSERT INTO Roles(RoleID,RoleName)" +
                "VALUES(@RoleID,@RoleName)";
            parameters.Add(l.CreateParamter("@UserID", DbType.Int32, roles.RoleID));
            parameters.Add(l.CreateParamter("@UserName", DbType.String, roles.RoleName));
            

            l.ExecuteNonQuery(Query, parameters);
            if (parameters != null)
            {

                // MessageBox.Show("Creat Tenant Sucsses ^_^");
            }

            return roles.RoleID;
        }


    }
}