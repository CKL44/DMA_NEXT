using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DMA_NEXT
{
    public class Items 
    {
        public string Item { get; set; }
        public string Value { get; set; }
        public string Path { get; set; }
        public string Key { get; set; }
        public string Component { get; set; }
        public string Status { get; set; }
        public string Recommended { get; set; }


        public Items(string item, string value, string bestpractice, string path, string key, string compon)
        {
            this.Item = item; ;
            this.Value = value;
            this.Path = path;
            this.Key = key;
            this.Component = compon;
            this.Recommended = bestpractice;

        }

    }
}
