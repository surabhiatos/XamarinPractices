﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EmployeeManage
{
    public class FlyoutPageEmpFlyoutMenuItem
    {
        public FlyoutPageEmpFlyoutMenuItem()
        {
            TargetType = typeof(FlyoutPageEmpFlyoutMenuItem);
        }
        public int Id { get; set; }
        public string Title { get; set; }

        public Type TargetType { get; set; }
    }
}