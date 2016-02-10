// FILE AUTOGENERATED BY SOMNIUM13.

using System;
using Somnium.Engine.ByImpl;

namespace Somnium.Game {
	class Obj_Machinery_Computer_Security_Advanced : Obj_Machinery_Computer_Security {

		protected override void __FieldInit() {
			base.__FieldInit();

			this.circuit = "/obj/item/weapon/circuitboard/security/advanced";
		}

		// Function from file: adv_camera.dm
		public Obj_Machinery_Computer_Security_Advanced ( dynamic loc = null ) : base( (object)(loc) ) {
			// Warning: Super call was HERE! If anything above HERE is needed by the super call, it might break!;
			GlobalVars.html_machines.Add( this );
			return;
		}

		// Function from file: adv_camera.dm
		public override dynamic Topic( string href = null, ByTable href_list = null, dynamic hclient = null, HtmlInterface currui = null ) {
			dynamic cam = null;
			Mob A = null;

			
			if ( Lang13.Bool( base.Topic( href, href_list, (object)(hclient) ) ) ) {
				return 0;
			}

			if ( Lang13.Bool( href_list["cancel"] ) ) {
				Task13.User.reset_view( null );
				this.current = null;
			}

			if ( Lang13.Bool( href_list["view"] ) ) {
				cam = Lang13.FindObj( href_list["view"] );

				if ( Lang13.Bool( cam ) ) {
					
					if ( Task13.User is Mob_Living_Silicon_Ai ) {
						A = Task13.User;
						((Ent_Dynamic)((dynamic)A).eyeobj).forceMove( GlobalFuncs.get_turf( cam ) );
						A.client.eye = ((dynamic)A).eyeobj;
					} else {
						this.f_use_power( 50 );
						this.current = cam;
						Task13.User.reset_view( this.current );
					}
				}
			}
			return 1;
		}

		// Function from file: adv_camera.dm
		public override bool? check_eye( Mob user = null ) {
			
			if ( ( Map13.GetDistance( user, this ) > 1 || !user.canmove || Lang13.Bool( user.blinded ) ) && !( user is Mob_Living_Silicon ) ) {
				
				if ( user.machine == this ) {
					user.machine = null;
				}
				return null;
			}

			if ( ( this.stat & 3 ) != 0 ) {
				return null;
			}
			user.reset_view( this.current );
			return true;
		}

		// Function from file: adv_camera.dm
		public override dynamic attack_hand( dynamic a = null, dynamic b = null, dynamic c = null ) {
			
			if ( this.z > 6 ) {
				GlobalFuncs.to_chat( a, "<span class='danger'>Unable to establish a connection: </span>You're too far away from the station!" );
				return null;
			}

			if ( ( this.stat & 3 ) != 0 ) {
				return null;
			}
			GlobalVars.adv_camera.show( a, ( Lang13.Bool( this.current ) ? Convert.ToInt32( this.current.z ) : this.z ) );

			if ( Lang13.Bool( this.current ) ) {
				a.reset_view( this.current );
			}
			a.machine = this;
			return null;
		}

	}

}