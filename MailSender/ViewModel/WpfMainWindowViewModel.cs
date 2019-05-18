using System;
using System.Collections.ObjectModel;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using GalaSoft.MvvmLight;
using WpfMailSender.lib.Data.LinqToSQL;
using WpfMailSender.lib.Services.Interfaces;
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


        public string mvvmTitle
        {
            get => _title;
            set => Set ( ref _title, value );
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

            mvvmRefreshDataCommand = new RelayCommand ( OnRefreshDataCommandExecute, CanRefreshDataCommandExecute );
        }

        private void LoadData ()
        {
            mvvmRecipients = new ObservableCollection<Recipient> ( recipData.GetAll () );
        }

        #region Commands
        public ICommand mvvmRefreshDataCommand { get; }
        #endregion

        private bool CanRefreshDataCommandExecute () => true;
        private void OnRefreshDataCommandExecute () => LoadData ();


    }
}
