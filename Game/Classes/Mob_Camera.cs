// FILE AUTOGENERATED BY SOM13. DO NOT EDIT YET.

using System;
using Somnium.Engine.ByImpl;

namespace Somnium.Game {
	class Mob_Camera : Mob {

		protected override void __FieldInit() {
			base.__FieldInit();

			this.invisibility = 101;
			this.anchored = 1;
			this.status_flags = 4096;
			this.move_on_shuttle = false;
			this.see_in_dark = 7;
		}

		public Mob_Camera ( dynamic loc = null ) : base( (object)(loc) ) {
			
		}

		// Function from file: camera.dm
		public override dynamic Login(  ) {
			base.Login();
			this.update_interface();
			return null;
		}

		// Function from file: camera.dm
		public override bool experience_pressure_difference( dynamic pressure_difference = null, int direction = 0 ) {
			return false;
		}

	}

}