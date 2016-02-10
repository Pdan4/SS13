// FILE AUTOGENERATED BY SOMNIUM13.

using System;
using Somnium.Engine.ByImpl;

namespace Somnium.Game {
	class Obj_Item_Weapon_Storage_Fancy_DonutBox : Obj_Item_Weapon_Storage_Fancy {

		protected override void __FieldInit() {
			base.__FieldInit();

			this.storage_slots = 6;
			this.can_hold = new ByTable(new object [] { "/obj/item/weapon/reagent_containers/food/snacks/donut", "/obj/item/weapon/reagent_containers/food/snacks/customizable/candy/donut" });
			this.foldable = typeof(Obj_Item_Stack_Sheet_Cardboard);
			this.starting_materials = new ByTable().Set( "$cardboard", 3750 );
			this.w_type = 1;
		}

		// Function from file: fancy.dm
		public Obj_Item_Weapon_Storage_Fancy_DonutBox ( dynamic loc = null ) : base( (object)(loc) ) {
			int? i = null;

			// Warning: Super call was HERE! If anything above HERE is needed by the super call, it might break!;

			if ( this.empty ) {
				this.update_icon();
				return;
			}
			i = null;
			i = 1;

			while (( i ??0) <= ( this.storage_slots ??0)) {
				new Obj_Item_Weapon_ReagentContainers_Food_Snacks_Donut_Normal( this );
				i++;
			}
			return;
		}

	}

}