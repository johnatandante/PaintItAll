using System;
using System.Net;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Documents;
using System.Windows.Ink;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Animation;
using System.Windows.Shapes;
using System.ComponentModel;

namespace PaintItAll.Model.Colors
{
    public class ColorItem : INotifyPropertyChanged {
        public event PropertyChangedEventHandler PropertyChanged;

        private string _colorComponent;
        private int _colorComponentValue;

        public string ColorComponent {
            get {
                return _colorComponent;
            }
            set {
                _colorComponent = value;
                PropertyChanged(this, new PropertyChangedEventArgs("ColorComponent"));
            }
        }

        public int ColorComponentValue {
            get {
                return _colorComponentValue;
            }
            set {
                _colorComponentValue = value;
                PropertyChanged(this, new PropertyChangedEventArgs("ColorComponentValue"));
            }
        }
    }
}
