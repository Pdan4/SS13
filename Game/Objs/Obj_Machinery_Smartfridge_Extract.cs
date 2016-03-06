// FILE AUTOGENERATED BY SOMNIUM13.

using System;
using Somnium.Engine.ByImpl;

namespace Somnium.Game {
	class Obj_Machinery_Smartfridge_Extract : Obj_Machinery_Smartfridge {

		// Function from file: smartfridge.dm
		public Obj_Machinery_Smartfridge_Extract ( dynamic loc = null ) : base( (object)(loc) ) {
			Obj_Item_Device_SlimeScanner I = null;
			Obj_Item_Device_SlimeScanner T = null;

			// Warning: Super call was HERE! If anything above HERE is needed by the super call, it might break!;
			I = new Obj_Item_Device_SlimeScanner( this );
			this.load( I );
			T = new Obj_Item_Device_SlimeScanner( this );
			this.load( T );
			return;
		}

		// Function from file: smartfridge.dm
		public override bool accept_check( dynamic O = null ) {
			
			if ( O is Obj_Item_SlimeExtract ) {
				return true;
			}

			if ( O is Obj_Item_Device_SlimeScanner ) {
				return true;
			}
			return false;
		}

	}

}