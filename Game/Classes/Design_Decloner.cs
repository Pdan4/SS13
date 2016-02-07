// FILE AUTOGENERATED BY SOM13. DO NOT EDIT YET.

using System;
using Somnium.Engine.ByImpl;

namespace Somnium.Game {
	class Design_Decloner : Design {

		protected override void __FieldInit() {
			base.__FieldInit();

			this.name = "Decloner";
			this.desc = "Your opponent will bubble into a messy pile of goop.";
			this.id = "decloner";
			this.req_tech = new ByTable().Set( "combat", 8 ).Set( "materials", 7 ).Set( "biotech", 5 ).Set( "powerstorage", 6 );
			this.build_type = 2;
			this.materials = new ByTable().Set( "$gold", 5000 ).Set( "$uranium", 10000 );
			this.reagents = new ByTable().Set( "mutagen", 40 );
			this.build_path = typeof(Obj_Item_Weapon_Gun_Energy_Decloner);
			this.category = new ByTable(new object [] { "Weapons" });
		}

	}

}