﻿using Capstone.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Capstone.DAO.Interfaces
{
    public interface IBreweryEventsDao
    {
      List<BreweryEvents> GetEventsByBreweryId(int breweryId);
    }
}
