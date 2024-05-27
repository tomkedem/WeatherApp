using System.ComponentModel;
using WeatherApp.Model;

namespace WeatherApp.ViewModel;
public class WeatherVM : INotifyPropertyChanged
{
    private string query;

    public string Query
    {
        get { return query; }
        set {
            query = value; 
            OnPropertyChanged("Query");
        }
    }

    private CurrentConditions currentConditions;

    public CurrentConditions CurrentConditions
    {
        get { return currentConditions; }
        set { 
            currentConditions = value;
            OnPropertyChanged("CurrentConditions");
        }
    }    

    private City selectedCity;

    public City SelectedCity
    {
        get { return selectedCity; }
        set
        {
            selectedCity = value;
            OnPropertyChanged("SelectedCity");
        }
    }

    public event PropertyChangedEventHandler? PropertyChanged;
    private void OnPropertyChanged(string propertyName)
    {
        PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
    }

}
