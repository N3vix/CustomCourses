using System;
using System.Windows;
using System.Windows.Controls.Primitives;

namespace CustomCurses
{
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        private void FrameworkElement_OnSizeChanged(object sender, SizeChangedEventArgs e)
        {
            if (!(sender is UniformGrid uniformgrid)) throw new ArgumentNullException(nameof(uniformgrid));
            var math = uniformgrid.Children.Count / 3.0;
            uniformgrid.Height = Math.Ceiling(math) * 100;
            uniformgrid.VerticalAlignment = VerticalAlignment.Top;
        }
    }
}
