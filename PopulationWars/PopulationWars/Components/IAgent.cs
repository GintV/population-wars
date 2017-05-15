﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PopulationWars.Components
{
    /*
     * Interface for Agents that allows to specify where agent's
     * data is / can be stored and to force loading of said data
     */
    public interface IAgent : IGovernment
    {
        void SetDataPath(string path);
        bool LoadData();
    }
}
