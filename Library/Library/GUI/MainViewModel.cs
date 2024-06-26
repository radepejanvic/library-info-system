using Library.ViewModel;
using Library.Core.TehnicalService.Interface;
using Library.GUI.Login;

namespace Library
{
    public class MainViewModel : ViewModelBase
    {
		private ViewModelBase _currentViewModel;
		public ViewModelBase CurrentViewModel
		{
			get
			{
				return _currentViewModel;
			}
			set
			{
                _currentViewModel = value;
				OnPropertyChanged(nameof(CurrentViewModel));
			}
		}
		public MainViewModel(ILoginService login)
        {
            CurrentViewModel = new LoginViewModel(this,login);
        }
    }
}