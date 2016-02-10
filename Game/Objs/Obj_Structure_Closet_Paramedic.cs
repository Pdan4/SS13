// FILE AUTOGENERATED BY SOMNIUM13.

using System;
using Somnium.Engine.ByImpl;

namespace Somnium.Game {
	class Obj_Structure_Closet_Paramedic : Obj_Structure_Closet {

		protected override void __FieldInit() {
			base.__FieldInit();

			this.icon_closed = "blue";
			this.icon_state = "blue";
		}

		// Function from file: job_closets.dm
		public Obj_Structure_Closet_Paramedic ( dynamic loc = null ) : base( (object)(loc) ) {
			// Warning: Super call was HERE! If anything above HERE is needed by the super call, it might break!;
			new Obj_Item_Clothing_Under_Rank_Medical_Paramedic( this );
			new Obj_Item_Clothing_Under_Rank_Medical_Paramedic( this );
			new Obj_Item_Device_Radio_Headset_HeadsetMed(  );
			new Obj_Item_Device_Radio_Headset_HeadsetMed(  );
			new Obj_Item_Clothing_Head_Soft_Paramedic( this );
			new Obj_Item_Clothing_Head_Soft_Paramedic( this );
			new Obj_Item_Clothing_Head_Soft_Paramedic( this );
			new Obj_Item_Clothing_Head_Soft_Paramedic( this );
			new Obj_Item_Clothing_Gloves_Latex( this );
			new Obj_Item_Clothing_Gloves_Latex( this );
			new Obj_Item_Clothing_Gloves_Latex( this );
			new Obj_Item_Clothing_Gloves_Latex( this );
			new Obj_Item_Clothing_Shoes_Black( this );
			new Obj_Item_Clothing_Shoes_Black( this );
			new Obj_Item_Clothing_Suit_Storage_Paramedic( this );
			new Obj_Item_Clothing_Suit_Storage_Paramedic( this );
			new Obj_Item_Clothing_Suit_Storage_Paramedic( this );
			new Obj_Item_Clothing_Suit_Storage_Paramedic( this );
			new Obj_Item_Weapon_Tank_EmergencyOxygen_Engi( this );
			new Obj_Item_Weapon_Tank_EmergencyOxygen_Engi( this );
			new Obj_Item_Weapon_Tank_EmergencyOxygen_Engi( this );
			new Obj_Item_Weapon_Tank_EmergencyOxygen_Engi( this );
			new Obj_Item_Device_Gps_Paramedic( this );
			new Obj_Item_Device_Gps_Paramedic( this );
			return;
		}

	}

}