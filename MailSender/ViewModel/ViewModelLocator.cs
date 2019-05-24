/*
  In App.xaml:
  <Application.Resources>
      <vm:ViewModelLocator xmlns:vm="clr-namespace:WpfMailSender"
                           x:Key="Locator" />
  </Application.Resources>
  
  In the View:
  DataContext="{Binding Source={StaticResource Locator}, Path=ViewModelName}"

  You can also use Blend to do all this with the tool's support.
  See http://www.galasoft.ch/mvvm
*/

using CommonServiceLocator;
using GalaSoft.MvvmLight;
using GalaSoft.MvvmLight.Ioc;
using WpfMailSender.lib.Data.LinqToSQL;
using WpfMailSender.lib.Services;
using WpfMailSender.lib.Services.Interfaces;
using WpfMailSender.lib.Services.LinqToSQL;
//using Microsoft.Practices.ServiceLocation;

namespace WpfMailSender.ViewModel
{
    /// <summary>
    /// This class contains static references to all the view models in the
    /// application and provides an entry point for the bindings.
    /// </summary>
    public class ViewModelLocator
    {
        /// <summary>
        /// Initializes a new instance of the ViewModelLocator class.
        /// </summary>
        public ViewModelLocator()
        {
            ServiceLocator.SetLocatorProvider(() => SimpleIoc.Default);

            ////if (ViewModelBase.IsInDesignModeStatic)
            ////{
            ////    // Create design time view services and models
            ////    SimpleIoc.Default.Register<IDataService, DesignDataService>();
            ////}
            ////else
            ////{
            ////    // Create run time view services and models
            ////    SimpleIoc.Default.Register<IDataService, DataService>();
            ////}
            if (!SimpleIoc.Default.IsRegistered<MailSenderDB> ()) SimpleIoc.Default.Register ( () => new MailSenderDB () );
            SimpleIoc.Default.Register<IRecipientsData, RecipientsDataLinqToSQL> ();

            //SimpleIoc.Default.Unregister<WpfMainWindowViewModel> ();
            SimpleIoc.Default.Register<WpfMainWindowViewModel> ();

        }

        public WpfMainWindowViewModel WpfMainWindowModel => ServiceLocator.Current.GetInstance<WpfMainWindowViewModel>();

        public static void Cleanup()
        {
            // TODO Clear the ViewModels
        }
    }
}