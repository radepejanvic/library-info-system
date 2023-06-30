﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Library.Model;
using Library.Model.Enum;
using Library.ViewModel.Structure;

namespace Library.ViewModel
{
    public class StaticEquipmentViewModel : EquipmentViewModel
    {
        private readonly StaticEquipment _staticEquipment;


        public StaticEquipmentType Type => _staticEquipment.Type;
        public EquipmentPurpose Purpose => _staticEquipment.Purpose;

        public string EquipmentTypeWithQuantity => _staticEquipment.Type.ToString() + " : " + _staticEquipment.Quantity.ToString();
        public StaticEquipmentViewModel(StaticEquipment staticEquipment) : base(staticEquipment)
        {
            _staticEquipment = staticEquipment;
        }
 
    }
}
