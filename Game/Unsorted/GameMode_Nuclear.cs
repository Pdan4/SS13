// FILE AUTOGENERATED BY SOMNIUM13.

using System;
using Somnium.Engine.ByImpl;

namespace Somnium.Game {
	class GameMode_Nuclear : GameMode {

		public int agents_possible = 5;
		public int nukes_left = 1;
		public int nuke_off_station = 0;
		public bool syndies_didnt_escape = false;

		protected override void __FieldInit() {
			base.__FieldInit();

			this.name = "nuclear emergency";
			this.config_tag = "nuclear";
			this.required_players = 20;
			this.required_enemies = 5;
			this.recommended_enemies = 5;
			this.antag_flag = "operative";
			this.enemy_minimum_age = 14;
		}

		// Function from file: nuclear.dm
		public override bool declare_completion(  ) {
			bool disk_rescued = false;
			Obj_Item_Weapon_Disk_Nuclear D = null;
			bool crew_evacuated = false;

			disk_rescued = true;

			foreach (dynamic _a in Lang13.Enumerate( GlobalVars.poi_list, typeof(Obj_Item_Weapon_Disk_Nuclear) )) {
				D = _a;
				

				if ( !D.onCentcom() ) {
					disk_rescued = false;
					break;
				}
			}
			crew_evacuated = GlobalVars.SSshuttle.emergency.mode >= 6;

			if ( !disk_rescued && this.station_was_nuked && !this.syndies_didnt_escape ) {
				GlobalFuncs.feedback_set_details( "round_end_result", "win - syndicate nuke" );
				Game13.WriteMsg( "<FONT size = 3><B>Syndicate Major Victory!</B></FONT>" );
				Game13.WriteMsg( "<B>" + GlobalFuncs.syndicate_name() + " operatives have destroyed " + GlobalFuncs.station_name() + "!</B>" );
			} else if ( !disk_rescued && this.station_was_nuked && this.syndies_didnt_escape ) {
				GlobalFuncs.feedback_set_details( "round_end_result", "halfwin - syndicate nuke - did not evacuate in time" );
				Game13.WriteMsg( "<FONT size = 3><B>Total Annihilation</B></FONT>" );
				Game13.WriteMsg( "<B>" + GlobalFuncs.syndicate_name() + " operatives destroyed " + GlobalFuncs.station_name() + " but did not leave the area in time and got caught in the explosion.</B> Next time, don't lose the disk!" );
			} else if ( !disk_rescued && !this.station_was_nuked && this.nuke_off_station != 0 && !this.syndies_didnt_escape ) {
				GlobalFuncs.feedback_set_details( "round_end_result", "halfwin - blew wrong station" );
				Game13.WriteMsg( "<FONT size = 3><B>Crew Minor Victory</B></FONT>" );
				Game13.WriteMsg( "<B>" + GlobalFuncs.syndicate_name() + " operatives secured the authentication disk but blew up something that wasn't " + GlobalFuncs.station_name() + ".</B> Next time, don't lose the disk!" );
			} else if ( !disk_rescued && !this.station_was_nuked && this.nuke_off_station != 0 && this.syndies_didnt_escape ) {
				GlobalFuncs.feedback_set_details( "round_end_result", "halfwin - blew wrong station - did not evacuate in time" );
				Game13.WriteMsg( "<FONT size = 3><B>" + GlobalFuncs.syndicate_name() + " operatives have earned Darwin Award!</B></FONT>" );
				Game13.WriteMsg( "<B>" + GlobalFuncs.syndicate_name() + " operatives blew up something that wasn't " + GlobalFuncs.station_name() + " and got caught in the explosion.</B> Next time, don't lose the disk!" );
			} else if ( ( disk_rescued || GlobalVars.SSshuttle.emergency.mode < 6 ) && this.are_operatives_dead() ) {
				GlobalFuncs.feedback_set_details( "round_end_result", "loss - evacuation - disk secured - syndi team dead" );
				Game13.WriteMsg( "<FONT size = 3><B>Crew Major Victory!</B></FONT>" );
				Game13.WriteMsg( "<B>The Research Staff has saved the disc and killed the " + GlobalFuncs.syndicate_name() + " Operatives</B>" );
			} else if ( disk_rescued ) {
				GlobalFuncs.feedback_set_details( "round_end_result", "loss - evacuation - disk secured" );
				Game13.WriteMsg( "<FONT size = 3><B>Crew Major Victory</B></FONT>" );
				Game13.WriteMsg( "<B>The Research Staff has saved the disc and stopped the " + GlobalFuncs.syndicate_name() + " Operatives!</B>" );
			} else if ( !disk_rescued && this.are_operatives_dead() ) {
				GlobalFuncs.feedback_set_details( "round_end_result", "loss - evacuation - disk not secured" );
				Game13.WriteMsg( "<FONT size = 3><B>Syndicate Minor Victory!</B></FONT>" );
				Game13.WriteMsg( "<B>The Research Staff failed to secure the authentication disk but did manage to kill most of the " + GlobalFuncs.syndicate_name() + " Operatives!</B>" );
			} else if ( !disk_rescued && crew_evacuated ) {
				GlobalFuncs.feedback_set_details( "round_end_result", "halfwin - detonation averted" );
				Game13.WriteMsg( "<FONT size = 3><B>Syndicate Minor Victory!</B></FONT>" );
				Game13.WriteMsg( "<B>" + GlobalFuncs.syndicate_name() + " operatives recovered the abandoned authentication disk but detonation of " + GlobalFuncs.station_name() + " was averted.</B> Next time, don't lose the disk!" );
			} else if ( !disk_rescued && !crew_evacuated ) {
				GlobalFuncs.feedback_set_details( "round_end_result", "halfwin - interrupted" );
				Game13.WriteMsg( "<FONT size = 3><B>Neutral Victory</B></FONT>" );
				Game13.WriteMsg( "<B>Round was mysteriously interrupted!</B>" );
			}
			base.declare_completion();
			return false;
		}

		// Function from file: nuclear.dm
		public override bool check_finished(  ) {
			
			if ( Lang13.Bool( this.replacementmode ) && this.round_converted == 2 ) {
				return ((GameMode)this.replacementmode).check_finished();
			}

			if ( GlobalVars.SSshuttle.emergency.mode >= 6 || this.station_was_nuked ) {
				return true;
			}

			if ( this.are_operatives_dead() ) {
				
				if ( GlobalVars.bomb_set ) {
					return false;
				}
			}
			base.check_finished();
			return false;
		}

		// Function from file: nuclear.dm
		public override bool check_win(  ) {
			
			if ( this.nukes_left == 0 ) {
				return true;
			}
			return base.check_win();
		}

		// Function from file: nuclear.dm
		public override bool post_setup( bool? report = null ) {
			ByTable synd_spawn = null;
			Obj_Effect_Landmark A = null;
			string nuke_code = null;
			bool leader_selected = false;
			int agent_number = 0;
			int spawnpos = 0;
			Mind synd_mind = null;
			dynamic nuke = null;

			synd_spawn = new ByTable();

			foreach (dynamic _a in Lang13.Enumerate( GlobalVars.landmarks_list, typeof(Obj_Effect_Landmark) )) {
				A = _a;
				

				if ( A.name == "Syndicate-Spawn" ) {
					synd_spawn.Add( GlobalFuncs.get_turf( A ) );
					continue;
				}
			}
			nuke_code = "" + Rand13.Int( 10000, 99999 );
			leader_selected = false;
			agent_number = 1;
			spawnpos = 1;

			foreach (dynamic _b in Lang13.Enumerate( this.syndicates, typeof(Mind) )) {
				synd_mind = _b;
				

				if ( spawnpos > synd_spawn.len ) {
					spawnpos = 2;
				}
				synd_mind.current.loc = synd_spawn[spawnpos];
				this.forge_syndicate_objectives( synd_mind );
				this.greet_syndicate( synd_mind );
				this.equip_syndicate( synd_mind.current );

				if ( Lang13.Bool( nuke_code ) ) {
					synd_mind.store_memory( "<B>Syndicate Nuclear Bomb Code</B>: " + nuke_code );
					synd_mind.current.WriteMsg( "The nuclear authorization code is: <B>" + nuke_code + "</B>" );
				}

				if ( !leader_selected ) {
					this.prepare_syndicate_leader( synd_mind, nuke_code );
					leader_selected = true;
				} else {
					synd_mind.current.real_name = "" + GlobalFuncs.syndicate_name() + " Operative #" + agent_number;
					agent_number++;
				}
				spawnpos++;
				this.update_synd_icons_added( synd_mind );
			}
			nuke = Lang13.FindIn( "syndienuke", GlobalVars.nuke_list );

			if ( Lang13.Bool( nuke ) ) {
				nuke.r_code = nuke_code;
			}
			return base.post_setup( report );
		}

		// Function from file: nuclear.dm
		public override bool pre_setup(  ) {
			double agent_number = 0;
			double n_players = 0;
			dynamic new_syndicate = null;
			Mind synd_mind = null;
			dynamic human = null;

			agent_number = 0;

			if ( this.antag_candidates.len > GlobalVars.agents_possible ) {
				agent_number = GlobalVars.agents_possible;
			} else {
				agent_number = this.antag_candidates.len;
			}
			n_players = this.num_players();

			if ( agent_number > n_players ) {
				agent_number = n_players / 2;
			}

			while (agent_number > 0) {
				new_syndicate = Rand13.PickFromTable( this.antag_candidates );
				this.syndicates.Add( new_syndicate );
				this.antag_candidates.Remove( new_syndicate );
				agent_number--;
			}

			foreach (dynamic _a in Lang13.Enumerate( this.syndicates, typeof(Mind) )) {
				synd_mind = _a;
				
				synd_mind.assigned_role = "Syndicate";
				synd_mind.special_role = "Syndicate";
				GlobalFuncs.log_game( "" + synd_mind.key + " (ckey) has been selected as a nuclear operative" );

				if ( synd_mind.current is Mob_Living_Carbon_Human ) {
					human = synd_mind.current;

					if ( Lang13.Bool( human.dna ) && human.dna.species.dangerous_existence ) {
						((Mob)human).set_species( typeof(Species_Human) );
					}
				}
			}
			return true;
		}

		// Function from file: nuclear.dm
		public override void announce(  ) {
			Game13.WriteMsg( "<B>The current game mode is - Nuclear Emergency!</B>" );
			Game13.WriteMsg( "<B>A " + GlobalFuncs.syndicate_name() + " Strike Force is approaching " + GlobalFuncs.station_name() + "!</B>" );
			Game13.WriteMsg( "A nuclear explosive was being transported by Nanotrasen to a military base. The transport ship mysteriously lost contact with Space Traffic Control (STC). About that time a strange disk was discovered around " + GlobalFuncs.station_name() + ". It was identified by Nanotrasen as a nuclear auth. disk and now Syndicate Operatives have arrived to retake the disk and detonate SS13! Also, most likely Syndicate star ships are in the vicinity so take care not to lose the disk!\n<B>Syndicate</B>: Reclaim the disk and detonate the nuclear bomb anywhere on SS13.\n<B>Personnel</B>: Hold the disk and <B>escape with the disk</B> on the shuttle!" );
			return;
		}

	}

}