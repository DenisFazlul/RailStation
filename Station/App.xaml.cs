using Microsoft.Extensions.DependencyInjection;
using Station.Savers;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Threading.Tasks;
using System.Windows;

namespace Station
{
    /// <summary>
    /// Interaction logic for App.xaml
    /// </summary>
    public partial class App : Application
    {
        private ServiceProvider serviceProvider;
        public App() {
            ServiceCollection services = new ServiceCollection();
            ConfigureServices(services);
            serviceProvider = services.BuildServiceProvider();
        }
        private void ConfigureServices(ServiceCollection services) {
            services.AddSingleton<ISaveFile>(new BinarySaver());
            services.AddSingleton<MainWindow>();
        }
        protected override void OnStartup(StartupEventArgs e) {
            //DI
            base.OnStartup(e);
            MainWindow w = serviceProvider.GetRequiredService<MainWindow>();  
            w.Show();
        }
    }
}
