using EmployeeManage;
using EmployeeManage.Models;
using EmployeeManage.OfflineStorage;
using EmployeeManage.ViewModels;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using Xamarin.Forms;
namespace Student_Management_1.ViewModels
{
    public class AddUpdatePageViewModel : BaseViewModel
    {
        private string _firstName;
        private string _lastName;
        private DateTime _dateofbirth;
        private string _address;
        private int _departmentId;
        private bool _rdbMale;
        private bool _rdbFemale;
        private string _title;
        private List<Departments> _departmentList;
        
        private string _package;
        private bool IsEnabled;
        private bool _isReadOnlyPage;
        readonly Employee _employee;
        public AddUpdatePageViewModel(Employee employee, bool isReadOnly = true)
        {
            _employee = employee;
            IsReadOnlyPage = isReadOnly;
            InitMe();
        }
        private async void InitMe()
        {
            DepartmentList = await DepartmentOperation.GetDepartmentsAsync();
            if (_employee != null)
            {
                Title = "Details for ID:" + _employee.ID;
                FirstName = _employee.FirstName;
                LastName = _employee.LastName;
                DateOfBirth = _employee.Birthday;
                Address = _employee.Address;
                DepartmentId = _employee.Department;
                if (_employee.Gender == 0)
                {
                    RdbMale = true;
                    RdbFemale = false;
                }
                else
                {
                    RdbMale = false;
                    RdbFemale = true;
                }
            }
            else
            {
                Title = "Add";
            }
        }
        public string Title
        {
            get => _title;
            set
            {
                if (value != _title)
                {
                    _title = value;
                    OnPropertyChanged(nameof(Title));
                }
            }
        }
        public string FirstName
        {
            get => _firstName;
            set
            {
                if (value != _firstName)
                {
                    _firstName = value;
                    OnPropertyChanged(nameof(FirstName));
                }
            }
        }
        public string LastName
        {
            get => _lastName;
            set
            {
                if (value != _lastName)
                {
                    _lastName = value;
                    OnPropertyChanged(nameof(LastName));
                }
            }
        }
        public DateTime DateOfBirth
        {
            get => _dateofbirth;
            set
            {
                if (value != _dateofbirth)
                {
                    _dateofbirth = value;
                    OnPropertyChanged(nameof(DateOfBirth));
                }
            }
        }
        public string Address
        {
            get => _address;
            set
            {
                if (value != _address)
                {
                    _address = value;
                    OnPropertyChanged(nameof(Address));
                }
            }
        }
        public int DepartmentId
        {
            get => _departmentId;
            set
            {
                if (value != _departmentId)
                {
                    _departmentId = value;
                    OnPropertyChanged(nameof(DepartmentId));
                }
            }
        }
        public List<Departments> DepartmentList
        {
            get => _departmentList;
            set
            {
                if (value != _departmentList)
                {
                    _departmentList = value;
                    OnPropertyChanged(nameof(DepartmentList));
                }
            }
        }
        public bool RdbMale
        {
            get => _rdbMale;
            set
            {
                if (value != _rdbMale)
                {
                    _rdbMale = value;
                    OnPropertyChanged(nameof(RdbMale));
                }
            }
        }
        public bool RdbFemale
        {
            get => _rdbFemale;
            set
            {
                if (value != _rdbFemale)
                {
                    _rdbFemale = value;
                    OnPropertyChanged(nameof(RdbFemale));
                }
            }
        }
        public string Package
        {
            get => _package;
            set
            {
                if (value != _package)
                {
                    _package = value;
                    OnPropertyChanged(nameof(Package));
                }
            }
        }

        public bool IsReadOnlyPage
        {
            get => _isReadOnlyPage;
            set
            {
                if (value != _isReadOnlyPage)
                {
                    _isReadOnlyPage = value;
                    OnPropertyChanged(nameof(IsReadOnlyPage));
                }
            }
        }

        private async Task<bool> Validate()
        {
            if (string.IsNullOrEmpty(FirstName))
            {
                await Application.Current.MainPage.DisplayAlert("Validation", "Please enter first name", "OK");
                return false;
            }
            else if (string.IsNullOrEmpty(LastName))
            {
                await Application.Current.MainPage.DisplayAlert("Validation", "Please enter Last name", "OK");
                return false;
            }
            else if (string.IsNullOrEmpty(Address))
            {
                await Application.Current.MainPage.DisplayAlert("Validation", "Please enter Address", "OK");
                return false;
            }
            else if (DepartmentId <= -1)
            {
                await Application.Current.MainPage.DisplayAlert("Validation", "Please select Department", "OK");
                return false;
            }
            else if (RdbFemale == false && RdbMale == false)
            {
                await Application.Current.MainPage.DisplayAlert("Validation", "Please choose gender", "OK");
                return false;
            }
            
            else if (string.IsNullOrEmpty(Package))
            {
                await Application.Current.MainPage.DisplayAlert("Validation", "Please enter package", "OK");
                return false;
            }
            return true;
        }
        public ICommand SaveCommand
        {
            get
            {
                return new Command(async () =>
                {
                    IsEnabled = false;
                    try
                    {
                        if (await Validate())
                        {
                            int id = 0;
                            if (_employee != null)
                                id = _employee.ID; int gender = 0;
                            if (RdbMale)
                                gender = 0;
                            else
                                gender = 1; Employee employee = new Employee()
                                {
                                    ID = id,
                                    FirstName = FirstName,
                                    LastName = LastName,
                                    Birthday = DateOfBirth,
                                    Address = Address,
                                    Department = DepartmentId,
                                    Gender = gender,
                                    Package = Package,
                                };
                            await EmployeeOperations.InsertOrUpdateEmployeeAsync(employee);
                            await Application.Current.MainPage.Navigation.PopAsync();
                        }
                    }
                    catch (Exception)
                    { }
                    await Task.Delay(500); IsEnabled = true;
                });

            }
        }
        public ICommand DeleteCommand
        {
            get
            {
                return new Command(async () =>
                {
                    IsEnabled = false; await Application.Current.MainPage.Navigation.PushAsync(new ListViewEmp());
                    await Task.Delay(500); IsEnabled = true;
                });
            }
        }
    }
}



