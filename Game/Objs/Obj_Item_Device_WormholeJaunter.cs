// FILE AUTOGENERATED BY SOMNIUM13.

using System;
using Somnium.Engine.ByImpl;

namespace Somnium.Game {
	class Obj_Item_Device_WormholeJaunter : Obj_Item_Device {

		protected override void __FieldInit() {
			base.__FieldInit();

			this.item_state = "electronic";
			this.throwforce = 0;
			this.w_class = 2;
			this.throw_speed = 3;
			this.throw_range = 5;
			this.origin_tech = "bluespace=2";
			this.icon_state = "Jaunter";
		}

		public Obj_Item_Device_WormholeJaunter ( dynamic loc = null ) : base( (object)(loc) ) {
			
		}

		// Function from file: mine_items.dm
		public override dynamic attack_self( dynamic user = null, dynamic flag = null, bool? emp = null ) {
			dynamic device_turf = null;
			ByTable L = null;
			Obj_Item_Beacon B = null;
			dynamic T = null;
			dynamic chosen_beacon = null;
			Obj_Effect_Portal_JauntTunnel J = null;

			device_turf = GlobalFuncs.get_turf( user );

			if ( !Lang13.Bool( device_turf ) || Convert.ToInt32( device_turf.z ) == 2 || Convert.ToDouble( device_turf.z ) >= GlobalVars.map.zLevels.len ) {
				GlobalFuncs.to_chat( user, "<span class='notice'>You're having difficulties getting the " + this.name + " to work.</span>" );
				return null;
			} else {
				((Ent_Static)user).visible_message( "<span class='notice'>" + user.name + " activates the " + this.name + "!</span>" );
				L = new ByTable();

				foreach (dynamic _a in Lang13.Enumerate( GlobalVars.beacons, typeof(Obj_Item_Beacon) )) {
					B = _a;
					
					T = GlobalFuncs.get_turf( B );

					if ( !( T == null ) ) {
						
						if ( Convert.ToInt32( T.z ) == GlobalVars.map.zMainStation ) {
							L.Add( B );
						}
					}
				}

				if ( !( L.len != 0 ) ) {
					GlobalFuncs.to_chat( user, "<span class='notice'>The " + this.name + " failed to create a wormhole.</span>" );
					return null;
				}
				chosen_beacon = Rand13.PickFromTable( L );
				J = new Obj_Effect_Portal_JauntTunnel( GlobalFuncs.get_turf( this ) );
				J.target = chosen_beacon;
				GlobalFuncs.try_move_adjacent( J );
				GlobalFuncs.playsound( this, "sound/effects/sparks4.ogg", 50, 1 );
				GlobalFuncs.qdel( this );
			}
			return null;
		}

	}

}