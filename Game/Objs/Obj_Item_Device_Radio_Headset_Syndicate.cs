// FILE AUTOGENERATED BY SOMNIUM13.

using System;
using Somnium.Engine.ByImpl;

namespace Somnium.Game {
	class Obj_Item_Device_Radio_Headset_Syndicate : Obj_Item_Device_Radio_Headset {

		protected override void __FieldInit() {
			base.__FieldInit();

			this.origin_tech = "syndicate=3";
		}

		// Function from file: headset.dm
		public Obj_Item_Device_Radio_Headset_Syndicate ( dynamic loc = null ) : base( (object)(loc) ) {
			// Warning: Super call was HERE! If anything above HERE is needed by the super call, it might break!;
			this.make_syndie();
			return;
		}

	}

}