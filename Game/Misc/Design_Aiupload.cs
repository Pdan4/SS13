// FILE AUTOGENERATED BY SOMNIUM13.

using System;
using Somnium.Engine.ByImpl;

namespace Somnium.Game {
	class Design_Aiupload : Design {

		protected override void __FieldInit() {
			base.__FieldInit();

			this.name = "Circuit Design (AI Upload)";
			this.desc = "Allows for the construction of circuit boards used to build an AI Upload Console.";
			this.id = "aiupload";
			this.req_tech = new ByTable().Set( "programming", 4 );
			this.build_type = 1;
			this.materials = new ByTable().Set( "$glass", 2000 ).Set( "sacid", 20 );
			this.category = "Console Boards";
			this.build_path = typeof(Obj_Item_Weapon_Circuitboard_Aiupload);
			this.locked = true;
			this.req_lock_access = new ByTable(new object [] { 7, 29, 30 });
		}

	}

}