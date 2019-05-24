using System;
using System.Collections.ObjectModel;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using GalaSoft.MvvmLight;
using WpfMailSender.lib.Entities;
using WpfMailSender.lib.Services.Interfaces;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using GalaSoft.MvvmLight.CommandWpf;
using System.Windows.Data;
using System.ComponentModel;

namespace WpfMailSender.ViewModel
{
    public class WpfMainWindowViewModel : ViewModelBase
    {
        private string _title = "Рассылка писем wpf+mvvm";
        private readonly IRecipientsData recipData;
        private ObservableCollection<Recipient> recipCol;
        private Recipient selRecipient;
        private TabControl mainTabControl;
        private string recipNameFilterText;
        private CollectionViewSource filtredRecipViewSource;

        public ICollectionView mvvmFiltredRecipients
        {
            get => filtredRecipViewSource?.View;
        }

        public string mvvmRecipientNameFilterText
        {
            get => recipNameFilterText;
            set
            {
                if(!Set ( ref recipNameFilterText, value )) return;
                mvvmFiltredRecipients?.Refresh ();
            }
        }

        public string mvvmTitle
        {
            get => _title;
            set => Set ( ref _title, value );
        }

        public TabControl mvvmMainTabControl
        {
            get => mainTabControl;
            set => Set ( ref mainTabControl, value );
        }


        public ObservableCollection<Recipient> mvvmRecipients
        {
            get => recipCol;
            set
            {
                if (!Set ( ref recipCol, value )) return;
                if(filtredRecipViewSource != null) filtredRecipViewSource.Filter -= OnFiltredRecipViewSource_Filter;
                filtredRecipViewSource = new CollectionViewSource { Source = value };
                filtredRecipViewSource.Filter += OnFiltredRecipViewSource_Filter;
                RaisePropertyChanged ( nameof ( mvvmFiltredRecipients ) );
            }
        }

        private void OnFiltredRecipViewSource_Filter ( object sender, FilterEventArgs e )
        {
            if (!(e.Item is Recipient recipient)) return;

            if (string.IsNullOrWhiteSpace(recipNameFilterText) || recipient.Name.IndexOf(recipNameFilterText, StringComparison.OrdinalIgnoreCase) >=0)
            {
                e.Accepted = true;
            }
        }

        public Recipient mvvmSelectedRecipient
        {
            get => selRecipient;
            set => Set ( ref selRecipient, value );
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

        private bool CanWpfMainWindowLoadedExecute ( Window window ) => true;
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
            recipData.Edit ( recipient );
            recipData.Save ();
        }

        private bool CanCreateRecipientDataCommandExecute () => true;

        private void OnCreateRecipientDataCommandExecute ()
        {
            var newrecip = new Recipient { Name = "New recipient", Email = "test@mail.ru" };
            int newid = recipData.Add ( newrecip );
            if (newid != 0)
            {
                recipCol.Add ( newrecip );
                mvvmSelectedRecipient = newrecip;
            }
        }
    }
}
