// FILE AUTOGENERATED BY SOMNIUM13.

using System;
using Somnium.Engine.ByImpl;

namespace Somnium.Game {
	class Design_Stunshell : Design {

		protected override void __FieldInit() {
			base.__FieldInit();

			this.name = "Stun Shell";
			this.desc = "A stunning shell for a shotgun.";
			this.id = "stunshell";
			this.req_tech = new ByTable().Set( "combat", 3 ).Set( "materials", 3 );
			this.build_type = 2;
			this.materials = new ByTable().Set( "$metal", 200 );
			this.build_path = typeof(Obj_Item_AmmoCasing_Shotgun_Stunslug);
			this.category = new ByTable(new object [] { "Ammo" });
		}

	}

}