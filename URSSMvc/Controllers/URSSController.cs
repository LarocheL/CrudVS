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
            return View();
        }

        // POST: URSS/Edit/5
        [HttpPost]
        public ActionResult Edit(int id, FormCollection collection)
        {
            try
            {
                // TODO: Add update logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: URSS/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: URSS/Delete/5
        [HttpPost]
        public ActionResult Delete(int id, FormCollection collection)
        {
            try
            {
                // TODO: Add delete logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }
    }
}
