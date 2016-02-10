// FILE AUTOGENERATED BY SOMNIUM13.

using System;
using Somnium.Engine.ByImpl;

namespace Somnium.Game {
	class Obj_Item_Device_Flash_Synthetic : Obj_Item_Device_Flash {

		protected override void __FieldInit() {
			base.__FieldInit();

			this.icon_state = "sflash";
		}

		public Obj_Item_Device_Flash_Synthetic ( dynamic loc = null ) : base( (object)(loc) ) {
			
		}

		// Function from file: flash.dm
		public override dynamic attack_self( dynamic user = null, dynamic flag = null, bool? emp = null ) {
			flag = flag ?? 0;
			emp = emp ?? false;

			base.attack_self( (object)(user), (object)(flag), emp );

			if ( !this.broken ) {
				this.broken = true;
				GlobalFuncs.to_chat( user, "<span class='warning'>The bulb has burnt out!</span>" );
				this.icon_state = "flashburnt";
			}
			return null;
		}

		// Function from file: flash.dm
		public override bool? attack( dynamic M = null, dynamic user = null, string def_zone = null, bool? eat_override = null ) {
			base.attack( (object)(M), (object)(user), def_zone, eat_override );

			if ( !this.broken ) {
				this.broken = true;
				GlobalFuncs.to_chat( user, "<span class='warning'>The bulb has burnt out!</span>" );
				this.icon_state = "flashburnt";
			}
			return null;
		}

	}

}