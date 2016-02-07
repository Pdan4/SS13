// FILE AUTOGENERATED BY SOM13. DO NOT EDIT YET.

using System;
using Somnium.Engine.ByImpl;

namespace Somnium.Game {
	class Design_SeedExtractor : Design {

		protected override void __FieldInit() {
			base.__FieldInit();

			this.name = "Machine Design (Seed Extractor Board)";
			this.desc = "The circuit board for a seed extractor.";
			this.id = "seed_extractor";
			this.req_tech = new ByTable().Set( "programming", 1 );
			this.build_type = 1;
			this.materials = new ByTable().Set( "$glass", 1000 ).Set( "sacid", 20 );
			this.build_path = typeof(Obj_Item_Weapon_Circuitboard_SeedExtractor);
			this.category = new ByTable(new object [] { "Misc. Machinery" });
		}

	}

}