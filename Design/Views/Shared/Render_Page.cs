using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Design.Views.Shared
{
    public class Render_Page
    {
        // Variables
        public int Id { get; set; }
        public string Title { get; set; }

        public Type TargetType { get; set; }

        // Constructor
        public Render_Page()
        {
            TargetType = typeof(Render_Page);
        }
        // :::::::::::
    }
}