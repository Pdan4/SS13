// FILE AUTOGENERATED BY SOMNIUM13.

using System;
using Somnium.Engine.ByImpl;

namespace Somnium.Game {
	class Obj_Item_Device_Encryptionkey_Ert : Obj_Item_Device_Encryptionkey {

		protected override void __FieldInit() {
			base.__FieldInit();

			this.channels = new ByTable().Set( "Response Team", 1 ).Set( "Science", 1 ).Set( "Command", 1 ).Set( "Medical", 1 ).Set( "Engineering", 1 ).Set( "Security", 1 ).Set( "Mining", 1 ).Set( "Cargo", 1 );
			this.icon_state = "ert_cypherkey";
		}

		public Obj_Item_Device_Encryptionkey_Ert ( dynamic loc = null ) : base( (object)(loc) ) {
			
		}

	}

}