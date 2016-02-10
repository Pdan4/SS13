// FILE AUTOGENERATED BY SOMNIUM13.

using System;
using Somnium.Engine.ByImpl;

namespace Somnium.Game {
	class Obj_Structure_Window_Reinforced_Plasma : Obj_Structure_Window_Reinforced {

		protected override void __FieldInit() {
			base.__FieldInit();

			this.shardtype = typeof(Obj_Item_Weapon_Shard_Plasma);
			this.sheettype = typeof(Obj_Item_Stack_Sheet_Glass_Plasmarglass);
			this.health = 160;
			this.penetration_dampening = 7;
			this.icon_state = "plasmarwindow";
		}

		public Obj_Structure_Window_Reinforced_Plasma ( dynamic loc = null ) : base( (object)(loc) ) {
			
		}

		// Function from file: window.dm
		public override bool fire_act( GasMixture air = null, double? exposed_temperature = null, int exposed_volume = 0 ) {
			return false;
		}

	}

}