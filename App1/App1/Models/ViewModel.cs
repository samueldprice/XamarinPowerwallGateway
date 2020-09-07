using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Text;

namespace App1.Models
{
    public class ViewModel : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;

        public string Battery { get; set; }
        public string Home { get; set; }
        public string Solar { get; set; }
        public string Grid { get; set; }
        public string Errors { get; set; }
    }
}
