// FILE AUTOGENERATED BY SOM13. DO NOT EDIT YET.

using System;
using Somnium.Engine.ByImpl;

namespace Somnium.Game {
	class Obj_Effect_Landmark_Corpse_Scientist : Obj_Effect_Landmark_Corpse {

		protected override void __FieldInit() {
			base.__FieldInit();

			this.corpseradio = typeof(Obj_Item_Device_Radio_Headset_HeadsetSci);
			this.corpseuniform = typeof(Obj_Item_Clothing_Under_Rank_Scientist);
			this.corpsesuit = typeof(Obj_Item_Clothing_Suit_Toggle_Labcoat_Science);
			this.corpseback = typeof(Obj_Item_Weapon_Storage_Backpack);
			this.corpseshoes = typeof(Obj_Item_Clothing_Shoes_Sneakers_White);
			this.corpseid = true;
			this.corpseidjob = "Scientist";
			this.corpseidaccess = "Scientist";
		}

		public Obj_Effect_Landmark_Corpse_Scientist ( dynamic loc = null ) : base( (object)(loc) ) {
			
		}

	}

}