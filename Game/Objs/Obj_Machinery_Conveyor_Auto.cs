// FILE AUTOGENERATED BY SOMNIUM13.

using System;
using Somnium.Engine.ByImpl;

namespace Somnium.Game {
	class Obj_Machinery_Conveyor_Auto : Obj_Machinery_Conveyor {

		// Function from file: conveyor2.dm
		public Obj_Machinery_Conveyor_Auto ( dynamic loc = null, double? newdir = null, bool? building = null ) : base( (object)(loc), newdir, building ) {
			// Warning: Super call was HERE! If anything above HERE is needed by the super call, it might break!;
			this.operating = 1;
			this.setmove();
			return;
		}

		// Function from file: conveyor2.dm
		public override void update(  ) {
			
			if ( ( this.stat & 1 ) != 0 ) {
				this.icon_state = "conveyor-broken";
				this.operating = 0;
				return;
			} else if ( !this.operable ) {
				this.operating = 0;
			} else if ( ( this.stat & 2 ) != 0 ) {
				this.operating = 0;
			} else {
				this.operating = 1;
			}
			this.icon_state = "conveyor" + this.operating;
			return;
		}

	}

}