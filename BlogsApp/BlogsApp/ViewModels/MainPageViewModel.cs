using BlogsApp.Model;
using Prism.Commands;
using Prism.Mvvm;
using Prism.Navigation;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Xml.Serialization;

namespace BlogsApp.ViewModels
{
    public class MainPageViewModel : ViewModelBase, INotifyPropertyChanged
    {
        public Posts Blog { get; set; }

        public event PropertyChangedEventHandler PropertyChanged;

        public MainPageViewModel(INavigationService navigationService)
            : base(navigationService)
        {
            Title = "Blogs";

            ReadRss();
        }

        public void ReadRss()
        {
            XmlSerializer serializer = new XmlSerializer(typeof(Posts));

            using (WebClient client = new WebClient())
            {
                string xml = Encoding.Default.GetString(client.DownloadData("https://www.nasa.gov/rss/dyn/shuttle_station.rss"));
                using (Stream reader = new MemoryStream(Encoding.UTF8.GetBytes(xml)))
                {
                    Blog = (Posts)serializer.Deserialize(reader);
                }
            }
        }

        private void OnPropertyChanged(string propertyName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}
