// FILE AUTOGENERATED BY SOMNIUM13.

using System;
using Somnium.Engine.ByImpl;

namespace Somnium.Game {
	class Obj_Item_Weapon_Tank_Internals_Plasma : Obj_Item_Weapon_Tank_Internals {

		protected override void __FieldInit() {
			base.__FieldInit();

			this.force = 8;
			this.icon_state = "plasma";
		}

		// Function from file: tank_types.dm
		public Obj_Item_Weapon_Tank_Internals_Plasma ( dynamic loc = null ) : base( (object)(loc) ) {
			// Warning: Super call was HERE! If anything above HERE is needed by the super call, it might break!;
			this.air_contents.assert_gas( "plasma" );
			this.air_contents.gases["plasma"][1] = ( this.volume ??0) * 303.9749755859375 / 2436.07666015625;
			return;
		}

		// Function from file: tank_types.dm
		public override dynamic attackby( dynamic A = null, dynamic user = null, string _params = null, bool? silent = null, bool? replace_spent = null ) {
			dynamic F = null;

			base.attackby( (object)(A), (object)(user), _params, silent, replace_spent );

			if ( A is Obj_Item_Weapon_Flamethrower ) {
				F = A;

				if ( !Lang13.Bool( F.status ) || Lang13.Bool( F.ptank ) ) {
					return null;
				}
				this.master = F;
				F.ptank = this;
				((Mob)user).unEquip( this );
				this.loc = F;
				F.update_icon();
			}
			return null;
		}

	}

}