// FILE AUTOGENERATED BY SOMNIUM13.

using System;
using Somnium.Engine.ByImpl;

namespace Somnium.Game {
	class Obj_Item_Weapon_ReagentContainers_Pill : Obj_Item_Weapon_ReagentContainers {

		protected override void __FieldInit() {
			base.__FieldInit();

			this.item_state = "pill";
			this.possible_transfer_amounts = null;
			this.volume = 50;
			this.w_type = 4;
		}

		// Function from file: pill.dm
		public Obj_Item_Weapon_ReagentContainers_Pill ( dynamic loc = null ) : base( (object)(loc) ) {
			// Warning: Super call was HERE! If anything above HERE is needed by the super call, it might break!;

			if ( !Lang13.Bool( this.icon_state ) ) {
				this.icon_state = "pill" + Rand13.Int( 1, 20 );
			}
			return;
		}

		// Function from file: pill.dm
		public virtual void injest( dynamic M = null ) {
			
			if ( !Lang13.Bool( this.reagents ) ) {
				return;
			}

			if ( !Lang13.Bool( M ) ) {
				return;
			}

			if ( !this.is_empty() ) {
				((Reagents)this.reagents).reaction( M, GlobalVars.INGEST );
				((Reagents)this.reagents).trans_to( M, this.reagents.total_volume );
			}
			GlobalFuncs.qdel( this );
			return;
		}

		// Function from file: pill.dm
		public override bool afterattack( dynamic A = null, dynamic user = null, bool? flag = null, dynamic _params = null, bool? struggle = null ) {
			bool target_was_empty = false;
			ByTable bad_reagents = null;
			dynamic tx_amount = null;

			
			if ( !( flag == true ) || !( A is Obj_Item_Weapon_ReagentContainers ) || !Lang13.Bool( ((Ent_Static)A).is_open_container() ) ) {
				return false;
			}
			target_was_empty = A.reagents.total_volume == 0;
			bad_reagents = ((Reagents)this.reagents).get_bad_reagent_names();
			tx_amount = ((Reagents)this.reagents).trans_to( A, this.reagents.total_volume );

			if ( Convert.ToDouble( tx_amount ) > 0 && A.log_reagents && bad_reagents != null && bad_reagents.len > 0 ) {
				GlobalFuncs.log_reagents( user, this, A, tx_amount, bad_reagents );
			}

			if ( Convert.ToDouble( tx_amount ) > 0 ) {
				((Ent_Static)user).visible_message( new Txt( "<span class='warning'>" ).item( user ).str( " puts something into " ).the( A ).item().str( ", filling it.</span>" ).ToString() );

				if ( this.is_empty() ) {
					GlobalFuncs.to_chat( user, new Txt( "<span class='notice'>You " ).item( ( target_was_empty ? "crush" : "dissolve" ) ).str( " the pill into " ).the( A ).item().str( ".</span>" ).ToString() );
					GlobalFuncs.qdel( this );
				} else {
					GlobalFuncs.to_chat( user, new Txt( "<span class='notice'>You " ).item( ( target_was_empty ? "crush partially" : "partially dissolve" ) ).str( " the pill into " ).the( A ).item().str( ", filling it.</span>" ).ToString() );
				}
			} else {
				GlobalFuncs.to_chat( user, new Txt( "<span class='notice'>" ).The( A ).item().str( " is full!</span>" ).ToString() );
			}
			return false;
		}

		// Function from file: pill.dm
		public override bool? attack( dynamic M = null, dynamic user = null, string def_zone = null, bool? eat_override = null ) {
			dynamic H = null;

			
			if ( user != M && ( M is Mob_Living_Carbon_Human || M is Mob_Living_Carbon_Monkey ) ) {
				((Ent_Static)user).visible_message( new Txt( "<span class='warning'>" ).item( user ).str( " attempts to force " ).item( M ).str( " to swallow " ).the( this ).item().str( ".</span>" ).ToString(), new Txt( "<span class='notice'>You attempt to force " ).item( M ).str( " to swallow " ).the( this ).item().str( ".</span>" ).ToString() );

				if ( !GlobalFuncs.do_mob( user, M ) ) {
					return true;
				}
				((Ent_Static)user).visible_message( new Txt( "<span class='warning'>" ).item( user ).str( " forces " ).item( M ).str( " to swallow " ).the( this ).item().str( ".</span>" ).ToString(), new Txt( "<span class='notice'>You force " ).item( M ).str( " to swallow " ).the( this ).item().str( ".</span>" ).ToString() );
				GlobalFuncs.add_attacklogs( user, M, "fed", this, "Reagents: " + GlobalFuncs.english_list( new ByTable(new object [] { this.reagentlist( this ) }) ), GlobalVars.TRUE );
			} else if ( user == M ) {
				((Ent_Static)user).visible_message( new Txt( "<span class='notice'>" ).item( user ).str( " swallows " ).the( this ).item().str( ".</span>" ).ToString(), new Txt( "<span class='notice'>You swallow " ).the( this ).item().str( ".</span>" ).ToString() );
			} else {
				return false;
			}
			((Mob)user).drop_from_inventory( this );

			if ( M is Mob_Living_Carbon_Human ) {
				H = M;

				if ( ( H.species.chem_flags & 2 ) != 0 ) {
					this.forceMove( GlobalFuncs.get_turf( H ) );
					((Ent_Static)H).visible_message( new Txt( "<span class='warning'>" ).The( this ).item().str( " falls through and onto the ground.</span>" ).ToString(), new Txt( "<span class='notice'>You hear " ).the( this ).item().str( " plinking around for a second before it hits the ground below you.</span>" ).ToString() );
					return false;
				}
			}
			this.injest( M );
			return true;
		}

		// Function from file: pill.dm
		public override dynamic attack_self( dynamic user = null, dynamic flag = null, bool? emp = null ) {
			return this.attack( user, user );
		}

	}

}