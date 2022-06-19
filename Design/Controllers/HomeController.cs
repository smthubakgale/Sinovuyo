
using Nancy.Json;
using System; 

namespace Design.Controllers
{
    public class HomeController
    { 
        public string Get0(string controller, string func, string param)
        { 
            Type type = Type.GetType("Design.Controller.Systems." + controller);
            var obj = Activator.CreateInstance(type);
            var method = obj.GetType().GetMethod(func);
            var ret = method.Invoke(obj, new object[1] { param });

            return (new JavaScriptSerializer()).Serialize(ret);
        } 
        public string Post0(string controller, string func, string param)
        { 
            Type type = Type.GetType("Design.Controller.Systems." + controller);
            var obj = Activator.CreateInstance(type);
            var method = obj.GetType().GetMethod(func);
            var ret = method.Invoke(obj, new object[1] { param });

            return (string) ret;
        } 
    }
}
