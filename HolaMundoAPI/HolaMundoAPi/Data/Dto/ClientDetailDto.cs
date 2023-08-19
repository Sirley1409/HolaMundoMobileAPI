namespace HolaMundoAPi.Data.Dto
{
    using global::HolaMundoAPi.Data.Models;

    namespace HolaMundoAPi.API.Data.Dto
    {
        public class ClientDetailDto : Client
        {
            public int Age { get; set; }
            public int Weight { get; set; }
            public int Height { get; set; }
            public double LifeExpectancy { get; set; }
        }
    }
}
