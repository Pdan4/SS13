// FILE AUTOGENERATED BY SOM13. DO NOT EDIT YET.

using System;
using Somnium.Engine.ByImpl;

namespace Somnium.Game {
	class Design_Rapidsyringe : Design {

		protected override void __FieldInit() {
			base.__FieldInit();

			this.name = "Rapid Syringe Gun";
			this.desc = "A gun that fires many syringes.";
			this.id = "rapidsyringe";
			this.req_tech = new ByTable().Set( "combat", 3 ).Set( "materials", 3 ).Set( "engineering", 3 ).Set( "biotech", 2 );
			this.build_type = 2;
			this.materials = new ByTable().Set( "$metal", 5000 ).Set( "$glass", 1000 );
			this.build_path = typeof(Obj_Item_Weapon_Gun_Syringe_Rapidsyringe);
			this.category = new ByTable(new object [] { "Weapons" });
		}

	}

}