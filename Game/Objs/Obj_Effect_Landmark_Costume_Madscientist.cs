// FILE AUTOGENERATED BY SOMNIUM13.

using System;
using Somnium.Engine.ByImpl;

namespace Somnium.Game {
	class Obj_Effect_Landmark_Costume_Madscientist : Obj_Effect_Landmark_Costume {

		// Function from file: landmarks.dm
		public Obj_Effect_Landmark_Costume_Madscientist ( dynamic loc = null ) : base( (object)(loc) ) {
			new Obj_Item_Clothing_Under_Gimmick_Rank_Captain_Suit( this.loc );
			new Obj_Item_Clothing_Head_Flatcap( this.loc );
			new Obj_Item_Clothing_Suit_Toggle_Labcoat_Mad( this.loc );
			new Obj_Item_Clothing_Glasses_Gglasses( this.loc );
			GlobalFuncs.qdel( this );
			return;
		}

	}

}