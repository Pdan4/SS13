// FILE AUTOGENERATED BY SOMNIUM13.

using System;
using Somnium.Engine.ByImpl;

namespace Somnium.Game {
	class Obj_Item_Clothing_Head_Helmet_Space_Ert : Obj_Item_Clothing_Head_Helmet_Space {

		public Obj_Machinery_Camera camera = null;

		protected override void __FieldInit() {
			base.__FieldInit();

			this.item_state = "helm-command";
			this.armor = new ByTable().Set( "melee", 50 ).Set( "bullet", 50 ).Set( "laser", 30 ).Set( "energy", 15 ).Set( "bomb", 30 ).Set( "bio", 100 ).Set( "rad", 60 );
			this.siemens_coefficient = 0.6;
			this.max_heat_protection_temperature = 30000;
			this.flags = 16640;
			this.species_restricted = new ByTable(new object [] { "exclude", "Vox" });
			this.pressure_resistance = 20265;
			this.eyeprot = 3;
			this.icon_state = "ert_commander";
		}

		public Obj_Item_Clothing_Head_Helmet_Space_Ert ( dynamic loc = null ) : base( (object)(loc) ) {
			
		}

		// Function from file: ert.dm
		public override dynamic examine( dynamic user = null, string size = null ) {
			base.examine( (object)(user), size );

			if ( Map13.GetDistance( user, this ) <= 1 ) {
				GlobalFuncs.to_chat( user, "This helmet has a built-in camera. It's " + ( this.camera != null ? "" : "in" ) + "active." );
			}
			return null;
		}

		// Function from file: ert.dm
		public override dynamic attack_self( dynamic user = null, dynamic flag = null, bool? emp = null ) {
			
			if ( this.camera != null ) {
				base.attack_self( (object)(user), (object)(flag), emp );
			} else {
				this.camera = new Obj_Machinery_Camera( this );
				this.camera.network = new ByTable(new object [] { "ERT" });
				GlobalVars.cameranet.removeCamera( this.camera );
				this.camera.c_tag = user.name;
				GlobalFuncs.to_chat( user, "<span class='notice'>User scanned as " + this.camera.c_tag + ". Camera activated.</span>" );
			}
			return null;
		}

	}

}