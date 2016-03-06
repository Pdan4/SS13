// FILE AUTOGENERATED BY SOMNIUM13.

using System;
using Somnium.Engine.ByImpl;

namespace Somnium.Game {
	class Obj_Item_AmmoCasing_Caseless : Obj_Item_AmmoCasing {

		public Obj_Item_AmmoCasing_Caseless ( dynamic loc = null ) : base( (object)(loc) ) {
			
		}

		// Function from file: ammo_casings.dm
		public override bool update_icon( dynamic new_state = null, dynamic new_icon = null, int? new_px = null, int? new_py = null ) {
			base.update_icon( (object)(new_state), (object)(new_icon), new_px, new_py );
			this.icon_state = "" + Lang13.Initial( this, "icon_state" );
			return false;
		}

		// Function from file: ammo_casings.dm
		public override bool fire( dynamic target = null, dynamic user = null, string _params = null, double? distro = null, dynamic quiet = null, dynamic zone_override = null ) {
			
			if ( base.fire( (object)(target), (object)(user), _params, distro, (object)(quiet), (object)(zone_override) ) ) {
				this.loc = null;
				return true;
			} else {
				return false;
			}
		}

	}

}