// FILE AUTOGENERATED BY SOMNIUM13.

using System;
using Somnium.Engine.ByImpl;

namespace Somnium.Game {
	class Obj_Item_Device_Encryptionkey_Syndicate_Hacked : Obj_Item_Device_Encryptionkey_Syndicate {

		protected override void __FieldInit() {
			base.__FieldInit();

			this.channels = new ByTable().Set( "Command", 0 ).Set( "Security", 0 ).Set( "Engineering", 0 ).Set( "Science", 0 ).Set( "Medical", 0 ).Set( "Supply", 0 );
		}

		public Obj_Item_Device_Encryptionkey_Syndicate_Hacked ( dynamic loc = null ) : base( (object)(loc) ) {
			
		}

	}

}