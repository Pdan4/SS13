// FILE AUTOGENERATED BY SOM13. DO NOT EDIT YET.

using System;
using Somnium.Engine.ByImpl;

namespace Somnium.Game {
	class GameMode_Changeling : GameMode {

		public int prob_int_murder_target = 50;
		public int prob_right_murder_target_l = 25;
		public int prob_right_murder_target_h = 50;
		public int prob_int_item = 50;
		public int prob_right_item_l = 25;
		public int prob_right_item_h = 50;
		public int prob_int_sab_target = 50;
		public int prob_right_sab_target_l = 25;
		public int prob_right_sab_target_h = 50;
		public int prob_right_killer_l = 25;
		public int prob_right_killer_h = 50;
		public int prob_right_objective_l = 25;
		public int prob_right_objective_h = 50;
		public int changeling_amount = 4;
		public dynamic changeling_team_objective_type = null;

		protected override void __FieldInit() {
			base.__FieldInit();

			this.name = "changeling";
			this.config_tag = "changeling";
			this.antag_flag = "changeling";
			this.restricted_jobs = new ByTable(new object [] { "AI", "Cyborg" });
			this.protected_jobs = new ByTable(new object [] { "Security Officer", "Warden", "Detective", "Head of Security", "Captain" });
			this.required_players = 15;
			this.required_enemies = 1;
			this.recommended_enemies = 4;
			this.reroll_friendly = true;
		}

		// Function from file: changeling.dm
		public override void forge_changeling_objectives( Mind changeling = null, bool? team_mode = null ) {
			dynamic team_objective = null;

			
			if ( Lang13.Bool( this.changeling_team_objective_type ) ) {
				team_objective = Lang13.Call( this.changeling_team_objective_type );
				team_objective.owner = changeling;
				changeling.objectives.Add( team_objective );
				base.forge_changeling_objectives( changeling, true );
			} else {
				base.forge_changeling_objectives( changeling, false );
			}
			return;
		}

		// Function from file: changeling.dm
		public override void make_antag_chance( Mob_Living_Carbon_Human character = null ) {
			int changelingcap = 0;

			changelingcap = Num13.MinInt( Num13.Floor( GlobalVars.joined_player_list.len / ( ( GlobalVars.config.changeling_scaling_coeff ??0) * 2 ) ) + 2, Num13.Floor( GlobalVars.joined_player_list.len / ( GlobalVars.config.changeling_scaling_coeff ??0) ) );

			if ( GlobalVars.ticker.mode.changelings.len >= changelingcap ) {
				return;
			}

			if ( GlobalVars.ticker.mode.changelings.len <= changelingcap - 2 || Rand13.PercentChance( ((int)( 100 - ( GlobalVars.config.changeling_scaling_coeff ??0) * 2 )) ) ) {
				
				if ( character.client.prefs.be_special.Contains( "changeling" ) ) {
					
					if ( !GlobalFuncs.jobban_isbanned( character.client, "changeling" ) && !GlobalFuncs.jobban_isbanned( character.client, "Syndicate" ) ) {
						
						if ( this.age_check( character.client ) ) {
							
							if ( !this.restricted_jobs.Contains( character.job ) ) {
								character.mind.make_Changling();
							}
						}
					}
				}
			}
			return;
		}

		// Function from file: changeling.dm
		public override bool post_setup( bool? report = null ) {
			dynamic team_objectives = null;
			ByTable possible_team_objectives = null;
			dynamic T = null;
			dynamic CTO = null;
			Mind changeling = null;

			team_objectives = Lang13.GetTypes( typeof(Objective_ChangelingTeamObjective) ) - typeof(Objective_ChangelingTeamObjective);
			possible_team_objectives = new ByTable();

			foreach (dynamic _a in Lang13.Enumerate( team_objectives )) {
				T = _a;
				
				CTO = T;

				if ( this.changelings.len >= Convert.ToDouble( Lang13.Initial( CTO, "min_lings" ) ) ) {
					possible_team_objectives.Add( T );
				}
			}

			if ( possible_team_objectives.len != 0 && Rand13.PercentChance( this.changelings.len * 20 ) ) {
				this.changeling_team_objective_type = Rand13.PickFromTable( possible_team_objectives );
			}

			foreach (dynamic _b in Lang13.Enumerate( this.changelings, typeof(Mind) )) {
				changeling = _b;
				
				GlobalFuncs.log_game( "" + changeling.key + " (ckey) has been selected as a changeling" );
				((Mob)changeling.current).make_changeling();
				changeling.special_role = "Changeling";
				this.forge_changeling_objectives( changeling );
				this.greet_changeling( changeling );
			}
			base.post_setup( report );
			return false;
		}

		// Function from file: changeling.dm
		public override bool pre_setup(  ) {
			int? num_changelings = null;
			int? i = null;
			dynamic changeling = null;

			
			if ( GlobalVars.config.protect_roles_from_antagonist ) {
				this.restricted_jobs.Add( this.protected_jobs );
			}

			if ( GlobalVars.config.protect_assistant_from_antagonist ) {
				this.restricted_jobs.Add( "Assistant" );
			}
			num_changelings = 1;

			if ( Lang13.Bool( GlobalVars.config.changeling_scaling_coeff ) ) {
				num_changelings = Num13.MaxInt( 1, Num13.MinInt( Num13.Floor( this.num_players() / ( ( GlobalVars.config.changeling_scaling_coeff ??0) * 2 ) ) + 2, Num13.Floor( this.num_players() / ( GlobalVars.config.changeling_scaling_coeff ??0) ) ) );
			} else {
				num_changelings = Num13.MaxInt( 1, Num13.MinInt( this.num_players(), GlobalVars.changeling_amount ) );
			}

			if ( this.antag_candidates.len > 0 ) {
				i = null;
				i = 0;

				while (( i ??0) < ( num_changelings ??0)) {
					
					if ( !( this.antag_candidates.len != 0 ) ) {
						break;
					}
					changeling = Rand13.PickFromTable( this.antag_candidates );
					this.antag_candidates.Remove( changeling );
					this.changelings.Add( changeling );
					changeling.restricted_roles = this.restricted_jobs;
					this.modePlayer.Add( this.changelings );
					i++;
				}
				return true;
			} else {
				return false;
			}
		}

		// Function from file: changeling.dm
		public override void announce(  ) {
			Game13.WriteMsg( "<b>The current game mode is - Changeling!</b>" );
			Game13.WriteMsg( "<b>There are alien changelings on the station. Do not let the changelings succeed!</b>" );
			return;
		}

	}

}