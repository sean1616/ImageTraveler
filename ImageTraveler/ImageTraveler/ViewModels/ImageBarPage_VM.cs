using System;
using System.ComponentModel;
using System.Windows;

namespace ImageTraveler.ViewModels
{
    public class ImageBarPage_VM : INotifyPropertyChanged
    {
        private Point[] _sPosi = new Point[7];
        public Point[] sPosi
        {
            get { return _sPosi; }
            set
            {
                _sPosi = value;
                OnPropertyChanged("sPosi");
            }
        }

        private Point[] _Posi = new Point[7];
        public Point[] Posi
        {
            get { return _Posi; }
            set
            {
                _Posi = value;
                OnPropertyChanged("Posi");
            }
        }
               
        private Point _sPosi_fit = new Point(0.2, 0.2);
        public Point sPosi_fit
        {
            get { return _sPosi_fit; }
            set
            {
                _sPosi_fit = value;
                OnPropertyChanged("sPosi_fit");
            }
        }

        private Point _Posi_fit = new Point(1, 1);
        public Point Posi_fit
        {
            get { return _Posi_fit; }
            set
            {
                _Posi_fit = value;
                OnPropertyChanged("Posi_fit");
            }
        }

        private Point _sPosi_previous;
        public Point sPosi_previous
        {
            get { return _sPosi_previous; }
            set
            {
                _sPosi_previous = value;
                OnPropertyChanged("sPosi_previous");
            }
        }

        private Point _Posi_previous;
        public Point Posi_previous
        {
            get { return _Posi_previous; }
            set
            {
                _Posi_previous = value;
                OnPropertyChanged("Posi_previous");
            }
        }

        //private Point _sPosi_previous;
        //public Point sPosi_previous
        //{
        //    get { return _sPosi_previous; }
        //    set
        //    {
        //        _sPosi_previous = value;
        //        OnPropertyChanged("sPosi_previous");
        //    }
        //}

        //private Point _Posi_previous;
        //public Point Posi_previous
        //{
        //    get { return _Posi_previous; }
        //    set
        //    {
        //        _Posi_previous = value;
        //        OnPropertyChanged("Posi_previous");
        //    }
        //}

        private Point _sPosi_next;
        public Point sPosi_next
        {
            get { return _sPosi_next; }
            set
            {
                _sPosi_next = value;
                OnPropertyChanged("sPosi_next");
            }
        }

        private Point _Posi_next;
        public Point Posi_next
        {
            get { return _Posi_next; }
            set
            {
                _Posi_next = value;
                OnPropertyChanged("Posi_next");
            }
        }



        //泛型寫法, 簡化型別判斷，並判斷新舊值是否相等
        protected virtual bool SetProperty<T>(ref T storage, T value, string propertyName = null)
        {
            if (Object.Equals(storage, value))
                return false;

            storage = value;
            //OnPropertyChanged(propertyName);
            OnPropertyChanged_Normal(propertyName);
            return true;
        }

        public event PropertyChangedEventHandler PropertyChanged;

        //OnPropertyChanged 寫成共用副程式,並寫成強型別
        //不指名發生改變的參數，並激發"所有"參數的改變
        protected void OnPropertyChanged(string propertyName = null)
        {
            PropertyChangedEventHandler handler = PropertyChanged;
            if (handler != null)
            {
                PropertyChanged(this, new PropertyChangedEventArgs(propertyName));
            }
        }

        //一般寫法
        //指名已改變的參數並激發
        //public event PropertyChangedEventHandler PropertyChanged_Normal;
        public void OnPropertyChanged_Normal(string propertyName)
        {
            if (PropertyChanged != null)
            {
                PropertyChanged(this, new PropertyChangedEventArgs(propertyName));
            }
        }
    }
}
