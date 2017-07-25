﻿using GuildCars.Models.Tables;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GuildCars.Data.Interfaces
{
    public interface ISpecialsRepository
    {
        IEnumerable<Special> GetAll();
        Special GetSpecialById(int SpecialId);
    }
}