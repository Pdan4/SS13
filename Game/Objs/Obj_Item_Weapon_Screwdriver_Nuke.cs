// FILE AUTOGENERATED BY SOMNIUM13.

using System;
using Somnium.Engine.ByImpl;

namespace Somnium.Game {
	class Obj_Item_Weapon_Screwdriver_Nuke : Obj_Item_Weapon_Screwdriver {

		protected override void __FieldInit() {
			base.__FieldInit();

			this.item_state = "screwdriver_nuke";
			this.toolspeed = 2;
			this.icon = "icons/obj/nuke_tools.dmi";
			this.icon_state = "screwdriver_nuke";
		}

		// Function from file: nuke_tools.dm
		public Obj_Item_Weapon_Screwdriver_Nuke ( dynamic loc = null, string param_color = null ) : base( (object)(loc), param_color ) {
			return;
		}

	}

}