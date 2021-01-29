using System;

namespace AcTools.WheelAngles.Implementations {
    internal class ThrustmasterTGT : ThrustmasterT500 {
        public override string ControllerName => "Thrustmaster T-GT";

        public override bool Test(string productGuid) {
            return string.Equals(productGuid, "B684044F-0000-0000-0000-504944564944", StringComparison.OrdinalIgnoreCase);
        }

        protected override int ProductId => 0xb684;
    }
}