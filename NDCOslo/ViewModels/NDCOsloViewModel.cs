using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Windows.Input;
using Xamarin.Essentials;
using Xamarin.Forms;

namespace NDCOslo.ViewModels
{
    public class NDCOsloViewModel
    {
        public ICommand NDCBUttonCommand { get; set; }

        public NDCOsloViewModel()
        {
            NDCBUttonCommand = new Command(ActionButton);
        }

        private async void ActionButton()
        {
            try
            {
                var Address = "Oslo Spektrum Arena 0185 Oslo Norway";
                var Locations = await Geocoding.GetLocationsAsync(Address);

                var location = Locations?.FirstOrDefault();

                if (location != null)
                {
                    var options = new MapLaunchOptions { NavigationMode = NavigationMode.Driving };
                    await Map.OpenAsync(location, options);
                }
            }
            catch (Exception ex)
            {
                Debug.WriteLine($"Error {ex.Message}");
            }
        }
    }
}
