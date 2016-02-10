// FILE AUTOGENERATED BY SOMNIUM13.

using System;
using Somnium.Engine.ByImpl;

namespace Somnium.Game {
	class Obj_Item_Delivery_Large : Obj_Item_Delivery {

		// Function from file: packagewrap.dm
		public Obj_Item_Delivery_Large ( dynamic loc = null, dynamic target = null, int? size = null ) : base( (object)(loc), (object)(target), size ) {
			// Warning: Super call was HERE! If anything above HERE is needed by the super call, it might break!;
			this.wrapped = target;

			if ( this.wrapped is Obj_Structure_Closet_Crate || target is Mob_Living_Carbon_Human ) {
				this.icon_state = "deliverycrate";
			} else if ( this.wrapped is Obj_Structure_Vendomatpack ) {
				this.icon_state = "deliverypack";
			} else if ( this.wrapped is Obj_Structure_Stackopacks ) {
				this.icon_state = "deliverystack";
			} else if ( this.wrapped is Obj_Structure_Closet ) {
				this.icon_state = "deliverycloset";
			}
			return;
		}

		// Function from file: packagewrap.dm
		public override dynamic attack_robot( Mob_Living_Silicon_Robot user = null ) {
			
			if ( !this.Adjacent( user ) ) {
				return null;
			}
			this.attack_hand( user );
			return null;
		}

		// Function from file: packagewrap.dm
		public override dynamic attack_hand( dynamic a = null, dynamic b = null, dynamic c = null ) {
			
			if ( this.wrapped != null ) {
				this.wrapped.forceMove( GlobalFuncs.get_turf( this.loc ) );
			}
			GlobalFuncs.qdel( this );
			return null;
		}

	}

}