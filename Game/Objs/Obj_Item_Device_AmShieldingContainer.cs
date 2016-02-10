// FILE AUTOGENERATED BY SOMNIUM13.

using System;
using Somnium.Engine.ByImpl;

namespace Somnium.Game {
	class Obj_Item_Device_AmShieldingContainer : Obj_Item_Device {

		protected override void __FieldInit() {
			base.__FieldInit();

			this.item_state = "electronic";
			this.w_class = 4;
			this.throwforce = 5;
			this.throw_speed = 1;
			this.throw_range = 2;
			this.starting_materials = new ByTable().Set( "$iron", 7500 );
			this.w_type = 4;
			this.icon = "icons/obj/machines/antimatter.dmi";
			this.icon_state = "box";
		}

		public Obj_Item_Device_AmShieldingContainer ( dynamic loc = null ) : base( (object)(loc) ) {
			
		}

		// Function from file: shielding.dm
		public override dynamic attackby( dynamic a = null, dynamic b = null, dynamic c = null ) {
			
			if ( a is Obj_Item_Device_Multitool && this.loc is Tile ) {
				new Obj_Machinery_AmShielding( this.loc );
				GlobalFuncs.qdel( this );
				return null;
			}
			base.attackby( (object)(a), (object)(b), (object)(c) );
			return null;
		}

	}

}