// FILE AUTOGENERATED BY SOMNIUM13.

using System;
using Somnium.Engine.ByImpl;

namespace Somnium.Game {
	class Obj_Item_Weapon_Storage_Briefcase : Obj_Item_Weapon_Storage {

		public bool empty = false;

		protected override void __FieldInit() {
			base.__FieldInit();

			this.force = 8;
			this.throw_speed = 1;
			this.throw_range = 4;
			this.w_class = 4;
			this.max_w_class = 3;
			this.max_combined_w_class = 16;
			this.icon_state = "briefcase";
		}

		// Function from file: briefcase.dm
		public Obj_Item_Weapon_Storage_Briefcase ( dynamic loc = null ) : base( (object)(loc) ) {
			// Warning: Super call was HERE! If anything above HERE is needed by the super call, it might break!;

			if ( this.empty ) {
				return;
			}
			new Obj_Item_Weapon_Paper_DemotionKey( this );
			new Obj_Item_Weapon_Paper_CommendationKey( this );
			return;
		}

		// Function from file: briefcase.dm
		public override bool? attack( dynamic M = null, dynamic user = null, string def_zone = null, bool? eat_override = null ) {
			dynamic H = null;
			int time = 0;
			dynamic O = null;

			Interface13.Stat( null, user.mutations.Contains( 5 ) );

			if ( false && Rand13.PercentChance( 50 ) ) {
				GlobalFuncs.to_chat( user, "<span class='warning'>The " + this + " slips out of your hand and hits your head.</span>" );
				((Mob_Living)user).take_organ_damage( 10 );
				((Mob)user).Paralyse( 2 );
				return null;
			}
			M.attack_log.Add( "[" + GlobalFuncs.time_stamp() + "] <font color='orange'>Has been attacked with " + this.name + " by " + user.name + " (" + user.ckey + ")</font>" );
			user.attack_log.Add( "[" + GlobalFuncs.time_stamp() + "] <font color='red'>Used the " + this.name + " to attack " + M.name + " (" + M.ckey + ")</font>" );
			GlobalFuncs.msg_admin_attack( new Txt().item( user.name ).str( " (" ).item( user.ckey ).str( ") attacked " ).item( M.name ).str( " (" ).item( M.ckey ).str( ") with " ).item( this.name ).str( " (INTENT: " ).item( String13.ToUpper( user.a_intent ) ).str( ") (<A HREF='?_src_=holder;adminmoreinfo=" ).Ref( user ).str( "'>?</A>)" ).ToString() );

			if ( !( user is Mob_Living_Carbon ) ) {
				M.LAssailant = null;
			} else {
				M.LAssailant = user;
			}

			if ( Convert.ToDouble( M.stat ) < 2 && Convert.ToDouble( M.health ) < 50 && Rand13.PercentChance( 90 ) ) {
				H = M;

				if ( H is Mob_Living_Carbon_Human && H is Obj_Item_Clothing_Head && Lang13.Bool( H.flags & 8 ) && Rand13.PercentChance( 80 ) ) {
					GlobalFuncs.to_chat( M, "<span class='warning'>The helmet protects you from being hit hard in the head!</span>" );
					return null;
				}
				time = Rand13.Int( 2, 6 );

				if ( Rand13.PercentChance( 75 ) ) {
					((Mob)M).Paralyse( time );
				} else {
					((Mob)M).Stun( time );
				}

				if ( Convert.ToInt32( M.stat ) != 2 ) {
					M.stat = 1;
				}

				foreach (dynamic _a in Lang13.Enumerate( Map13.FetchViewers( null, M ) )) {
					O = _a;
					
					O.show_message( "<span class='danger'>" + M + " has been knocked unconscious!</span>", 1, "<span class='warning'>You hear someone fall.</span>", 2 );
				}
			} else {
				GlobalFuncs.to_chat( M, "<span class='warning'>" + user + " tried to knock you unconcious!</span>" );
				M.eye_blurry += 3;
			}
			return null;
		}

		// Function from file: briefcase.dm
		public override dynamic suicide_act( Mob_Living_Carbon_Human user = null ) {
			GlobalFuncs.to_chat( Map13.FetchViewers( null, user ), new Txt( "<span class='danger'><b>" ).item( user ).str( " is smashing " ).his_her_its_their().str( " head inside the " ).item( this.name ).str( "! It looks like " ).he_she_it_they().str( "'s  trying to commit suicide!</b></span>" ).ToString() );
			return 1;
		}

	}

}