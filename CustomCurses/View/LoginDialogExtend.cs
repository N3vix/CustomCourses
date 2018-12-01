using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Interactivity;

namespace CustomCurses.View
{
    public class CloseWindowBehavior : Behavior<Window>
    {
        public bool CloseTrigger
        {
            get => (bool)GetValue(CloseTriggerProperty);
            set => SetValue(CloseTriggerProperty, value);
        }

        public static readonly DependencyProperty CloseTriggerProperty =
            DependencyProperty.Register("CloseTrigger", typeof(bool), typeof(CloseWindowBehavior), new PropertyMetadata(false, OnCloseTriggerChanged));

        private static void OnCloseTriggerChanged(DependencyObject d, DependencyPropertyChangedEventArgs e)
        {
            if (d is CloseWindowBehavior behavior)
            {
                behavior.OnCloseTriggerChanged();
            }
        }

        private void OnCloseTriggerChanged()
        {
            if (this.CloseTrigger)
            {
                this.AssociatedObject.Close();
            }
        }
    }
}
