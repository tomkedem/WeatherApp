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

    public WeatherVM()
    {
        if(DesignerProperties.GetIsInDesignMode(new System.Windows.DependencyObject()))
        {
            SelectedCity = new City
            {
                LocalizedName = "Tel Aviv",
            };
            CurrentConditions = new CurrentConditions
            {
                WeatherText = "Sunny",
                Temperature = new Temperature
                {
                    Metric = new Units
                    {
                        Value = 25,
                        Unit = "C"
                    },
                    Imperial = new Units
                    {
                        Value = 77,
                        Unit = "F"
                    }
                }
            };
        }
       
    }

    public event PropertyChangedEventHandler? PropertyChanged;
    private void OnPropertyChanged(string propertyName)
    {
        PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
    }

}
