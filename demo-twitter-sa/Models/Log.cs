using System;

namespace DemoTwitterSA.Models
{
    public class Log
    {
        public Log()
        {
            this.DateTime = DateTime.Now;
        }

        public int Id { get; set; }
        public DateTime DateTime { get; set; }
        public string Action { get; set; }
        public string Message { get; set; }
    }
}