using System;

namespace Station.DB
{
    [Serializable]
    public class Document
    {
        public string Name { get; set; }
        public Station Station { get; set; }
        public Document()
        {
            Station= new Station();
        }
    }
}
