// FILE AUTOGENERATED BY SOMNIUM13.

using System;
using Somnium.Engine.ByImpl;

namespace Somnium.Game {
	class Obj_Item_Clothing_Suit_Apron_Surgical : Obj_Item_Clothing_Suit_Apron {

		protected override void __FieldInit() {
			base.__FieldInit();

			this.v_allowed = new ByTable(new object [] { 
				typeof(Obj_Item_Weapon_Scalpel), 
				typeof(Obj_Item_Weapon_SurgicalDrapes), 
				typeof(Obj_Item_Weapon_Cautery), 
				typeof(Obj_Item_Weapon_Hemostat), 
				typeof(Obj_Item_Weapon_Retractor)
			 });
			this.icon_state = "surgical";
		}

		public Obj_Item_Clothing_Suit_Apron_Surgical ( dynamic loc = null ) : base( (object)(loc) ) {
			
		}

	}

}