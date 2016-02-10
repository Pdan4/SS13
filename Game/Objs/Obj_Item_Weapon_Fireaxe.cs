// FILE AUTOGENERATED BY SOMNIUM13.

using System;
using Somnium.Engine.ByImpl;

namespace Somnium.Game {
	class Obj_Item_Weapon_Fireaxe : Obj_Item_Weapon {

		protected override void __FieldInit() {
			base.__FieldInit();

			this.w_class = 4;
			this.sharpness = 1.2;
			this.slot_flags = 1024;
			this.attack_verb = new ByTable(new object [] { "attacked", "chopped", "cleaved", "torn", "cut" });
			this.flags = 288;
			this.icon_state = "fireaxe0";
		}

		public Obj_Item_Weapon_Fireaxe ( dynamic loc = null ) : base( (object)(loc) ) {
			
		}

		// Function from file: twohanded.dm
		public override bool afterattack( dynamic A = null, dynamic user = null, bool? flag = null, dynamic _params = null, bool? struggle = null ) {
			double pdiff = 0;
			dynamic W = null;

			
			if ( !( flag == true ) ) {
				return false;
			}
			base.afterattack( (object)(A), (object)(user), flag, (object)(_params), struggle );

			if ( Lang13.Bool( A ) && Lang13.Bool( this.wielded ) && ( A is Obj_Structure_Window || A is Obj_Structure_Grille ) ) {
				((Mob)user).delayNextAttack( 8 );

				if ( A is Obj_Structure_Window ) {
					pdiff = GlobalFuncs.performWallPressureCheck( A.loc );

					if ( pdiff > 0 ) {
						GlobalFuncs.message_admins( "" + A + " with pdiff " + pdiff + " fire-axed by " + user.real_name + " (" + GlobalFuncs.formatPlayerPanel( user, user.ckey ) + ") at " + GlobalFuncs.formatJumpTo( A.loc ) + "!" );
						GlobalFuncs.log_admin( "" + A + " with pdiff " + pdiff + " fire-axed by " + user.real_name + " (" + user.ckey + ") at " + A.loc + "!" );
					}
					W = A;
					((Game_Data)W).Destroy( 1 );
				} else {
					GlobalFuncs.qdel( A );
					A = null;
				}
			}
			return false;
		}

		// Function from file: twohanded.dm
		public override dynamic suicide_act( Mob_Living_Carbon_Human user = null ) {
			GlobalFuncs.to_chat( Map13.FetchViewers( null, user ), new Txt( "<span class='danger'>" ).item( user ).str( " is smashing " ).himself_herself_itself_themself().str( " in the head with the " ).item( this.name ).str( "! It looks like " ).he_she_it_they().str( "'s commit suicide!</span>" ).ToString() );
			return 1;
		}

		// Function from file: twohanded.dm
		public override void update_wield( dynamic user = null ) {
			base.update_wield( (object)(user) );
			this.item_state = "fireaxe" + ( Lang13.Bool( this.wielded ) ? true : false );
			this.force = ( Lang13.Bool( this.wielded ) ? 40 : 10 );

			if ( Lang13.Bool( user ) ) {
				((Mob)user).update_inv_l_hand();
				((Mob)user).update_inv_r_hand();
			}
			return;
		}

	}

}