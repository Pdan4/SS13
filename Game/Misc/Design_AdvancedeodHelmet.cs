// FILE AUTOGENERATED BY SOMNIUM13.

using System;
using Somnium.Engine.ByImpl;

namespace Somnium.Game {
	class Design_AdvancedeodHelmet : Design {

		protected override void __FieldInit() {
			base.__FieldInit();

			this.name = "Advanced EOD Helmet";
			this.desc = "An advanced EOD helmet that affords great protection at the cost of mobility.";
			this.id = "advanced eod helmet";
			this.req_tech = new ByTable().Set( "combat", 5 ).Set( "materials", 5 ).Set( "biotech", 2 );
			this.build_type = 2;
			this.materials = new ByTable().Set( "$iron", 3750 ).Set( "$glass", 2500 ).Set( "$gold", 3750 ).Set( "$silver", 1000 );
			this.category = "Armor";
			this.build_path = typeof(Obj_Item_Clothing_Head_AdvancedeodHelmet);
		}

	}

}