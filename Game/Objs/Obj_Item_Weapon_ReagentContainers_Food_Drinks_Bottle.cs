// FILE AUTOGENERATED BY SOMNIUM13.

using System;
using Somnium.Engine.ByImpl;

namespace Somnium.Game {
	class Obj_Item_Weapon_ReagentContainers_Food_Drinks_Bottle : Obj_Item_Weapon_ReagentContainers_Food_Drinks {

		public int duration = 13;
		public bool isGlass = true;

		protected override void __FieldInit() {
			base.__FieldInit();

			this.amount_per_transfer_from_this = 10;
			this.volume = 100;
			this.throwforce = 15;
			this.item_state = "broken_beer";
		}

		public Obj_Item_Weapon_ReagentContainers_Food_Drinks_Bottle ( dynamic location = null, int? vol = null ) : base( (object)(location), vol ) {
			
		}

		// Function from file: bottle.dm
		public override bool attack( dynamic M = null, dynamic user = null, bool? def_zone = null ) {
			string affecting = null;
			dynamic armor_block = null;
			dynamic armor_duration = null;
			dynamic H = null;
			bool headarmor = false;
			string head_attack_message = null;

			
			if ( !Lang13.Bool( M ) ) {
				return false;
			}

			if ( user.a_intent != "harm" || !this.isGlass ) {
				return base.attack( (object)(M), (object)(user), def_zone );
			}
			this.force = 15;
			affecting = user.zone_selected;
			armor_block = 0;
			armor_duration = 0;

			if ( M is Mob_Living_Carbon_Human ) {
				H = M;
				headarmor = false;
				armor_block = ((Mob_Living)H).run_armor_check( affecting, "melee", "", "", this.armour_penetration );

				if ( H.head is Obj_Item_Clothing_Head && affecting == "head" ) {
					
					if ( Lang13.Bool( H.head.armor["melee"] ) ) {
						headarmor = Lang13.Bool( H.head.armor["melee"] );
					} else {
						headarmor = false;
					}
				} else {
					headarmor = false;
				}
				armor_duration = GlobalVars.duration - ( headarmor ?1:0) + Convert.ToDouble( this.force );
			} else {
				armor_block = ((Mob_Living)M).run_armor_check( affecting, "melee" );

				if ( affecting == "head" ) {
					armor_duration = this.force + 13;
				}
			}
			armor_duration /= 10;
			armor_block = Num13.MinInt( 90, Convert.ToInt32( armor_block ) );
			M.apply_damage( this.force, "brute", affecting, armor_block );
			head_attack_message = "";

			if ( affecting == "head" && M is Mob_Living_Carbon ) {
				head_attack_message = " on the head";

				if ( Lang13.Bool( armor_duration ) ) {
					((Mob_Living)M).apply_effect( Num13.MinInt( Convert.ToInt32( armor_duration ), 10 ), "weaken" );
				}
			}

			if ( M != user ) {
				((Ent_Static)M).visible_message( "<span class='danger'>" + user + " has hit " + M + head_attack_message + " with a bottle of " + this.name + "!</span>", "<span class='userdanger'>" + user + " has hit " + M + head_attack_message + " with a bottle of " + this.name + "!</span>" );
			} else {
				((Ent_Static)user).visible_message( new Txt( "<span class='danger'>" ).item( M ).str( " hits " ).himself_herself_itself_themself().str( " with a bottle of " ).item( this.name ).item( head_attack_message ).str( "!</span>" ).ToString(), new Txt( "<span class='userdanger'>" ).item( M ).str( " hits " ).himself_herself_itself_themself().str( " with a bottle of " ).item( this.name ).item( head_attack_message ).str( "!</span>" ).ToString() );
			}
			GlobalFuncs.add_logs( user, M, "attacked", this );
			this.SplashReagents( M );
			this.smash( M, user );
			return false;
		}

		// Function from file: bottle.dm
		public void SplashReagents( dynamic M = null ) {
			
			if ( Lang13.Bool( this.reagents.total_volume ) ) {
				((Ent_Static)M).visible_message( new Txt( "<span class='danger'>The contents of " ).the( this ).item().str( " splashes all over " ).item( M ).str( "!</span>" ).ToString() );
				this.reagents.reaction( M, GlobalVars.TOUCH );
				this.reagents.clear_reagents();
			}
			return;
		}

		// Function from file: bottle.dm
		public void smash( dynamic target = null, dynamic user = null, bool? ranged = null ) {
			ranged = ranged ?? false;

			dynamic new_location = null;
			Obj_Item_Weapon_BrokenBottle B = null;
			Icon I = null;

			new_location = GlobalFuncs.get_turf( this.loc );
			B = new Obj_Item_Weapon_BrokenBottle( new_location );

			if ( ranged == true ) {
				B.loc = new_location;
			} else {
				user.drop_item();
				((Mob)user).put_in_active_hand( B );
			}
			B.icon_state = this.icon_state;
			I = new Icon( "icons/obj/drinks.dmi", this.icon_state );
			I.Blend( B.broken_outline, 3, Rand13.Int( 5 ), 1 );
			I.SwapColor( "#ff00dcff", "#00000000" );
			B.icon = I;

			if ( this.isGlass ) {
				
				if ( Rand13.PercentChance( 33 ) ) {
					new Obj_Item_Weapon_Shard( new_location );
				}
				GlobalFuncs.playsound( this, "shatter", 70, 1 );
			} else {
				B.name = "broken carton";
				B.force = 0;
				B.throwforce = 0;
				B.desc = "A carton with the bottom half burst open. Might give you a papercut.";
			}
			this.transfer_fingerprints_to( B );
			GlobalFuncs.qdel( this );
			return;
		}

		// Function from file: bottle.dm
		public override bool throw_impact( dynamic target = null, Mob_Living_Carbon thrower = null ) {
			base.throw_impact( (object)(target), thrower );
			this.SplashReagents( target );
			this.smash( target, thrower, true );
			return false;
		}

	}

}