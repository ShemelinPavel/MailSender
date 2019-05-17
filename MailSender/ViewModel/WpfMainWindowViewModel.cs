using System;
using System.Collections.ObjectModel;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using GalaSoft.MvvmLight;
using WpfMailSender.lib.Data.LinqToSQL;
using WpfMailSender.lib.Services.Interfaces;

namespace WpfMailSender.ViewModel
{
    public class WpfMainWindowViewModel : ViewModelBase
    {
        private string _title = "Рассылка писем wpf+mvvm";
        private readonly IRecipientsData recipData;
        private ObservableCollection<Recipient> recipCol;


        public string mvvmTitle
        {
            get => _title;
            set => Set ( ref _title, value );
        }

        public ObservableCollection<Recipient> mvvmRecipients
        {
            get => recipCol;
            set => Set ( ref recipCol, value );
        }

        public WpfMainWindowViewModel ( IRecipientsData recipientsData )
        {
            recipData = recipientsData;

            LoadData ();
        }

        private void LoadData ()
        {
            recipCol = new ObservableCollection<Recipient> ( recipData.GetAll () );
        }
    }
}
