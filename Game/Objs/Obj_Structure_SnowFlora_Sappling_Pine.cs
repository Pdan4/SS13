// FILE AUTOGENERATED BY SOMNIUM13.

using System;
using Somnium.Engine.ByImpl;

namespace Somnium.Game {
	class Obj_Structure_SnowFlora_Sappling_Pine : Obj_Structure_SnowFlora_Sappling {

		protected override void __FieldInit() {
			base.__FieldInit();

			this.pixel_x = 0;
			this.pixel_y = 0;
			this.growthlevel = 30;
		}

		// Function from file: snow.dm
		public Obj_Structure_SnowFlora_Sappling_Pine ( dynamic loc = null ) : base( (object)(loc) ) {
			// Warning: Super call was HERE! If anything above HERE is needed by the super call, it might break!;
			this.growthlevel = Rand13.Int( 25, 35 );
			return;
		}

		// Function from file: snow.dm
		public override void growing(  ) {
			return;
		}

	}

}