/*
    Thubakgale MS - 201701870
    27-10-2021
 */
using Hybrid.Views.Layout;
using System.Collections.Generic; 

namespace Design.Controller.Systems
{
    public class TestController
    {  
        //-- Post
        public string post1(string param)
        {
            var res = param;

            return res;
        } 
        //-- Get  
        public List<string> get1(string param)
        {
            var res = new List<string>() {"1" , param };
             
            return res;
        } 
    }
}