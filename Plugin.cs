using GameReaderCommon;
using SimHub.Plugins;
using System.Collections.Generic;

namespace Havner.AccSteeringLock
{
    [PluginDescription("Sets SIMUCUBE steering lock based on loaded car")]
    [PluginAuthor("Havner")]
    [PluginName("ACC Steering Lock Setter")]

    public class Plugin : IPlugin, IDataPlugin
    {
        internal string lastCar;
        internal int lastRotation;
        internal SimuCube sc;
        internal Dictionary<string, int> cars;

        internal void ResetRotation()
        {
            if (lastRotation > 0)
            {
                SimHub.Logging.Current.Info("AccSteeringLock: resetting rotation from: " + lastRotation.ToString());
                if (!sc.Apply(lastRotation, true, out lastRotation))
                    SimHub.Logging.Current.Error("AccSteeringLock: SimuCube::Apply() failed.");
                lastRotation = 0;
            }
        }

        /// <summary>
        /// Instance of the current plugin manager
        /// </summary>
        public PluginManager PluginManager { get; set; }

        /// <summary>
        /// Called once after plugins startup
        /// Plugins are rebuilt at game change
        /// </summary>
        /// <param name="pluginManager"></param>
        public void Init(PluginManager pluginManager)
        {
            SimHub.Logging.Current.Info("AccSteeringLock: Init()");

            lastCar = null;
            lastRotation = 0;
            sc = new SimuCube();
            cars = new Dictionary<string, int>()
            {
                // GT3
                {"amr_v12_vantage_gt3", 640},
                {"amr_v8_vantage_gt3", 640},
                {"audi_r8_lms", 720},
                {"audi_r8_lms_evo", 720},
                {"bentley_continental_gt3_2016", 640},
                {"bentley_continental_gt3_2018", 640},
                {"bmw_m6_gt3", 565},
                {"jaguar_g3", 720},
                {"ferrari_488_gt3", 480},
                {"ferrari_488_gt3_evo", 480},
                {"honda_nsx_gt3", 620},
                {"honda_nsx_gt3_evo", 620},
                {"lamborghini_huracan_gt3", 620},
                {"lamborghini_huracan_gt3_evo", 620},
                {"lexus_rc_f_gt3", 640},
                {"mclaren_650s_gt3", 480},
                {"mclaren_720s_gt3", 480},
                {"mercedes_amg_gt3", 640},
                {"mercedes_amg_gt3_evo", 640},
                {"nissan_gt_r_gt3_2017", 640},
                {"nissan_gt_r_gt3_2018", 640},
                {"porsche_991_gt3_r", 800},
                {"porsche_991ii_gt3_r", 800},
                {"lamborghini_gallardo_rex", 720},
                // ST
                {"lamborghini_huracan_st", 620},
                // CUP
                {"porsche_991ii_gt3_cup", 800},
                // GT4
                {"alpine_a110_gt4", 720},
                {"amr_v8_vantage_gt4", 640},
                {"audi_r8_gt4", 720},
                {"bmw_m4_gt4", 490},
                {"chevrolet_camaro_gt4r", 720},
                {"ginetta_g55_gt4", 720},
                {"ktm_xbow_gt4", 580},
                {"maserati_mc_gt4", 900},
                {"mclaren_570s_gt4", 480},
                {"mercedes_amg_gt4", 490},
                {"porsche_718_cayman_gt4_mr", 800},
            };
        }

        /// <summary>
        /// Called at plugin manager stop, close/dispose anything needed here !
        /// Plugins are rebuilt at game change
        /// </summary>
        /// <param name="pluginManager"></param>
        public void End(PluginManager pluginManager)
        {
            SimHub.Logging.Current.Info("AccSteeringLock: End()");

            ResetRotation();
        }

        /// <summary>
        /// Called one time per game data update, contains all normalized game data,
        /// raw data are intentionnally "hidden" under a generic object type (A plugin SHOULD NOT USE IT)
        ///
        /// This method is on the critical path, it must execute as fast as possible and avoid throwing any error
        ///
        /// </summary>
        /// <param name="pluginManager"></param>
        /// <param name="data"></param>
        public void DataUpdate(PluginManager pluginManager, ref GameData data)
        {
            if (data.GameName != "AssettoCorsaCompetizione") return;
            if (!data.GameRunning)
            {
                ResetRotation();
                lastCar = null;
                return;
            }

            if (data.NewData == null) return;
            if (data.NewData.CarId == lastCar) return;

            ResetRotation();
            lastCar = data.NewData.CarId;
            if (cars.TryGetValue(lastCar, out int newRotation))
            {
                SimHub.Logging.Current.Info("AccSteeringLock: setting rotation of " + lastCar + " to: " + newRotation.ToString());
                if (!sc.Apply(newRotation, false, out lastRotation))
                    SimHub.Logging.Current.Error("AccSteeringLock: SimuCube::Apply() failed.");
            }
            else
            {
                SimHub.Logging.Current.Info("AccSteeringLock: no data for " + lastCar);
            }
        }
    }
}
