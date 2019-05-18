using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace WpfMailSender.Components
{
    /// <summary>
    /// Логика взаимодействия для TabItemsControl.xaml
    /// </summary>
    public partial class TabItemsControl : UserControl
    {
        public event EventHandler LeftButtonClick;
        public event EventHandler RightButtonClick;

        private void OnLeftButtonClick ( EventArgs e ) => LeftButtonClick ( this, e );
        private void OnRightButtonClick ( EventArgs e ) => RightButtonClick ( this, e );

        public TabItemsControl ()
        {
            InitializeComponent ();
        }
               
        private void UniformGrid_Click ( object sender, RoutedEventArgs e )
        {
            if (!(e.Source is Button)) return;

            Button button = (Button)e.Source;

            switch (button.Name)
            {
                case "LeftArrowButton":
                    OnLeftButtonClick ( EventArgs.Empty );
                    break;
                case "RightArrowButton":
                    OnRightButtonClick ( EventArgs.Empty );
                    break;
            }
        }
    }
}