// FILE AUTOGENERATED BY SOMNIUM13.

using System;
using Somnium.Engine.ByImpl;

namespace Somnium.Game {
	class Obj_Item_Weapon_Arrow : Obj_Item_Weapon {

		protected override void __FieldInit() {
			base.__FieldInit();

			this.item_state = "bolt";
			this.throwforce = 8;
			this.sharpness = 1;
			this.icon_state = "bolt";
		}

		public Obj_Item_Weapon_Arrow ( dynamic loc = null ) : base( (object)(loc) ) {
			
		}

		// Function from file: bow.dm
		public virtual void removed( dynamic user = null ) {
			return;
		}

	}

}