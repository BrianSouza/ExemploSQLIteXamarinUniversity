using ExXUDataStorage.Models;
using System;
using Xamarin.Forms;
using System.Collections.ObjectModel;

namespace ExXUDataStorage
{
    public partial class MainPage : ContentPage
    {
        public MainPage()
        {
            InitializeComponent();            
        }

        public async  void OnNewButtonClicked(object sender, EventArgs args)
        {
            statusMessage.Text = "";
                        
            await App.PersonRepo.AddNewPerson(newPerson.Text);
            statusMessage.Text = App.PersonRepo.StatusMessage;
        }
        
        public async void OnGetButtonClicked(object sender, EventArgs args)
        {
            statusMessage.Text = "";

            ObservableCollection<Person> people = new ObservableCollection<Person>(await App.PersonRepo.GetAllPeople());
            peopleList.ItemsSource = people;
        }
    }
}
