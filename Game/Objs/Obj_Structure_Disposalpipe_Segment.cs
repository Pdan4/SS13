// FILE AUTOGENERATED BY SOMNIUM13.

using System;
using Somnium.Engine.ByImpl;

namespace Somnium.Game {
	class Obj_Structure_Disposalpipe_Segment : Obj_Structure_Disposalpipe {

		protected override void __FieldInit() {
			base.__FieldInit();

			this.icon_state = "pipe-s";
		}

		// Function from file: disposal.dm
		public Obj_Structure_Disposalpipe_Segment ( dynamic loc = null ) : base( (object)(loc) ) {
			// Warning: Super call was HERE! If anything above HERE is needed by the super call, it might break!;

			if ( this.icon_state == "pipe-s" ) {
				this.dpdir = this.dir | Num13.Rotate( this.dir, 180 );
			} else {
				this.dpdir = this.dir | Num13.Rotate( this.dir, -90 );
			}
			this.update();
			return;
		}

	}

}