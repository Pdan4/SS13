// FILE AUTOGENERATED BY SOMNIUM13.

using System;
using Somnium.Engine.ByImpl;

namespace Somnium.Game {
	class Obj_Item_Weapon_VendingRefill_Clothing : Obj_Item_Weapon_VendingRefill {

		protected override void __FieldInit() {
			base.__FieldInit();

			this.machine_name = "ClothesMate";
			this.charges = new ByTable(new object [] { 29, 2, 3 });
			this.init_charges = new ByTable(new object [] { 29, 2, 3 });
			this.icon_state = "refill_clothes";
		}

		public Obj_Item_Weapon_VendingRefill_Clothing ( dynamic amt = null ) : base( (object)(amt) ) {
			
		}

	}

}