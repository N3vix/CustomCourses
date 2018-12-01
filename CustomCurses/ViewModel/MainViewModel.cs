using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using CustomCurses.View;
using CustomCursesLibrary.Models;
using GalaSoft.MvvmLight;
using GalaSoft.MvvmLight.Command;

namespace CustomCurses.ViewModel
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
            var dialog = new LoginDialog()
            {
                DataContext = new LoginDialogViewModel()
            };
            var result = dialog.ShowDialog();
            if (!result.HasValue || !result.Value) return;
        }

        private void OpenSelectedCourseCommandExecute()
        {
            SelectedCourseModeFirst = !_selectedCourseMode;
        }
    }
}