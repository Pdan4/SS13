// FILE AUTOGENERATED BY SOMNIUM13.

using System;
using Somnium.Engine.ByImpl;

namespace Somnium.Game {
	class Obj_Item_Stack_Medical_Advanced_BruisePack : Obj_Item_Stack_Medical_Advanced {

		protected override void __FieldInit() {
			base.__FieldInit();

			this.singular_name = "advanced trauma kit";
			this.heal_brute = 10;
			this.origin_tech = "biotech=2";
			this.icon_state = "traumakit";
		}

		public Obj_Item_Stack_Medical_Advanced_BruisePack ( dynamic loc = null, int? amount = null ) : base( (object)(loc), amount ) {
			
		}

		// Function from file: medical.dm
		public override bool? attack( dynamic M = null, dynamic user = null, string def_zone = null, bool? eat_override = null ) {
			dynamic H = null;
			dynamic affecting = null;
			Wound W = null;

			
			if ( base.attack( (object)(M), (object)(user), def_zone, eat_override ) == true ) {
				return true;
			}

			if ( M is Mob_Living_Carbon_Human ) {
				H = M;
				affecting = ((Mob_Living_Carbon_Human)H).get_organ( ((dynamic)user.zone_sel).selecting );

				if ( Lang13.Bool( affecting.open ) == false ) {
					
					if ( !( ((Organ_External)affecting).bandage() != 0 ) ) {
						GlobalFuncs.to_chat( user, "<span class='warning'>The wounds on " + M + "'s " + affecting.display_name + " have already been treated.</span>" );
						return true;
					} else {
						
						foreach (dynamic _a in Lang13.Enumerate( affecting.wounds, typeof(Wound) )) {
							W = _a;
							

							if ( W.v_internal ) {
								continue;
							}

							if ( W.current_stage <= W.max_bleeding_stage ) {
								((Ent_Static)user).visible_message( new Txt( "<span class='notice'>" ).item( user ).str( " cleans " ).the( W.desc ).item().str( " on " ).item( M ).str( "'s " ).item( affecting.display_name ).str( " and seals the edges with bioglue.</span>" ).ToString(), new Txt( "<span class='notice'>You clean " ).the( W.desc ).item().str( " on " ).item( M ).str( "'s " ).item( affecting.display_name ).str( " and seal the edges with bioglue .</span>" ).ToString() );
							} else if ( W is Wound_Bruise ) {
								((Ent_Static)user).visible_message( new Txt( "<span class='notice'>" ).item( user ).str( " disinfects and places a medicine patch over " ).the( W.desc ).item().str( " on " ).item( M ).str( "'s " ).item( affecting.display_name ).str( ".</span>" ).ToString(), new Txt( "<span class='notice'>You disinfect and place a medicine patch over " ).the( W.desc ).item().str( " on " ).item( M ).str( "'s " ).item( affecting.display_name ).str( ".</span>" ).ToString() );
							} else {
								((Ent_Static)user).visible_message( new Txt( "<span class='notice'>" ).item( user ).str( " smears some bioglue over " ).the( W.desc ).item().str( " on " ).item( M ).str( "'s " ).item( affecting.display_name ).str( ".</span>" ).ToString(), new Txt( "<span class='notice'>You smear some bioglue over " ).the( W.desc ).item().str( " on " ).item( M ).str( "'s " ).item( affecting.display_name ).str( ".</span>" ).ToString() );
							}
						}
						affecting.heal_damage( Rand13.Int( this.heal_brute, this.heal_brute + 5 ), 0 );
						this.use( 1 );
					}
				} else if ( GlobalFuncs.can_operate( H ) ) {
					
					if ( GlobalFuncs.do_surgery( H, user, this ) ) {
						return null;
					}
				} else {
					GlobalFuncs.to_chat( user, "<span class='notice'>" + H + "'s " + affecting.display_name + " is cut wide open, even bioglue won't do!</span>" );
				}
			}
			return null;
		}

	}

}