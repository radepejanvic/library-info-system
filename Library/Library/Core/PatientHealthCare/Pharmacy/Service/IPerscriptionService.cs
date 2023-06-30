﻿using System.Collections.Generic;
using Library.Model;

namespace Library.Service.FarmaceuticalService.Interface
{
    public interface IPerscriptionService
    {
        void Add(Perscription drug);
        Perscription Get(int id);
        Dictionary<int, Perscription> GetAll();
        Dictionary<int, Perscription> GetAll(int patientId);
        void Remove(int id);
        void Update(Perscription drug);
    }
}