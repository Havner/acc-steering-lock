﻿using System;

namespace AcTools.WheelAngles.Implementations {
    internal class ThrustmasterTSPC : ThrustmasterT500 {
        public override string ControllerName => "Thrustmaster TS-PC Racer";

        public override bool Test(string productGuid) {
            return string.Equals(productGuid, "B689044F-0000-0000-0000-504944564944", StringComparison.OrdinalIgnoreCase);
        }

        protected override int ProductId => 0xb689;
    }
}