// FILE AUTOGENERATED BY SOMNIUM13.

using System;
using Somnium.Engine.ByImpl;

namespace Somnium.Game {
	class Obj_Item_Device_AntibodyScanner : Obj_Item_Device {

		protected override void __FieldInit() {
			base.__FieldInit();

			this.w_class = 2;
			this.item_state = "electronic";
			this.icon_state = "antibody";
		}

		public Obj_Item_Device_AntibodyScanner ( dynamic loc = null ) : base( (object)(loc) ) {
			
		}

		// Function from file: items_devices.dm
		public override bool? attack( dynamic M = null, dynamic user = null, string def_zone = null, bool? eat_override = null ) {
			dynamic C = null;
			string code = null;

			
			if ( !( M is Mob_Living_Carbon ) ) {
				GlobalFuncs.to_chat( user, "<span class='notice'>Incompatible object, scan aborted.</span>" );
				return null;
			}
			C = M;

			if ( !Lang13.Bool( C.antibodies ) ) {
				GlobalFuncs.to_chat( user, "<span class='notice'>Unable to detect antibodies.</span>" );
				return null;
			}
			code = GlobalFuncs.antigens2string( M.antibodies );
			GlobalFuncs.to_chat( user, "<span class='notice'>" + this + " The antibody scanner displays a cryptic set of data: " + code + "</span>" );
			return null;
		}

	}

}