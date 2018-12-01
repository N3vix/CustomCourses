using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using Windows.UI.Xaml.Controls;
using GalaSoft.MvvmLight;
using GalaSoft.MvvmLight.Command;
using UwpCustomCourses.View;
using UwpCustomCursesLibrary.Models;

namespace UwpCustomCourses.ViewModel
{
    public class MainViewModel : ViewModelBase
    {
        private ObservableCollection<Course> _coursesCollection;
        public IEnumerable<Course> CoursesCollection => _coursesCollection;

        private Course _selectedCourse;
        public Course SelectedCourse
        {
            get => _selectedCourse;
            set
            {
                _selectedCourse = value;
                RaisePropertyChanged(nameof(SelectedCourse));
            }
        }

        private bool _selectedCourseMode = true;
        public bool SelectedCourseModeFirst
        {
            get => _selectedCourseMode;
            set
            {
                _selectedCourseMode = value;
                RaisePropertyChanged(nameof(SelectedCourseModeFirst));
            }
        }

        private Page _selectedNvPage = new MainNVPage();
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
        public object SelectedNvPage1
        {
            get => _selectedNvItem;
            set
            {
                _selectedNvItem = value;
                RaisePropertyChanged(nameof(SelectedNvPage1));
            }
        }

        public ObservableCollection<NVItem> MenuItems => new ObservableCollection<NVItem>()
        {
            new NVItem() { Text = "Home", Icon = "", ItemType = NVItemEnum.NVItemItem},
            new NVItem() { Text = "Ho1me", Icon = "" , ItemType = NVItemEnum.NVItemItem},
            new NVItem() { Text = "Ho121me", Icon = "" , ItemType = NVItemEnum.NVItemItem},
            new NVItem() { Text = "Ho121me", Icon = "" , ItemType = NVItemEnum.NVItemSeparator},
            new NVItem() { Text = "Ho121me", Icon = "" , ItemType = NVItemEnum.NVItemHeader},
            new NVItem() { Text = "Ho121me", Icon = "" , ItemType = NVItemEnum.NVItemItem},
        };

        public bool SelectedCourseModeSecond => !_selectedCourseMode;

        public RelayCommand OpenLoginDialogCommand { get; }
        public RelayCommand OpenSelectedCourseCommand { get; }

        public MainViewModel()
        {
            OpenLoginDialogCommand = new RelayCommand(OpenLoginDialogCommandExecute);
            OpenSelectedCourseCommand = new RelayCommand(OpenSelectedCourseCommandExecute);
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

        private void OpenLoginDialogCommandExecute()
        {
            //var dialog = new LoginDialog()
            //{
            //    DataContext = new LoginDialogViewModel()
            //};
            //var result = dialog.ShowDialog();
            //if (!result.HasValue || !result.Value) return;
        }

        private void OpenSelectedCourseCommandExecute()
        {
            SelectedCourseModeFirst = !_selectedCourseMode;
        }
    }
}