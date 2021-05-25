using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Text;
namespace JsonToDictionary
{
    public class Converter3000
    {
        private Dictionary<string, string> _pairs;
        private StringBuilder _name = new();

        private void FindKeyValuePairs(JObject jobj)
        {
            int position;

            foreach (var item in jobj)
            {
                try
                {
                    _name.Append(_name.Length != 0 ? (':' + item.Key) : (item.Key));
                    FindKeyValuePairs((JObject)item.Value);
                }
                catch (InvalidCastException)
                {
                    string value = item.Value.ToString();

                    _pairs.Add(_name.ToString(), value);

                    position = _name.ToString().LastIndexOf(':');
                    _name.Remove(position, _name.Length - position);
                }
                catch (ArgumentException)
                {
                    // skip adding the same values

                    position = _name.ToString().LastIndexOf(':');
                    _name.Remove(position, _name.Length - position);
                }
            }

            position = _name.ToString().LastIndexOf(':');
            if (position != -1)
            {
                _name.Remove(position, _name.Length - position);
            }
        }

        /// <summary>
        /// Desserializes and converts JSON to Dictionary.
        /// </summary>
        /// <param name="json">Parameter can only accept typed json data</param>
        /// <returns>Returns a collection of value keys containing the value path and value.</returns>
        public Dictionary<string, string> ConvertJsonToDictionary(string json)
        {
            _pairs = new();

            try
            {
                JObject _json = (JObject)JsonConvert.DeserializeObject(json);

                FindKeyValuePairs(_json);
            }
            catch (JsonReaderException)
            {
                throw new JsonReaderException("You are using the wrong json");
            }

            return _pairs;
        }

        /// <summary>
        /// Desserializes and converts JSON to Dictionary.
        /// </summary>
        /// <param name="json">Parameter can only accept typed json data</param>
        /// <returns>Returns a collection of value keys containing the value path and value.</returns>
        public Dictionary<string, string> ConvertJsonToDictionary(JObject json)
        {
            _pairs = new();

            FindKeyValuePairs(json);

            return _pairs;
        }

        /// <summary>
        /// Method to display data in dictionary. 
        /// Use only after method ConvertJsonToDictionary is called
        /// </summary>
        public void ShowConvertedData()
        {
            if(_pairs.Count > 0)
            {
                Console.WriteLine("***** Show converted data *****");
                foreach (var item in _pairs)
                {
                    Console.WriteLine($"\"{item.Key}\" = \"{item.Value}\"");
                }
                Console.WriteLine("* * * * *  The End  * * * * * *\n");
            }
            else
            {
                Console.WriteLine("***** Dictionary is empty *****\n");
            }
        }
    }
}