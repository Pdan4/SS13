// FILE AUTOGENERATED BY SOMNIUM13.

using System;
using Somnium.Engine.ByImpl;

namespace Somnium.Game {
	class Obj_Item_Device_FiringPin_Implant_Loyalty : Obj_Item_Device_FiringPin_Implant {

		protected override void __FieldInit() {
			base.__FieldInit();

			this.req_implant = typeof(Obj_Item_Weapon_Implant_Loyalty);
			this.icon_state = "firing_pin_loyalty";
		}

		public Obj_Item_Device_FiringPin_Implant_Loyalty ( dynamic newloc = null ) : base( (object)(newloc) ) {
			
		}

	}

}