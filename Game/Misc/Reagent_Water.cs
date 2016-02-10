// FILE AUTOGENERATED BY SOMNIUM13.

using System;
using Somnium.Engine.ByImpl;

namespace Somnium.Game {
	class Reagent_Water : Reagent {

		protected override void __FieldInit() {
			base.__FieldInit();

			this.name = "Water";
			this.id = "water";
			this.description = "A ubiquitous chemical substance that is composed of hydrogen and oxygen.";
			this.reagent_state = 2;
			this.color = "#DEF7F5";
			this.alpha = 128;
		}

		// Function from file: Chemistry-Reagents.dm
		public override bool reaction_animal( dynamic M = null, int? method = null, double volume = 0 ) {
			method = method ?? GlobalVars.TOUCH;

			dynamic S = null;

			base.reaction_animal( (object)(M), method, volume );

			if ( M is Mob_Living_SimpleAnimal_Hostile_Slime ) {
				S = M;
				((Mob_Living_SimpleAnimal_Hostile_Slime)S).calm();
			}
			return false;
		}

		// Function from file: Chemistry-Reagents.dm
		public override bool reaction_obj( dynamic O = null, double volume = 0 ) {
			Reagent_Water self = null;
			dynamic T = null;
			dynamic cube = null;

			self = this;

			if ( base.reaction_obj( (object)(O), volume ) ) {
				return true;
			}
			T = GlobalFuncs.get_turf( O );
			self.reaction_turf( T, volume );

			if ( O is Obj_Item_Weapon_ReagentContainers_Food_Snacks_Monkeycube ) {
				cube = O;

				if ( !Lang13.Bool( cube.wrapped ) ) {
					((Obj_Item_Weapon_ReagentContainers_Food_Snacks_Monkeycube)cube).Expand();
				}
			}
			return false;
		}

		// Function from file: Chemistry-Reagents.dm
		public override bool reaction_turf( dynamic T = null, double volume = 0 ) {
			dynamic hotspot = null;
			dynamic lowertemp = null;

			
			if ( base.reaction_turf( (object)(T), volume ) ) {
				return true;
			}

			if ( volume >= 3 ) {
				((Tile_Simulated)T).f_wet( 800 );
			}
			hotspot = Lang13.FindIn( typeof(Obj_Fire), T );

			if ( Lang13.Bool( hotspot ) ) {
				lowertemp = ((Ent_Static)T).remove_air( ((GasMixture)T.air).f_total_moles() );
				lowertemp.temperature = Num13.MaxInt( Num13.MinInt( Convert.ToInt32( lowertemp.temperature - 2000 ), Convert.ToInt32( lowertemp.temperature / 2 ) ), 0 );
				lowertemp.react();
				((Ent_Static)T).assume_air( lowertemp );
				GlobalFuncs.qdel( hotspot );
			}
			return false;
		}

		// Function from file: Chemistry-Reagents.dm
		public override bool reaction_mob( dynamic M = null, int? method = null, double volume = 0 ) {
			method = method ?? GlobalVars.TOUCH;

			dynamic H = null;
			dynamic affecting = null;

			
			if ( base.reaction_mob( (object)(M), method, volume ) ) {
				return true;
			}

			if ( method == GlobalVars.TOUCH ) {
				((Mob_Living)M).adjust_fire_stacks( -( volume / 10 ) );

				if ( M.fire_stacks <= 0 ) {
					((Mob_Living)M).ExtinguishMob();
				}
			}

			if ( M is Mob_Living_Carbon_Slime ) {
				((Mob_Living)M).adjustToxLoss( Rand13.Int( 15, 20 ) );
			}

			if ( M is Mob_Living_Carbon_Human ) {
				H = M;

				if ( H.species.name == "Grey" ) {
					
					if ( method == GlobalVars.TOUCH ) {
						
						if ( Lang13.Bool( H.wear_mask ) ) {
							GlobalFuncs.to_chat( H, "<span class='warning'>Your mask protects you from the water!</span>" );
							return false;
						}

						if ( Lang13.Bool( H.head ) ) {
							GlobalFuncs.to_chat( H, "<span class='warning'>Your helmet protects you from the water!</span>" );
							return false;
						}

						if ( !Lang13.Bool( M.unacidable ) ) {
							
							if ( Rand13.PercentChance( 15 ) && volume >= 30 ) {
								affecting = ((Mob_Living_Carbon_Human)H).get_organ( "head" );

								if ( Lang13.Bool( affecting ) ) {
									
									if ( Lang13.Bool( affecting.take_damage( 25, 0 ) ) ) {
										((Mob_Living)H).UpdateDamageIcon( true );
									}
									H.status_flags |= 16384;
									((Mob)H).emote( "scream", null, null, true );
								}
							} else {
								((Mob_Living)M).take_organ_damage( Num13.MinInt( 15, ((int)( volume * 2 )) ) );
							}
						}
					} else if ( !Lang13.Bool( M.unacidable ) ) {
						((Mob_Living)M).take_organ_damage( Num13.MinInt( 15, ((int)( volume * 2 )) ) );
					}
				} else if ( H.dna.mutantrace == "slime" ) {
					((Mob_Living)H).adjustToxLoss( Rand13.Int( 1, 3 ) );
				}
			}
			return false;
		}

		// Function from file: Chemistry-Reagents.dm
		public override bool on_mob_life( Mob_Living M = null, int? alien = null ) {
			Mob_Living H = null;

			
			if ( base.on_mob_life( M, alien ) ) {
				return true;
			}

			if ( M is Mob_Living_Carbon_Human ) {
				H = M;

				if ( ((dynamic)H).species.name == "Grey" ) {
					M.adjustToxLoss( 0.5 );
					M.take_organ_damage( 0, 0.5 );
				}
			}
			return false;
		}

		// Function from file: hydroponics_reagents.dm
		public override void on_plant_life( Obj_Machinery_PortableAtmospherics_Hydroponics T = null ) {
			base.on_plant_life( T );
			T.adjust_water( 1 );
			return;
		}

	}

}