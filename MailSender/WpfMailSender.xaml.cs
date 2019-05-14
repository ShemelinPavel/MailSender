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

namespace WpfMailSender
{
    /// <summary>
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        /// <summary>
        /// конструктор окна
        /// </summary>
        public MainWindow ()
        {
            InitializeComponent ();
        }

        /// <summary>
        /// обработчик события нажатия пункта "Close" в меню
        /// </summary>
        /// <param name="sender">объект-инициатор</param>
        /// <param name="e">параметры события</param>
        private void MenuItem_Close_Click ( object sender, RoutedEventArgs e )
        {
            Close ();
        }

         /// <summary>
        /// обработчик события щелчка мышью "влево"
        /// </summary>
        /// <param name="sender">объект-инициатор</param>
        /// <param name="e">параметры события</param>
        private void TabItemsControl_LeftButtonClick ( object sender, EventArgs e )
        {
            if (MainTabControl.Items.Count == 0) return;

            if (MainTabControl.SelectedIndex > 0)
            {
                MainTabControl.SelectedIndex--;
            }
            else
            {
                MainTabControl.SelectedIndex = MainTabControl.Items.Count - 1;
            }
        }

        /// <summary>
        /// обработчик события щелчка мышью "вправо"
        /// </summary>
        /// <param name="sender">объект-инициатор</param>
        /// <param name="e">параметры события</param>
        private void TabItemsControl_RightButtonClick ( object sender, EventArgs e )
        {
            if (MainTabControl.Items.Count == 0) return;

            if (MainTabControl.SelectedIndex < MainTabControl.Items.Count - 1)
            {
                MainTabControl.SelectedIndex++;
            }
            else
            {
                MainTabControl.SelectedIndex = 0;
            }
        }
    }
}
