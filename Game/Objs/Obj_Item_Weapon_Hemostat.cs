// FILE AUTOGENERATED BY SOMNIUM13.

using System;
using Somnium.Engine.ByImpl;

namespace Somnium.Game {
	class Obj_Item_Weapon_Hemostat : Obj_Item_Weapon {

		protected override void __FieldInit() {
			base.__FieldInit();

			this.materials = new ByTable().Set( "$metal", 5000 ).Set( "$glass", 2500 );
			this.flags = 64;
			this.w_class = 1;
			this.origin_tech = "materials=1;biotech=1";
			this.attack_verb = new ByTable(new object [] { "attacked", "pinched" });
			this.icon = "icons/obj/surgery.dmi";
			this.icon_state = "hemostat";
		}

		public Obj_Item_Weapon_Hemostat ( dynamic loc = null ) : base( (object)(loc) ) {
			
		}

	}

}