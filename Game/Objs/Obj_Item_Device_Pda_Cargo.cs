// FILE AUTOGENERATED BY SOMNIUM13.

using System;
using Somnium.Engine.ByImpl;

namespace Somnium.Game {
	class Obj_Item_Device_Pda_Cargo : Obj_Item_Device_Pda {

		protected override void __FieldInit() {
			base.__FieldInit();

			this.default_cartridge = typeof(Obj_Item_Weapon_Cartridge_Quartermaster);
			this.icon_state = "pda-cargo";
		}

		// Function from file: PDA.dm
		public Obj_Item_Device_Pda_Cargo ( dynamic loc = null ) : base( (object)(loc) ) {
			PdaApp_Ringer app = null;

			// Warning: Super call was HERE! If anything above HERE is needed by the super call, it might break!;
			app = new PdaApp_Ringer();
			app.onInstall( this );
			app.frequency = Convert.ToInt32( GlobalVars.deskbell_freq_cargo );
			return;
		}

	}

}