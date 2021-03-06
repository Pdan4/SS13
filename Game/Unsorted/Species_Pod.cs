// FILE AUTOGENERATED BY SOMNIUM13.

using System;
using Somnium.Engine.ByImpl;

namespace Somnium.Game {
	class Species_Pod : Species {

		protected override void __FieldInit() {
			base.__FieldInit();

			this.name = "Podperson";
			this.id = "pod";
			this.default_color = "59CE00";
			this.specflags = new ByTable(new object [] { 1, 8 });
			this.attack_verb = "slash";
			this.attack_sound = "sound/weapons/slice.ogg";
			this.miss_sound = "sound/weapons/slashmiss.ogg";
			this.burnmod = 1.25;
			this.heatmod = 1.5;
			this.meat = typeof(Obj_Item_Weapon_ReagentContainers_Food_Snacks_Meat_Slab_Human_Mutant_Plant);
		}

		// Function from file: species_types.dm
		public override void on_hit( dynamic proj_type = null, Mob H = null ) {
			
			dynamic _a = proj_type; // Was a switch-case, sorry for the mess.
			if ( _a==typeof(Obj_Item_Projectile_Energy_Floramut) ) {
				
				if ( Rand13.PercentChance( 15 ) ) {
					H.rad_act( Rand13.Int( 30, 80 ) );
					H.Weaken( 5 );
					H.visible_message( new Txt( "<span class='warning'>" ).item( H ).str( " writhes in pain as " ).his_her_its_their().str( " vacuoles boil.</span>" ).ToString(), "<span class='userdanger'>You writhe in pain as your vacuoles boil!</span>", "<span class='italics'>You hear the crunching of leaves.</span>" );

					if ( Rand13.PercentChance( 80 ) ) {
						GlobalFuncs.randmutb( H );
					} else {
						GlobalFuncs.randmutg( H );
					}
					H.domutcheck();
				} else {
					((Mob_Living)H).adjustFireLoss( Rand13.Int( 5, 15 ) );
					H.show_message( "<span class='userdanger'>The radiation beam singes you!</span>" );
				}
			} else if ( _a==typeof(Obj_Item_Projectile_Energy_Florayield) ) {
				H.nutrition = Num13.MinInt( ((int)( H.nutrition + 30 )), 550 );
			}
			return;
		}

		// Function from file: species_types.dm
		public override bool handle_chemicals( dynamic chem = null, Mob_Living H = null ) {
			
			if ( chem.id == "plantbgone" ) {
				H.adjustToxLoss( 3 );
				H.reagents.remove_reagent( chem.id, 0.4 );
				return true;
			}
			return false;
		}

		// Function from file: species_types.dm
		public override void spec_life( Mob_Living H = null ) {
			int light_amount = 0;
			Ent_Static T = null;

			
			if ( H.stat == 2 ) {
				return;
			}
			light_amount = 0;

			if ( H.loc is Tile ) {
				T = H.loc;
				light_amount = Num13.MinInt( 10, ((int)( ((Tile)T).get_lumcount() )) ) - 5;
				H.nutrition += light_amount;

				if ( H.nutrition > 550 ) {
					H.nutrition = 550;
				}

				if ( light_amount > 2 ) {
					H.heal_overall_damage( 1, 1 );
					H.adjustToxLoss( -1 );
					H.adjustOxyLoss( -1 );
				}
			}

			if ( H.nutrition < 200 ) {
				H.take_overall_damage( 2, 0 );
			}
			return;
		}

	}

}