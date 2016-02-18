// FILE AUTOGENERATED BY SOMNIUM13.

using System;
using Somnium.Engine.ByImpl;

namespace Somnium.Game {
	class Design_PlasmacutterAdv : Design {

		protected override void __FieldInit() {
			base.__FieldInit();

			this.name = "Advanced Plasma Cutter";
			this.desc = "It's an advanced plasma cutter, oh my god.";
			this.id = "plasmacutter_adv";
			this.req_tech = new ByTable().Set( "materials", 4 ).Set( "plasmatech", 3 ).Set( "engineering", 3 ).Set( "combat", 3 ).Set( "magnets", 3 );
			this.build_type = 2;
			this.materials = new ByTable().Set( "$metal", 3000 ).Set( "$glass", 1000 ).Set( "$plasma", 2000 ).Set( "$gold", 500 );
			this.reliability = 79;
			this.build_path = typeof(Obj_Item_Weapon_Gun_Energy_Plasmacutter_Adv);
			this.category = new ByTable(new object [] { "Mining Designs" });
		}

	}

}