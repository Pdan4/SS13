// FILE AUTOGENERATED BY SOMNIUM13.

using System;
using Somnium.Engine.ByImpl;

namespace Somnium.Game {
	class Obj_Item_Weapon_Cautery : Obj_Item_Weapon {

		protected override void __FieldInit() {
			base.__FieldInit();

			this.materials = new ByTable().Set( "$metal", 2500 ).Set( "$glass", 750 );
			this.flags = 64;
			this.w_class = 1;
			this.origin_tech = "materials=1;biotech=1";
			this.attack_verb = new ByTable(new object [] { "burnt" });
			this.icon = "icons/obj/surgery.dmi";
			this.icon_state = "cautery";
		}

		public Obj_Item_Weapon_Cautery ( dynamic loc = null ) : base( (object)(loc) ) {
			
		}

	}

}