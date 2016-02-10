// FILE AUTOGENERATED BY SOMNIUM13.

using System;
using Somnium.Engine.ByImpl;

namespace Somnium.Game {
	class Design_SechudSunglass : Design {

		protected override void __FieldInit() {
			base.__FieldInit();

			this.name = "HUDSunglasses";
			this.desc = "Sunglasses with a heads-up display that scans the humans in view and provides accurate data about their ID status.";
			this.id = "sechud_sunglass";
			this.req_tech = new ByTable().Set( "magnets", 3 ).Set( "combat", 2 );
			this.build_type = 2;
			this.materials = new ByTable().Set( "$iron", 50 ).Set( "$glass", 50 );
			this.category = "Armor";
			this.build_path = typeof(Obj_Item_Clothing_Glasses_Sunglasses_Sechud);
			this.locked = true;
			this.req_lock_access = new ByTable(new object [] { 3 });
		}

	}

}