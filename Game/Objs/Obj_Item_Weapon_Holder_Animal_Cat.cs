// FILE AUTOGENERATED BY SOMNIUM13.

using System;
using Somnium.Engine.ByImpl;

namespace Somnium.Game {
	class Obj_Item_Weapon_Holder_Animal_Cat : Obj_Item_Weapon_Holder_Animal {

		protected override void __FieldInit() {
			base.__FieldInit();

			this.item_state = "cat1";
			this.update_itemstate_on_twohand = true;
		}

		public Obj_Item_Weapon_Holder_Animal_Cat ( dynamic loc = null, Ent_Static M = null ) : base( (object)(loc), M ) {
			
		}

	}

}