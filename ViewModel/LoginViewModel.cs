using AutoService.UoF;
using AutoService.View;
using AutoService.ViewModel.Base;
using AutoService.ViewModel.Command;
using AutoService.ViewModel.Common;
using AutoService.ViewModel.TransferObjects;
using System.Windows.Controls;

namespace AutoService.ViewModel
{
    public class LoginViewModel : BaseViewModel
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IShowMesage _showMessage = new ShowMessage();
        private RelayCommand _loginCommand;
        private RelayCommand _createAccCommand;

        public LoginViewModel()
        {
            _unitOfWork = new UnitOfWork();
        }

        public LoginObject Login { get; set; } = new LoginObject();

        public RelayCommand LoginCommand
        {
            get
            {
                return _loginCommand ?? (_loginCommand = new RelayCommand((o) =>
                {
                    var passwordBox = o as PasswordBox;

                    Login.Password = passwordBox.Password;

                    var customer = _unitOfWork.CustomerRepository.GetEntityByConditionOrDefault(c => string.Equals(c.Email, Login.Login));

                    if (customer != null)
                    {
                        if (BCrypt.Net.BCrypt.Verify(Login.Password, customer.Password))
                        {
                            CurrentUser.Id = customer.Id;
                            var main = new MainWindow();
                            main.Show();

                            Close();
                            return;
                        }
                    }

                    var admin = _unitOfWork.AdminRepository.GetEntityByConditionOrDefault(c => string.Equals(c.Login, Login.Login));

                    if (admin != null)
                    {
                        if (BCrypt.Net.BCrypt.Verify(Login.Password, admin.Password))
                        {
                            var main = new MainAdmin();
                            main.Show();

                            Close();
                            return;
                        }
                    }

                    _showMessage.Show(
                        "Логин или пароль введены неверно!", 
                        "AutoService",
                        System.Windows.Forms.MessageBoxButtons.OK,
                        System.Windows.Forms.MessageBoxIcon.Information);

                }));
            }
        }

        public RelayCommand CreateAccCommand
        {
            get
            {
                return _createAccCommand ?? (_createAccCommand = new RelayCommand((o) =>
                {

                    var register = new Register();

                    register.Show();

                    Close();
                }));
            }
        }
    }
}
