// FILE AUTOGENERATED BY SOMNIUM13.

using System;
using Somnium.Engine.ByImpl;

namespace Somnium.Game {
	class Obj_Effect_Landmark_Corpse_Doctor : Obj_Effect_Landmark_Corpse {

		protected override void __FieldInit() {
			base.__FieldInit();

			this.corpseradio = typeof(Obj_Item_Device_Radio_Headset_HeadsetMed);
			this.corpseuniform = typeof(Obj_Item_Clothing_Under_Rank_Medical);
			this.corpsesuit = typeof(Obj_Item_Clothing_Suit_Storage_Labcoat);
			this.corpseback = typeof(Obj_Item_Weapon_Storage_Backpack_Medic);
			this.corpsepocket1 = typeof(Obj_Item_Device_Flashlight_Pen);
			this.corpseshoes = typeof(Obj_Item_Clothing_Shoes_Black);
			this.corpseid = true;
			this.corpseidjob = "Medical Doctor";
			this.corpseidaccess = "Medical Doctor";
		}

		public Obj_Effect_Landmark_Corpse_Doctor ( dynamic loc = null ) : base( (object)(loc) ) {
			
		}

	}

}