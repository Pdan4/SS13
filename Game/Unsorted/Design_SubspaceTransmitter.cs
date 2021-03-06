// FILE AUTOGENERATED BY SOMNIUM13.

using System;
using Somnium.Engine.ByImpl;

namespace Somnium.Game {
	class Design_SubspaceTransmitter : Design {

		protected override void __FieldInit() {
			base.__FieldInit();

			this.name = "Subspace Transmitter";
			this.desc = "A large piece of equipment used to open a window into the subspace dimension.";
			this.id = "s-transmitter";
			this.req_tech = new ByTable().Set( "magnets", 3 ).Set( "materials", 3 ).Set( "bluespace", 2 );
			this.build_type = 2;
			this.materials = new ByTable().Set( "$glass", 100 ).Set( "$silver", 10 ).Set( "$uranium", 15 );
			this.build_path = typeof(Obj_Item_Weapon_StockParts_Subspace_Transmitter);
			this.category = new ByTable(new object [] { "Stock Parts" });
		}

	}

}