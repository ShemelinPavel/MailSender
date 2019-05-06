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
using System.Windows.Shapes;

namespace WpfMailSender
{
    /// <summary>
    /// Логика взаимодействия для InfoWindow.xaml
    /// </summary>
    public partial class InfoWindow : Window
    {
        public InfoWindow ( InfoType it = InfoType.Info )
        {
            InitializeComponent ();

            SetWindowType ( it );
        }

        private void Button_Click ( object sender, RoutedEventArgs e )
        {
            Close ();
        }

        void SetWindowType ( InfoType it )
        {
            if (it == InfoType.Error)
            {
                Title = "Ошибка:";
                InfoMessage.Foreground = new SolidColorBrush ( Colors.Red );
            }
            else
            {
                Title = "Инфо:";
                InfoMessage.Foreground = new SolidColorBrush ( Colors.Black );
            }
        }
    }
}
