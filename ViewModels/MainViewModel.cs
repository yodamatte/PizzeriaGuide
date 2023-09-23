using PizzeriaGuide.Handlers;
using PizzeriaGuide.Models;
using PizzeriaGuide.Services;
using PizzeriaGuide.Views;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Windows.Input;

namespace PizzeriaGuide.ViewModels
{
    public class MainViewModel
    {
        public ObservableCollection<Pizzeria> Pizzerias { get; set; } = new();

        private ICommand _addPizzeriaCommand;
        public ICommand AddPizzeriaCommand => _addPizzeriaCommand ?? (_addPizzeriaCommand = new CommandHandler(AddPizzeria));

        private ICommand _removePizzeriaCommand;
        public ICommand RemovePizzeriaCommand => _removePizzeriaCommand ?? (_removePizzeriaCommand = new CommandHandler(RemovePizzeria, HasSelectedItem));

        public Pizzeria SelectedItem { get; set; }

        public MainViewModel() 
        {
            LoadPizzerias();
        }

        public bool HasSelectedItem() => SelectedItem is not null;

        public void AddPizzeria()
        {
            var view = new CreatePizzeriaDialog();
            var viewModel = new CreatePizzeriaDialogViewModel();
            CurrentDialogService.Instance.ShowDialog(view, viewModel);

            if (viewModel.IsPizzeriaCreated)
            {
                Pizzerias.Add(viewModel.GetCreatedPizzeria());
            }
        }

        public void RemovePizzeria()
        {
            Pizzerias.Remove(SelectedItem);
        }

        private void LoadPizzerias()
        {
            Pizzerias.Add(new Pizzeria { Name = "Pizza1", Address = "adress1", PhoneNumber = "54543535" });
            Pizzerias.Add(new Pizzeria { Name = "Pizza2", Address = "adress2", PhoneNumber = "453252522" });
            Pizzerias.Add(new Pizzeria { Name = "Pizza3", Address = "adress3", PhoneNumber = "0123456789" });
        }
    }
}
