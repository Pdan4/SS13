// FILE AUTOGENERATED BY SOMNIUM13.

using System;
using Somnium.Engine.ByImpl;

namespace Somnium.Game {
	class Design_RustInjector : Design {

		protected override void __FieldInit() {
			base.__FieldInit();

			this.name = "Internal circuitry (R-UST Mk. 7 tokamak core)";
			this.desc = "The circuit board that for a RUST-pattern particle accelerator.";
			this.id = "pacman";
			this.req_tech = new ByTable().Set( "powerstorage", 3 ).Set( "engineering", 4 ).Set( "plasmatech", 4 ).Set( "materials", 6 );
			this.build_type = 1;
			this.reliability_base = 79;
			this.materials = new ByTable().Set( "$glass", 2000 ).Set( "sacid", 20 ).Set( "$plasma", 3000 ).Set( "$uranium", 2000 );
			this.build_path = "/obj/item/weapon/circuitboard/rust_core";
		}

	}

}