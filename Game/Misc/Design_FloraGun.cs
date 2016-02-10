// FILE AUTOGENERATED BY SOMNIUM13.

using System;
using Somnium.Engine.ByImpl;

namespace Somnium.Game {
	class Design_FloraGun : Design {

		protected override void __FieldInit() {
			base.__FieldInit();

			this.name = "Floral Somatoray";
			this.desc = "A tool that discharges controlled radiation which induces mutation in plant cells. Harmless to other organic life.";
			this.id = "flora_gun";
			this.req_tech = new ByTable().Set( "materials", 2 ).Set( "biotech", 3 ).Set( "powerstorage", 3 );
			this.build_type = 2;
			this.materials = new ByTable().Set( "$iron", 2000 ).Set( "$glass", 500 ).Set( "$uranium", 500 );
			this.build_path = typeof(Obj_Item_Weapon_Gun_Energy_Floragun);
		}

	}

}