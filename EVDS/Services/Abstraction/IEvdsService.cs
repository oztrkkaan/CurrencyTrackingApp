namespace EVDS.Services.Abstraction
{
    public interface IEvdsService
    {

        public IEvdsCurrencyService CurrencyService { get; }
        public IEvdsCurrencyRatingService CurrencyRatingService { get; }
    }
}
