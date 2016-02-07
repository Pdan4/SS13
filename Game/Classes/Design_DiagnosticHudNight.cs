// FILE AUTOGENERATED BY SOM13. DO NOT EDIT YET.

using System;
using Somnium.Engine.ByImpl;

namespace Somnium.Game {
	class Design_DiagnosticHudNight : Design {

		protected override void __FieldInit() {
			base.__FieldInit();

			this.name = "Night Vision Diagnostic HUD";
			this.desc = "Upgraded version of the diagnostic HUD designed to function during a power failure.";
			this.id = "dianostic_hud_night";
			this.req_tech = new ByTable().Set( "magnets", 5 ).Set( "engineering", 4 ).Set( "powerstorage", 4 );
			this.build_type = 2;
			this.materials = new ByTable().Set( "$metal", 200 ).Set( "$glass", 200 ).Set( "$uranium", 1000 ).Set( "$plasma", 300 );
			this.build_path = typeof(Obj_Item_Clothing_Glasses_Hud_Diagnostic_Night);
			this.category = new ByTable(new object [] { "Equipment" });
		}

	}

}