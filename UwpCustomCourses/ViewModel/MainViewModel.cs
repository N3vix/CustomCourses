using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Threading.Tasks;
using Windows.Data.Xml.Dom;
using Windows.UI.Notifications;
using Windows.UI.Xaml.Controls;
using GalaSoft.MvvmLight;
using GalaSoft.MvvmLight.Command;
using UwpCustomCourses.Helpers;
using UwpCustomCourses.View;
using UwpCustomCursesLibrary.Helpers;
using UwpCustomCursesLibrary.Models;

namespace UwpCustomCourses.ViewModel
{
    public class MainViewModel : ViewModelBase
    {
        public MainViewModel()
        {
            LoginCommand = new RelayCommand(LoginCommandExecute);
            RegistrationCommand = new RelayCommand(RegistrationCommandExecute);
            BackToMainPageCommand = new RelayCommand(BackToMainPageExecute);

            _coursesCollection = new ObservableCollection<Course>()
            {
                new Course()
                {
                    Name ="d1asda",
                    Description = "Dasdas",
                    StartTime = DateTime.Now
                },
                new Course()
                {
                    Name ="d2asda",
                    Description = "Dasdas",
                    StartTime = DateTime.Now
                },
                new Course()
                {
                    Name ="d3asda",
                    Description = "Dasdas",
                    StartTime = DateTime.Now
                },
                new Course()
                {
                    Name ="d4asda",
                    Description = "Dasdas",
                    StartTime = DateTime.Now
                },
                new Course()
                {
                    Name ="d5asda",
                    Description = "Dasdas",
                    StartTime = DateTime.Now
                },
                new Course()
                {
                    Name ="d6asda",
                    Description = "Dasdas",
                    StartTime = DateTime.Now
                },
                new Course()
                {
                    Name ="dasda",
                    Description = "Dasdas",
                    StartTime = DateTime.Now
                },
                new Course()
                {
                    Name ="dasda",
                    Description = "Dasdas",
                    StartTime = DateTime.Now
                },
                new Course()
                {
                    Name ="dasda",
                    Description = "Dasdas",
                    StartTime = DateTime.Now
                },
                new Course()
                {
                    Name ="dasda",
                    Description = "Dasdas",
                    StartTime = DateTime.Now
                },
            };
        }

        private ObservableCollection<Course> _coursesCollection;
        public IEnumerable<Course> CoursesCollection => _coursesCollection;

        private Course _selectedCourse;
        public Course SelectedCourse
        {
            get => _selectedCourse;
            set
            {
                if (value == null) return;
                _selectedCourse = value;
                PreviousPages.Add(_selectedNvPage);
                _selectedNvPage = new SelectedCoursesNVPage();
                RaisePropertyChanged(nameof(SelectedNvPage));
                RaisePropertyChanged(nameof(SelectedCourse));
            }
        }
        
        public List<Page> PreviousPages = new List<Page>();

        private Page _selectedNvPage;
        public Page SelectedNvPage
        {
            get => _selectedNvPage;
            set
            {
                _selectedNvPage = value;
                RaisePropertyChanged(nameof(SelectedNvPage));
            }
        }

        private object _selectedNvItem;
        public object SelectedNvItem
        {
            get => _selectedNvItem;
            set
            {
                BackToMainPageExecute();
                   _selectedNvItem = value;
                SelectedNvPage = SwitchMenuItemToPage(value as NavigationViewItem);
                RaisePropertyChanged(nameof(SelectedNvItem));
            }
        }

        public ObservableCollection<NVItem> MenuItems => new ObservableCollection<NVItem>
        {
            new NVItem() { Text = "Home", Icon = Symbol.Home, ItemType = NVItemEnum.NVItemItem},
            new NVItem() { Text = "", ItemType = NVItemEnum.NVItemSeparator},
            new NVItem() { Text = "Account", ItemType = NVItemEnum.NVItemHeader},
            new NVItem() { Text = "Login", Icon = Symbol.Contact , ItemType = NVItemEnum.NVItemItem},
        };
        private Page SwitchMenuItemToPage(NavigationViewItem item)
        {
            switch (item.Content)
            {
                case "Home":
                    return new MainNVPage();
                case "Login":
                    return new LoginNVPage();
            }
            return null;
        }

        private string _nickName;
        public string NickName
        {
            get => _nickName;
            set
            {
                _nickName = value;
                RaisePropertyChanged(nameof(NickName));
            }
        }

        private string _password;
        public string Password
        {
            get => _password;
            set
            {
                _password = value;
                RaisePropertyChanged(nameof(Password));
            }
        }

        private User _authorisedUser;
        public User AuthorisedUser
        {
            get => _authorisedUser;
            set
            {
                _authorisedUser = value;
                RaisePropertyChanged(nameof(AuthorisedUser));
            }
        }

        public RelayCommand LoginCommand { get; }
        public RelayCommand RegistrationCommand { get; }
        public RelayCommand BackToMainPageCommand { get; }

        private void LoginCommandExecute()
        {
            if (string.IsNullOrEmpty(NickName))
            {
                ToastNotifications.ShowToastNotification("Login page", "Please, enter a username");
                return;
            }
            if (string.IsNullOrEmpty(Password))
            {
                ToastNotifications.ShowToastNotification("Login page", "Please, enter a password");
                return;
            }
            string result;
            try
            {
                result = Task.Run(async () => await DbRequests.GetUserByUserName(NickName)).Result;
            }
            catch (Exception exc)
            {
                ToastNotifications.ShowToastNotification("Login page", exc.Message);
                return;
            }
            var user = JsonSerialization<User>.GetModel(result);
            if (user == null ||
                !PasswordHashHelpers.VerifyPasswordHash(Password, user.PasswordHash, user.PasswordSalt)) return;
            AuthorisedUser = user;
        }
        private void RegistrationCommandExecute()
        {
        }
        private void BackToMainPageExecute()
        {
            if (!PreviousPages.Any()) return;
            SelectedNvPage = PreviousPages.Last();
            PreviousPages.Remove(PreviousPages.Last());
            _selectedCourse = null;
        }
    }
}