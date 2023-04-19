﻿using System;

namespace AcTools.WheelAngles.Implementations {
    internal class ThrustmasterFerrariF1Advanced1 : ThrustmasterT500 {
        public override string ControllerName => "Thrustmaster Ferrari F1 Advanced";

        public override bool Test(string productGuid) {
            return string.Equals(productGuid, "B66B044F-0000-0000-0000-504944564944", StringComparison.OrdinalIgnoreCase);
        }

        protected override int ProductId => 0xb66b;
    }
}