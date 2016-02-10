// FILE AUTOGENERATED BY SOMNIUM13.

using System;
using Somnium.Engine.ByImpl;

namespace Somnium.Game {
	class Obj_Item_Bodybag : Obj_Item {

		protected override void __FieldInit() {
			base.__FieldInit();

			this.icon = "icons/obj/bodybag.dmi";
			this.icon_state = "bodybag_folded";
		}

		public Obj_Item_Bodybag ( dynamic loc = null ) : base( (object)(loc) ) {
			
		}

		// Function from file: bodybag.dm
		public override dynamic attack_self( dynamic user = null, dynamic flag = null, bool? emp = null ) {
			Obj_Structure_Closet_BodyBag R = null;

			R = new Obj_Structure_Closet_BodyBag( user.loc );
			R.add_fingerprint( user );
			GlobalFuncs.qdel( this );
			return null;
		}

	}

}