using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace AppListView
{
    class Animal:INotifyPropertyChanged
    {
        private string _title;

        public string Title
        {
            get { return _title; }
            set {
                if (value != _title)
                {
                    _title = value;

                    NotifyPropetyChanged();
                }
            }
        }

        private void NotifyPropetyChanged([CallerMemberName]string caller="")
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(caller));
        }

        private int _age;

        public event PropertyChangedEventHandler PropertyChanged;

        public int Age
        {
            get { return _age; }
            set {
                if (value != _age)
                {
                    _age = value;
                    NotifyPropetyChanged();
                }
            }
        }

    }
}
