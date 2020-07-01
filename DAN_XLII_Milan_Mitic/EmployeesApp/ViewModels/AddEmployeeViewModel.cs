using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EmployeesApp.Model;
using EmployeesApp.ViewModels;
using EmployeesApp.Views;

namespace EmployeesApp.ViewModels
{
    class AddEmployeeViewModel : ViewModelBase
    {
        AddEmployee addEmployee = new AddEmployee();
        Service service = new Service();

        //constructors

        public AddEmployeeViewModel(AddEmployee addEmployeeOpen)
        {
            employee = new tblEmployee();
            addEmployee = addEmployeeOpen;

            LocationList = service.GetAllLocations();
            ManagerList = service.GetAllManagers(Employee.JMBG);
        }

        public AddEmployeeViewModel(AddEmployee addEmployeeOpen, tblEmployee employeeEdit)
        {
            employee = employeeEdit;
            addEmployee = addEmployeeOpen;

            LocationList = service.GetAllLocations();
            ManagerList = service.GetAllManagers(Employee.JMBG);
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
    }
}
