using System;
using System.Collections.Generic;
using System.Windows.Input;
using Xamarin.Forms;

namespace csharp_grund_lab4
{
    public class MainViewModel : SimpleViewModel
    {
        private readonly CountryRepository repository;
        private readonly List<Country> countries;
        private Country selectedCountry;
        public ICommand NextCountryCommand { get; set; }
        public ICommand PrevCountryCommand { get; set; }

        public MainViewModel()
        {
            repository = CountryRepository.Instance;
            repository.LoadData();
            countries = repository.CountryList.Countries;

            SelectedCountry = countries[0];

            NextCountryCommand = new Command(() => { NextCountry(); });
            PrevCountryCommand = new Command(() => { PrevCountry(); });
        }

        void NextCountry()
        {
            int currentIndex = countries.IndexOf(selectedCountry);

            if (currentIndex != countries.Count - 1)
            {
                SelectedCountry = countries[currentIndex + 1];
            }
            else
            {
                SelectedCountry = countries[0];
            }

            RaiseAllPropertiesChanged();
        }

        void PrevCountry()
        {
            int currentIndex = countries.IndexOf(selectedCountry);

            if (currentIndex != 0)
            {
                SelectedCountry = countries[currentIndex - 1];
            }
            else
            {
                SelectedCountry = countries[countries.Count - 1];
            }

            RaiseAllPropertiesChanged();
        }

        public Country SelectedCountry
        {
            get { return selectedCountry; }
            set { SetPropertyValue(ref selectedCountry, value); }
        }

        public string Name
        {
            get { return selectedCountry.name; }
            set { SetPropertyValue(ref selectedCountry.name, value); }
        }

        public string Currency
        {
            get { return selectedCountry.currency; }
            set { SetPropertyValue(ref selectedCountry.currency, value); }
        }

        public string Population
        {
            get { return selectedCountry.population; }
            set { SetPropertyValue(ref selectedCountry.population, value); }
        }

        public string PictureUrl
        {
            get { return selectedCountry.pictureUrl; }
            set { SetPropertyValue(ref selectedCountry.pictureUrl, value); }
        }

        public string Description
        {
            get { return selectedCountry.description; }
            set { SetPropertyValue(ref selectedCountry.description, value); }
        }
    }
}
