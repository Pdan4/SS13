// FILE AUTOGENERATED BY SOMNIUM13.

using System;
using Somnium.Engine.ByImpl;

namespace Somnium.Game {
	class Outfit_Job_Virologist : Outfit_Job {

		protected override void __FieldInit() {
			base.__FieldInit();

			this.name = "Virologist";
			this.belt = typeof(Obj_Item_Device_Pda_Viro);
			this.ears = typeof(Obj_Item_Device_Radio_Headset_HeadsetMed);
			this.uniform = typeof(Obj_Item_Clothing_Under_Rank_Virologist);
			this.mask = typeof(Obj_Item_Clothing_Mask_Surgical);
			this.shoes = typeof(Obj_Item_Clothing_Shoes_Sneakers_White);
			this.suit = typeof(Obj_Item_Clothing_Suit_Toggle_Labcoat_Virologist);
			this.suit_store = typeof(Obj_Item_Device_Flashlight_Pen);
			this.backpack = typeof(Obj_Item_Weapon_Storage_Backpack_Virology);
			this.satchel = typeof(Obj_Item_Weapon_Storage_Backpack_SatchelVir);
			this.dufflebag = typeof(Obj_Item_Weapon_Storage_Backpack_Dufflebag_Med);
		}

	}

}