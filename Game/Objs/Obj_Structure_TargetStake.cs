// FILE AUTOGENERATED BY SOMNIUM13.

using System;
using Somnium.Engine.ByImpl;

namespace Somnium.Game {
	class Obj_Structure_TargetStake : Obj_Structure {

		public dynamic pinned_target = null;

		protected override void __FieldInit() {
			base.__FieldInit();

			this.flags = 64;
			this.icon = "icons/obj/objects.dmi";
			this.icon_state = "target_stake";
		}

		public Obj_Structure_TargetStake ( dynamic loc = null ) : base( (object)(loc) ) {
			
		}

		// Function from file: target_stake.dm
		public override dynamic bullet_act( dynamic P = null, dynamic def_zone = null ) {
			
			if ( Lang13.Bool( this.pinned_target ) ) {
				((Ent_Static)this.pinned_target).bullet_act( P );
			} else {
				base.bullet_act( (object)(P), (object)(def_zone) );
			}
			return null;
		}

		// Function from file: target_stake.dm
		public override dynamic attack_hand( dynamic a = null, bool? b = null, bool? c = null ) {
			
			if ( Lang13.Bool( this.pinned_target ) ) {
				this.removeTarget( a );
			}
			return null;
		}

		// Function from file: target_stake.dm
		public override dynamic attackby( dynamic A = null, dynamic user = null, string _params = null, bool? silent = null, bool? replace_spent = null ) {
			
			if ( Lang13.Bool( this.pinned_target ) ) {
				return null;
			}

			if ( A is Obj_Item_Target && Lang13.Bool( user.drop_item() ) ) {
				this.pinned_target = A;
				A.pinnedLoc = this;
				A.density = true;
				A.layer = 301;
				A.loc = this.loc;
				user.WriteMsg( "<span class='notice'>You slide the target into the stake.</span>" );
			}
			return null;
		}

		// Function from file: target_stake.dm
		public override bool Move( dynamic NewLoc = null, int? Dir = null, int step_x = 0, int step_y = 0 ) {
			base.Move( (object)(NewLoc), Dir, step_x, step_y );

			if ( Lang13.Bool( this.pinned_target ) ) {
				this.pinned_target.loc = this.loc;
			}
			return false;
		}

		// Function from file: target_stake.dm
		public void removeTarget( dynamic user = null ) {
			this.pinned_target.layer = GlobalVars.OBJ_LAYER;
			this.pinned_target.loc = user.loc;
			((Obj_Item_Target)this.pinned_target).nullPinnedLoc();
			this.nullPinnedTarget();

			if ( user is Mob_Living_Carbon_Human ) {
				
				if ( !Lang13.Bool( ((Mob)user).get_active_hand() ) ) {
					((Mob)user).put_in_hands( this.pinned_target );
					user.WriteMsg( "<span class='notice'>You take the target out of the stake.</span>" );
				}
			} else {
				this.pinned_target.loc = GlobalFuncs.get_turf( user );
				user.WriteMsg( "<span class='notice'>You take the target out of the stake.</span>" );
			}
			return;
		}

		// Function from file: target_stake.dm
		public void nullPinnedTarget(  ) {
			this.pinned_target = null;
			return;
		}

		// Function from file: target_stake.dm
		public override dynamic Destroy(  ) {
			
			if ( Lang13.Bool( this.pinned_target ) ) {
				((Obj_Item_Target)this.pinned_target).nullPinnedLoc();
			}
			return base.Destroy();
		}

	}

}