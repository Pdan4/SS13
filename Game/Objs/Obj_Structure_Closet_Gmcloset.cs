// FILE AUTOGENERATED BY SOMNIUM13.

using System;
using Somnium.Engine.ByImpl;

namespace Somnium.Game {
	class Obj_Structure_Closet_Gmcloset : Obj_Structure_Closet {

		protected override void __FieldInit() {
			base.__FieldInit();

			this.icon_door = "black";
		}

		// Function from file: job_closets.dm
		public Obj_Structure_Closet_Gmcloset ( dynamic loc = null ) : base( (object)(loc) ) {
			// Warning: Super call was HERE! If anything above HERE is needed by the super call, it might break!;
			new Obj_Item_Clothing_Head_That( this );
			new Obj_Item_Device_Radio_Headset_HeadsetSrv( this );
			new Obj_Item_Device_Radio_Headset_HeadsetSrv( this );
			new Obj_Item_Clothing_Head_That( this );
			new Obj_Item_Clothing_Under_SlSuit( this );
			new Obj_Item_Clothing_Under_SlSuit( this );
			new Obj_Item_Clothing_Under_Rank_Bartender( this );
			new Obj_Item_Clothing_Under_Rank_Bartender( this );
			new Obj_Item_Clothing_Tie_Waistcoat( this );
			new Obj_Item_Clothing_Tie_Waistcoat( this );
			new Obj_Item_Clothing_Head_Soft_Black( this );
			new Obj_Item_Clothing_Head_Soft_Black( this );
			new Obj_Item_Clothing_Shoes_Sneakers_Black( this );
			new Obj_Item_Clothing_Shoes_Sneakers_Black( this );
			new Obj_Item_Weapon_ReagentContainers_Glass_Rag( this );
			new Obj_Item_Weapon_ReagentContainers_Glass_Rag( this );
			new Obj_Item_Weapon_Storage_Box_Beanbag( this );
			new Obj_Item_Clothing_Suit_Armor_Vest( this );
			new Obj_Item_Clothing_Glasses_Sunglasses_Reagent( this );
			new Obj_Item_Weapon_Storage_Belt_Bandolier( this );
			return;
		}

	}

}