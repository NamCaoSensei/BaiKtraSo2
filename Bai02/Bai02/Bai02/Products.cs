using System.ComponentModel;
using System.Runtime.CompilerServices;

namespace Bai02
{
    public class Product : INotifyPropertyChanged
    {
        private string _id = "";
        private string _name = "";
        private string _category = "";
        private decimal _price;
        private int _quantity;
        private string _imagePath = "";

        public string Id { get => _id; set => Set(ref _id, value); }
        public string Name { get => _name; set => Set(ref _name, value); }
        public string Category { get => _category; set => Set(ref _category, value); }
        public decimal Price { get => _price; set => Set(ref _price, value); }
        public int Quantity { get => _quantity; set => Set(ref _quantity, value); }

        public string ImagePath
        {
            get => _imagePath;
            set
            {
                if (Set(ref _imagePath, value))
                    OnPropertyChanged(nameof(ImageFileName));
            }
        }

        public string ImageFileName => string.IsNullOrEmpty(_imagePath) ? "" : Path.GetFileName(_imagePath);

        public event PropertyChangedEventHandler? PropertyChanged;

        private void OnPropertyChanged(string prop) =>
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(prop));

        private bool Set<T>(ref T field, T value, [CallerMemberName] string? prop = null)
        {
            if (EqualityComparer<T>.Default.Equals(field, value)) return false;
            field = value;
            OnPropertyChanged(prop!);
            return true;
        }
    }
}