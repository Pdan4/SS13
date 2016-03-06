// FILE AUTOGENERATED BY SOMNIUM13.

using System;
using Somnium.Engine.ByImpl;

namespace Somnium.Game {
	class Obj_Item_Clothing_Mask_Luchador : Obj_Item_Clothing_Mask {

		protected override void __FieldInit() {
			base.__FieldInit();

			this.item_state = "luchag";
			this.flags = 32768;
			this.flags_inv = 8;
			this.w_class = 2;
			this.icon_state = "luchag";
		}

		public Obj_Item_Clothing_Mask_Luchador ( dynamic loc = null ) : base( (object)(loc) ) {
			
		}

		// Function from file: boxing.dm
		public override dynamic speechModification( dynamic message = null ) {
			
			if ( String13.SubStr( message, 1, 2 ) != "*" ) {
				message = GlobalFuncs.replacetext( message, "captain", "CAPITÁN" );
				message = GlobalFuncs.replacetext( message, "station", "ESTACIÓN" );
				message = GlobalFuncs.replacetext( message, "sir", "SEÑOR" );
				message = GlobalFuncs.replacetext( message, "the ", "el " );
				message = GlobalFuncs.replacetext( message, "my ", "mi " );
				message = GlobalFuncs.replacetext( message, "is ", "es " );
				message = GlobalFuncs.replacetext( message, "it's", "es" );
				message = GlobalFuncs.replacetext( message, "friend", "amigo" );
				message = GlobalFuncs.replacetext( message, "buddy", "amigo" );
				message = GlobalFuncs.replacetext( message, "hello", "hola" );
				message = GlobalFuncs.replacetext( message, " hot", " caliente" );
				message = GlobalFuncs.replacetext( message, " very ", " muy " );
				message = GlobalFuncs.replacetext( message, "sword", "espada" );
				message = GlobalFuncs.replacetext( message, "library", "biblioteca" );
				message = GlobalFuncs.replacetext( message, "traitor", "traidor" );
				message = GlobalFuncs.replacetext( message, "wizard", "mago" );
				message = String13.ToUpper( message );

				if ( Rand13.PercentChance( 25 ) ) {
					message += " OLE!";
				}
			}
			return message;
		}

	}

}