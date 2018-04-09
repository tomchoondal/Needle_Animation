using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Interactivity;

namespace Design_Test_TomJoseC
{
    public class ClickToDegreeBehavior: Behavior<UIElement>
    {
        private FrameworkElement button;
        int clickCount = 0;



        public string Text
        {
            get { return (string)GetValue(TextProperty); }
            set { SetValue(TextProperty, value); }
        }

        // Using a DependencyProperty as the backing store for Text.  This enables animation, styling, binding, etc...
        public static readonly DependencyProperty TextProperty =
            DependencyProperty.Register("Text", typeof(string), typeof(ClickToDegreeBehavior), new PropertyMetadata(string.Empty));


        public double DegreeToRotate
        {
            get { return (double)GetValue(DegreeToRotateProperty); }
            set { SetValue(DegreeToRotateProperty, value); }
        }

        // Using a DependencyProperty as the backing store for DegreeToRotate.  This enables animation, styling, binding, etc...
        public static readonly DependencyProperty DegreeToRotateProperty =
            DependencyProperty.Register("DegreeToRotate", typeof(double), typeof(ClickToDegreeBehavior), new PropertyMetadata(0.0));

        public double TargetAngle
        {
            get { return (double)GetValue(TargetAngleProperty); }
            set { SetValue(TargetAngleProperty, value); }
        }

        // Using a DependencyProperty as the backing store for TargetAngle.  This enables animation, styling, binding, etc...
        public static readonly DependencyProperty TargetAngleProperty =
            DependencyProperty.Register("TargetAngle", typeof(double), typeof(ClickToDegreeBehavior), new PropertyMetadata(0.0));
        

        protected override void OnAttached()
        {
            base.OnAttached();
            button = (AssociatedObject as Button);
            button.PreviewMouseDown += Button_PreviewMouseDown;
        }

        private void Button_PreviewMouseDown(object sender, System.Windows.Input.MouseButtonEventArgs e)
        {
            clickCount++;
            DegreeToRotate = clickCount * 10;
            TargetAngle = double.Parse(Text);
        }
        
        protected override void OnDetaching()
        {
            base.OnDetaching();
        }
    }
}
