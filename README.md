# HKDamageLimit
Hollow Knight mod that sets all damage received to 0 or 1.

You can enable this mod or change its setting any time during a game. The purpose is that you can choose when to make a certain section easier, and then return the game to normal if you want.

# Usage
The mod can be used with existing saves.

Once it's installed, an entry will appear in Pause Menu > Options > Mods. Use the settings to select always low damage or no damage at all, or disable the mod entirely and play as normal.

# Install
Requires the [Modding API](https://github.com/hk-modding/api). Tested with version 1.5.78.11833-71.

Place the file `HKDamageLimit.dll` inside `Hollow Knight_Data > Managed > Mods > HKDamageLimit`.

# Build
Place a copy of a Hollow Knight installation's `Hollow Knight_Data` directory in the project directory and rename it to `HollowKnightManaged`.

Alternatively, modify `HKDamageLimit.csproj` to point to the existing directory in your Hollow Knight installation.

Build with `dotnet build` or any other method. The resulting file will be in a `bin` subdirectory, named `HKDamageLimit.dll`.

License
=======
Distributed under the MIT [license](https://github.com/GistOfSpirit/HKDamageLimit/blob/main/LICENSE).
