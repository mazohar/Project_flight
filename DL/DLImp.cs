using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DLAPI;
using Entities;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

namespace DL
{
    public class DLImp : IDL
    {
        //AsynceAdapter data = new AsynceAdapter();
        private const string AllURL = @"https://data-cloud.flightradar24.com/zones/fcgi/feed.js?faa=1&bounds=41.828%2C14.592%2C7.532%2C50.685&satellite=1&mlat=1&flarm=1&adsb=1&gnd=1&air=1&vehicles=1&estimated=1&maxage=14400&gliders=1&stats=1";
        private const string FlightURL = @"https://data-live.flightradar24.com/clickhandler/?version=1.5&flight=";
        #region singelton
        static readonly DLImp instance = new DLImp();
        static DLImp() { }
        public static DLImp Instance => instance;
        #endregion

        //private Dictionary<string, List<FlightData>> Flights = new Dictionary<string, List<FlightData>>();
        //private List<FlightData> FIncoming = new List<FlightData>();
        //private List<FlightData> FOutgoing = new List<FlightData>();

        //return all the data at the data base
        public Dictionary<string, List<FlightData>> getFlights()
        {
            Dictionary<string, List<FlightData>> Result = new Dictionary<string, List<FlightData>>(); // return to BL

            JObject AllFlightData = null;
            //IList<string> Keys = null;
            //IList<Object> Values = null;

            List<FlightData> Incoming = new List<FlightData>();
            List<FlightData> Outgoing = new List<FlightData>();

            using (var webClient = new System.Net.WebClient())
            {
                HelperClass Helper = new HelperClass();
                var json = webClient.DownloadString(AllURL);
                
                AllFlightData = JObject.Parse(json);

                try
                {
                    //over all the flights
                    foreach (var item in AllFlightData)
                    {
                        var key = item.Key;
                        if (key == "full_count" || key == "version") continue;

                        
                        if (item.Value[11].ToString() == "TLV" && item.Value[12].ToString() != "")
                        {

                            Outgoing.Add(new FlightData
                            {
                                Id = item.Value[0].ToString(),
                                //Id = -1,
                                Source = item.Value[11].ToString(),
                                Destination = item.Value[12].ToString(),
                                SourceId = key,
                                Long = Convert.ToDouble(item.Value[2]),
                                Lat = Convert.ToDouble(item.Value[1]),
                                DataAndTime = Helper.GetDateTimeFromEpohc(Convert.ToDouble(item.Value[10])),
                                FlightCode = item.Value[13].ToString(),
                                DirectionFly = Convert.ToInt32(item.Value[3])
                            }) ;

                        }
                        if (item.Value[12].ToString() == "TLV" && item.Value[11].ToString() != "")
                        {

                            Incoming.Add(new FlightData
                            {
                                Id = item.Value[0].ToString(),
                                //Id = -1,
                                Source = item.Value[11].ToString(),
                                Destination = item.Value[12].ToString(),
                                SourceId = key,
                                Long = Convert.ToDouble(item.Value[2]),
                                Lat = Convert.ToDouble(item.Value[1]),
                                DataAndTime = Helper.GetDateTimeFromEpohc(Convert.ToDouble(item.Value[10])),
                                FlightCode = item.Value[13].ToString(),
                                DirectionFly = Convert.ToInt32(item.Value[3])

                            });

                        }
                    }
                }
                catch (Exception e) { Debug.Print(e.Message); }

            }

            Result.Add("Incoming", Incoming);
            Result.Add("Outgoing", Outgoing);
            return Result;
        }

        //return one flights
        public FlightDetails getFlightData(string key)
        {
            HelperClass Helper = new HelperClass();
            var currentFlightURL = FlightURL + key;
            FlightDetails currentFlight = new FlightDetails();
            using (var webClient = new System.Net.WebClient())
            {
                var json = webClient.DownloadString(currentFlightURL);
                try
                {
                    var v = JsonConvert.DeserializeObject<Entities.FlightM.Root>(json);
                    currentFlight.directionFly = v.trail[0].hd;
                    currentFlight.DestinationCode = v.airport.destination.code.iata;
                    currentFlight.DestinationName = v.airport.destination.position.region.city;
                    currentFlight.DestinationLat = v.airport.destination.position.latitude;
                    currentFlight.DestinationLong = v.airport.destination.position.longitude;
                    currentFlight.FlightCode = v.identification.number.@default;
                    currentFlight.Id = v.identification.id;
                    currentFlight.SourceCode = v.airport.origin.code.iata;
                    currentFlight.SourceName = v.airport.origin.position.region.city;
                    currentFlight.SourceLat = v.airport.origin.position.latitude;
                    currentFlight.SourceLong = v.airport.origin.position.longitude;
                    currentFlight.PictureOfAirPlane = v.aircraft.images.large[0].src;
                    currentFlight.AirLainName = v.airline.name;
                    currentFlight.TimeOfFArrive = (Helper.GetDateTimeFromEpohc(Convert.ToDouble(v.time.scheduled.arrival + v.airport.destination.timezone.offset))).ToString("HH:mm");
                    currentFlight.TimeOfFly = (Helper.GetDateTimeFromEpohc(Convert.ToDouble(v.time.scheduled.departure + v.airport.origin.timezone.offset))).ToString("HH:mm");
                    currentFlight.Trail = v.trail;
                    
                }
                catch (Exception e)
                {
                    Debug.WriteLine(e.Message);
                    return null;
                }
            }
            return currentFlight;
        }

        public Weather GetWeather(double latatiude, double longitude)
        {
            var weatherURL = @"https://api.openweathermap.org/data/2.5/weather?lat="+latatiude+"&lon="+longitude+"&appid=bf170d314bba00b81c13654dc76b3e09";
            Weather weather = new Weather();
            using (var webClient = new System.Net.WebClient())
            {
                var json = webClient.DownloadString(weatherURL);
                //JObject allWeather = JObject.Parse(json);
                try
                {
                    var v = JsonConvert.DeserializeObject<Entities.FlightM.Root1>(json);
                    weather.Temp = (v.main.temp-273.15).ToString("00.0") + "°";
                    weather.FeelLikeTemp = (v.main.feels_like-273.15).ToString("00.0") + "°";
                    weather.State = v.weather[0].description;
                }
                catch (Exception e)
                {
                    Debug.WriteLine(e.Message);
                }
            }
            return weather;
        }
        public string IfErevHolliday(int year, int month, int day)
        {
            DateTime date = new DateTime(year, month, day);
            //date = DateTime.Today;
            for (int i = 1; i <= 6; i++)
            {
                date = date.AddDays(1);
                using (var webClient = new System.Net.WebClient())
                {
                    var yyyy = date.ToString("yyyy");
                    var mm = date.ToString("MM");
                    var dd = date.ToString("dd");
                    string dateURL = $"https://www.hebcal.com/converter?cfg=json&date={yyyy}-{mm}-{dd}&g2h=1&strict=1";
                    //var json = await webClient.DownloadStringTaskAsync(dateURL);
                    var json = webClient.DownloadString(dateURL);
                    var v = JsonConvert.DeserializeObject<Entities.FlightM.Root2>(json);
                    var events = v.events;
                    foreach (var e in events)
                    {
                        if (e.Contains("Erev"))
                            return e.ToString();
                    }
                    
                }
            }
            return "no holliday";
        }

        public void addFlightToDB(FlightDetails flight)
        {
            FlightDB flightDB = new FlightDB();
            flightDB.Id = flight.Id;
            flightDB.SourceCode = flight.SourceCode;
            flightDB.SourceName = flight.SourceName;
            flightDB.DestinationCode = flight.DestinationCode;
            flightDB.DestinationName = flight.DestinationName;
            flightDB.FlightCode = flight.FlightCode;
            flightDB.DateToday = DateTime.Now;

            using (var db = new FlightsContext())
            {
                if (db.flights.Find(flightDB.Id) == null)
                {
                    db.flights.Add(flightDB);
                    db.SaveChanges();
                }
            }
        }

        public ObservableCollection<FlightDB> GetFlightsFromDB()
        {
            using (var db = new FlightsContext())
            {
                List<FlightDB> flights = (from f in db.flights
                               select f).ToList<FlightDB>();
                ObservableCollection<FlightDB> observableCollection = new ObservableCollection<FlightDB>(flights);
                return observableCollection;
            }
        }

        public void FixEfProviderServicesProblem()
        {
            //The Entity Framework provider type 'System.Data.Entity.SqlServer.SqlProviderServices, EntityFramework.SqlServer'
            //for the 'System.Data.SqlClient' ADO.NET provider could not be loaded. 
            //Make sure the provider assembly is available to the running application. 
            //See http://go.microsoft.com/fwlink/?LinkId=260882 for more information.

            var instance = System.Data.Entity.SqlServer.SqlProviderServices.Instance;
        }

    }
}
