﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BO;
namespace BLApi
{
    public interface IBL
    {
        IEnumerable<BusLineBO> GetAllLines();
    }
}