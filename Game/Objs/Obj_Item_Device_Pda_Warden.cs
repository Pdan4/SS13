// FILE AUTOGENERATED BY SOMNIUM13.

using System;
using Somnium.Engine.ByImpl;

namespace Somnium.Game {
	class Obj_Item_Device_Pda_Warden : Obj_Item_Device_Pda {

		protected override void __FieldInit() {
			base.__FieldInit();

			this.default_cartridge = typeof(Obj_Item_Weapon_Cartridge_Security);
			this.icon_state = "pda-warden";
		}

		public Obj_Item_Device_Pda_Warden ( dynamic loc = null ) : base( (object)(loc) ) {
			
		}

	}

}