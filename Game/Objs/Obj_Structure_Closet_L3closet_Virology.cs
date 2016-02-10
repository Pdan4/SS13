// FILE AUTOGENERATED BY SOMNIUM13.

using System;
using Somnium.Engine.ByImpl;

namespace Somnium.Game {
	class Obj_Structure_Closet_L3closet_Virology : Obj_Structure_Closet_L3closet {

		protected override void __FieldInit() {
			base.__FieldInit();

			this.icon_closed = "bio_virology";
			this.icon_opened = "bio_virologyopen";
			this.icon_state = "bio_virology";
		}

		// Function from file: l3closet.dm
		public Obj_Structure_Closet_L3closet_Virology ( dynamic loc = null ) : base( (object)(loc) ) {
			// Warning: Super call was HERE! If anything above HERE is needed by the super call, it might break!;
			Task13.Sleep( 2 );
			this.contents = new ByTable();
			new Obj_Item_Clothing_Suit_BioSuit_Virology( this );
			new Obj_Item_Clothing_Head_BioHood_Virology( this );
			return;
		}

	}

}