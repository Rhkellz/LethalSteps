using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BepInEx.Logging;
using GameNetcodeStuff;
using HarmonyLib;

namespace LCmod1.Patches
{
    [HarmonyPatch(typeof(PlayerControllerB))]
    internal class PlayerControllerBPatch
    {
        internal static ManualLogSource stepLog;
        public static int numSteps = 0;
        [HarmonyPatch("PlayFootstepSound")]
        [HarmonyPostfix]
        static void stepCount() {
            stepLog = BepInEx.Logging.Logger.CreateLogSource("steps");
            numSteps++;
            stepLog.LogInfo("steps = " + numSteps);
        }
    }
}
