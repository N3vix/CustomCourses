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

        public List<object> PreviousMenuItems = new List<object>();
        public List<Page> PreviousPages = new List<Page>();

        private Page _selectedNvPage;
        public Page SelectedNvPage
        {
            get => _selectedNvPage;
            set
            {
                if(_selectedNvPage != null) PreviousPages.Add(_selectedNvPage);
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
                if (_selectedNvItem != null) PreviousMenuItems.Add(_selectedNvItem);
                _selectedNvItem = value;
                SelectedNvPage = MenuItemToPage(value as NavigationViewItem);
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
        private Page MenuItemToPage(NavigationViewItem item)
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

        public MainViewModel()
        {
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
    }
}