// FILE AUTOGENERATED BY SOMNIUM13.

using System;
using Somnium.Engine.ByImpl;

namespace Somnium.Game {
	class Obj_Structure_SnowFlora_Tree_Pine_Xmas : Obj_Structure_SnowFlora_Tree_Pine {

		protected override void __FieldInit() {
			base.__FieldInit();

			this.icon_state = "pine_c";
		}

		// Function from file: snow.dm
		public Obj_Structure_SnowFlora_Tree_Pine_Xmas ( dynamic loc = null ) : base( (object)(loc) ) {
			Tile_Simulated_Floor T = null;
			bool blocked = false;
			Ent_Static A = null;
			int? i = null;

			// Warning: Super call was HERE! If anything above HERE is needed by the super call, it might break!;
			this.icon_state = "pine_c";

			foreach (dynamic _b in Lang13.Enumerate( Map13.FetchInRangeExcludeThis( this, 1 ), typeof(Tile_Simulated_Floor) )) {
				T = _b;
				
				blocked = false;

				foreach (dynamic _a in Lang13.Enumerate( T, typeof(Ent_Static) )) {
					A = _a;
					

					if ( A.density ) {
						blocked = true;
					}
				}

				if ( blocked ) {
					continue;
				}
				i = null;
				i = 1;

				while (( i ??0) <= Rand13.Int( 1, 3 )) {
					Lang13.Call( typeof(Obj_Item_Weapon_WinterGift).GetMethod( "pick_a_gift" ), T, 5 );
					i++;
				}
			}
			return;
		}

	}

}