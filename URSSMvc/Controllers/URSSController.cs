using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Data;
using System.Data.SqlClient;
using MySql.Data.MySqlClient;
using URSSMvc.Models;

namespace URSSMvc.Controllers
{
    public class URSSController : Controller
    {
        string connectionString = "datasource=127.0.0.1;port=3306;username=root;password=;database=urssmvc;";

        // GET: URSS
        [HttpGet]
        public ActionResult Index()
        {
            DataTable dtblUrss = new DataTable();
            using (MySqlConnection sqlCon = new MySqlConnection(connectionString))
            {
                sqlCon.Open();
                MySqlDataAdapter sqlDa = new MySqlDataAdapter("SELECT * FROM peuple", sqlCon);
                sqlDa.Fill(dtblUrss);
            }
            return View(dtblUrss);
        }

        // GET: URSS/Create
        [HttpGet]
        public ActionResult Create()
        {
            return View(new PeupleModel());
        }

        // POST: URSS/Create
        [HttpPost]
        public ActionResult Create(PeupleModel peupleModel)
        {
            using (MySqlConnection sqlCon = new MySqlConnection(connectionString))
            {
                sqlCon.Open();
                string query = "INSERT INTO peuple (Nom, Age, Ville) VALUES(@Nom, @Age, @Ville)";
                MySqlCommand sqlCmd = new MySqlCommand(query, sqlCon);
                sqlCmd.Parameters.AddWithValue("@Nom", peupleModel.Nom);
                sqlCmd.Parameters.AddWithValue("@Age", peupleModel.Age);
                sqlCmd.Parameters.AddWithValue("@Ville", peupleModel.Ville);
                sqlCmd.ExecuteNonQuery();
            }
            return RedirectToAction("Index");
        }

        // GET: URSS/Edit/5
        public ActionResult Edit(int id)
        {
            PeupleModel peupleModel = new PeupleModel();
            DataTable dtblPeuple = new DataTable();
            using (MySqlConnection sqlCon = new MySqlConnection(connectionString))
            {
                sqlCon.Open();
                string query = "SELECT * FROM peuple WHERE PersonneID = @PersonneID";
                MySqlDataAdapter sqlDa = new MySqlDataAdapter(query, sqlCon);
                sqlDa.SelectCommand.Parameters.AddWithValue("@PersonneID", id);
                sqlDa.Fill(dtblPeuple);
            }
            if(dtblPeuple.Rows.Count == 1)
            {
                peupleModel.PersonneID = Convert.ToInt32(dtblPeuple.Rows[0][0].ToString());
                peupleModel.Nom = dtblPeuple.Rows[0][1].ToString();
                peupleModel.Age = Convert.ToInt32(dtblPeuple.Rows[0][2].ToString());
                peupleModel.Ville = dtblPeuple.Rows[0][3].ToString();

                return View(peupleModel);
            }
            else
                return RedirectToAction("Index");
        }

        // POST: URSS/Edit/5
        [HttpPost]
        public ActionResult Edit(PeupleModel peupleModel)
        {
            using (MySqlConnection sqlCon = new MySqlConnection(connectionString))
            {
                sqlCon.Open();
                string query = "UPDATE peuple SET Nom = @Nom, Age = @Age, Ville = @Ville WHERE PersonneID = @PersonneID";
                MySqlCommand sqlCmd = new MySqlCommand(query, sqlCon);
                sqlCmd.Parameters.AddWithValue("@PersonneID", peupleModel.PersonneID);
                sqlCmd.Parameters.AddWithValue("@Nom", peupleModel.Nom);
                sqlCmd.Parameters.AddWithValue("@Age", peupleModel.Age);
                sqlCmd.Parameters.AddWithValue("@Ville", peupleModel.Ville);
                sqlCmd.ExecuteNonQuery();
            }
            return RedirectToAction("Index");
        }

        // GET: URSS/Delete/5
        public ActionResult Delete(int id)
        {
            using (MySqlConnection sqlCon = new MySqlConnection(connectionString))
            {
                sqlCon.Open();
                string query = "DELETE FROM peuple WHERE PersonneID = @PersonneID";
                MySqlCommand sqlCmd = new MySqlCommand(query, sqlCon);
                sqlCmd.Parameters.AddWithValue("@PersonneID", id);
                sqlCmd.ExecuteNonQuery();
            }
            return RedirectToAction("Index");
        }
    }
}
