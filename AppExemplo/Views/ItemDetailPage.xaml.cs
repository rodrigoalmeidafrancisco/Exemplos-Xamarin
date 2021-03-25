using AppExemplo.ViewModels;
using System.ComponentModel;
using Xamarin.Forms;

namespace AppExemplo.Views
{
    public partial class ItemDetailPage : ContentPage
    {
        public ItemDetailPage()
        {
            InitializeComponent();
            BindingContext = new ItemDetailViewModel();
        }
    }
}