using System;
using System.ComponentModel;
using System.Runtime.CompilerServices;

namespace MobileClient.Models
{
    public class WordItem : INotifyPropertyChanged
    {
        private long _id;
        public long Id
        {
            get { return _id; }
            set
            {
                if (value != _id)
                {
                    _id = value;
                    NotifyPropertyChanged();
                }
            }
        }

        private string _value;
        public string Value
        {
            get { return _value; }
            set
            {
                if (value != _value)
                {
                    _value = value;
                    NotifyPropertyChanged();
                }
            }
        }

        private string _translation;
        public string Translation
        {
            get { return _translation; }
            set
            {
                if (value != _translation)
                {
                    _translation = value;
                    NotifyPropertyChanged();
                }
            }
        }

        private string _languageFrom;
        public string LanguageFrom
        {
            get { return _languageFrom; }
            set
            {
                if (value != _languageFrom)
                {
                    _languageFrom = value;
                    NotifyPropertyChanged();
                }
            }
        }


        private string _languageTo;
        public string LanguageTo
        {
            get { return _languageTo; }
            set
            {
                if (value != _languageTo)
                {
                    _languageTo = value;
                    NotifyPropertyChanged();
                }
            }
        }

        private string _description;
        public string Description
        {
            get { return _description; }
            set
            {
                if (value != _description)
                {
                    _description = value;
                    NotifyPropertyChanged();
                }
            }
        }

        public event PropertyChangedEventHandler PropertyChanged;

        private void NotifyPropertyChanged([CallerMemberName] String propertyName = "")
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }

        public static int NextId = 1;
    }
}
