using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows;
using EmployeesApp.Model;

namespace EmployeesApp
{
    class Service
    {
        /// <summary>
        /// Reads all lines from a txt file and returns a list of strings with all lines from the file.
        /// </summary>
        /// <returns></returns>
        public List<string> GetAllLocations()
        {
            List<string> locations = new List<string>();
            try
            {
                using (StreamReader sr = new StreamReader("../../Locations.txt"))
                {
                    string line;
                    while ((line = sr.ReadLine()) != null)
                    {
                        locations.Add(line);
                    }
                }
            }
            catch 
            {
                MessageBox.Show("There are no locations available");
            }
            return locations;
        }

        public List<tblEmployee> GetAllEmployees()
        {
            try
            {
                using (EmployeesEntities context = new EmployeesEntities())
                {
                    List<tblEmployee> list = new List<tblEmployee>();
                    list = (from x in context.tblEmployees select x).ToList();
                    return list;
                }
            }
            catch (Exception ex)
            {
                System.Diagnostics.Debug.Write("Exception" + ex.Message.ToString());
                return null;
            }
        }

        public List<tblEmployee> GetAllManagers(string jMBG)
        {
            throw new NotImplementedException();
        }

        public void DeleteEmployee(string jMBG)
        {
            throw new NotImplementedException();
        }

        internal void AddEmployee(tblEmployee employee, string sector, string location)
        {
            Thread.Sleep(2000);
            try
            {
                using (EmployeesEntities context = new EmployeesEntities())
                {
                    employee.SectorID = Convert.ToInt32(sector);
                    employee.LocationOfEmployee = location;
                    context.tblEmployees.Add(employee);
                    context.SaveChanges();
                }
            }
            catch (Exception ex)
            {
                System.Diagnostics.Debug.Write("Exception" + ex.Message.ToString());
            }
        }
    }
}
