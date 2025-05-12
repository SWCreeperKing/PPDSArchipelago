A mod and APWorld made in 2 days with a lot of help 

---

## How to install
(tutorial totally not copy and pasted from Tunic AP mod)

- Download [BepInEx 6 IL2Cpp Bleeding Edge v.735](https://builds.bepinex.dev/projects/bepinex_be/735/BepInEx-Unity.IL2CPP-win-x64-6.0.0-be.735%2B5fef357.zip).
- Extract the BepInEx zip folder you downloaded from the previous step into your game's install directory (For example: C:\Program Files (x86)\Steam\steamapps\common\Placid Plastic Duck Simulator)
- Launch the game and close it. This will finalize the BepInEx installation.
- Download and extract the `SW_CreeperKing.ArchipelagoMod.Zip` from the release page.
    - Copy the `SW_CreeperKing.ArchipelagoMod` folder from the release zip into `BepInEx/plugins` under your game's install directory.
- Launch the game again and you should see the connection input on the top left of the title screen!
- To uninstall the mod, either remove/delete the `SW_CreeperKing.ArchipelagoMod` folder from the plugins folder or rename the winhttp.dll file located in the game's root directory (this will disable all installed mods from running).

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

- BepInEx (obv)
- Rider
- ILRepacker
- UnityExplorer (yukieiji fork)