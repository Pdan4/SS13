// FILE AUTOGENERATED BY SOMNIUM13.

using System;
using Somnium.Engine.ByImpl;

namespace Somnium.Game {
	class Obj_Item_Device_Encryptionkey_HeadsetServeng : Obj_Item_Device_Encryptionkey {

		protected override void __FieldInit() {
			base.__FieldInit();

			this.channels = new ByTable().Set( "Engineering", 1 ).Set( "Service", 1 );
			this.icon_state = "serveng_cypherkey";
		}

		public Obj_Item_Device_Encryptionkey_HeadsetServeng ( dynamic loc = null ) : base( (object)(loc) ) {
			
		}

	}

}