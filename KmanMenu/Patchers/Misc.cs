using GorillaLocomotion;
using HarmonyLib;
using System;
using System.Collections.Generic;
using System.Text;
using UnityEngine;

namespace KmanMenu.Patchers.Misc
{
    [HarmonyPatch(typeof(GameObject))]
    [HarmonyPatch("CreatePrimitive", MethodType.Normal)]
    internal class GameObjectPatch
    {
        private static void Postfix(GameObject __result)
        {
            __result.GetComponent<Renderer>().material.shader = Shader.Find("GorillaTag/UberShader");
            __result.GetComponent<Renderer>().material.color = Color.black;
        }
    }

    [HarmonyPatch(typeof(Player))]
    [HarmonyPatch("AntiTeleportTechnology", MethodType.Normal)]
    internal class AntiTeleportTechnologyPatch
    {
        private static bool Prefix()
        {
            Player.Instance.teleportThresholdNoVel = int.MaxValue;
            return false;
        }
    }

    [HarmonyPatch(typeof(GorillaNetworkPublicTestsJoin))]
    [HarmonyPatch("GracePeriod", MethodType.Enumerator)]
    class NoGracePeriod
    {
        public static bool Prefix()
        {
            return false;
        }
    }

    [HarmonyPatch(typeof(GorillaNetworkPublicTestJoin2))]
    [HarmonyPatch("LateUpdate", MethodType.Normal)]
    class NoGracePeriod2
    {
        public static bool Prefix()
        {
            return false;
        }
    }
}
