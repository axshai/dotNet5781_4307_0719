using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace dotNet5781_02_4307_0719
{
    public enum OPERATION //Choices for main menu
    {
        ADD, DELETE, FIND, PRINT, EXIT = -1
    }

    public enum Area//Areas for bus lines
    {  
        GENERAL, NORTH, SOUTH, CENTER, JERUSALEM, SHFELA, WESTBANK
    }

    public enum CHOICE //Choice, 0 for bus line, 1 for station (Add or remove)
    {
        ZERO, ONE
    }
}