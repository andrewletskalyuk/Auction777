using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AuctionClient.TimerClass
{
    public class TimeClass : INotifyPropertyChanged
    {
        public TimeClass()
        {
            MyTime = 10;
            IsEn = false;
        }

        private bool _isEn;

        public bool IsEn
        {
            get { return _isEn; }
            set { _isEn = value;
                OnPropertyChanged("IsEn");
            }
        }

        private int _myTime;

        public int MyTime
        {
            get { return _myTime; }
            set { _myTime = value;
                OnPropertyChanged("MyTime");
            }
        }
        public void counterOne_Tick(object sender, EventArgs e)
        {
            // code goes here

            if (MyTime > 0)
            {
                MyTime--;               
            }            
            else
            {
                IsEn = true;
            }
                

        }

        public event PropertyChangedEventHandler PropertyChanged;
        public void OnPropertyChanged(string propertyName)
        {
            if (PropertyChanged != null)
                PropertyChanged(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}
