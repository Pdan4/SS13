// FILE AUTOGENERATED BY SOMNIUM13.

using System;
using Somnium.Engine.ByImpl;

namespace Somnium.Game {
	class Obj_Item_Device_Encryptionkey_Heads_Rd : Obj_Item_Device_Encryptionkey_Heads {

		protected override void __FieldInit() {
			base.__FieldInit();

			this.channels = new ByTable().Set( "Science", 1 ).Set( "Command", 1 );
			this.icon_state = "rd_cypherkey";
		}

		public Obj_Item_Device_Encryptionkey_Heads_Rd ( dynamic loc = null ) : base( (object)(loc) ) {
			
		}

	}

}