using DataHandlingMVC2.Models;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace DataHandlingMVC2.Controllers
{
    public class PersonController : Controller
    {
        string connectionString = "Server=ARYASHAJI\\SQLEXPRESS;Database=StaffManagement;Trusted_Connection=True";
        // GET: Person
        public ActionResult StudentDetail()
        {
            List<Person> persons = new List<Person>();

            SqlConnection connection = new SqlConnection(connectionString);
            connection.Open();

            SqlCommand command = new SqlCommand("PersonRead", connection);
            command.CommandType = System.Data.CommandType.StoredProcedure;


            SqlDataReader reader = command.ExecuteReader();
            while (reader.Read())
            {
                
                var person = new Person();
                person.ID = Convert.ToInt32(reader["Id"]);
                person.Name = reader["Name"].ToString();
                person.Class= reader["Class"].ToString();
                
                
                persons.Add(person);

            }

            return View(persons);
        }
            
        }
    }
