// FILE AUTOGENERATED BY SOMNIUM13.

using System;
using Somnium.Engine.ByImpl;

namespace Somnium.Game {
	class Obj_Structure_Powerup_Bombup : Obj_Structure_Powerup {

		protected override void __FieldInit() {
			base.__FieldInit();

			this.icon_state = "bombup";
		}

		public Obj_Structure_Powerup_Bombup ( dynamic loc = null ) : base( (object)(loc) ) {
			
		}

		// Function from file: bomberman.dm
		public override void apply_power( dynamic dispenser = null ) {
			dispenser.bomblimit++;
			dispenser.bombtotal++;
			base.apply_power( (object)(dispenser) );
			return;
		}

	}

}