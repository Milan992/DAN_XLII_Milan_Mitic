using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

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
    }
}
