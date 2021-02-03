using System;
using System.ComponentModel;

namespace StringFormatBinding.Models
{
    public class CardModel : IFormattable, INotifyPropertyChanged 
    {
        private bool _cardOnUser;
        public bool CardOnUsing
        {
            get => _cardOnUser;
            set
            {
                _cardOnUser = value;
                OnPropertyChanged(nameof(CardOnUsing));
            }
        }
        public string AccountNumber { get; set; }
        public string ExpirationDate { get; set; }
         
        public string ToString(string format, IFormatProvider formatProvider)
        {
            switch (format)
            {
                case "CardMask":
                    return AccountNumber.Substring(AccountNumber.Length - 4);
                case "ExpirationDate":
                    string exp = ExpirationDate;

                    if (ExpirationDate.Length == 3) 
                    {
                        exp = ExpirationDate.Insert(1, " / ");
                    }
                    else if (ExpirationDate.Length == 4)  
                    {
                        exp = ExpirationDate.Insert(2, " / ");
                    }
                    return exp;
                default:
                    return "";
            }
        }

        public event PropertyChangedEventHandler PropertyChanged;
        protected virtual void OnPropertyChanged(string propertyName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }

    }
}
