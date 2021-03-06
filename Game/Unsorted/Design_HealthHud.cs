// FILE AUTOGENERATED BY SOMNIUM13.

using System;
using Somnium.Engine.ByImpl;

namespace Somnium.Game {
	class Design_HealthHud : Design {

		protected override void __FieldInit() {
			base.__FieldInit();

			this.name = "Health Scanner HUD";
			this.desc = "A heads-up display that scans the humans in view and provides accurate data about their health status.";
			this.id = "health_hud";
			this.req_tech = new ByTable().Set( "biotech", 2 ).Set( "magnets", 3 );
			this.build_type = 2;
			this.materials = new ByTable().Set( "$metal", 50 ).Set( "$glass", 50 );
			this.build_path = typeof(Obj_Item_Clothing_Glasses_Hud_Health);
			this.category = new ByTable(new object [] { "Equipment" });
		}

	}

}