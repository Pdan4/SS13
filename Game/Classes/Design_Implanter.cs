// FILE AUTOGENERATED BY SOM13. DO NOT EDIT YET.

using System;
using Somnium.Engine.ByImpl;

namespace Somnium.Game {
	class Design_Implanter : Design {

		protected override void __FieldInit() {
			base.__FieldInit();

			this.name = "Implanter";
			this.desc = "A sterile automatic implant injector.";
			this.id = "implanter";
			this.req_tech = new ByTable().Set( "materials", 1 ).Set( "programming", 2 ).Set( "biotech", 3 );
			this.build_type = 2;
			this.materials = new ByTable().Set( "$metal", 600 ).Set( "$glass", 200 );
			this.build_path = typeof(Obj_Item_Weapon_Implanter);
			this.category = new ByTable(new object [] { "Medical Designs" });
		}

	}

}