// FILE AUTOGENERATED BY SOMNIUM13.

using System;
using Somnium.Engine.ByImpl;

namespace Somnium.Game {
	class Obj_Machinery_Teleport_Hub_Syndicate : Obj_Machinery_Teleport_Hub {

		// Function from file: teleporter.dm
		public Obj_Machinery_Teleport_Hub_Syndicate ( dynamic loc = null ) : base( (object)(loc) ) {
			// Warning: Super call was HERE! If anything above HERE is needed by the super call, it might break!;
			this.component_parts.Add( new Obj_Item_Weapon_StockParts_MatterBin_Super( null ) );
			this.RefreshParts();
			return;
		}

	}

}