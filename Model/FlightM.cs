﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities
{
    // entities of json conversions
    public class FlightM
    {
        public class Aircraft
        {
            public Model model { get; set; }
            public int countryId { get; set; }
            public string registration { get; set; }
            public string hex { get; set; }
            public object age { get; set; }
            public object msn { get; set; }
            public Images images { get; set; }
            public Identification identification { get; set; }
            public Airport airport { get; set; }
            public Time time { get; set; }
        }

        public class Airline
        {
            public string name { get; set; }
            public string @short { get; set; }
            public Code code { get; set; }
            public string url { get; set; }
        }

        public class Airport
        {
            public Origin origin { get; set; }
            public Destination destination { get; set; }
            public object real { get; set; }
        }

        public class Code
        {
            public string iata { get; set; }
            public string icao { get; set; }
        }

        public class Country
        {
            public object id { get; set; }
            public string name { get; set; }
            public string code { get; set; }
        }

        public class Destination
        {
            public string name { get; set; }
            public Code code { get; set; }
            public Position position { get; set; }
            public Timezone timezone { get; set; }
            public bool visible { get; set; }
            public string website { get; set; }
            public Info info { get; set; }
        }

        public class Estimated
        {
            public object departure { get; set; }
            public int arrival { get; set; }
        }

        public class EventTime
        {
            public int utc { get; set; }
            public int local { get; set; }
        }

        public class FlightHistory
        {
            public List<Aircraft> aircraft { get; set; }
        }

        public class Generic
        {
            public Status status { get; set; }
            public EventTime eventTime { get; set; }
        }

        public class Historical
        {
            public string flighttime { get; set; }
            public string delay { get; set; }
        }

        public class Identification
        {
            public string id { get; set; }
            public long row { get; set; }
            public Number number { get; set; }
            public string callsign { get; set; }
        }

        public class Images
        {
            public List<Thumbnail> thumbnails { get; set; }
            public List<Medium> medium { get; set; }
            public List<Large> large { get; set; }
        }

        public class Info
        {
            public object terminal { get; set; }
            public object baggage { get; set; }
            public string gate { get; set; }
        }

        public class Large
        {
            public string src { get; set; }
            public string link { get; set; }
            public string copyright { get; set; }
            public string source { get; set; }
        }

        public class Medium
        {
            public string src { get; set; }
            public string link { get; set; }
            public string copyright { get; set; }
            public string source { get; set; }
        }

        public class Model
        {
            public string code { get; set; }
            public string text { get; set; }
        }

        public class Number
        {
            public string @default { get; set; }
            public string alternative { get; set; }
        }

        public class Origin
        {
            public string name { get; set; }
            public Code code { get; set; }
            public Position position { get; set; }
            public Timezone timezone { get; set; }
            public bool visible { get; set; }
            public string website { get; set; }
            public Info info { get; set; }
        }

        public class Other
        {
            public int eta { get; set; }
            public int updated { get; set; }
        }

        public class Owner
        {
            public string name { get; set; }
            public Code code { get; set; }
            public string url { get; set; }
        }

        public class Position
        {
            public double latitude { get; set; }
            public double longitude { get; set; }
            public int altitude { get; set; }
            public Country country { get; set; }
            public Region region { get; set; }
        }

        public class Real
        {
            public int departure { get; set; }
            public object arrival { get; set; }
        }

        public class Region
        {
            public string city { get; set; }
        }

        public class Root
        {
            public Identification identification { get; set; }
            public Status status { get; set; }
            public string level { get; set; }
            public bool promote { get; set; }
            public Aircraft aircraft { get; set; }
            public Airline airline { get; set; }
            public Owner owner { get; set; }
            public object airspace { get; set; }
            public Airport airport { get; set; }
            public FlightHistory flightHistory { get; set; }
            public object ems { get; set; }
            public List<string> availability { get; set; }
            public Time time { get; set; }
            public List<Trail> trail { get; set; }
            public int firstTimestamp { get; set; }
            public string s { get; set; }
        }

        public class Scheduled
        {
            public int departure { get; set; }
            public int arrival { get; set; }
        }

        public class Status
        {
            public bool live { get; set; }
            public string text { get; set; }
            public string icon { get; set; }
            public object estimated { get; set; }
            public bool ambiguous { get; set; }
            public Generic generic { get; set; }
            public string color { get; set; }
            public string type { get; set; }
        }

        public class Thumbnail
        {
            public string src { get; set; }
            public string link { get; set; }
            public string copyright { get; set; }
            public string source { get; set; }
        }

        public class Time
        {
            public Real real { get; set; }
            public Scheduled scheduled { get; set; }
            public Estimated estimated { get; set; }
            public Other other { get; set; }
            public Historical historical { get; set; }
        }

        public class Timezone
        {
            public string name { get; set; }
            public int offset { get; set; }
            public string offsetHours { get; set; }
            public string abbr { get; set; }
            public string abbrName { get; set; }
            public bool isDst { get; set; }
        }

        public class Trail
        {
            public double lat { get; set; }
            public double lng { get; set; }
            public int alt { get; set; }
            public int spd { get; set; }
            public int ts { get; set; }
            public int hd { get; set; }
        }

        /**
         * ************************************************************
         * */

        public class Clouds
        {
            public int all { get; set; }
        }

        public class Coord
        {
            public double lon { get; set; }
            public double lat { get; set; }
        }

        public class Main
        {
            public double temp { get; set; }
            public double feels_like { get; set; }
            public double temp_min { get; set; }
            public double temp_max { get; set; }
            public int pressure { get; set; }
            public int humidity { get; set; }
        }

        public class Root1
        {
            public Coord coord { get; set; }
            public List<Weather> weather { get; set; }
            public string @base { get; set; }
            public Main main { get; set; }
            public int visibility { get; set; }
            public Wind wind { get; set; }
            public Clouds clouds { get; set; }
            public int dt { get; set; }
            public Sys sys { get; set; }
            public int timezone { get; set; }
            public int id { get; set; }
            public string name { get; set; }
            public int cod { get; set; }
        }

        public class Sys
        {
            public int type { get; set; }
            public int id { get; set; }
            public string country { get; set; }
            public int sunrise { get; set; }
            public int sunset { get; set; }
        }

        public class Weather
        {
            public int id { get; set; }
            public string main { get; set; }
            public string description { get; set; }
            public string icon { get; set; }
        }

        public class Wind
        {
            public double speed { get; set; }
            public int deg { get; set; }
        }

        /*
         * *************************************************
         */

        public class HeDateParts
        {
            public string y { get; set; }
            public string m { get; set; }
            public string d { get; set; }
        }

        public class Root2
        {
            public int gy { get; set; }
            public int gm { get; set; }
            public int gd { get; set; }
            public bool afterSunset { get; set; }
            public int hy { get; set; }
            public string hm { get; set; }
            public int hd { get; set; }
            public string hebrew { get; set; }
            public HeDateParts heDateParts { get; set; }
            public List<string> events { get; set; }
        }


    }
}
