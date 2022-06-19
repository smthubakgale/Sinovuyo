
using Nancy.Json;
using Newtonsoft.Json;  
using System.Collections.Generic; 

namespace Hybrid.Views.Layout
{
    public class JC<T>
    {
        //------------- Json Conversion 
        public JC() { }
        public T ToObj(string json)
        {
            T obj = JsonConvert.DeserializeObject<T>(json);

            return obj;
        }
        public List<T> ToObjArr(string json)
        {
            List<T> obj = JsonConvert.DeserializeObject<List<T>>(json);

            return obj;
        }
        public string ToJson(T obj)
        {
            var json = (new JavaScriptSerializer() { }).Serialize(obj);

            return json;
        }
        public string ToJsonArr(List<T> obj)
        {
            var json = "[";
            var cnt = 0;
            foreach (var item in obj)
            {
                cnt++;

                json += (new JavaScriptSerializer() { }).Serialize(item);

                if (cnt != obj.Count)
                {
                    json += " , ";
                }

            }
            json += "]";

            return json;
        } 
    }
}
