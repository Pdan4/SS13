// FILE AUTOGENERATED BY SOMNIUM13.

using System;
using Somnium.Engine.ByImpl;

namespace Somnium.Game {
	class Obj_Item_Weapon_Resonator_Upgraded : Obj_Item_Weapon_Resonator {

		protected override void __FieldInit() {
			base.__FieldInit();

			this.item_state = "resonator_u";
			this.origin_tech = "magnets=3;combat=3";
			this.fieldlimit = 5;
			this.icon_state = "resonator_u";
		}

		public Obj_Item_Weapon_Resonator_Upgraded ( dynamic loc = null ) : base( (object)(loc) ) {
			
		}

	}

}