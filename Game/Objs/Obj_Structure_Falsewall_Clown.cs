// FILE AUTOGENERATED BY SOMNIUM13.

using System;
using Somnium.Engine.ByImpl;

namespace Somnium.Game {
	class Obj_Structure_Falsewall_Clown : Obj_Structure_Falsewall {

		protected override void __FieldInit() {
			base.__FieldInit();

			this.mineral = "bananium";
			this.walltype = "bananium";
			this.canSmoothWith = new ByTable(new object [] { typeof(Obj_Structure_Falsewall_Clown), typeof(Tile_Simulated_Wall_Mineral_Clown) });
			this.icon = "icons/turf/walls/bananium_wall.dmi";
			this.icon_state = "bananium";
		}

		public Obj_Structure_Falsewall_Clown ( dynamic loc = null ) : base( (object)(loc) ) {
			
		}

	}

}