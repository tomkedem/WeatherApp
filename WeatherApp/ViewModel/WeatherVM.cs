using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WeatherApp.ViewModel;
public class WeatherVM : INotifyPropertyChanged
{
    private int Query;

    public int MyProperty
    {
        get { return Query; }
        set { 
            Query = value; 
            OnPropertyChanged("Query");
        }
    }

    public event PropertyChangedEventHandler? PropertyChanged;
    private void OnPropertyChanged(string propertyName)
    {
        PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
    }
}
