// FILE AUTOGENERATED BY SOMNIUM13.

using System;
using Somnium.Engine.ByImpl;

namespace Somnium.Game {
	class Obj_Item_Device_Abductor_Gizmo : Obj_Item_Device_Abductor {

		public int mode = 1;
		public dynamic marked = null;
		public Obj_Machinery_Abductor_Console console = null;

		protected override void __FieldInit() {
			base.__FieldInit();

			this.item_state = "silencer";
			this.origin_tech = "materials=5;magnets=5;bluespace=6";
			this.icon = "icons/obj/abductor.dmi";
			this.icon_state = "gizmo_scan";
		}

		public Obj_Item_Device_Abductor_Gizmo ( dynamic loc = null ) : base( (object)(loc) ) {
			
		}

		// Function from file: abduction_gear.dm
		public void prepare( dynamic target = null, dynamic user = null ) {
			
			if ( Map13.GetDistance( target, user ) > 1 ) {
				user.WriteMsg( "<span class='warning'>You need to be next to the specimen to prepare it for transport!</span>" );
				return;
			}
			user.WriteMsg( "<span class='notice'>You begin preparing " + target + " for transport...</span>" );

			if ( GlobalFuncs.do_after( user, 100, null, target ) ) {
				this.marked = target;
				user.WriteMsg( "<span class='notice'>You finish preparing " + target + " for transport.</span>" );
			}
			return;
		}

		// Function from file: abduction_gear.dm
		public void mark( dynamic target = null, dynamic user = null ) {
			
			if ( this.marked == target ) {
				user.WriteMsg( "<span class='warning'>This specimen is already marked!</span>" );
				return;
			}

			if ( target is Mob_Living_Carbon_Human ) {
				
				if ( this.IsAbductor( target ) ) {
					this.marked = target;
					user.WriteMsg( "<span class='notice'>You mark " + target + " for future retrieval.</span>" );
				} else {
					this.prepare( target, user );
				}
			} else {
				this.prepare( target, user );
			}
			return;
		}

		// Function from file: abduction_gear.dm
		public void scan( dynamic target = null, dynamic user = null ) {
			
			if ( target is Mob_Living_Carbon_Human ) {
				
				if ( this.console != null ) {
					this.console.AddSnapshot( target );
					user.WriteMsg( "<span class='notice'>You scan " + target + " and add them to the database.</span>" );
				}
			}
			return;
		}

		// Function from file: abduction_gear.dm
		public override bool afterattack( dynamic target = null, dynamic user = null, bool? proximity_flag = null, string click_parameters = null ) {
			
			if ( proximity_flag == true ) {
				return false;
			}

			if ( !this.AbductorCheck( user ) ) {
				return false;
			}

			if ( !this.ScientistCheck( user ) ) {
				user.WriteMsg( "<span class='notice'>You're not trained to use this</span>" );
				return false;
			}

			switch ((int)( this.mode )) {
				case 1:
					this.scan( target, user );
					break;
				case 2:
					this.mark( target, user );
					break;
			}
			return false;
		}

		// Function from file: abduction_gear.dm
		public override bool attack( dynamic M = null, dynamic user = null, bool? def_zone = null ) {
			
			if ( !this.AbductorCheck( user ) ) {
				return false;
			}

			if ( !this.ScientistCheck( user ) ) {
				user.WriteMsg( "<span class='notice'>You're not trained to use this</span>" );
				return false;
			}

			switch ((int)( this.mode )) {
				case 1:
					this.scan( M, user );
					break;
				case 2:
					this.mark( M, user );
					break;
			}
			return false;
		}

		// Function from file: abduction_gear.dm
		public override dynamic attack_self( dynamic user = null, dynamic flag = null, bool? emp = null ) {
			
			if ( !this.AbductorCheck( user ) ) {
				return null;
			}

			if ( !this.ScientistCheck( user ) ) {
				user.WriteMsg( "<span class='warning'>You're not trained to use this!</span>" );
				return null;
			}

			if ( this.mode == 1 ) {
				this.mode = 2;
				this.icon_state = "gizmo_mark";
			} else {
				this.mode = 1;
				this.icon_state = "gizmo_scan";
			}
			user.WriteMsg( "<span class='notice'>You switch the device to " + ( this.mode == 1 ? "SCAN" : "MARK" ) + " MODE</span>" );
			return null;
		}

	}

}