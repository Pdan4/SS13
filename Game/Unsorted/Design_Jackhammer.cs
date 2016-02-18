// FILE AUTOGENERATED BY SOMNIUM13.

using System;
using Somnium.Engine.ByImpl;

namespace Somnium.Game {
	class Design_Jackhammer : Design {

		protected override void __FieldInit() {
			base.__FieldInit();

			this.name = "Sonic Jackhammer";
			this.desc = "Essentially a handheld planet-cracker. Can drill through walls with ease as well.";
			this.id = "jackhammer";
			this.req_tech = new ByTable().Set( "materials", 6 ).Set( "powerstorage", 6 ).Set( "engineering", 5 ).Set( "magnets", 6 );
			this.build_type = 2;
			this.materials = new ByTable().Set( "$metal", 6000 ).Set( "$glass", 2000 ).Set( "$silver", 2000 ).Set( "$diamond", 6000 );
			this.build_path = typeof(Obj_Item_Weapon_Pickaxe_Drill_Jackhammer);
			this.category = new ByTable(new object [] { "Mining Designs" });
		}

	}

}