// FILE AUTOGENERATED BY SOMNIUM13.

using System;
using Somnium.Engine.ByImpl;

namespace Somnium.Game {
	class Obj_Item_Weapon_Implanter_Compressed : Obj_Item_Weapon_Implanter {

		public ByTable forbidden_types = new ByTable();

		protected override void __FieldInit() {
			base.__FieldInit();

			this.icon_state = "cimplanter1";
		}

		// Function from file: implanter.dm
		public Obj_Item_Weapon_Implanter_Compressed ( dynamic loc = null ) : base( (object)(loc) ) {
			this.imp = new Obj_Item_Weapon_Implant_Compressed( this );
			// Warning: Super call was HERE! If anything above HERE is needed by the super call, it might break!;
			this.update();
			return;
		}

		// Function from file: implanter.dm
		public override bool afterattack( dynamic A = null, dynamic user = null, bool? flag = null, dynamic _params = null, bool? struggle = null ) {
			Obj_Item_Weapon_Implant c = null;

			
			if ( GlobalFuncs.is_type_in_list( A, this.forbidden_types ) ) {
				GlobalFuncs.to_chat( user, "<span class='warning'>A red light flickers on the implanter.</span>" );
				return false;
			}

			if ( A is Obj_Item && this.imp != null ) {
				c = this.imp;

				if ( Lang13.Bool( ((dynamic)c).scanned ) ) {
					
					if ( A is Obj_Item_Weapon_Storage ) {
						base.afterattack( (object)(A), (object)(user), flag, (object)(_params), struggle );
						return false;
					}
					GlobalFuncs.to_chat( user, "<span class='warning'>Something is already scanned inside the implant!</span>" );
					return false;
				}

				if ( Lang13.Bool( user ) ) {
					((Mob)user).u_equip( A, false );
					user.update_icons();
				}
				((dynamic)c).scanned = A;
				((dynamic)c).scanned.loc = c;
				this.update();
			}
			return false;
		}

		// Function from file: implanter.dm
		public override bool? attack( dynamic M = null, dynamic user = null, string def_zone = null, bool? eat_override = null ) {
			Obj_Item_Weapon_Implant c = null;

			
			if ( !( M is Mob ) ) {
				return null;
			}
			c = this.imp;

			if ( !( c != null ) ) {
				return null;
			}

			if ( ((dynamic)c).scanned == null ) {
				GlobalFuncs.to_chat( user, "Please scan an object with the implanter first." );
				return null;
			}
			base.attack( (object)(M), (object)(user), def_zone, eat_override );
			return null;
		}

		// Function from file: implanter.dm
		public override void update(  ) {
			Obj_Item_Weapon_Implant c = null;

			
			if ( this.imp != null ) {
				c = this.imp;

				if ( !Lang13.Bool( ((dynamic)c).scanned ) ) {
					this.icon_state = "cimplanter1";
				} else {
					this.icon_state = "cimplanter2";
				}
			} else {
				this.icon_state = "cimplanter0";
			}
			return;
		}

	}

}