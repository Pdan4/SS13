// FILE AUTOGENERATED BY SOM13. DO NOT EDIT YET.

using System;
using Somnium.Engine.ByImpl;

namespace Somnium.Game {
	class Design_CyberimpSecurityHud : Design {

		protected override void __FieldInit() {
			base.__FieldInit();

			this.name = "Security HUD implant";
			this.desc = "These cybernetic eyes will display a security HUD over everything you see. Wiggle eyes to control.";
			this.id = "ci-sechud";
			this.req_tech = new ByTable().Set( "materials", 6 ).Set( "programming", 5 ).Set( "biotech", 4 ).Set( "combat", 2 );
			this.build_type = 18;
			this.construction_time = 50;
			this.materials = new ByTable().Set( "$metal", 200 ).Set( "$glass", 200 ).Set( "$silver", 750 ).Set( "$gold", 750 );
			this.build_path = typeof(Obj_Item_Organ_Internal_Cyberimp_Eyes_Hud_Security);
			this.category = new ByTable(new object [] { "Misc", "Medical Designs" });
		}

	}

}