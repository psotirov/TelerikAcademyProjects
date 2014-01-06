using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Windows.Data;

namespace ViewModels
{
    public class CountriesAndTownsViewModel
    {
        public string CountriesDocumentPath { get; set; }

        public CountriesAndTownsViewModel()
        {
            this.CountriesDocumentPath = "..\\..\\..\\ViewModels\\countries.xml";
        }

        private IEnumerable<CountryViewModel> countries;
        private IEnumerable<TownViewModel> currentCountryTowns;

        public IEnumerable<CountryViewModel> Countries
        {
            get
            {
                if (this.countries == null)
                {
                    this.countries = DataPersister.GetAll(CountriesDocumentPath);
                }

                return countries;
            }
        }

        public void Next()
        {
            var countriesCollectionView = this.GetDefaultView(this.countries);
            countriesCollectionView.MoveCurrentToNext();
            if (countriesCollectionView.IsCurrentAfterLast)
            {
                countriesCollectionView.MoveCurrentToFirst();
            }
        }



        public void Prev()
        {
            var countriesCollectionView = this.GetDefaultView(this.countries);
            countriesCollectionView.MoveCurrentToPrevious();
            if (countriesCollectionView.IsCurrentBeforeFirst)
            {
                countriesCollectionView.MoveCurrentToLast();
            }
        }

        public void NextTown()
        {
            var countriesCollectionView = this.GetDefaultView(this.countries);
            var currentCountry = countriesCollectionView.CurrentItem as CountryViewModel;

            this.currentCountryTowns = currentCountry.Towns;
            var townsCollectionView = this.GetDefaultView(this.currentCountryTowns);

            townsCollectionView.MoveCurrentToNext();
            if (townsCollectionView.IsCurrentAfterLast)
            {
                townsCollectionView.MoveCurrentToFirst();
            }
        }

        public void PrevTown()
        {
            var countriesCollectionView = this.GetDefaultView(this.countries);
            var currentCountry = countriesCollectionView.CurrentItem as CountryViewModel;
            this.currentCountryTowns = currentCountry.Towns;
            var townsCollectionView = this.GetDefaultView(this.currentCountryTowns);

            townsCollectionView.MoveCurrentToPrevious();
            if (townsCollectionView.IsCurrentBeforeFirst)
            {
                townsCollectionView.MoveCurrentToLast();
            }
        }

        private ICollectionView GetDefaultView<T>(IEnumerable<T> collection)
        {
            return CollectionViewSource.GetDefaultView(collection);
        }
    }
}
