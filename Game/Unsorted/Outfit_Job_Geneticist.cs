// FILE AUTOGENERATED BY SOMNIUM13.

using System;
using Somnium.Engine.ByImpl;

namespace Somnium.Game {
	class Outfit_Job_Geneticist : Outfit_Job {

		protected override void __FieldInit() {
			base.__FieldInit();

			this.name = "Geneticist";
			this.belt = typeof(Obj_Item_Device_Pda_Geneticist);
			this.ears = typeof(Obj_Item_Device_Radio_Headset_HeadsetMedsci);
			this.uniform = typeof(Obj_Item_Clothing_Under_Rank_Geneticist);
			this.shoes = typeof(Obj_Item_Clothing_Shoes_Sneakers_White);
			this.suit = typeof(Obj_Item_Clothing_Suit_Toggle_Labcoat_Genetics);
			this.suit_store = typeof(Obj_Item_Device_Flashlight_Pen);
			this.backpack = typeof(Obj_Item_Weapon_Storage_Backpack_Genetics);
			this.satchel = typeof(Obj_Item_Weapon_Storage_Backpack_SatchelGen);
			this.dufflebag = typeof(Obj_Item_Weapon_Storage_Backpack_Dufflebag_Med);
		}

	}

}