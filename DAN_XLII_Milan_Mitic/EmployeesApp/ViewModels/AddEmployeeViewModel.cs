using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Input;
using EmployeesApp.Model;
using EmployeesApp.ViewModels;
using EmployeesApp.Views;

namespace EmployeesApp.ViewModels
{
    class AddEmployeeViewModel : ViewModelBase
    {
        AddEmployee addEmployee;
        Service service = new Service();
        BackgroundWorker worker = new BackgroundWorker();

        //constructors

        public AddEmployeeViewModel(AddEmployee addEmployeeOpen)
        {
            employee = new tblEmployee();
            addEmployee = addEmployeeOpen;

            worker.DoWork += worker_DoWork;

            LocationList = service.GetAllLocations();
           // ManagerList = service.GetAllManagers(Employee.JMBG);
        }

        public AddEmployeeViewModel(AddEmployee addEmployeeOpen, tblEmployee employeeEdit)
        {
            employee = employeeEdit;
            addEmployee = addEmployeeOpen;
            worker.DoWork += worker_DoWork;

            LocationList = service.GetAllLocations();
          //  ManagerList = service.GetAllManagers(Employee.JMBG);
        }

        private void worker_DoWork(object sender, DoWorkEventArgs e)
        {
            service.AddEmployee(employee, sector, location);
        }
        // properties

        private tblEmployee employee;

        public tblEmployee Employee
        {
            get
            {
                return employee;
            }
            set
            {
                employee = value;
                OnPropertyChanged("Employee");
            }
        }

        private List<string> locationList;

        public List<string> LocationList
        {
            get { return locationList; }
            set
            {
                locationList = value;
                OnPropertyChanged("LocationList");
            }
        }

        private string sector;

        public string Sector
        {
            get { return sector; }
            set
            {
                sector = value;
                OnPropertyChanged("Issuer");
            }
        }

        private string location;

        public string Location
        {
            get { return location; }
            set
            {
                location = value;
                OnPropertyChanged("Location");
            }
        }

        private List<tblEmployee> managerList;

        public List<tblEmployee> ManagerList
        {
            get { return managerList; }
            set
            {
                managerList = value;
                OnPropertyChanged("ManagerList");
            }
        }

        //commands

        private ICommand save;

        public ICommand Save
        {
            get
            {
                if (save == null)
                {
                    save = new RelayCommand(param => SaveExecute(), param => CanSaveExecute());
                }

                return save;
            }
        }

        private void SaveExecute()
        {
            try
            {
                try
                {
                    worker.RunWorkerAsync();
                }
                catch
                {
                    MessageBox.Show("Already saving. . .");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
        }

        private bool CanSaveExecute()
        {
            if (string.IsNullOrEmpty(employee.JMBG))    // validacija jmbg
            {
                return false;
            }
            else
            {
                return true;

            }
        }
        private ICommand close;

        public ICommand Close
        {
            get
            {
                if (close == null)
                {
                    close = new RelayCommand(param => CloseExecute(), param => CanCloseExecute());
                }

                return close;
            }
        }

        private void CloseExecute()
        {
            try
            {
                addEmployee.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
        }

        private bool CanCloseExecute()
        {
            return true;
        }
    }
}

