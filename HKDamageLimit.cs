using UnityEngine;
using Modding;
using System.Reflection;
using System.Collections.Generic;

namespace HKDamageLimitMod
{
	public class HKDamageLimit : Mod,
		ILocalSettings<DamageSettingData>,
		ITogglableMod,
		IMenuMod
	{
		public static HKDamageLimit LoadedInstance { get; set; }

		public DamageSettingData LocalSaveData { get; set; } = new();

		public bool ToggleButtonInsideMenu => true;

		public void OnLoadLocal(DamageSettingData s) => this.LocalSaveData = s;

		public DamageSettingData OnSaveLocal() => this.LocalSaveData;

		public override string GetVersion() => Assembly.GetExecutingAssembly()
			.GetName().Version.ToString();

		public override void Initialize()
		{
			if (HKDamageLimit.LoadedInstance != null)
			{
				return;
			}

			HKDamageLimit.LoadedInstance = this;

			ModHooks.TakeHealthHook += DamageModifier;
		}

		public void Unload()
		{
			ModHooks.TakeHealthHook -= DamageModifier;

			HKDamageLimit.LoadedInstance = null;
		}

		public List<IMenuMod.MenuEntry> GetMenuData(
			IMenuMod.MenuEntry? toggleButtonEntry)
		{
			var entry = new IMenuMod.MenuEntry(
				"All damage set to:",
				new string[] { "0", "1" },
				"Sets all damage received to a given number",
				MenuSaver,
				MenuLoader
			);

			return new List<IMenuMod.MenuEntry>()
			{
				entry,
				toggleButtonEntry.Value
			};
		}

		public void MenuSaver(int value)
		{
			this.LocalSaveData.DamageSetting = value;
		}

		public int MenuLoader()
		{
			return this.LocalSaveData.DamageSetting;
		}

		public int DamageModifier(int orig)
		{
			return this.LocalSaveData.DamageSetting;
		}
	}
}
