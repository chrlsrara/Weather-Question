using System;
using System.Collections.Generic;
using System.Text;

namespace Weather_Assistant.Util
{
    public static class Constants
    {
        public static string AskZipCodeMessage = "What's your Zip Code? : ";
        public static string ConfirmedZipCodeMessage = "Loading data... Please wait...";
        public static string SelectQuestionMessage = "Please select your question.\n==================";
        public static string ZipCodeValid = "Location: {0}\nCountry: {1}\nRegion: {2}";
        public static string ZipCodeInvalid = "It seems that zip code is not valid US Code...";
    }
}