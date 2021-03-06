// FILE AUTOGENERATED BY SOMNIUM13.

using System;
using Somnium.Engine.ByImpl;

namespace Somnium.Game {
	class Tile_Simulated_Wall_Mineral_Wood : Tile_Simulated_Wall_Mineral {

		protected override void __FieldInit() {
			base.__FieldInit();

			this.walltype = "wood";
			this.mineral = "wood";
			this.sheet_type = typeof(Obj_Item_Stack_Sheet_Mineral_Wood);
			this.hardness = 70;
			this.canSmoothWith = new ByTable(new object [] { typeof(Tile_Simulated_Wall_Mineral_Wood), typeof(Obj_Structure_Falsewall_Wood) });
			this.icon = "icons/turf/walls/wood_wall.dmi";
			this.icon_state = "wood";
		}

		public Tile_Simulated_Wall_Mineral_Wood ( dynamic loc = null ) : base( (object)(loc) ) {
			
		}

	}

}