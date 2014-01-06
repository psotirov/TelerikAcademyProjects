/*
  In App.xaml:
  <Application.Resources>
      <vm:ViewModelLocator xmlns:vm="clr-namespace:ParseStarterProject"
                           x:Key="Locator" />
  </Application.Resources>
  
  In the View:
  DataContext="{Binding Source={StaticResource Locator}, Path=ViewModelName}"

  You can also use Blend to do all this with the tool's support.
  See http://www.galasoft.ch/mvvm
*/

using GalaSoft.MvvmLight;
using GalaSoft.MvvmLight.Ioc;
using Microsoft.Practices.ServiceLocation;
using ParseStarterProject.Services;

namespace ParseStarterProject.ViewModel
{
    /// <summary>
    /// This class contains static references to all the view models in the
    /// application and provides an entry point for the bindings.
    /// </summary>
    public class ViewModelLocator
    {

        public INavigationService DefaultNavigationService { get; private set; }
        public static ViewModelLocator Default { get; private set; }

        /// <summary>
        /// Initializes a new instance of the ViewModelLocator class.
        /// </summary>
        public ViewModelLocator()
        {
            ServiceLocator.SetLocatorProvider(() => SimpleIoc.Default);

            ////if (ViewModelBase.IsInDesignModeStatic)
            ////{
            ////    // Create design time view services and models
            ////    SimpleIoc.Default.Register<IDataService, DesignDataService>();
            ////}
            ////else
            ////{
            ////    // Create run time view services and models
            ////    SimpleIoc.Default.Register<IDataService, DataService>();
            ////}

            SimpleIoc.Default.Register<MainViewModel>();

            SimpleIoc.Default.Register<INavigationService, NavigationService>();
            SimpleIoc.Default.Register<IDataService, ExternalDataService>();


            // dataService = SimpleIoc.Default.GetInstance<IDataService>();

            SimpleIoc.Default.Register<UpdatesViewModel>();
            SimpleIoc.Default.Register<ProfileViewModel>();
            SimpleIoc.Default.Register<NavigateViewModel>();
            SimpleIoc.Default.Register<ToastViewModel>();

            DefaultNavigationService = SimpleIoc.Default.GetInstance<INavigationService>();
        }

        public ViewModelBase Main
        {
            get
            {
                return ServiceLocator.Current.GetInstance<MainViewModel>();
            }
        }

        public ViewModelBase UpdatesModel
        {
            get
            {
                return ServiceLocator.Current.GetInstance<UpdatesViewModel>();
            }
        }

        public ViewModelBase ProfileViewModel
        {
            get
            {
                return ServiceLocator.Current.GetInstance<ProfileViewModel>();
            }
        }

        public ViewModelBase NavigateViewModel
        {
            get
            {
                return ServiceLocator.Current.GetInstance<NavigateViewModel>();
            }
        }

        public ViewModelBase ToastViewModel
        {
            get
            {
                return ServiceLocator.Current.GetInstance<ToastViewModel>();
            }
        }

        public static void Cleanup()
        {
            // TODO Clear the ViewModels
        }
    }
}