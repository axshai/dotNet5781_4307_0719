using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DO
{
    public class PassengerTravelDO
    {

     
       
        public int Id { get; set; }
        public String Name { get; set; }
        public string LineNumber { get; set; }
        public int StartingStation { get; set; }
        public int DestinationStation { get; set; }
        public DateTime Start { get; set; }
        public DateTime End { get; set; }
        public bool IsExists { get; set; }
        public override string ToString()
        {
            string result = "Id: " + Id.ToString() + "\nName: " + Name + "\nLineNumber" + LineNumber + "\nStartingStation: " + StartingStation.ToString() + "\nDestinationStation" + DestinationStation.ToString() + "\nStart: " + Start.ToString() + "\nEnd" + End.ToString() + "\nIsExists? " + IsExists.ToString();
            return result;
        }
    }
}
