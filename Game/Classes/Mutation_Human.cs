// FILE AUTOGENERATED BY SOM13. DO NOT EDIT YET.

using System;
using Somnium.Engine.ByImpl;

namespace Somnium.Game {
	class Mutation_Human : Mutation {

		public int dna_block = 0;
		public int quality = 0;
		public int get_chance = 100;
		public int lowest_value = 2048;
		public string text_gain_indication = "";
		public string text_lose_indication = "";
		public ByTable visual_indicators = new ByTable();
		public int layer_used = 26;
		public ByTable species_allowed = new ByTable();
		public int health_req = 0;
		public int time_coeff = 1;

		// Function from file: mutations.dm
		public virtual ByTable get_spans(  ) {
			return new ByTable();
		}

		// Function from file: mutations.dm
		public virtual dynamic say_mod( dynamic message = null ) {
			
			if ( Lang13.Bool( message ) ) {
				return message;
			}
			return null;
		}

		// Function from file: mutations.dm
		public virtual dynamic on_losing( dynamic owner = null ) {
			ByTable mut_overlay = null;

			
			if ( Lang13.Bool( owner ) && owner is Mob_Living_Carbon_Human && Lang13.Bool( owner.dna.mutations.Remove( this ) ) ) {
				
				if ( Lang13.Bool( this.text_lose_indication ) && Convert.ToInt32( owner.stat ) != 2 ) {
					owner.WriteMsg( this.text_lose_indication );
				}

				if ( this.visual_indicators.len != 0 ) {
					mut_overlay = new ByTable();

					if ( Lang13.Bool( owner.overlays_standing[this.layer_used] ) ) {
						mut_overlay = owner.overlays_standing[this.layer_used];
					}
					((Mob_Living_Carbon)owner).remove_overlay( this.layer_used );
					mut_overlay.Remove( this.get_visual_indicator( owner ) );
					owner.overlays_standing[this.layer_used] = mut_overlay;
					((Mob_Living_Carbon)owner).apply_overlay( this.layer_used );
				}
				return 0;
			}
			return 1;
		}

		// Function from file: mutations.dm
		public virtual void on_life( dynamic owner = null ) {
			return;
		}

		// Function from file: mutations.dm
		public virtual void on_move( dynamic owner = null, dynamic new_loc = null ) {
			return;
		}

		// Function from file: mutations.dm
		public virtual void on_ranged_attack( Mob_Living_Carbon_Human owner = null, dynamic target = null ) {
			return;
		}

		// Function from file: mutations.dm
		public virtual bool on_attack_hand( Mob_Living_Carbon_Human owner = null, dynamic target = null ) {
			return false;
		}

		// Function from file: mutations.dm
		public virtual dynamic get_visual_indicator( dynamic owner = null ) {
			return null;
		}

		// Function from file: mutations.dm
		public virtual dynamic on_acquiring( dynamic owner = null ) {
			ByTable mut_overlay = null;

			
			if ( !Lang13.Bool( owner ) || !( owner is Mob_Living_Carbon_Human ) || Convert.ToInt32( owner.stat ) == 2 || Lang13.Bool( owner.dna.mutations.Contains( this ) ) ) {
				return 1;
			}

			if ( this.species_allowed.len != 0 && !( this.species_allowed.Find( owner.dna.species.id ) != 0 ) ) {
				return 1;
			}

			if ( this.health_req != 0 && Convert.ToDouble( owner.health ) < this.health_req ) {
				return 1;
			}
			owner.dna.mutations.Add( this );

			if ( Lang13.Bool( this.text_gain_indication ) ) {
				owner.WriteMsg( this.text_gain_indication );
			}

			if ( this.visual_indicators.len != 0 ) {
				mut_overlay = new ByTable(new object [] { this.get_visual_indicator( owner ) });

				if ( Lang13.Bool( owner.overlays_standing[this.layer_used] ) ) {
					mut_overlay = owner.overlays_standing[this.layer_used];
					mut_overlay.Or( this.get_visual_indicator( owner ) );
				}
				owner.remove_overlay( this.layer_used );
				owner.overlays_standing[this.layer_used] = mut_overlay;
				owner.apply_overlay( this.layer_used );
			}
			return null;
		}

		// Function from file: mutations.dm
		public dynamic check_block( Mob_Living_Carbon owner = null ) {
			dynamic _default = null;

			
			if ( this.check_block_string( owner.dna.struc_enzymes ) ) {
				
				if ( Rand13.PercentChance( this.get_chance ) ) {
					_default = this.on_acquiring( owner );
				}
			} else {
				_default = this.on_losing( owner );
			}
			return _default;
		}

		// Function from file: mutations.dm
		public bool check_block_string( dynamic se_string = null ) {
			
			if ( !Lang13.Bool( se_string ) || Lang13.Length( se_string ) < 57 ) {
				return false;
			}

			if ( GlobalFuncs.hex2num( GlobalFuncs.getblock( se_string, this.dna_block ) ) >= this.lowest_value ) {
				return true;
			}
			return false;
		}

		// Function from file: mutations.dm
		public void set_block( dynamic owner = null, bool? on = null ) {
			on = on ?? true;

			
			if ( Lang13.Bool( owner ) && Lang13.Bool( owner.has_dna() ) ) {
				owner.dna.struc_enzymes = this.set_se( owner.dna.struc_enzymes, on );
			}
			return;
		}

		// Function from file: mutations.dm
		public string set_se( dynamic se_string = null, bool? on = null ) {
			on = on ?? true;

			string before = null;
			string injection = null;
			string after = null;

			
			if ( !Lang13.Bool( se_string ) || Lang13.Length( se_string ) < 57 ) {
				return null;
			}
			before = String13.SubStr( se_string, 1, ( this.dna_block - 1 ) * 3 + 1 );
			injection = GlobalFuncs.num2hex( ( on == true ? Rand13.Int( this.lowest_value, 4095 ) : Rand13.Int( 0, this.lowest_value - 1 ) ), 3 );
			after = String13.SubStr( se_string, this.dna_block * 3 + 1, 0 );
			return before + injection + after;
		}

		// Function from file: mutations.dm
		public dynamic force_lose( dynamic owner = null ) {
			dynamic _default = null;

			this.set_block( owner, false );
			_default = this.on_losing( owner );
			return _default;
		}

		// Function from file: mutations.dm
		public dynamic force_give( dynamic owner = null ) {
			dynamic _default = null;

			this.set_block( owner );
			_default = this.on_acquiring( owner );
			return _default;
		}

	}

}