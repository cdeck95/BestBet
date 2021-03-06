﻿using System;
using System.Collections.Generic;
using System.ComponentModel;

namespace BestBet.ViewModels
{
    public enum ListMode
    {
        Hot = 0,
        Live = 1,
        Watchlist = 2,
        Settings = 3
    }

    public class BooksViewModel : INotifyPropertyChanged
    {
        public BooksViewModel()
        {
        }

        

        public event PropertyChangedEventHandler PropertyChanged;

        private List<Book> allBooks;

        public List<Book> AllBooks
        {
            get
            {
                return allBooks;
            }
            set
            {
                try
                {
                    allBooks = value;
                    PropertyChanged?.Invoke(this, new PropertyChangedEventArgs("AllBooks"));
                }
                catch (Exception ex)
                {
                    Console.WriteLine($"crash: {ex.Message}");
                }
            }
        }

        public async void getBooks()
        {
            allBooks = await App.Database.GetBooksAsync();
        }
        
    }
}
