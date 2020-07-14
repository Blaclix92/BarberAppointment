using HotChocolate.AspNetCore.Authorization;

namespace BarberAppointment.GraphQLApi.DataStore
{
    [Authorize]
    public class BookAppointment
    {

        public int Id { get; set; }
        public string Date { get; set; }
        public int Cancel { get; set; }
        public string Hour { get; set; }
        public int BarberId { get; set; }
        public int ClientId { get; set; }
    }
}