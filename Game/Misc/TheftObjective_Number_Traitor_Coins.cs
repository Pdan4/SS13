// FILE AUTOGENERATED BY SOMNIUM13.

using System;
using Somnium.Engine.ByImpl;

namespace Somnium.Game {
	class TheftObjective_Number_Traitor_Coins : TheftObjective_Number_Traitor {

		protected override void __FieldInit() {
			base.__FieldInit();

			this.name = "credits of coins (in bag)";
			this.min = 1000;
			this.max = 5000;
			this.step = 500;
		}

		// Function from file: steal_items.dm
		public override bool? check_completion( Game_Data owner = null ) {
			dynamic all_items = null;
			double found_amount = 0;
			Obj_Item_Weapon_Storage_Bag_Money B = null;
			Obj_Item_Weapon_Coin C = null;

			
			if ( !Lang13.Bool( ((dynamic)owner).current ) ) {
				return false;
			}

			if ( !( ((dynamic)owner).current is Mob_Living ) ) {
				return false;
			}
			all_items = ((dynamic)owner).current.get_contents();
			found_amount = 0;

			foreach (dynamic _b in Lang13.Enumerate( all_items, typeof(Obj_Item_Weapon_Storage_Bag_Money) )) {
				B = _b;
				

				if ( B != null ) {
					
					foreach (dynamic _a in Lang13.Enumerate( B, typeof(Obj_Item_Weapon_Coin) )) {
						C = _a;
						
						found_amount += C.credits;
					}
				}
			}
			return found_amount >= this.required_amount;
		}

	}

}