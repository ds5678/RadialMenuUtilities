using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RadialMenuUtilities
{
    internal class RadialUtils
    {
        public static GearItem[] GetBestGearItems(string[] gearNames)
        {
            GearItem[] result = new GearItem[gearNames.Length];
            for (int i = 0; i < gearNames.Length; i++)
            {
                result[i] = GameManager.GetInventoryComponent().GetHighestConditionGearThatMatchesName(gearNames[i]);
            }
            return result;
        }

        public static GearItem[] GetWorstGearItems(string[] gearNames)
        {
            GearItem[] result = new GearItem[gearNames.Length];
            for (int i = 0; i < gearNames.Length; i++)
            {
                result[i] = GameManager.GetInventoryComponent().GetLowestConditionGearThatMatchesName(gearNames[i]);
            }
            return result;
        }

        public static GearItem[] GetAllGearItems(string gearName)
        {
            Il2CppSystem.Collections.Generic.List<GearItem> result = new Il2CppSystem.Collections.Generic.List<GearItem>();
            GameManager.GetInventoryComponent().GetItems(gearName, result);
            return result.ToArray();
        }

        public static GearItem[] GetAllGearItems(string[] gearNames)
        {
            List<GearItem> result = new List<GearItem>();
            foreach(string gearName in gearNames)
            {
                GearItem[] items = GetAllGearItems(gearName);
                result.AddRange(items);
            }
            return result.ToArray();
        }

        public static int GetNumberNotNull<T>(T[] array)
        {
            int num = 0;
            for (int i = 0; i < array.Length; i++)
            {
                if (!(array[i] == null))
                {
                    num++;
                }
            }
            return num;
        }

        public static T[] Combine<T>(T[] array1, T[] array2)
        {
            T[] result = new T[array1.Length + array2.Length];
            for (int i = 0; i < array1.Length; i++)
            {
                result[i] = array1[i];
            }
            for (int j = 0; j < array2.Length; j++)
            {
                result[j + array1.Length] = array2[j];
            }
            return result;
        }
    }
}
