// FILE AUTOGENERATED BY SOMNIUM13.

using System;
using Somnium.Engine.ByImpl;

namespace Somnium.Game {
	class Obj_Item_Clothing_Accessory_Storage_Knifeharness : Obj_Item_Clothing_Accessory_Storage {

		protected override void __FieldInit() {
			base.__FieldInit();

			this._color = "unathiharness2";
			this.slots = 2;
			this.icon_state = "unathiharness2";
		}

		// Function from file: storage.dm
		public Obj_Item_Clothing_Accessory_Storage_Knifeharness ( dynamic loc = null ) : base( (object)(loc) ) {
			// Warning: Super call was HERE! If anything above HERE is needed by the super call, it might break!;
			new Obj_Item_Weapon_Hatchet_Unathiknife( this.hold );
			new Obj_Item_Weapon_Hatchet_Unathiknife( this.hold );
			this.hold.can_hold = new ByTable(new object [] { "obj/item/weapon/hatchet", "obj/item/weapon/kitchen/utensil/knife" });
			return;
		}

		// Function from file: storage.dm
		public void update(  ) {
			int count = 0;
			Obj_Item I = null;
			Ent_Static U = null;
			Ent_Static H = null;

			count = 0;

			foreach (dynamic _a in Lang13.Enumerate( this.hold, typeof(Obj_Item) )) {
				I = _a;
				

				if ( I is Obj_Item_Weapon_Hatchet_Unathiknife ) {
					count++;
				}
			}

			if ( count > 2 ) {
				count = 2;
			}
			this.item_state = "unathiharness" + count;
			this.icon_state = this.item_state;
			this._color = this.item_state;

			if ( this.loc is Obj_Item_Clothing ) {
				U = this.loc;

				if ( U.loc is Mob_Living_Carbon_Human ) {
					H = U.loc;
					((dynamic)H).update_inv_w_uniform();
				}
			}
			return;
		}

		// Function from file: storage.dm
		public override dynamic attackby( dynamic a = null, dynamic b = null, dynamic c = null ) {
			base.attackby( (object)(a), (object)(b), (object)(c) );
			this.update();
			return null;
		}

	}

}