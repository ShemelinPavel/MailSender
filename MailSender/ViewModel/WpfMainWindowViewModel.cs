using System;
using System.Collections.ObjectModel;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using GalaSoft.MvvmLight;
using WpfMailSender.lib.Data.LinqToSQL;
using WpfMailSender.lib.Services.Interfaces;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using GalaSoft.MvvmLight.Command;

namespace WpfMailSender.ViewModel
{
    public class WpfMainWindowViewModel : ViewModelBase
    {
        private string _title = "Рассылка писем wpf+mvvm";
        private readonly IRecipientsData recipData;
        private ObservableCollection<Recipient> recipCol;
        private Recipient selrecipient;
        private TabControl maintabcontrol;

        public string mvvmTitle
        {
            get => _title;
            set => Set ( ref _title, value );
        }

        public TabControl mvvmMainTabControl
        {
            get => maintabcontrol;
            set => Set ( ref maintabcontrol, value );
        }


        public ObservableCollection<Recipient> mvvmRecipients
        {
            get => recipCol;
            private set => Set ( ref recipCol, value );
        }

        public Recipient mvvmSelectedRecipient
        {
            get => selrecipient;
            set => Set ( ref selrecipient, value );
        }

        public WpfMainWindowViewModel ( IRecipientsData recipientsData )
        {
            recipData = recipientsData;

            mvvmWpfMainWindowLoaded = new RelayCommand<Window> ( OnWpfMainWindowLoadedExecute, CanWpfMainWindowLoadedExecute );
            mvvmWriteRecipientDataCommand = new RelayCommand<Recipient> ( OnWriteRecipientDataCommandExecute, CanWriteRecipientDataCommandExecute );
            mvvmCreateRecipientDataCommand = new RelayCommand ( OnCreateRecipientDataCommandExecute, CanCreateRecipientDataCommandExecute );
            mvvvmCloseWpfMainWindowCommand = new RelayCommand<Window> ( OnCloseWpfMainWindowCommandExecute, CanCloseWpfMainWindowCommandExecute );
            mvvvmGotoSchedulerCommand = new RelayCommand<TabControl> ( OnGotoSchedulerCommandExecute, CanGotoSchedulerCommandExecute );

            mvvvmClickLeftArrowTabItemsControlCommand = new RelayCommand ( OnClickLeftArrowTabItemsControlCommandExecute, CanClickLeftArrowTabItemsControlCommandExecute );
            mvvvmClickRightArrowTabItemsControlCommand = new RelayCommand ( OnClickRightArrowTabItemsControlCommandExecute, CanClickRightArrowTabItemsControlCommandExecute );
        }

        private void LoadData ()
        {
            mvvmRecipients = new ObservableCollection<Recipient> ( recipData.GetAll () );
        }

        #region Commands
        public ICommand mvvmWpfMainWindowLoaded { get; }
        public ICommand mvvmWriteRecipientDataCommand { get; }
        public ICommand mvvmCreateRecipientDataCommand { get; }
        public ICommand mvvvmCloseWpfMainWindowCommand { get; }
        public ICommand mvvvmGotoSchedulerCommand { get; }
        public ICommand mvvvmClickLeftArrowTabItemsControlCommand { get; }
        public ICommand mvvvmClickRightArrowTabItemsControlCommand { get; }

        #endregion

        private bool CanWpfMainWindowLoadedExecute (Window window) => true;
        private void OnWpfMainWindowLoadedExecute ( Window window )
        {

            mvvmMainTabControl = ((WpfMailSender.MainWindow)window).MainTabControl;
            LoadData ();
        }

        private bool CanCloseWpfMainWindowCommandExecute ( Window window ) => true;

        private void OnCloseWpfMainWindowCommandExecute ( Window window )
        {
            window.Close ();
        }

        private bool CanGotoSchedulerCommandExecute ( TabControl tab ) => true;

        private void OnGotoSchedulerCommandExecute ( TabControl tab )
        {
            if (tab.Items.Count == 0) return;

            tab.SelectedIndex = 1;
        }

        private bool CanClickLeftArrowTabItemsControlCommandExecute () => true;

        private void OnClickLeftArrowTabItemsControlCommandExecute ()
        {
            if (mvvmMainTabControl.Items.Count == 0) return;

            if (mvvmMainTabControl.SelectedIndex > 0)
            {
                mvvmMainTabControl.SelectedIndex--;
            }
            else
            {
                mvvmMainTabControl.SelectedIndex = mvvmMainTabControl.Items.Count - 1;
            }
        }

        private bool CanClickRightArrowTabItemsControlCommandExecute () => true;

        private void OnClickRightArrowTabItemsControlCommandExecute ()
        {
            if (mvvmMainTabControl.Items.Count == 0) return;

            if (mvvmMainTabControl.SelectedIndex < mvvmMainTabControl.Items.Count - 1)
            {
                mvvmMainTabControl.SelectedIndex++;
            }
            else
            {
                mvvmMainTabControl.SelectedIndex = 0;
            }
        }

        private bool CanWriteRecipientDataCommandExecute ( Recipient recipient ) => recipient != null;

        private void OnWriteRecipientDataCommandExecute ( Recipient recipient )
        {
            recipData.Write ( recipient );
            recipData.Save ();
        }

        private bool CanCreateRecipientDataCommandExecute () => true;

        private void OnCreateRecipientDataCommandExecute ()
        {
            var newrecip = new Recipient { Description = "New recipient", Email = "test@mail.ru" };
            int newid = recipData.Create ( newrecip );
            if (newid != 0)
            {
                recipCol.Add ( newrecip );
                mvvmSelectedRecipient = newrecip;
            }
        }
    }
}
