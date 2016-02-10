// FILE AUTOGENERATED BY SOMNIUM13.

using System;
using Somnium.Engine.ByImpl;

namespace Somnium.Game {
	class Obj_Structure_Closet_Walllocker_Defiblocker : Obj_Structure_Closet_Walllocker {

		public dynamic defib = null;

		protected override void __FieldInit() {
			base.__FieldInit();

			this.icon_opened = "medical_wall_open";
			this.icon_closed = "medical_wall";
			this.icon_state = "medical_wall";
		}

		// Function from file: walllocker.dm
		public Obj_Structure_Closet_Walllocker_Defiblocker ( dynamic loc = null ) : base( (object)(loc) ) {
			// Warning: Super call was HERE! If anything above HERE is needed by the super call, it might break!;
			this.defib = new Obj_Item_Weapon_Melee_Defibrillator( this );
			return;
		}

		// Function from file: walllocker.dm
		public override bool? update_icon( dynamic location = null, dynamic target = null ) {
			
			if ( Lang13.Bool( this.defib ) ) {
				this.icon_state = this.icon_closed;
			} else {
				this.icon_state = this.icon_opened;
			}
			return null;
		}

		// Function from file: walllocker.dm
		public override dynamic attackby( dynamic a = null, dynamic b = null, dynamic c = null ) {
			
			if ( a is Obj_Item_Weapon_Melee_Defibrillator ) {
				
				if ( Lang13.Bool( this.defib ) ) {
					GlobalFuncs.to_chat( Task13.User, "<spawn class='notice'>The locker is full." );
					return null;
				} else if ( Lang13.Bool( b.drop_item( a, this ) ) ) {
					GlobalFuncs.to_chat( Task13.User, new Txt( "<span class='notice'>You put " ).the( a ).item().str( " in " ).the( this ).item().str( ".</span>" ).ToString() );
					this.defib = a;
					this.update_icon();
					return null;
				}
			}
			return null;
		}

		// Function from file: walllocker.dm
		public override dynamic attack_hand( dynamic a = null, dynamic b = null, dynamic c = null ) {
			
			if ( a is Mob_Living_Silicon_Ai ) {
				return null;
			}

			if ( a is Mob_Living_Silicon_Robot ) {
				
				if ( !Lang13.Bool( this.defib ) ) {
					GlobalFuncs.to_chat( Task13.User, "<span class='notice'>It's empty.</span>" );
					return null;
				} else {
					GlobalFuncs.to_chat( Task13.User, new Txt( "<span class='notice'>You pull out an emergency defibrillator from " ).the( this ).item().str( ".</span>" ).ToString() );
					this.defib.loc = GlobalFuncs.get_turf( this );
					this.defib = null;
					this.update_icon();
				}
			}

			if ( !Lang13.Bool( this.defib ) ) {
				GlobalFuncs.to_chat( Task13.User, "<span class='notice'>It's empty.</span>" );
				return null;
			}

			if ( Lang13.Bool( this.defib ) ) {
				GlobalFuncs.to_chat( Task13.User, new Txt( "<span class='notice'>You take out an emergency defibrillator from " ).the( this ).item().str( ".</san>" ).ToString() );
				Task13.User.put_in_hands( this.defib );
				this.defib = null;
				this.update_icon();
			}
			return null;
		}

	}

}