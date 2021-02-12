# RadialMenuUtilities

A utility mod for *The Long Dark* that adds the ability for other mods to create custom radial menus. Used as a dependency for other mods.

## Installation

1. If you haven't done so already, install MelonLoader by downloading and running [MelonLoader.Installer.exe](https://github.com/HerpDerpinstine/MelonLoader/releases/latest/download/MelonLoader.Installer.exe)
2. Download the latest version of `RadialMenuUtilities.dll` from the [releases page](https://github.com/ds5678/RadialMenuUtilities/releases)
3. Download the latest version of `KeyboardUtilities.dll` from the [releases page](https://github.com/ds5678/KeyboardUtilities/releases).
4. Move `RadialMenuUtilities.dll` and `KeyboardUtilities.dll` into the Mods folder in your TLD install directory

## Use

If the radial menu does not require that the keycode be changeable, it can be declared with one line.
```
RadialMenuUtilities.CustomRadialMenu radialMenu = new RadialMenuUtilities.CustomRadialMenu(KeyCode.T, RadialMenuUtilities.CustomRadialMenuType.AllOfEach, new string[] {"GEAR_JerrycanRusty", "GEAR_KeroseneLampB"});
```
This line only needs to be run once. The `RadialMenuUtilities` mod will handle the custom radial after that.

### Changeable KeyCode and ability to disable

Take a look at `BetterFuelSettings.cs` in the [Better Fuel Management](https://github.com/ds5678/Better-Fuel-Management) mod.