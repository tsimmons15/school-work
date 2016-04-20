using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web;
using System.Net;
using System.IO;
using System.Windows.Forms;
using System.Timers;

namespace TranslationProject
{
    //Handles the interaction with the server to perform the actual translation
    static class Translate
    {
        //Tracks whether authentication is still active
        private static bool activeAuthentication = false;
        //Keeps track of the token itself
        private static AdmAccessToken admToken = null;
        //The header value used to validate our service
        private static string headerValue = string.Empty;
        //Timer to control whether the token is currently active
        private static System.Timers.Timer checkAuth = new System.Timers.Timer(600000);

        //Sets up the timer to go off after 10 minutes
        public static void primeTimer()
        {
            checkAuth.Elapsed += new ElapsedEventHandler(Tick);
            checkAuth.Enabled = true;
        }

        //Generates the header, which contains our information
        public static void generateHeader()
        {
            //Get Client Id and Client Secret from https://datamarket.azure.com/developer/applications/
            //Refer obtaining AccessToken (http://msdn.microsoft.com/en-us/library/hh454950.aspx) 
            //If there is no activeAuthentication
            if (!activeAuthentication)
            {
                //Start the process of authentication again
                AdmAuthentication admAuth = new AdmAuthentication("b60aa4e7-487b-4990-a3ec-4b463424ef5f", "GuRfyg30hQEY+wSw0aLKmm20s2wXLS7/JGLNfvQiUjg=");

                //Retrieve a new token
                admToken = admAuth.HttpPost();
                // Create a header with the access_token property of the returned token
                headerValue = "Bearer " + admToken.access_token;
                //Reset the activation to true;
                activeAuthentication = true;
                //Start the timer again
                checkAuth.Start();
            }
        }

        //Communicates with the server in an attempt to auto-detect the language
        public static void DetectMethod(string detect, string authToken)
        {
            //Console.WriteLine("Enter Text to detect language:");
            //string textToDetect = Console.ReadLine();
            //Keep appId parameter blank as we are sending access token in authorization header.
            string uri = "http://api.microsofttranslator.com/v2/Http.svc/Detect?text=" + detect;
            HttpWebRequest httpWebRequest = (HttpWebRequest)WebRequest.Create(uri);
            httpWebRequest.Headers.Add("Authorization", authToken);
            WebResponse response = null;
            try
            {
                response = httpWebRequest.GetResponse();
                using (Stream stream = response.GetResponseStream())
                {
                    System.Runtime.Serialization.DataContractSerializer dcs = new System.Runtime.Serialization.DataContractSerializer(Type.GetType("System.String"));
                    string languageDetected = (string)dcs.ReadObject(stream);
                    MessageBox.Show(string.Format("Language detected:{0}", languageDetected), "Output");
                }
            }

            catch
            {
                throw;
            }
            finally
            {
                if (response != null)
                {
                    response.Close();
                    response = null;
                }
            }
        }

        //Processing of web-related exceptions
        private static void ProcessWebException(WebException e)
        {
            MessageBox.Show(e.ToString(), "Information");
            // Obtain detailed error information
            string strResponse = string.Empty;
            using (HttpWebResponse response = (HttpWebResponse)e.Response)
            {
                using (Stream responseStream = response.GetResponseStream())
                {
                    using (StreamReader sr = new StreamReader(responseStream, System.Text.Encoding.ASCII))
                    {
                        strResponse = sr.ReadToEnd();
                    }
                }
            }
            MessageBox.Show("Http status code= " + e.Status + ", error message=" + strResponse, "Response");
        }

        //Gets the language code the server expects from the "name" that we all read
        public static string getLanguageCode(string language)
        {
            string ret = null;
            switch (language)
            {
                case "Bulgarian":
                    ret = "bg";
                    break;
                case "Catalan":
                    ret = "ca";
                    break;
                case "Chinese(Simplified)":
                    ret = "zh-CHS";
                    break;
                case "Chinese(Traditional)":
                    ret = "zh-CHT";
                    break;
                case "Czech":
                    ret = "cs";
                    break;
                case "Danish":
                    ret = "da";
                    break;
                case "Dutch":
                    ret = "nl";
                    break;
                case "English":
                    ret = "en";
                    break;
                case "Estonian":
                    ret = "et";
                    break;
                case "Finnish":
                    ret = "fi";
                    break;
                case "French":
                    ret = "fr";
                    break;
                case "German":
                    ret = "de";
                    break;
                case "Greek":
                    ret = "el";
                    break;
                case "Haitian Creole":
                    ret = "ht";
                    break;
                case "Hebrew":
                    ret = "he";
                    break;
                case "Hindi":
                    ret = "hi";
                    break;
                case "Hmong Daw":
                    ret = "mww";
                    break;
                case "Hungarian":
                    ret = "hu";
                    break;
                case "Indonesian":
                    ret = "id";
                    break;
                case "Italian":
                    ret = "it";
                    break;
                case "Japanese":
                    ret = "ja";
                    break;
                case "Korean":
                    ret = "ko";
                    break;
                case "Latvian":
                    ret = "lv";
                    break;
                case "Lithuanian":
                    ret = "lt";
                    break;
                case "Norwegian":
                    ret = "no";
                    break;
                case "Persian(Farsi)":
                    ret = "fa";
                    break;
                case "Polish":
                    ret = "pl";
                    break;
                case "Portuguese":
                    ret = "pt";
                    break;
                case "Romanian":
                    ret = "ro";
                    break;
                case "Russian":
                    ret = "ru";
                    break;
                case "Slovak":
                    ret = "sk";
                    break;
                case "Slovenian":
                    ret = "sl";
                    break;
                case "Spanish":
                    ret = "es";
                    break;
                case "Swedish":
                    ret = "sv";
                    break;
                case "Thai":
                    ret = "th";
                    break;
                case "Turkish":
                    ret = "tr";
                    break;
                case "Ukrainian":
                    ret = "uk";
                    break;
                case "Vietnamese":
                    ret = "vi";
                    break;
                case "Arabic":
                    ret = "ar";
                    break;
                default:
                    //Invalid code
                    ret = null;
                    break;
            }
            return ret;
        }

        //Get the whole "Name" from the saved code the server reads
        public static string getLanguageWhole(string code)
        {
            string ret = null;
            switch (code)
            {
                case "bg":
                    ret = "Bulgarian";
                    break;
                case "ca":
                    ret = "Catalan";
                    break;
                case "zh-CHS":
                    ret = "Chinese(Simplified)";
                    break;
                case "zh-CHT":
                    ret = "Chinese(Traditional)";
                    break;
                case "cs":
                    ret = "Czech";
                    break;
                case "da":
                    ret = "Danish";
                    break;
                case "nl":
                    ret = "Dutch";
                    break;
                case "en":
                    ret = "English";
                    break;
                case "et":
                    ret = "Estonian";
                    break;
                case "fi":
                    ret = "Finnish";
                    break;
                case "fr":
                    ret = "French";
                    break;
                case "de":
                    ret = "German";
                    break;
                case "el":
                    ret = "Greek";
                    break;
                case "ht":
                    ret = "Haitian Creole";
                    break;
                case "he":
                    ret = "Hebrew";
                    break;
                case "hi":
                    ret = "Hindi";
                    break;
                case "mww":
                    ret = "Hmong Daw";
                    break;
                case "hu":
                    ret = "Hungarian";
                    break;
                case "id":
                    ret = "Indonesian";
                    break;
                case "it":
                    ret = "Italian";
                    break;
                case "ja":
                    ret = "Japanese";
                    break;
                case "ko":
                    ret = "Korean";
                    break;
                case "lv":
                    ret = "Latvian";
                    break;
                case "lt":
                    ret = "Lithuanian";
                    break;
                case "no":
                    ret = "Norwegian";
                    break;
                case "fa":
                    ret = "Persian(Farsi)";
                    break;
                case "pl":
                    ret = "Polish";
                    break;
                case "pt":
                    ret = "Portuguese";
                    break;
                case "ro":
                    ret = "Romanian";
                    break;
                case "ru":
                    ret = "Russian";
                    break;
                case "sk":
                    ret = "Slovak";
                    break;
                case "sl":
                    ret = "Slovenian";
                    break;
                case "es":
                    ret = "Spanish";
                    break;
                case "sv":
                    ret = "Swedish";
                    break;
                case "th":
                    ret = "Thai";
                    break;
                case "tr":
                    ret = "Turkish";
                    break;
                case "uk":
                    ret = "Ukrainian";
                    break;
                case "vi":
                    ret = "Vietnamese";
                    break;
                case "ar":
                    ret = "Arabic";
                    break;
                default:
                    //Invalid code
                    ret = null;
                    break;
            }
            return ret;
        }
        //The method which connects to the server to handle translation
        public static string translateText(string text, string from, string to)
        {
            //The string which is sent over the network which contains the call to the translator
            string uri = "http://api.microsofttranslator.com/v2/Http.svc/Translate?text=" + System.Web.HttpUtility.UrlEncode(text) + "&from=" + from + "&to=" + to;
            try
            {
                string authToken = "Bearer" + " " + admToken.access_token;

                //Set up the request to the server
                HttpWebRequest httpWebRequest = (HttpWebRequest)WebRequest.Create(uri);
                //Set up the headers with our current (hopefully) authorization
                httpWebRequest.Headers.Add("Authorization", authToken);

                //Ready a response to our request                               
                WebResponse response = null;
            
                //Get a response from our request
                response = httpWebRequest.GetResponse();
                //Read the response into a stream
                using (Stream stream = response.GetResponseStream())
                {
                    System.Runtime.Serialization.DataContractSerializer dcs = new System.Runtime.Serialization.DataContractSerializer(Type.GetType("System.String"));
                    //Convert the server's response to a string
                    string translation = (string)dcs.ReadObject(stream);

                    return translation;
                }
            }
            catch (WebException ex)
            {
                MessageBox.Show("Invalid:\n" + ex.Message + "\nSource: " + ex.Source);
                return null;
            }
        }

        //Handles the timer tick, which indicates 10 minutes have passed since token was gained
        private static void Tick(object o, ElapsedEventArgs eea)
        {
            //If the authentication is true, set it to false
            //Is here to make sure that every 10 minutes it isn't flipping the flag
            if (activeAuthentication)
            {
                activeAuthentication = false;
                checkAuth.Stop();
            }
        }

        public static bool Authentication
        {
            get
            {
                return activeAuthentication;
            }
        }
    }
}
