// FILE AUTOGENERATED BY SOMNIUM13.

using System;
using Somnium.Engine.ByImpl;

namespace Somnium.Game {
	class SpriteAccessory_Skin_Skrell : SpriteAccessory_Skin {

		protected override void __FieldInit() {
			base.__FieldInit();

			this.name = "Default skrell skin";
			this.icon_state = "default";
			this.icon = "icons/mob/human_races/r_skrell.dmi";
			this.species_allowed = new ByTable(new object [] { "Skrell" });
		}

	}

}