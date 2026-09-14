using System.ComponentModel;
using System.Windows.Input;
using WpfMVVM.Models;
using WpfMVVM.Service;
using WpfMVVM.Commands;

namespace WpfMVVM.ViewModels
{
    public class MainViewModel : INotifyPropertyChanged
    {
        private List<Cat> listaMedKatter;

        public List<Cat> Cats
        {
            get { return listaMedKatter; }
            set
            {
                listaMedKatter = value;

                PropertyChanged?.Invoke(
                    this,
                    new PropertyChangedEventArgs(nameof(Cats)));
            }
        }


        private Cat valdKatt;

        public Cat SelectedCat
        {
            get { return valdKatt; }

            set
            {
                valdKatt = value;

                PropertyChanged?.Invoke(
                    this,
                    new PropertyChangedEventArgs(nameof(SelectedCat)));
            }
        }
       
        public event PropertyChangedEventHandler PropertyChanged;


        private CatService catService;

        

        public async Task LoadCats()
        {
            Cats = await catService.GetCats();
        }

        public ICommand LoadCatsCommand { get; }

        public MainViewModel()
        {
            catService = new CatService();
            LoadCatsCommand = new RelayCommand(() => LoadCats());
        }




    }

}
