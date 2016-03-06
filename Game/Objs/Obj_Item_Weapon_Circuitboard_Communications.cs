// FILE AUTOGENERATED BY SOMNIUM13.

using System;
using Somnium.Engine.ByImpl;

namespace Somnium.Game {
	class Obj_Item_Weapon_Circuitboard_Communications : Obj_Item_Weapon_Circuitboard {

		public int lastTimeUsed = 0;

		protected override void __FieldInit() {
			base.__FieldInit();

			this.build_path = typeof(Obj_Machinery_Computer_Communications);
			this.origin_tech = "programming=2;magnets=2";
		}

		public Obj_Item_Weapon_Circuitboard_Communications ( dynamic loc = null ) : base( (object)(loc) ) {
			
		}

		// Function from file: buildandrepair.dm
		public int cooldownLeft( int? deciseconds = null ) {
			deciseconds = deciseconds ?? 600;

			return Num13.MaxInt( ( deciseconds ??0) - ( Game13.time - this.lastTimeUsed ), 0 );
		}

	}

}