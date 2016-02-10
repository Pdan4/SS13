// FILE AUTOGENERATED BY SOMNIUM13.

using System;
using Somnium.Engine.ByImpl;

namespace Somnium.Game {
	class Design_Ricochet : Design {

		protected override void __FieldInit() {
			base.__FieldInit();

			this.name = "Ricochet Rifle";
			this.desc = "Here's a tip, get yourself an ablative armor before you start firing this one randomly.";
			this.id = "ricochet";
			this.req_tech = new ByTable().Set( "materials", 3 ).Set( "powerstorage", 3 ).Set( "combat", 3 ).Set( "nanotrasen", 1 );
			this.build_type = 2;
			this.materials = new ByTable().Set( "$iron", 5000 ).Set( "$glass", 1000 ).Set( "$uranium", 1000 );
			this.category = "Nanotrasen";
			this.build_path = typeof(Obj_Item_Weapon_Gun_Energy_Ricochet);
			this.locked = true;
			this.req_lock_access = new ByTable(new object [] { 3 });
		}

	}

}