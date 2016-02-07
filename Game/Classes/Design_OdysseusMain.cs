// FILE AUTOGENERATED BY SOM13. DO NOT EDIT YET.

using System;
using Somnium.Engine.ByImpl;

namespace Somnium.Game {
	class Design_OdysseusMain : Design {

		protected override void __FieldInit() {
			base.__FieldInit();

			this.name = "Exosuit Module (\"Odysseus\" Central Control module)";
			this.desc = "Allows for the construction of a \"Odysseus\" Central Control module.";
			this.id = "odysseus_main";
			this.req_tech = new ByTable().Set( "programming", 3 ).Set( "biotech", 2 );
			this.build_type = 1;
			this.materials = new ByTable().Set( "$glass", 1000 ).Set( "sacid", 20 );
			this.build_path = typeof(Obj_Item_Weapon_Circuitboard_Mecha_Odysseus_Main);
			this.category = new ByTable(new object [] { "Exosuit Modules" });
		}

	}

}