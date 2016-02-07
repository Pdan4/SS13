// FILE AUTOGENERATED BY SOM13. DO NOT EDIT YET.

using System;
using Somnium.Engine.ByImpl;

namespace Somnium.Game {
	class Design_SubspaceAmplifier : Design {

		protected override void __FieldInit() {
			base.__FieldInit();

			this.name = "Subspace Amplifier";
			this.desc = "A compact micro-machine capable of amplifying weak subspace transmissions.";
			this.id = "s-amplifier";
			this.req_tech = new ByTable().Set( "programming", 2 ).Set( "magnets", 2 ).Set( "materials", 2 ).Set( "bluespace", 1 );
			this.build_type = 2;
			this.materials = new ByTable().Set( "$metal", 10 ).Set( "$gold", 30 ).Set( "$uranium", 15 );
			this.build_path = typeof(Obj_Item_Weapon_StockParts_Subspace_Amplifier);
			this.category = new ByTable(new object [] { "Stock Parts" });
		}

	}

}