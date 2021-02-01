using System;
using System.Collections.Generic;
using System.Text;

namespace Radar.Library.Models.Entity
{
    public class Alert
    {
        public DateTime AlertTime 
        {
            get { return AlertTime; }
            set { AlertTime = DateTime.Now; }
        }

        
    }
}
