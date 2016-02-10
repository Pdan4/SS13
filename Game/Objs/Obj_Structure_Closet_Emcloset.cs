// FILE AUTOGENERATED BY SOMNIUM13.

using System;
using Somnium.Engine.ByImpl;

namespace Somnium.Game {
	class Obj_Structure_Closet_Emcloset : Obj_Structure_Closet {

		protected override void __FieldInit() {
			base.__FieldInit();

			this.icon_closed = "emergency";
			this.icon_opened = "emergencyopen";
			this.icon_state = "emergency";
		}

		// Function from file: utility_closets.dm
		public Obj_Structure_Closet_Emcloset ( dynamic loc = null ) : base( (object)(loc) ) {
			// Warning: Super call was HERE! If anything above HERE is needed by the super call, it might break!;
			new Obj_Item_Weapon_Tank_EmergencyNitrogen( this );

			dynamic _a = GlobalFuncs.pickweight( new ByTable().Set( "small", 55 ).Set( "aid", 25 ).Set( "tank", 10 ).Set( "both", 10 ).Set( "nothing", 0 ).Set( "delete", 0 ) ); // Was a switch-case, sorry for the mess.
			if ( _a=="small" ) {
				new Obj_Item_Weapon_Tank_EmergencyOxygen( this );
				new Obj_Item_Weapon_Tank_EmergencyOxygen( this );
				new Obj_Item_Clothing_Mask_Breath( this );
				new Obj_Item_Clothing_Mask_Breath( this );
				new Obj_Item_Weapon_Storage_Toolbox_Emergency( this );
			} else if ( _a=="aid" ) {
				new Obj_Item_Weapon_Tank_EmergencyOxygen( this );
				new Obj_Item_Weapon_Storage_Toolbox_Emergency( this );
				new Obj_Item_Clothing_Mask_Breath( this );
				new Obj_Item_Weapon_Storage_Firstaid_O2( this );
			} else if ( _a=="tank" ) {
				new Obj_Item_Weapon_Tank_EmergencyOxygen_Engi( this );
				new Obj_Item_Clothing_Mask_Breath( this );
				new Obj_Item_Weapon_Tank_EmergencyOxygen_Engi( this );
				new Obj_Item_Clothing_Mask_Breath( this );
				new Obj_Item_Weapon_Storage_Toolbox_Emergency( this );
			} else if ( _a=="both" ) {
				new Obj_Item_Weapon_Storage_Toolbox_Emergency( this );
				new Obj_Item_Weapon_Tank_EmergencyOxygen_Engi( this );
				new Obj_Item_Clothing_Mask_Breath( this );
				new Obj_Item_Weapon_Storage_Firstaid_O2( this );
			} else if ( _a=="nothing" ) {
				return;
			} else if ( _a=="delete" ) {
				GlobalFuncs.qdel( this );
				return;
			}
			return;
		}

	}

}