using PizzeriaGuide.Handlers;
using PizzeriaGuide.Models;
using PizzeriaGuide.Services;
using System;
using System.Windows.Input;

namespace PizzeriaGuide.ViewModels
{
    public class CreatePizzeriaDialogViewModel
    {
        public Guid Id { get; }
        public string Name { get; set; }
        public string Address { get; set; }
        public string PhoneNumber { get; set; }

        private Pizzeria _pizzeria;

        public bool IsPizzeriaCreated => _pizzeria != null;
        public Pizzeria GetCreatedPizzeria() => _pizzeria;


        private ICommand _createPizzeriaCommand;
        public ICommand CreatePizzeriaCommand => _createPizzeriaCommand ?? (_createPizzeriaCommand = new CommandHandler(Create, CanCreate));

        private ICommand _cancelCommand;
        public ICommand CancelCommand => _cancelCommand ?? (_cancelCommand = new CommandHandler(Cancel, null));

        public void Create(object param)
        {
            _pizzeria = new Pizzeria
            {
                Id = Guid.NewGuid(),
                Name = Name,
                Address = Address,
                PhoneNumber = PhoneNumber,
            };

            CurrentDialogService.Instance.CloseDialog();
        }

        public void Cancel(object param)
        {
            CurrentDialogService.Instance.CloseDialog();
        }

        public bool CanCreate(object param)
        {
            if (string.IsNullOrEmpty(Name))
            {
                return false;
            }
            if (string.IsNullOrEmpty(Address))
            {
                return false;
            }
            if (string.IsNullOrEmpty(PhoneNumber))
            {
                return false;
            }
            return true;
        }
    }
}
