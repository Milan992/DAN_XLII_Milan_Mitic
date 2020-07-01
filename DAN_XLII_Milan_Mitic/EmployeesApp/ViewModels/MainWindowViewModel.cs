using EmployeesApp.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using EmployeesApp;
using EmployeesApp.ViewModels;
using System.Windows;
using EmployeesApp.Views;

namespace EmployeesApp.ViewModels
{
    class MainWindowViewModel : ViewModelBase
    {
        Service service = new Service();
        MainWindow main;

        //constructors
        public MainWindowViewModel(MainWindow mainOpen)
        {
            main = mainOpen;
            employeesList = service.GetAllEmployees();
        }

        //properties
        private List<tblEmployee> employeesList;

        public List<tblEmployee> EmployeesList
        {
            get
            {
                return employeesList;
            }
            set
            {
                employeesList = value;
                OnPropertyChanged("EmployeesList");
            }
        }

        private vwEmployee employee;

        public vwEmployee Employee
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

        //Commands
        private ICommand deleteEmployee;

        public ICommand DeleteEmployee
        {
            get
            {
                if (deleteEmployee == null)
                {
                    deleteEmployee = new RelayCommand(param => DeleteEmployeeExecute(), param => CanDeleteEmployeeExecute());
                }

                return deleteEmployee;
            }
        }

        private void DeleteEmployeeExecute()
        {
            try
            {
                service.DeleteEmployee(employee.JMBG);
                MessageBox.Show("You deleted employee " + employee.FullName);
                EmployeesList = service.GetAllEmployees();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
        }

        private bool CanDeleteEmployeeExecute()
        {
            return true;
        }

        private ICommand addNewEmployee;

        public ICommand AddNewEmployee
        {
            get
            {
                if (addNewEmployee == null)
                {
                    addNewEmployee = new RelayCommand(param => AddNewEmployeeExecute(), param => CanAddNewEmployeeExecute());
                }

                return addNewEmployee;
            }
        }

        private void AddNewEmployeeExecute()
        {
            try
            {
                AddEmployee addEmployee = new AddEmployee();
                addEmployee.ShowDialog();
                EmployeesList = service.GetAllEmployees();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
        }

        private bool CanAddNewEmployeeExecute()
        {
            return true;
        }
    }
}
