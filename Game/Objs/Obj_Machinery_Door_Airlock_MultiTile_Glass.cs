// FILE AUTOGENERATED BY SOMNIUM13.

using System;
using Somnium.Engine.ByImpl;

namespace Somnium.Game {
	class Obj_Machinery_Door_Airlock_MultiTile_Glass : Obj_Machinery_Door_Airlock_MultiTile {

		protected override void __FieldInit() {
			base.__FieldInit();

			this.glass = true;
			this.assembly_type = "obj/structure/door_assembly/multi_tile";
			this.icon = "icons/obj/doors/Door2x1glass.dmi";
		}

		public Obj_Machinery_Door_Airlock_MultiTile_Glass ( dynamic loc = null ) : base( (object)(loc) ) {
			
		}

		// Function from file: multi_tile.dm
		public override void bump_open( Mob_Living user = null ) {
			
			if ( user is Mob_Living_SimpleAnimal_Hostile_GiantSpider ) {
				return;
			}
			base.bump_open( user );
			return;
		}

	}

}