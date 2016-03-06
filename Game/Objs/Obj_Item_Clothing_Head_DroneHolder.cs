// FILE AUTOGENERATED BY SOMNIUM13.

using System;
using Somnium.Engine.ByImpl;

namespace Somnium.Game {
	class Obj_Item_Clothing_Head_DroneHolder : Obj_Item_Clothing_Head {

		public Mob_Living_SimpleAnimal_Drone drone = null;

		protected override void __FieldInit() {
			base.__FieldInit();

			this.icon = "icons/mob/drone.dmi";
			this.icon_state = "drone_maint_hat";
		}

		public Obj_Item_Clothing_Head_DroneHolder ( dynamic loc = null ) : base( (object)(loc) ) {
			
		}

		// Function from file: drones_as_items.dm
		public override void container_resist( Mob user = null ) {
			this.uncurl();
			return;
		}

		// Function from file: drones_as_items.dm
		public override bool relaymove( Mob user = null, int? direction = null ) {
			this.uncurl();
			return false;
		}

		// Function from file: drones_as_items.dm
		public string updateVisualAppearence( Mob_Living_SimpleAnimal_Drone D = null ) {
			string _default = null;

			
			if ( !( D != null ) ) {
				return _default;
			}
			this.icon_state = "" + D.visualAppearence + "_hat";
			_default = this.icon_state;
			return _default;
		}

		// Function from file: drones_as_items.dm
		public void uncurl(  ) {
			Ent_Static L = null;

			
			if ( !( this.drone != null ) ) {
				return;
			}

			if ( this.loc is Mob_Living ) {
				L = this.loc;
				((dynamic)L).WriteMsg( "<span class='warning'>" + this.drone + " is trying to escape!</span>" );

				if ( !GlobalFuncs.do_after( this.drone, 50, null, L ) ) {
					return;
				}
				((Mob)L).unEquip( this );
			}
			this.contents.Remove( this.drone );
			this.drone.loc = GlobalFuncs.get_turf( this );
			this.drone.reset_perspective();
			this.drone.dir = ((int)( GlobalVars.SOUTH ));
			this.drone.visible_message( "<span class='warning'>" + this.drone + " uncurls!</span>" );
			this.drone = null;
			GlobalFuncs.qdel( this );
			return;
		}

	}

}