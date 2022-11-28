using Galary.Models;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Windows.Controls;
using System.Windows.Media;

namespace Galary.UserControls;



public partial class UserControl_Photos : UserControl, INotifyPropertyChanged
{
    public event PropertyChangedEventHandler PropertyChanged;
    protected void OnPropertyChanged([CallerMemberName] string name = null)
    {
        PropertyChangedEventHandler handler = PropertyChanged;
        if (handler != null)
        {
            handler(this, new PropertyChangedEventArgs(name));
        }
    }


    private GalaryImage photo;
    private ImageSource _currentImageSource;
    

    
    public GalaryImage Photo
    {
        get { return photo; }
        set 
        {
            photo = value;
            OnPropertyChanged(); 
        }
    }
    public ImageSource CurrentImageSource
    {
        get { return _currentImageSource; }
        set
        {
            _currentImageSource = value;
            OnPropertyChanged();
        }
    }


    public UserControl_Photos(ImageSource source,GalaryImage image)
    {
        InitializeComponent();

        Photo = image;
        CurrentImageSource = source;
        DataContext = this;
    }
}