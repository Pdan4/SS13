// FILE AUTOGENERATED BY SOMNIUM13.

using System;
using Somnium.Engine.ByImpl;

namespace Somnium.Game {
	class Obj_Item_MechaParts_Chassis_Ripley : Obj_Item_MechaParts_Chassis {

		// Function from file: mecha_parts.dm
		public Obj_Item_MechaParts_Chassis_Ripley ( dynamic loc = null ) : base( (object)(loc) ) {
			// Warning: Super call was HERE! If anything above HERE is needed by the super call, it might break!;
			this.construct = new Construction_MechaChassis_Ripley( this );
			return;
		}

	}

}