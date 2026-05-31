A mod and APWorld made in 2 days with a lot of help 
(my first ever game mod)

---

## How to install
(tutorial totally not copy and pasted from Tunic AP mod and BTD6 Mod helper)

1. Make sure to have [.Net6.0](https://dotnet.microsoft.com/en-us/download/dotnet/6.0) installed
2. Download and Install [Melon Loader](https://melonwiki.xyz/#/?id=automated-installation).
  - The default Placid Plastic Duck Simulator install directory (for steam): C:\Program Files (x86)\Steam\steamapps\common\Placid Plastic Duck Simulator
  - Make sure to use melon version: 7.3
3. Launch the game and close it. This will finalize the Melon installation.
  - If melon doesn't correctly install, then something is interfering with it like an antivirus/antimalware
4. Download and extract the `Duckipelago.zip` from the [latest release page](https://github.com/SWCreeperKing/PPDSArchipelago/releases/latest).
  - Copy the `Mods` and `UserLibs` folders from the zip into the game's directory.
  - To verify this is done correctly, the mod's path should be `Placid Plastic Duck Simulator/Mods/PPDSAP.dll`
5. Launch the game again and you should see the connection input on the top left of the title screen!
  - If melon is fine but the mod doesn't load check to make sure there isn't a `~` infront of `SW_CreeperKing.Duckipelago`, if so remove it
6. To uninstall the mod, either remove/delete/rename the `Placid Plastic Duck Simulator/Mods/PPDSAP.dll` folder

---

## Randomizer Info

- new game only appears once you connect to ap
- removed the ability to save (not needed)
- removed the ability to resume a save (not needed because you can't save)
- the classic spawner was shut down and replaced with a custom one
  - it will only spawn ducks from columns you have available, if you have no more unique ducks, it will spawn a random one from the available pool
  - random ducks do not count for checks
- goal requires all the 46 (excluding the alien) from the first page of the collection to be found
- `Progressive Column Unlock`
  - will make the next column in the collection book available to spawn
  - the first column is a given
- `Progressive Spawn Speed Upgrade`
  - spawn speed is calculated as so: [120 - `Progressive Spawn Speed Upgrade` amount * 10]
  - there are 9 of these so 120s -> 30s
- `Random Duck`
  - spawns a duck from the random pool
- funny quirks
  - will goal before sending last check
  - crashes when loosing connection
  - as long as you don't bk the MAX time to goal is 1hr 30min

---

# Special Thanks

- Sterlia for buying me the game and 'forcing' me to make an ap for it
- Silent, Ethical Logic, and FyreDay for programming support
- BadMagic for telling me about IlRepack

---

# Tools:

- ~~BepInEx~~ Melon Loader (obv) 
- Rider
- ILRepacker
- UnityExplorer (yukieiji fork)
