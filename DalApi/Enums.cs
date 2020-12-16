using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DO
{
   public enum Status
    {
        READY, INDRIVE, INREFUEL, INCARE, DANGEROUS
    }

    public enum Area//Areas for bus lines
    {
        GENERAL, NORTH, SOUTH, CENTER, JERUSALEM, SHFELA, WESTBANK
    }
}
