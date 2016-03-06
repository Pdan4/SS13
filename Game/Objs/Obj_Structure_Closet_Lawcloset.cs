// FILE AUTOGENERATED BY SOMNIUM13.

using System;
using Somnium.Engine.ByImpl;

namespace Somnium.Game {
	class Obj_Structure_Closet_Lawcloset : Obj_Structure_Closet {

		protected override void __FieldInit() {
			base.__FieldInit();

			this.icon_door = "blue";
		}

		// Function from file: job_closets.dm
		public Obj_Structure_Closet_Lawcloset ( dynamic loc = null ) : base( (object)(loc) ) {
			// Warning: Super call was HERE! If anything above HERE is needed by the super call, it might break!;
			new Obj_Item_Clothing_Under_Lawyer_Female( this );
			new Obj_Item_Clothing_Under_Lawyer_Black( this );
			new Obj_Item_Clothing_Under_Lawyer_Red( this );
			new Obj_Item_Clothing_Under_Lawyer_Bluesuit( this );
			new Obj_Item_Clothing_Suit_Toggle_Lawyer( this );
			new Obj_Item_Clothing_Under_Lawyer_Purpsuit( this );
			new Obj_Item_Clothing_Suit_Toggle_Lawyer_Purple( this );
			new Obj_Item_Clothing_Under_Lawyer_Blacksuit( this );
			new Obj_Item_Clothing_Suit_Toggle_Lawyer_Black( this );
			new Obj_Item_Clothing_Shoes_Laceup( this );
			new Obj_Item_Clothing_Shoes_Laceup( this );
			return;
		}

	}

}