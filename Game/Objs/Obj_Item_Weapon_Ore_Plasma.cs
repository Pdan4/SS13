// FILE AUTOGENERATED BY SOMNIUM13.

using System;
using Somnium.Engine.ByImpl;

namespace Somnium.Game {
	class Obj_Item_Weapon_Ore_Plasma : Obj_Item_Weapon_Ore {

		protected override void __FieldInit() {
			base.__FieldInit();

			this.origin_tech = "materials=2";
			this.material = "$plasma";
			this.melt_temperature = 2283.14990234375;
			this.icon_state = "Plasma ore";
		}

		public Obj_Item_Weapon_Ore_Plasma ( dynamic loc = null ) : base( (object)(loc) ) {
			
		}

	}

}