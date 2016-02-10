// FILE AUTOGENERATED BY SOMNIUM13.

using System;
using Somnium.Engine.ByImpl;

namespace Somnium.Game {
	class Obj_Item_Weapon_Circuitboard : Obj_Item_Weapon {

		public bool id_tag = false;
		public dynamic frequency = null;
		public dynamic build_path = null;
		public string board_type = "computer";
		public ByTable req_components = null;
		public dynamic powernet = null;
		public dynamic records = null;
		public string frame_desc = null;
		public bool contain_parts = true;

		protected override void __FieldInit() {
			base.__FieldInit();

			this.w_class = 2;
			this.item_state = "circuitboard";
			this.origin_tech = "programming=2";
			this.starting_materials = new ByTable().Set( "$glass", 2000 );
			this.w_type = 5;
			this.icon = "icons/obj/module.dmi";
			this.icon_state = "id_mod";
		}

		public Obj_Item_Weapon_Circuitboard ( dynamic loc = null ) : base( (object)(loc) ) {
			
		}

		// Function from file: buildandrepair.dm
		public virtual void solder_improve( dynamic user = null ) {
			GlobalFuncs.to_chat( user, "<span class='warning'>You fiddle with a few random fuses but can't find a routing that doesn't short the board.</span>" );
			return;
		}

		// Function from file: buildandrepair.dm
		public override dynamic attackby( dynamic a = null, dynamic b = null, dynamic c = null ) {
			dynamic S = null;
			dynamic WT = null;
			Obj_Item_Weapon_Circuitboard_Blank B = null;

			
			if ( a is Obj_Item_Weapon_Solder ) {
				S = a;

				if ( Lang13.Bool( S.remove_fuel( 2, b ) ) ) {
					this.solder_improve( b );
				}
			} else if ( a is Obj_Item_Weapon_Weldingtool ) {
				WT = a;

				if ( ((Obj_Item_Weapon_Weldingtool)WT).remove_fuel( 1, b ) ) {
					B = new Obj_Item_Weapon_Circuitboard_Blank( this.loc );
					GlobalFuncs.to_chat( b, "<span class='notice'>You melt away the circuitry, leaving behind a blank.</span>" );
					GlobalFuncs.playsound( B.loc, "sound/items/welder.ogg", 30, 1 );

					if ( ((Mob)b).get_inactive_hand() == this ) {
						((Mob)b).before_take_item( this );
						((Mob)b).put_in_hands( B );
					}
					GlobalFuncs.qdel( this );
					return null;
				}
			}
			return null;
		}

	}

}