// FILE AUTOGENERATED BY SOMNIUM13.

using System;
using Somnium.Engine.ByImpl;

namespace Somnium.Game {
	class Obj_Structure_Closet_SecureCloset_Paramedic : Obj_Structure_Closet_SecureCloset {

		protected override void __FieldInit() {
			base.__FieldInit();

			this.icon_closed = "medical";
			this.icon_locked = "medical1";
			this.icon_opened = "medicalopen";
			this.icon_broken = "medicalbroken";
			this.icon_off = "medicaloff";
			this.req_access = new ByTable(new object [] { 500 });
			this.icon_state = "medical1";
		}

		// Function from file: medical.dm
		public Obj_Structure_Closet_SecureCloset_Paramedic ( dynamic loc = null ) : base( (object)(loc) ) {
			// Warning: Super call was HERE! If anything above HERE is needed by the super call, it might break!;
			Task13.Sleep( 2 );
			new Obj_Item_Clothing_Suit_Space_Paramedic( this );
			new Obj_Item_Clothing_Head_Helmet_Space_Paramedic( this );
			new Obj_Item_Clothing_Shoes_Magboots( this );
			return;
		}

	}

}