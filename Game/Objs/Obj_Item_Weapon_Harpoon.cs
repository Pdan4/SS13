// FILE AUTOGENERATED BY SOMNIUM13.

using System;
using Somnium.Engine.ByImpl;

namespace Somnium.Game {
	class Obj_Item_Weapon_Harpoon : Obj_Item_Weapon {

		protected override void __FieldInit() {
			base.__FieldInit();

			this.sharpness = 1.2;
			this.item_state = "harpoon";
			this.hitsound = "sound/weapons/bladeslice.ogg";
			this.force = 20;
			this.throwforce = 15;
			this.attack_verb = new ByTable(new object [] { "jabbed", "stabbed", "ripped" });
			this.icon_state = "harpoon";
		}

		public Obj_Item_Weapon_Harpoon ( dynamic loc = null ) : base( (object)(loc) ) {
			
		}

	}

}