using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Harmony;

namespace RadialMenuUtilities
{
    internal class Patches
    {
        [HarmonyPatch(typeof(GameManager), "Update")]
        internal class ShowMenus
        {
            private static void Postfix()
            {
                RadialMenuManager.MaybeShowMenu();
            }
        }

        [HarmonyPatch(typeof(Panel_ActionsRadial), "CanPlaceFromRadial")]
        internal class PlaceAnything
        {
            private static void Postfix(ref bool __result)
            {
                __result = true;
            }
        }
    }
}
