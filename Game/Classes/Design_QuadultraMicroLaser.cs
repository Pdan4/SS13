// FILE AUTOGENERATED BY SOM13. DO NOT EDIT YET.

using System;
using Somnium.Engine.ByImpl;

namespace Somnium.Game {
	class Design_QuadultraMicroLaser : Design {

		protected override void __FieldInit() {
			base.__FieldInit();

			this.name = "Quad-Ultra Micro-Laser";
			this.desc = "A stock part used in the construction of various devices.";
			this.id = "quadultra_micro_laser";
			this.req_tech = new ByTable().Set( "magnets", 6 ).Set( "materials", 6 );
			this.build_type = 2;
			this.materials = new ByTable().Set( "$metal", 20 ).Set( "$glass", 40 ).Set( "$uranium", 20 ).Set( "$diamond", 20 );
			this.reliability = 70;
			this.build_path = typeof(Obj_Item_Weapon_StockParts_MicroLaser_Quadultra);
			this.category = new ByTable(new object [] { "Stock Parts" });
		}

	}

}