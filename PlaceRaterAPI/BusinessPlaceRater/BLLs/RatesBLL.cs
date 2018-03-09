using PlaceRaterAPI;
using PlaceRaterAPI.UOW;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessPlaceRater.BLLs
{
    public class RatesBLL
    {
        public double GetAvgStarsPlace(string name, string city, string state)
        {
            double avg = 0;
            using (var unitOfWork = new UnitOfWork(new PlaceRaterContext()))
            {
                avg = unitOfWork.Rates.GetPlaceAvgStars(new Place() { Name = name, City = city, State = state });
            }

            return avg;
        }

        public double GetAvgPricePlace(string name, string city, string state)
        {
            double avg = 0;
            using (var unitOfWork = new UnitOfWork(new PlaceRaterContext()))
            {
                avg = unitOfWork.Rates.GetPlaceAvgPrice(new Place() { Name = name, City = city, State = state });
            }

            return avg;
        }

        public int GetQtdePlace(string name, string city, string state)
        {
            int qtde = 0;
            using (var unitOfWork = new UnitOfWork(new PlaceRaterContext()))
            {
                qtde = unitOfWork.Rates.GetPlaceQtde(new Place() { Name = name, City = city, State = state });
            }

            return qtde;
        }

        public Rate PostRate(Rate rate)
        {
            Rate rateReturn = new Rate();
            using (var unitOfWork = new UnitOfWork(new PlaceRaterContext()))
            {
                rateReturn = unitOfWork.Rates.PostRate(rate);
                unitOfWork.Complete();
            }

            return rateReturn;
        }

        public Rate GetRate(string Login, string City, string State, string Name)
        {
            Rate rate = new Rate();
            using (var unitOfWork = new UnitOfWork(new PlaceRaterContext()))
            {
                rate = unitOfWork.Rates.GetRate(Login, City, State, Name);
            }

            return rate;
        }

        public Rate DeleteRate(Rate rate)
        {
            Rate rateReturn = new Rate();
            using (var unitOfWork = new UnitOfWork(new PlaceRaterContext()))
            {
                rateReturn = unitOfWork.Rates.DeleteRate(rate);
                unitOfWork.Complete();
            }

            return rateReturn;
        }

        public IEnumerable<Rate> GetUserRates(string Login)
        {
            IEnumerable<Rate> rates = new List<Rate>();
            using (var unitOfWork = new UnitOfWork(new PlaceRaterContext()))
            {
                rates = unitOfWork.Rates.GetUserRates(Login);
            }

            return rates;
        }

        public IEnumerable<Rate> GetRates()
        {
            IEnumerable<Rate> rates = new List<Rate>();
            using (var unitOfWork = new UnitOfWork(new PlaceRaterContext()))
            {
                rates = unitOfWork.Rates.GetAll();
            }

            return rates;
        }

        public IEnumerable<Rate> GetRatesByPlace(string City, string State, string Name)
        {
            IEnumerable<Rate> rates = new List<Rate>();
            using (var unitOfWork = new UnitOfWork(new PlaceRaterContext()))
            {
                rates = unitOfWork.Rates.GetRatesByPlace(new Place() { Name = Name, City = City, State = State });
            }

            return rates;
        }
    }
}
