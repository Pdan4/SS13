// FILE AUTOGENERATED BY SOMNIUM13.

using System;
using Somnium.Engine.ByImpl;

namespace Somnium.Game {
	class Obj_Item_Weapon_Card_Id_Engineering : Obj_Item_Weapon_Card_Id {

		protected override void __FieldInit() {
			base.__FieldInit();

			this.registered_name = "Engineer";
			this.access = new ByTable(new object [] { 10, 11, 23, 12, 13, 24, 14, 18, 32 });
			this.icon_state = "engineering";
		}

		public Obj_Item_Weapon_Card_Id_Engineering ( dynamic loc = null ) : base( (object)(loc) ) {
			
		}

	}

}