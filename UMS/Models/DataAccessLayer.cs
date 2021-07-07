using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data;
using System.Linq;
using System.Threading.Tasks;
using UMS.Utility;

namespace UMS.Models {
    public class DataAccessLayer {
        string connectionString = ConnectionString.getConnection;

        public IEnumerable<User> GetAllUsers() {
            List<User> UsersList = new List<User>();
            using(SqlConnection con = new SqlConnection(connectionString)) {
                SqlCommand cmd = new SqlCommand("spGetAllUsers", con);
                cmd.CommandType = CommandType.StoredProcedure;
                con.Open();
                SqlDataReader rdr = cmd.ExecuteReader();

                while(rdr.Read()) {
                    User user = new User();
                    user.UserID = Convert.ToInt32(rdr["UserID"]);
                    user.Username = rdr["Username"].ToString();
                    user.Password = rdr["Password"].ToString();
                    user.Firstname = rdr["Firstname"].ToString();
                    user.Lastname = rdr["Lastname"].ToString();
                    user.Email = rdr["Email"].ToString();
                    user.Phonenumber = rdr["Phonenumber"].ToString();
                    user.Department = Convert.ToInt32(rdr["Department"]);

                    UsersList.Add(user);
                }
                con.Close();
            }
            return UsersList;
        }

        public void AddUser(User user) {
            using(SqlConnection con = new SqlConnection(connectionString)) {
                SqlCommand cmd = new SqlCommand("spAddUser", con);
                cmd.CommandType = CommandType.StoredProcedure;

                cmd.Parameters.AddWithValue("@Username", user.Username);
                cmd.Parameters.AddWithValue("@Password", user.Password);
                cmd.Parameters.AddWithValue("@Firstname", user.Firstname);
                cmd.Parameters.AddWithValue("@Lastname", user.Lastname);
                cmd.Parameters.AddWithValue("@Email", user.Email);
                cmd.Parameters.AddWithValue("@Phonenumber", user.Phonenumber);
                cmd.Parameters.AddWithValue("@Department", user.Department);
                con.Open();
                cmd.ExecuteNonQuery();
                con.Close();
            }
        }

        public void UpdateUser(User user) {
            using(SqlConnection con = new SqlConnection(connectionString)) {
                SqlCommand cmd = new SqlCommand("spUpdateUser", con);
                cmd.CommandType = CommandType.StoredProcedure;

                cmd.Parameters.AddWithValue("@UserID", user.UserID);
                cmd.Parameters.AddWithValue("@Username", user.Username);
                cmd.Parameters.AddWithValue("@Password", user.Password);
                cmd.Parameters.AddWithValue("@Firstname", user.Firstname);
                cmd.Parameters.AddWithValue("@Lastname", user.Lastname);
                cmd.Parameters.AddWithValue("@Email", user.Email);
                cmd.Parameters.AddWithValue("@Phonenumber", user.Phonenumber);
                cmd.Parameters.AddWithValue("@Department", user.Department);
                con.Open();
                cmd.ExecuteNonQuery();
                con.Close();
            }
        }

        public void DeleteUser(int? UserID) {
            using(SqlConnection con = new SqlConnection(connectionString)) {
                SqlCommand cmd = new SqlCommand("spDeleteUser", con);
                cmd.CommandType = CommandType.StoredProcedure;

                cmd.Parameters.AddWithValue("@UserID", UserID);
                con.Open();
                cmd.ExecuteNonQuery();
                con.Close();
            }
        }

        public User GetUser(int? UserID) {
            User user = new User();
            using(SqlConnection con = new SqlConnection(connectionString)) {
                string SqlQuery = "SELECT * FROM dbo.Users WHERE UserID = " + UserID;
                SqlCommand cmd = new SqlCommand(SqlQuery, con);
                con.Open();
                SqlDataReader rdr = cmd.ExecuteReader();

                while(rdr.Read()) {
                    user.UserID = Convert.ToInt32(rdr["UserID"]);
                    user.Username = rdr["Username"].ToString();
                    user.Password = rdr["Password"].ToString();
                    user.Firstname = rdr["Firstname"].ToString();
                    user.Lastname = rdr["Lastname"].ToString();
                    user.Email = rdr["Email"].ToString();
                    user.Phonenumber = rdr["Phonenumber"].ToString();
                    user.Department = Convert.ToInt32(rdr["Department"]);
                }
                con.Close();
            }
            return user;
        }
    }
}
