using Caliburn.Micro;
using System.Windows;
using WpfCaliburn.ViewModels;

namespace WpfCaliburn
{
    public class Bootstrapper : BootstrapperBase
    {
        public Bootstrapper()
        {
            Initialize();
        }
        protected override void OnStartup(object sender, StartupEventArgs e)
        {
            //DisplayRootViewFor<ShellViewModel>();
            DisplayRootViewFor<ControlsViewModel>();
        }
    }
}
