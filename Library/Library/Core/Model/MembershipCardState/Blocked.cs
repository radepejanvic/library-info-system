﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Library.Core.Model.MembershipCardState
{
    public class Blocked : State
    {
        public Blocked(MembershipCard membershipCard) : base(membershipCard) { }

    }
}
