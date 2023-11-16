using HarmonyLib;
using System;
using System.Collections.Generic;
using System.Net;
using System.Text;
using UnityEngine;
using UnityEngine.UI;

namespace KmanMenu.Patchers.BoardPatchers
{
    [HarmonyPatch(typeof(GorillaLevelScreen), "UpdateText", MethodType.Normal)]
    public class UpdateText
    {
        static string fullstr;
        static bool Prefix(string newText, bool setToGoodMaterial, GorillaLevelScreen __instance)
        {
            if (newText == "")
            {
                if (__instance != null)
                {
                    Plugin.debug.LogDebug("Boards Updated!");
                    Color col = Color.red *0.3f;
                    GameObject.Find("Environment Objects/LocalObjects_Prefab/City/CosmeticsRoomAnchor/monitor (1)").GetComponent<Renderer>().material.color = col;

                    GameObject.Find("Environment Objects/LocalObjects_Prefab/Forest/Terrain/campgroundstructure/scoreboard/REMOVE board").GetComponent<Renderer>().material.color = col;
                    __instance.gameObject.GetComponent<Renderer>().material.color = col;
                }
                return false;
            }
            return true;
        }
    }

}
