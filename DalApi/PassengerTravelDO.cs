using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DO
{
    public class PassengerTravelDO
    {
        public PassengerTravelDO()
        {
            Id = Ids++;
        }

        public static int Ids { get; set; }
        public int Id { get; set; }
        public String Name { get; set; }
        public string LineNumber { get; set; }
        public int StartingStation { get; set; }
        public int DestinationStation { get; set; }
        public DateTime Start { get; set; }
        public DateTime End { get; set; }
        public bool IsExists { get; set; }
    }
}
