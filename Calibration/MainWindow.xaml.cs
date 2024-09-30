using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace Calibration
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();

            // Set DataContext to allow xaml and partial class interaction
            this.DataContext = userDC;
        }

        // Initialize global datacontext
        public UserDataContext userDC = new UserDataContext
        {
            // Initialize starting values for program
            PositiveCalVal = new CalValues { Measured = 0.0, Current = 0.0, Stored = 0.0, },
            NegativeCalVal = new CalValues { Measured = 0.0, Current = 0.0, Stored = 0.0, },
        };
        #region Plus and Minus Buttons
        private void Button_Click_Plus_Pos(object sender, RoutedEventArgs e)
        {
            increasePositive();
        }

        private void increasePositive()
        {
            userDC.PositiveCalVal.Current = Math.Round(userDC.PositiveCalVal.Current + 0.1, 2);
            BindingOperations.GetBindingExpression(CurrVpPlus, TextBlock.TextProperty).UpdateTarget();
        }

        private void Button_Click_Minus_Pos(object sender, RoutedEventArgs e)
        {
            decreasePositive();
        }

        private void decreasePositive()
        {
            userDC.PositiveCalVal.Current = Math.Round(userDC.PositiveCalVal.Current - 0.1, 2);
            BindingOperations.GetBindingExpression(CurrVpPlus, TextBlock.TextProperty).UpdateTarget();
        }

        private void Button_Click_Plus_Neg(object sender, RoutedEventArgs e)
        {
            increaseNegative();
        }

        private void increaseNegative()
        {
            userDC.NegativeCalVal.Current = Math.Round(userDC.NegativeCalVal.Current + 0.1, 2);
            BindingOperations.GetBindingExpression(CurrVpMin, TextBlock.TextProperty).UpdateTarget();
        }

        private void Button_Click_Minus_Neg(object sender, RoutedEventArgs e)
        {
            decreaseNegative();
        }

        private void decreaseNegative()
        {
            userDC.NegativeCalVal.Current = Math.Round(userDC.NegativeCalVal.Current - 0.1, 2);
            BindingOperations.GetBindingExpression(CurrVpMin, TextBlock.TextProperty).UpdateTarget();
        }

        #endregion
        private void Button_Click_Save_Cal_Values(object sender, RoutedEventArgs e)
        {
            // save Positive calibration values
            if (userDC.PositiveCalVal.Current != userDC.PositiveCalVal.Stored)
            {

            }

            // save Negative calibration values
            if (userDC.NegativeCalVal.Current != userDC.NegativeCalVal.Stored)
            {

            }
        }
        public class CalValues
        {
            // Constructor
            public CalValues()
            {

            }

            public double Measured { get; set; }
            public double Current { get; set; }
            public double Stored { get; set; }
        }

        /**
         * Class containing both negative and positive values.
         */
        public class UserDataContext
        {
            // Constructor
            public UserDataContext()
            {

            }

            public CalValues PositiveCalVal { get; set; }
            public CalValues NegativeCalVal { get; set; }
        }
        private void Button_Click_DCorvus_Messages(object sender, RoutedEventArgs e)
        {
            ComPortWindow objComPortWindow = new ComPortWindow();
            //this.Visibility = Visibility.Hidden;
            objComPortWindow.Show();
        }
    }
}