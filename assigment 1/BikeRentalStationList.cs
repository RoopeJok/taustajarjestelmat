using System.Collections.Generic;

namespace assigment_1
{
    public class BikeRentalStationList
    {
        public Station[] stations { get; set; }
        public BikeRentalStationList(Station[] station)
        {
            stations = station;
        }
    }
}