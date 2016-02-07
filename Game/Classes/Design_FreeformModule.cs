// FILE AUTOGENERATED BY SOM13. DO NOT EDIT YET.

using System;
using Somnium.Engine.ByImpl;

namespace Somnium.Game {
	class Design_FreeformModule : Design {

		protected override void __FieldInit() {
			base.__FieldInit();

			this.name = "Module Design (Freeform)";
			this.desc = "Allows for the construction of a Freeform AI Module.";
			this.id = "freeform_module";
			this.req_tech = new ByTable().Set( "programming", 4 ).Set( "materials", 4 );
			this.build_type = 1;
			this.materials = new ByTable().Set( "$glass", 1000 ).Set( "sacid", 20 ).Set( "$gold", 100 );
			this.build_path = typeof(Obj_Item_Weapon_AiModule_Supplied_Freeform);
			this.category = new ByTable(new object [] { "AI Modules" });
		}

	}

}