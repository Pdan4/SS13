// FILE AUTOGENERATED BY SOMNIUM13.

using System;
using Somnium.Engine.ByImpl;

namespace Somnium.Game {
	class Obj_Item_Device_Pda_Lawyer : Obj_Item_Device_Pda {

		protected override void __FieldInit() {
			base.__FieldInit();

			this.default_cartridge = typeof(Obj_Item_Weapon_Cartridge_Lawyer);
			this.ttone = "...";
			this.icon_state = "pda-lawyer";
		}

		public Obj_Item_Device_Pda_Lawyer ( dynamic loc = null ) : base( (object)(loc) ) {
			
		}

	}

}