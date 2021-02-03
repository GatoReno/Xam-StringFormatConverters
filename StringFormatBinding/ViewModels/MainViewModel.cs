using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using StringFormatBinding.Models;
using Xamarin.Forms.Internals;

namespace StringFormatBinding.ViewModels
{
    public class MainViewModel : INotifyPropertyChanged
    { 
        IList<CardModel> _cards = new List<CardModel>();
        public ObservableCollection<CardModel> Cards { get; set; }
        private CardModel _cardSelected;
        public CardModel CardSelected
        {
            get => _cardSelected;
            set
                {
                if (value != null)
                {
                    _cardSelected = value;
                    _cardSelected.CardOnUsing = !_cardSelected.CardOnUsing;

                    OnPropertyChanged(nameof(_cardSelected));
                    Cards.ForEach(p => p.CardOnUsing = false);
                    _cardSelected.CardOnUsing = true;
                    OnPropertyChanged(nameof(Cards));
                }
            }
        }
        public MainViewModel()
        {
            Cards = new ObservableCollection<CardModel>();
            LoadCards();
        }



        public void LoadCards() {
            _cards.Clear();
            CardModel card1 = new CardModel()
            {
                AccountNumber = "12345678",
                ExpirationDate = "1224",
                CardOnUsing = true 
            };

            CardModel card2 = new CardModel()
            {
                AccountNumber = "987654321",
                ExpirationDate = "122",
                CardOnUsing = false
            };

            _cards.Add(card1);
            _cards.Add(card2);
            Cards = new ObservableCollection<CardModel>(_cards);
            OnPropertyChanged(nameof(Cards));

        }

        public event PropertyChangedEventHandler PropertyChanged;
        protected virtual void OnPropertyChanged(string propertyName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }

    }
}
