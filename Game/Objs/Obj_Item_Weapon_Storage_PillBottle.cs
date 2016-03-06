// FILE AUTOGENERATED BY SOMNIUM13.

using System;
using Somnium.Engine.ByImpl;

namespace Somnium.Game {
	class Obj_Item_Weapon_Storage_PillBottle : Obj_Item_Weapon_Storage {

		protected override void __FieldInit() {
			base.__FieldInit();

			this.item_state = "contsolid";
			this.w_class = 2;
			this.can_hold = new ByTable(new object [] { typeof(Obj_Item_Weapon_ReagentContainers_Pill), typeof(Obj_Item_Weapon_Dice) });
			this.allow_quick_gather = true;
			this.use_to_pickup = true;
			this.icon = "icons/obj/chemical.dmi";
			this.icon_state = "pill_canister";
		}

		public Obj_Item_Weapon_Storage_PillBottle ( dynamic loc = null ) : base( (object)(loc) ) {
			
		}

		// Function from file: firstaid.dm
		public override dynamic MouseDrop( dynamic over = null, dynamic src_location = null, dynamic over_location = null, string src_control = null, dynamic over_control = null, string _params = null ) {
			Mob M = null;

			
			if ( Task13.User is Mob_Living_Carbon_Human || Task13.User is Mob_Living_Carbon_Monkey ) {
				M = Task13.User;

				if ( !( over is Obj_Screen ) || !this.Adjacent( M ) ) {
					return base.MouseDrop( (object)(over), (object)(src_location), (object)(over_location), src_control, (object)(over_control), _params );
				}

				if ( !M.restrained() && !( M.stat != 0 ) ) {
					
					dynamic _a = over.name; // Was a switch-case, sorry for the mess.
					if ( _a=="r_hand" ) {
						M.unEquip( this );
						M.put_in_r_hand( this );
					} else if ( _a=="l_hand" ) {
						M.unEquip( this );
						M.put_in_l_hand( this );
					}
					this.add_fingerprint( Task13.User );
					return null;
				}

				if ( over == Task13.User && Map13.GetDistance( this, Task13.User ) <= 1 || Task13.User.contents.Find( this ) != 0 ) {
					
					if ( Task13.User.s_active != null ) {
						Task13.User.s_active.close( Task13.User );
					}
					this.show_to( Task13.User );
					return null;
				}
			}
			return null;
		}

	}

}