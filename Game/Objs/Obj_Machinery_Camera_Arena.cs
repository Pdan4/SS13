// FILE AUTOGENERATED BY SOMNIUM13.

using System;
using Somnium.Engine.ByImpl;

namespace Somnium.Game {
	class Obj_Machinery_Camera_Arena : Obj_Machinery_Camera {

		protected override void __FieldInit() {
			base.__FieldInit();

			this.use_power = 0;
			this.icon_state = "camerarena";
			this.layer = 2.1;
		}

		// Function from file: camera.dm
		public Obj_Machinery_Camera_Arena ( dynamic loc = null ) : base( (object)(loc) ) {
			// Warning: Super call was HERE! If anything above HERE is needed by the super call, it might break!;
			this.pixel_x = 0;
			this.pixel_y = 0;
			this.upgradeXRay();
			this.upgradeHearing();
			return;
		}

		// Function from file: camera.dm
		public override void attack_pai( Mob_Living_Silicon_Pai user = null ) {
			return;
		}

		// Function from file: camera.dm
		public override double singularity_act( double? current_size = null, Obj_Machinery_Singularity S = null ) {
			return 0;
		}

		// Function from file: camera.dm
		public override bool blob_act( dynamic severity = null ) {
			return false;
		}

		// Function from file: camera.dm
		public override bool ex_act( double? severity = null, dynamic child = null ) {
			return false;
		}

		// Function from file: camera.dm
		public override dynamic emp_act( int severity = 0 ) {
			return null;
		}

		// Function from file: camera.dm
		public override bool? update_icon( dynamic location = null, dynamic target = null ) {
			return null;
		}

		// Function from file: camera.dm
		public override dynamic attack_paw( Mob a = null, dynamic b = null, dynamic c = null ) {
			a.visible_message( new Txt( "<span class='warning'>" ).The( a ).item().str( " slashes at " ).the( this ).item().str( ", but that didn't affect it at all.</span>" ).ToString(), new Txt( "<span class='warning'>You slash at " ).the( this ).item().str( ", but that didn't affect it at all.</span>" ).ToString() );
			return null;
		}

		// Function from file: camera.dm
		public override dynamic attackby( dynamic a = null, dynamic b = null, dynamic c = null ) {
			
			if ( a is Obj_Item_Weapon_Screwdriver ) {
				GlobalFuncs.to_chat( b, "<span class='warning'>There aren't any visible screws to unscrew.</span>" );
			} else {
				((Ent_Static)b).visible_message( new Txt( "<span class='warning'>" ).The( b ).item().str( " hits " ).the( this ).item().str( " with " ).the( a ).item().str( " but it doesn't seem to affect it in the least.</span>" ).ToString(), new Txt( "<span class='warning'>You hit " ).the( this ).item().str( " with " ).the( a ).item().str( " but it doesn't seem to affect it in the least</span>" ).ToString() );
			}
			return null;
		}

	}

}