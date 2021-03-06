// FILE AUTOGENERATED BY SOMNIUM13.

using System;
using Somnium.Engine.ByImpl;

namespace Somnium.Game {
	class Design_Xray : Design {

		protected override void __FieldInit() {
			base.__FieldInit();

			this.name = "Xray Laser Gun";
			this.desc = "Not quite as menacing as it sounds";
			this.id = "xray";
			this.req_tech = new ByTable().Set( "combat", 6 ).Set( "materials", 5 ).Set( "biotech", 5 ).Set( "powerstorage", 4 );
			this.build_type = 2;
			this.materials = new ByTable().Set( "$gold", 5000 ).Set( "$uranium", 10000 ).Set( "$metal", 4000 );
			this.build_path = typeof(Obj_Item_Weapon_Gun_Energy_Xray);
			this.category = new ByTable(new object [] { "Weapons" });
		}

	}

}