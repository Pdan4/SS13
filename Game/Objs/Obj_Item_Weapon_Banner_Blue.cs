// FILE AUTOGENERATED BY SOMNIUM13.

using System;
using Somnium.Engine.ByImpl;

namespace Somnium.Game {
	class Obj_Item_Weapon_Banner_Blue : Obj_Item_Weapon_Banner {

		protected override void __FieldInit() {
			base.__FieldInit();

			this.item_state = "banner-blue";
			this.icon_state = "banner-blue";
		}

		public Obj_Item_Weapon_Banner_Blue ( dynamic loc = null ) : base( (object)(loc) ) {
			
		}

		// Function from file: items.dm
		public override double examine( dynamic user = null ) {
			base.examine( (object)(user) );

			if ( GlobalFuncs.is_handofgod_redcultist( user ) ) {
				user.WriteMsg( "A heretical banner that should be destroyed posthaste." );
			} else if ( GlobalFuncs.is_handofgod_bluecultist( user ) ) {
				user.WriteMsg( "A banner representing our might against the heretics. We may use it to increase the morale of our fellow members!" );
			}
			return 0;
		}

	}

}