using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;
using System.Windows;

namespace PizzeriaGuide.Services
{
    public class CurrentDialogService
    {
        private static CurrentDialogService _instance;
        private Window _currentDialog;

        public static CurrentDialogService Instance => _instance ??= new CurrentDialogService();

        private CurrentDialogService() { }

        public void ShowDialog(UserControl dialogView, object viewModel)
        {
            _currentDialog = new Window
            {
                Content = dialogView,
                DataContext = viewModel,
                SizeToContent = SizeToContent.WidthAndHeight,
                WindowStartupLocation = WindowStartupLocation.CenterScreen,
                Title = "Dialog Title"
            };

            _currentDialog.Closed += (sender, args) =>
            {
                _currentDialog = null;
            };


            _currentDialog.ShowDialog();
        }

        public void CloseDialog()
        {
            _currentDialog?.Close();
        }
    }
}
