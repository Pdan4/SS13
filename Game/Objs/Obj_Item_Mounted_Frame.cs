// FILE AUTOGENERATED BY SOMNIUM13.

using System;
using Somnium.Engine.ByImpl;

namespace Somnium.Game {
	class Obj_Item_Mounted_Frame : Obj_Item_Mounted {

		public int sheets_refunded = 2;
		public ByTable mount_reqs = new ByTable();
		public Type frame_material = typeof(Obj_Item_Stack_Sheet_Metal);

		protected override void __FieldInit() {
			base.__FieldInit();

			this.w_type = 4;
		}

		public Obj_Item_Mounted_Frame ( dynamic loc = null ) : base( (object)(loc) ) {
			
		}

		// Function from file: frames.dm
		public override bool try_build( dynamic on_wall = null, dynamic user = null, bool? proximity_flag = null ) {
			dynamic turf_loc = null;

			
			if ( base.try_build( (object)(on_wall), (object)(user), proximity_flag ) ) {
				turf_loc = GlobalFuncs.get_turf( user );

				if ( this.mount_reqs.Find( "simfloor" ) != 0 && !( turf_loc is Tile_Simulated_Floor ) ) {
					GlobalFuncs.to_chat( user, "<span class='rose'>" + this + " cannot be placed on this spot.</span>" );
					return false;
				}

				if ( this.mount_reqs.Find( "nospace" ) != 0 && ( !this.areaMaster.requires_power || this.areaMaster.type == typeof(Zone) ) ) {
					GlobalFuncs.to_chat( user, "<span class='rose'>" + this + " cannot be placed in this area.</span>" );
					return false;
				}
				return true;
			}
			return false;
		}

		// Function from file: frames.dm
		public override dynamic attackby( dynamic a = null, dynamic b = null, dynamic c = null ) {
			Game_Data S = null;

			base.attackby( (object)(a), (object)(b), (object)(c) );

			if ( a is Obj_Item_Weapon_Wrench && this.sheets_refunded != 0 ) {
				S = GlobalFuncs.getFromPool( this.frame_material, GlobalFuncs.get_turf( this ) );
				((dynamic)S).amount = this.sheets_refunded;
				GlobalFuncs.qdel( this );
			}
			return null;
		}

	}

}