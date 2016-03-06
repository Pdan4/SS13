// FILE AUTOGENERATED BY SOMNIUM13.

using System;
using Somnium.Engine.ByImpl;

namespace Somnium.Game {
	class Obj_Item_Stack_Medical : Obj_Item_Stack {

		public double heal_brute = 0;
		public double heal_burn = 0;
		public int stop_bleeding = 0;
		public double? self_delay = 50;

		protected override void __FieldInit() {
			base.__FieldInit();

			this.singular_name = "medical pack";
			this.amount = 6;
			this.max_amount = 6;
			this.w_class = 1;
			this.throw_speed = 3;
			this.burn_state = 0;
			this.burntime = 5;
		}

		public Obj_Item_Stack_Medical ( dynamic loc = null, int? amount = null ) : base( (object)(loc), amount ) {
			
		}

		// Function from file: medical.dm
		public override bool attack( dynamic M = null, dynamic user = null, bool? def_zone = null ) {
			string t_him = null;
			dynamic H = null;
			dynamic critter = null;
			string t_himself = null;
			dynamic H2 = null;
			Obj_Item_Organ_Limb affecting = null;

			
			if ( Convert.ToInt32( M.stat ) == 2 ) {
				t_him = "it";

				if ( M.gender == GlobalVars.MALE ) {
					t_him = "him";
				} else if ( M.gender == GlobalVars.FEMALE ) {
					t_him = "her";
				}
				user.WriteMsg( new Txt( "<span class='danger'>" ).The( M ).item().str( " is dead, you cannot help " ).item( t_him ).str( "!</span>" ).ToString() );
				return false;
			}

			if ( !( M is Mob_Living_Carbon ) && !( M is Mob_Living_SimpleAnimal ) ) {
				user.WriteMsg( new Txt( "<span class='danger'>You don't know how to apply " ).the( this ).item().str( " to " ).item( M ).str( "!</span>" ).ToString() );
				return true;
			}

			if ( M is Mob_Living_Carbon_Human ) {
				H = M;

				if ( this.stop_bleeding != 0 ) {
					
					if ( H.bleedsuppress ) {
						user.WriteMsg( "<span class='warning'>" + H + "'s bleeding is already bandaged!</span>" );
						return false;
					} else if ( !( H.blood_max != 0 ) ) {
						user.WriteMsg( "<span class='warning'>" + H + " isn't bleeding!</span>" );
						return false;
					}
				}
			}

			if ( M is Mob_Living ) {
				
				if ( !((Mob_Living)M).can_inject( user, true ) ) {
					return false;
				}
			}

			if ( Lang13.Bool( user ) ) {
				
				if ( M != user ) {
					
					if ( M is Mob_Living_SimpleAnimal ) {
						critter = M;

						if ( !critter.healable ) {
							user.WriteMsg( "<span class='notice'> You cannot use " + this + " on " + M + "!</span>" );
							return false;
						} else if ( critter.health == critter.maxHealth ) {
							user.WriteMsg( "<span class='notice'> " + M + " is at full health.</span>" );
							return false;
						} else if ( this.heal_brute < 1 ) {
							user.WriteMsg( "<span class='notice'> " + this + " won't help " + M + " at all.</span>" );
							return false;
						}
					}
					((Ent_Static)user).visible_message( "<span class='green'>" + user + " applies " + this + " on " + M + ".</span>", "<span class='green'>You apply " + this + " on " + M + ".</span>" );
				} else {
					t_himself = "itself";

					if ( user.gender == GlobalVars.MALE ) {
						t_himself = "himself";
					} else if ( user.gender == GlobalVars.FEMALE ) {
						t_himself = "herself";
					}
					((Ent_Static)user).visible_message( "<span class='notice'>" + user + " starts to apply " + this + " on " + t_himself + "...</span>", "<span class='notice'>You begin applying " + this + " on yourself...</span>" );

					if ( !GlobalFuncs.do_mob( user, M, this.self_delay ) ) {
						return false;
					}
					((Ent_Static)user).visible_message( "<span class='green'>" + user + " applies " + this + " on " + t_himself + ".</span>", "<span class='green'>You apply " + this + " on yourself.</span>" );
				}
			}

			if ( M is Mob_Living_Carbon_Human ) {
				H2 = M;
				affecting = ((Mob_Living_Carbon_Human)H2).get_organ( GlobalFuncs.check_zone( user.zone_selected ) );

				if ( this.stop_bleeding != 0 ) {
					
					if ( !H2.bleedsuppress ) {
						((Mob_Living_Carbon_Human)H2).suppress_bloodloss( this.stop_bleeding );
					}
				}

				if ( affecting.status == 1 ) {
					
					if ( affecting.heal_damage( this.heal_brute, this.heal_burn, false ) ) {
						((Mob_Living)H2).update_damage_overlays(  );
					}
					((Mob_Living)M).updatehealth();
				} else {
					user.WriteMsg( "<span class='notice'>Medicine won't work on a robotic limb!</span>" );
				}
			} else {
				((Mob_Living)M).heal_organ_damage( this.heal_brute / 2, this.heal_burn / 2 );
			}
			this.use( 1 );
			return false;
		}

	}

}