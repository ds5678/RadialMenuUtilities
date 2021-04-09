using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;

namespace RadialMenuUtilities
{
    internal class RadialMenuManager
    {
        private static List<CustomRadialMenu> radialMenuList = new List<CustomRadialMenu>();

        internal static bool ContainsKeyCode(KeyCode key)
        {
            foreach(CustomRadialMenu radialMenu in radialMenuList)
            {
                if(radialMenu.enabled && radialMenu.GetKeyCode() == key)
                {
                    return true;
                }
            }
            return false;
        }

        internal static bool ContainsConflict(CustomRadialMenu customRadialMenu)
        {
            foreach (CustomRadialMenu radialMenu in radialMenuList)
            {
                bool bothEnabled = radialMenu.enabled && customRadialMenu.enabled;
                bool sameKey = radialMenu.GetKeyCode() == customRadialMenu.GetKeyCode();
                bool sameObject = radialMenu == customRadialMenu;

                if (bothEnabled && sameKey && !sameObject)
                {
                    return true;
                }
            }
            return false;
        }
        
        internal static void AddToList(CustomRadialMenu customRadialMenu)
        {
            radialMenuList.Add(customRadialMenu);
        }

        internal static void MaybeShowMenu()
        {
            foreach (CustomRadialMenu radialMenu in radialMenuList)
            {
                if (radialMenu.enabled)
                {
                    KeyCode keyCode = radialMenu.GetKeyCode();
                    if (KeyboardUtilities.InputManager.GetKeyDown(keyCode))
                    {
                        if(CanShowRadialMenu()) InputManager.OpenRadialMenu();
                    }
                    if (KeyboardUtilities.InputManager.GetKey(keyCode))
                    {
                        if (CanShowRadialMenu()) radialMenu.ShowGearItems();
                    }
                }
            }
            
        }

        public static bool CanShowRadialMenu()
        {
            return !GameManager.GetPlayerManagerComponent().IsInPlacementMode() && !IsOverlayActive();
        }
        public static bool IsOverlayActive()
        {
            return (InterfaceManager.IsOverlayActiveCached() && !InterfaceManager.m_Panel_ActionsRadial.IsEnabled() || uConsole.IsOn());
        }
        /*public static bool IsOverlayActive()
        {
            return InterfaceManager.m_Panel_ActionPicker.IsEnabled() || InterfaceManager.m_Panel_Actions.IsEnabled()
                || InterfaceManager.m_Panel_Affliction.IsEnabled() || InterfaceManager.m_Panel_Badges.IsEnabled() 
                || InterfaceManager.m_Panel_BedRollSelect.IsEnabled() || InterfaceManager.m_Panel_BodyHarvest.IsEnabled() 
                || InterfaceManager.m_Panel_BreakDown.IsEnabled() || InterfaceManager.m_Panel_CanOpening.IsEnabled() 
                || InterfaceManager.m_Panel_ChallengeComplete.IsEnabled() || InterfaceManager.m_Panel_Challenges.IsEnabled()
                || InterfaceManager.m_Panel_Choose4DON.IsEnabled() || InterfaceManager.m_Panel_ChooseChallenge.IsEnabled() 
                || InterfaceManager.m_Panel_ChooseEpisodeExperience.IsEnabled() || InterfaceManager.m_Panel_ChooseSandbox.IsEnabled() 
                || InterfaceManager.m_Panel_ChooseStory.IsEnabled() || InterfaceManager.m_Panel_Clothing.IsEnabled() 
                || InterfaceManager.m_Panel_Confirmation.IsEnabled() || InterfaceManager.m_Panel_Container.IsEnabled() 
                || InterfaceManager.m_Panel_Cooking.IsEnabled() || InterfaceManager.m_Panel_Crafting.IsEnabled() 
                || InterfaceManager.m_Panel_Credits.IsEnabled() || InterfaceManager.m_Panel_CustomXPSetup.IsEnabled()
                || InterfaceManager.m_Panel_Debug.IsEnabled() || InterfaceManager.m_Panel_Diagnosis.IsEnabled()
                || InterfaceManager.m_Panel_EpisodeContinue.IsEnabled() || InterfaceManager.m_Panel_EpisodeSelection.IsEnabled()
                || InterfaceManager.m_Panel_Extras.IsEnabled() || InterfaceManager.m_Panel_FeedFire.IsEnabled() 
                || InterfaceManager.m_Panel_FireStart.IsEnabled() || InterfaceManager.m_Panel_FirstAid.IsEnabled()
                || InterfaceManager.m_Panel_GearSelect.IsEnabled() || InterfaceManager.m_Panel_GenericProgressBar.IsEnabled() 
                || InterfaceManager.m_Panel_Harvest.IsEnabled() || InterfaceManager.m_Panel_Help.IsEnabled()
                || InterfaceManager.m_Panel_HUD.IsShowingCollectibleNote() || InterfaceManager.m_Panel_IceFishing.IsEnabled() 
                || InterfaceManager.m_Panel_IceFishingHoleClear.IsEnabled() || InterfaceManager.m_Panel_Inventory.IsEnabled() 
                || InterfaceManager.m_Panel_Inventory_Examine.IsEnabled() || InterfaceManager.m_Panel_Knowledge.IsEnabled()
                || InterfaceManager.m_Panel_LeanToBuild.IsEnabled() || InterfaceManager.m_Panel_LeanToInteract.IsEnabled() 
                || InterfaceManager.m_Panel_Loading.IsEnabled() || InterfaceManager.m_Panel_Log.IsEnabled() 
                || InterfaceManager.m_Panel_MainMenu.IsEnabled() || InterfaceManager.m_Panel_Map.IsEnabled()
                || InterfaceManager.m_Panel_MarkerList.IsEnabled() || InterfaceManager.m_Panel_Milling.IsEnabled() 
                || InterfaceManager.m_Panel_MissionsStory.IsEnabled() || InterfaceManager.m_Panel_Notifications.IsEnabled() 
                || InterfaceManager.m_Panel_OptionsMenu.IsEnabled() || InterfaceManager.m_Panel_PauseMenu.IsEnabled() 
                || InterfaceManager.m_Panel_PickUnits.IsEnabled() || InterfaceManager.m_Panel_PickWater.IsEnabled() 
                || InterfaceManager.m_Panel_Repair.IsEnabled() || InterfaceManager.m_Panel_Rest.IsEnabled() 
                || InterfaceManager.m_Panel_SafeCracking.IsEnabled() || InterfaceManager.m_Panel_Sandbox.IsEnabled() 
                || InterfaceManager.m_Panel_Sandbox4DON.IsEnabled() || InterfaceManager.m_Panel_SaveStory.IsEnabled() 
                || InterfaceManager.m_Panel_SelectChallengeType.IsEnabled() || InterfaceManager.m_Panel_SelectExperience.IsEnabled() 
                || InterfaceManager.m_Panel_SelectRegion.IsEnabled() || InterfaceManager.m_Panel_SelectSurvivor.IsEnabled() 
                || InterfaceManager.m_Panel_SnowShelterBuild.IsEnabled() || InterfaceManager.m_Panel_SnowShelterInteract.IsEnabled()
                || InterfaceManager.m_Panel_SprayPaint.IsEnabled() || InterfaceManager.m_Panel_Story.IsEnabled() 
                || InterfaceManager.m_Panel_TorchLight.IsEnabled() || InterfaceManager.m_Panel_TutorialPopup.IsEnabled()
                || InterfaceManager.m_Panel_WeaponPicker.IsEnabled() || InterfaceManager.m_Panel_WorldMap.IsEnabled() 
                || GameManager.GetPlayerStruggleComponent().IsControllingCamera() 
                || InterfaceManager.m_Panel_HUD.m_AccelTimePopup.IsActive() 
                || GameManager.GetPlayerManagerComponent().IsInspectModeActive();
        }*/
    }
}
