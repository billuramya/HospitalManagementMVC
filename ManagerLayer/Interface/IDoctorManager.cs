﻿using CommonLayer.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ManagerLayer.Interface
{
    public interface IDoctorManager
    {
        public bool AddDoctor(DoctorModel doctor);
        public List<DoctorModel> GetAllDoctor();
        public DoctorModel GetDoctorById(int id);
        public bool UpdateDoctor(DoctorModel doctor);
        public bool DeleteDoctorById(int id);

    }
}