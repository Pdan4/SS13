// FILE AUTOGENERATED BY SOMNIUM13.

using System;
using Somnium.Engine.ByImpl;

namespace Somnium.Game {
	class Obj_Item_Device_Deskbell_Signaler_Hop : Obj_Item_Device_Deskbell_Signaler {

		// Function from file: deskbell.dm
		public Obj_Item_Device_Deskbell_Signaler_Hop ( dynamic loc = null ) : base( (object)(loc) ) {
			// Warning: Super call was HERE! If anything above HERE is needed by the super call, it might break!;
			this.frequency = Convert.ToDouble( GlobalVars.deskbell_freq_hop );
			return;
		}

	}

}