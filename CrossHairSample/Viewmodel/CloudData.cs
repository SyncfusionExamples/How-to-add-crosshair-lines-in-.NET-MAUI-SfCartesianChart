using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Runtime.CompilerServices;

namespace CrossHairSample.Viewmodel
{
    public class CloudProvider
    {
        public string? Company { get; set; }
        public double MarketShare { get; set; }
    }

    public class CloudDataViewModel : INotifyPropertyChanged
    {
        private ObservableCollection<CloudProvider>? _cloudData;
        public ObservableCollection<CloudProvider>? CloudData
        {
            get { return _cloudData; }
            set 
            { 
                _cloudData = value;
                OnPropertyChanged();
            }
        }

        public CloudDataViewModel()
        {
            LoadCloudData();
        }

        private void LoadCloudData()
        {
            CloudData =
            [
                new CloudProvider { Company = "Amazon", MarketShare = 25 },
                new CloudProvider { Company = "Alphabet", MarketShare = 13 },
                new CloudProvider { Company = "Oracle", MarketShare = 8 },
                new CloudProvider { Company = "Microsoft", MarketShare = 20 },
                new CloudProvider { Company = "Salesforce", MarketShare = 5 },
                new CloudProvider { Company = "Alibaba", MarketShare = 10 },
                new CloudProvider { Company = "Huawei", MarketShare = 3 },
                new CloudProvider { Company = "IBM", MarketShare = 2 },
                new CloudProvider { Company = "Others", MarketShare = 14 }
            ];
        }

        public event PropertyChangedEventHandler? PropertyChanged;

        protected void OnPropertyChanged([CallerMemberName] string? name = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(name));
        }
    }
}
