// FILE AUTOGENERATED BY SOMNIUM13.

using System;
using Somnium.Engine.ByImpl;

namespace Somnium.Game {
	class Obj_Mecha_Working_Ripley_Mining : Obj_Mecha_Working_Ripley {

		// Function from file: ripley.dm
		public Obj_Mecha_Working_Ripley_Mining ( dynamic loc = null ) : base( (object)(loc) ) {
			Obj_Item_MechaParts_MechaEquipment_Tool_Drill_Diamonddrill D = null;
			Obj_Item_MechaParts_MechaEquipment_Tool_Drill D2 = null;
			Obj_Item_MechaParts_MechaEquipment_Tool_HydraulicClamp HC = null;
			Obj_Item_MechaParts_MechaTracking B = null;

			// Warning: Super call was HERE! If anything above HERE is needed by the super call, it might break!;

			if ( Rand13.PercentChance( 25 ) ) {
				D = new Obj_Item_MechaParts_MechaEquipment_Tool_Drill_Diamonddrill();
				D.attach( this );
			} else {
				D2 = new Obj_Item_MechaParts_MechaEquipment_Tool_Drill();
				D2.attach( this );
			}
			HC = new Obj_Item_MechaParts_MechaEquipment_Tool_HydraulicClamp();
			HC.attach( this );
			this.hydraulic_clamp = HC;

			foreach (dynamic _a in Lang13.Enumerate( this.contents, typeof(Obj_Item_MechaParts_MechaTracking) )) {
				B = _a;
				
				GlobalFuncs.qdel( B );
				B = null;
				this.tracking = null;
			}
			return;
		}

	}

}