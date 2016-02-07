// FILE AUTOGENERATED BY SOM13. DO NOT EDIT YET.

using System;
using Somnium.Engine.ByImpl;

namespace Somnium.Game {
	class GameMode_Traitor_DoubleAgents : GameMode_Traitor {

		public ByTable target_list = new ByTable();
		public ByTable late_joining_list = new ByTable();

		protected override void __FieldInit() {
			base.__FieldInit();

			this.name = "double agents";
			this.config_tag = "double_agents";
			this.required_players = 25;
			this.required_enemies = 5;
			this.recommended_enemies = 8;
			this.reroll_friendly = false;
			this.traitors_possible = 10;
			this.num_modifier = 6;
		}

		// Function from file: double_agents.dm
		public void check_potential_agents(  ) {
			dynamic M = null;
			dynamic agent_mind = null;
			dynamic H = null;

			
			foreach (dynamic _a in Lang13.Enumerate( this.late_joining_list )) {
				M = _a;
				

				if ( M is Mind ) {
					agent_mind = M;

					if ( agent_mind.current is Mob_Living_Carbon_Human ) {
						H = agent_mind.current;

						if ( Convert.ToInt32( H.stat ) != 2 ) {
							
							if ( Lang13.Bool( H.client ) ) {
								continue;
							}
						}
					}
				}
				this.late_joining_list.Remove( M );
			}
			return;
		}

		// Function from file: double_agents.dm
		public override void add_latejoin_traitor( Mind character = null ) {
			int i = 0;
			Mind traitor = null;
			Mind traitor2 = null;

			this.check_potential_agents();

			if ( this.late_joining_list.len >= Rand13.Int( 3, 4 ) ) {
				GlobalFuncs.shuffle( this.late_joining_list );
				this.target_list = new ByTable();
				i = 0;

				foreach (dynamic _a in Lang13.Enumerate( this.late_joining_list, typeof(Mind) )) {
					traitor = _a;
					
					i++;

					if ( i + 1 > this.late_joining_list.len ) {
						i = 0;
					}
					this.target_list[traitor] = this.late_joining_list[i + 1];
					traitor.special_role = this.traitor_name;
				}

				foreach (dynamic _b in Lang13.Enumerate( this.target_list, typeof(Mind) )) {
					traitor2 = _b;
					
					base.add_latejoin_traitor( traitor2 );
				}
				this.late_joining_list = new ByTable();
			} else {
				this.late_joining_list.Add( character );
			}
			return;
		}

		// Function from file: double_agents.dm
		public override void forge_traitor_objectives( Mind traitor = null ) {
			dynamic target_mind = null;
			dynamic destroy_objective = null;
			dynamic kill_objective = null;

			
			if ( this.target_list.len != 0 && Lang13.Bool( this.target_list[traitor] ) ) {
				target_mind = this.target_list[traitor];

				if ( target_mind.current is Mob_Living_Silicon ) {
					destroy_objective = GlobalFuncs.add_objective( traitor, typeof(Objective_Default_Destroy) );
					destroy_objective.target = target_mind;
					((Objective)destroy_objective).update_explanation_text();
				} else {
					kill_objective = GlobalFuncs.add_objective( traitor, typeof(Objective_Default_Assassinate) );
					kill_objective.target = target_mind;
					((Objective)kill_objective).update_explanation_text();
				}

				if ( traitor.current is Mob_Living_Silicon ) {
					GlobalFuncs.add_objective( traitor, typeof(Objective_EscapeObj_Survive) );
				} else {
					GlobalFuncs.add_objective( traitor, typeof(Objective_EscapeObj_Escape) );
				}
			} else {
				base.forge_traitor_objectives( traitor );
			}
			return;
		}

		// Function from file: double_agents.dm
		public override bool post_setup( bool? report = null ) {
			int i = 0;
			Mind traitor = null;

			i = 0;

			foreach (dynamic _a in Lang13.Enumerate( this.traitors, typeof(Mind) )) {
				traitor = _a;
				
				i++;

				if ( i + 1 > this.traitors.len ) {
					i = 0;
				}
				this.target_list[traitor] = this.traitors[i + 1];
			}
			base.post_setup( report );
			return false;
		}

		// Function from file: double_agents.dm
		public override void announce(  ) {
			Game13.WriteMsg( "<B>The current game mode is - Double Agents!</B>" );
			Game13.WriteMsg( "<B>There are double agents killing eachother! Do not let them succeed!</B>" );
			return;
		}

	}

}