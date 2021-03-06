// FILE AUTOGENERATED BY SOMNIUM13.

using System;
using Somnium.Engine.ByImpl;

namespace Somnium.Game {
	class Configuration : Game_Data {

		public string name = "Configuration";
		public dynamic server_name = null;
		public dynamic station_name = null;
		public bool server_suffix = false;
		public double? lobby_countdown = 120;
		public double? round_end_countdown = 25;
		public bool log_ooc = false;
		public bool log_access = false;
		public bool log_say = false;
		public bool log_admin = false;
		public bool log_game = false;
		public bool log_vote = false;
		public bool log_whisper = false;
		public bool log_prayer = false;
		public bool log_law = false;
		public bool log_emote = false;
		public bool log_attack = false;
		public bool log_adminchat = false;
		public bool log_pda = false;
		public bool log_hrefs = false;
		public bool sql_enabled = false;
		public bool allow_admin_ooccolor = false;
		public bool allow_vote_restart = false;
		public bool allow_vote_mode = false;
		public double? vote_delay = 6000;
		public double? vote_period = 600;
		public bool vote_no_default = false;
		public bool vote_no_dead = false;
		public bool del_new_on_log = true;
		public bool allow_Metadata = false;
		public bool popup_admin_pm = false;
		public dynamic fps = 10;
		public bool allow_holidays = false;
		public dynamic hostedby = null;
		public bool respawn = true;
		public bool guest_jobban = true;
		public bool usewhitelist = false;
		public dynamic kick_inactive = 0;
		public bool load_jobs_from_txt = false;
		public bool automute_on = false;
		public double? minimal_access_threshold = 0;
		public bool jobs_have_minimal_access = false;
		public int jobs_have_maint_access = 0;
		public bool sec_start_brig = false;
		public dynamic server = null;
		public dynamic banappeals = null;
		public dynamic wikiurl = "http://www.tgstation13.org/wiki";
		public dynamic forumurl = "http://tgstation13.org/phpBB/index.php";
		public dynamic rulesurl = "http://www.tgstation13.org/wiki/Rules";
		public dynamic githuburl = "https://www.github.com/tgstation/-tg-station";
		public bool forbid_singulo_possession = false;
		public bool useircbot = false;
		public bool admin_legacy_system = false;
		public bool ban_legacy_system = false;
		public bool use_age_restriction_for_jobs = false;
		public bool see_own_notes = false;
		public double? soft_popcap = 0;
		public double? hard_popcap = 0;
		public double? extreme_popcap = 0;
		public dynamic soft_popcap_message = "Be warned that the server is currently serving a high number of users, consider using alternative game servers.";
		public dynamic hard_popcap_message = "The server is currently serving a high number of users, You cannot currently join. You may wait for the number of living crew to decline, observe, or find alternative servers.";
		public dynamic extreme_popcap_message = "The server is currently serving a high number of users, find alternative servers.";
		public bool force_random_names = false;
		public ByTable mode_names = new ByTable();
		public ByTable modes = new ByTable();
		public ByTable votable_modes = new ByTable();
		public ByTable probabilities = new ByTable();
		public bool humans_need_surnames = false;
		public bool allow_random_events = false;
		public bool allow_ai = false;
		public bool panic_bunker = false;
		public double? notify_new_player_age = 0;
		public bool irc_first_connection_alert = false;
		public double? traitor_scaling_coeff = 6;
		public double? changeling_scaling_coeff = 6;
		public double? security_scaling_coeff = 8;
		public double? abductor_scaling_coeff = 15;
		public double? traitor_objectives_amount = 2;
		public bool protect_roles_from_antagonist = false;
		public bool protect_assistant_from_antagonist = false;
		public bool enforce_human_authority = false;
		public bool allow_latejoin_antagonists = false;
		public ByTable continuous = new ByTable();
		public ByTable midround_antag = new ByTable();
		public dynamic midround_antag_time_check = 60;
		public dynamic midround_antag_life_check = 061;
		public double? shuttle_refuel_delay = 12000;
		public bool show_game_type_odds = false;
		public bool mutant_races = false;
		public ByTable roundstart_races = new ByTable();
		public bool cleared_default_races = false;
		public bool mutant_humans = false;
		public bool no_summon_guns = false;
		public bool no_summon_magic = false;
		public bool no_summon_events = false;
		public bool intercept = true;
		public dynamic alert_desc_green = "All threats to the station have passed. Security may not have weapons visible, privacy laws are once again fully enforced.";
		public dynamic alert_desc_blue_upto = "The station has received reliable information about possible hostile activity on the station. Security staff may have weapons visible, random searches are permitted.";
		public dynamic alert_desc_blue_downto = "The immediate threat has passed. Security may no longer have weapons drawn at all times, but may continue to have them visible. Random searches are still allowed.";
		public dynamic alert_desc_red_upto = "There is an immediate serious threat to the station. Security may have weapons unholstered at all times. Random searches are allowed and advised.";
		public dynamic alert_desc_red_downto = "The station's destruction has been averted. There is still however an immediate serious threat to the station. Security may have weapons unholstered at all times, random searches are allowed and advised.";
		public dynamic alert_desc_delta = "Destruction of the station is imminent. All crew are instructed to obey all instructions given by heads of staff. Any violations of these orders can be punished by death. This is not a drill.";
		public double? health_threshold_crit = 0;
		public double? health_threshold_dead = -100;
		public double? revival_pod_plants = 1;
		public double? revival_cloning = 1;
		public double? revival_brain_life = -1;
		public bool rename_cyborg = false;
		public bool ooc_during_round = false;
		public bool emojis = false;
		public double? run_speed = 0;
		public double? walk_speed = 0;
		public double? human_delay = 0;
		public double? robot_delay = 0;
		public double? monkey_delay = 0;
		public double? alien_delay = 0;
		public double? slime_delay = 0;
		public double? animal_delay = 0;
		public double? gateway_delay = 18000;
		public bool ghost_interaction = false;
		public bool silent_ai = false;
		public bool silent_borg = false;
		public bool allowwebclient = false;
		public bool webclientmembersonly = false;
		public bool sandbox_autoclose = false;
		public double? default_laws = 0;
		public double? silicon_max_law_amount = 12;
		public double? assistant_cap = -1;
		public bool starlight = false;
		public bool grey_assistants = false;
		public bool aggressive_changelog = false;
		public bool reactionary_explosions = false;
		public bool autoconvert_notes = false;
		public bool announce_admin_logout = false;
		public bool announce_admin_login = false;
		public ByTable maplist = new ByTable();
		public Votablemap defaultmap = null;
		public bool maprotation = true;
		public double? maprotatechancedelta = 0.75;
		public Obj_Effect_Statclick_Debug statclick = null;

		// Function from file: configuration.dm
		public Configuration (  ) {
			dynamic L = null;
			dynamic T = null;
			dynamic M = null;

			L = Lang13.GetTypes( typeof(GameMode) ) - typeof(GameMode);

			foreach (dynamic _a in Lang13.Enumerate( L )) {
				T = _a;
				
				M = Lang13.Call( T );

				if ( Lang13.Bool( M.config_tag ) ) {
					
					if ( !this.modes.Contains( M.config_tag ) ) {
						GlobalVars.diary.WriteMsg( "Adding game mode " + M.name + " (" + M.config_tag + ") to configuration." );
						this.modes.Add( M.config_tag );
						this.mode_names[M.config_tag] = M.name;
						this.probabilities[M.config_tag] = M.probability;

						if ( M.votable ) {
							this.votable_modes.Add( M.config_tag );
						}
					}
				}
				GlobalFuncs.qdel( M );
			}
			this.votable_modes.Add( "secret" );
			return;
		}

		// Function from file: configuration.dm
		public void stat_entry(  ) {
			
			if ( !( this.statclick != null ) ) {
				this.statclick = new Obj_Effect_Statclick_Debug( "Edit", this );
			}
			Interface13.Stat( "" + this.name + ":", this.statclick );
			return;
		}

		// Function from file: configuration.dm
		public ByTable get_runnable_midround_modes( int crew = 0 ) {
			ByTable runnable_modes = null;
			dynamic T = null;
			dynamic M = null;

			runnable_modes = new ByTable();

			foreach (dynamic _a in Lang13.Enumerate( Lang13.GetTypes( typeof(GameMode) ) - typeof(GameMode) - GlobalVars.ticker.mode.type )) {
				T = _a;
				
				M = Lang13.Call( T );

				if ( !this.modes.Contains( M.config_tag ) ) {
					GlobalFuncs.qdel( M );
					continue;
				}

				if ( Convert.ToDouble( this.probabilities[M.config_tag] ) <= 0 ) {
					GlobalFuncs.qdel( M );
					continue;
				}

				if ( M.required_players <= crew ) {
					runnable_modes[M] = this.probabilities[M.config_tag];
				}
			}
			return runnable_modes;
		}

		// Function from file: configuration.dm
		public ByTable get_runnable_modes(  ) {
			ByTable runnable_modes = null;
			dynamic T = null;
			dynamic M = null;

			runnable_modes = new ByTable();

			foreach (dynamic _a in Lang13.Enumerate( Lang13.GetTypes( typeof(GameMode) ) - typeof(GameMode) )) {
				T = _a;
				
				M = Lang13.Call( T );

				if ( !this.modes.Contains( M.config_tag ) ) {
					GlobalFuncs.qdel( M );
					continue;
				}

				if ( Convert.ToDouble( this.probabilities[M.config_tag] ) <= 0 ) {
					GlobalFuncs.qdel( M );
					continue;
				}

				if ( ((GameMode)M).can_start() ) {
					runnable_modes[M] = this.probabilities[M.config_tag];
				}
			}
			return runnable_modes;
		}

		// Function from file: configuration.dm
		public dynamic pick_mode( dynamic mode_name = null ) {
			dynamic T = null;
			dynamic M = null;

			
			foreach (dynamic _a in Lang13.Enumerate( Lang13.GetTypes( typeof(GameMode) ) - typeof(GameMode) )) {
				T = _a;
				
				M = Lang13.Call( T );

				if ( Lang13.Bool( M.config_tag ) && M.config_tag == mode_name ) {
					return M;
				}
				GlobalFuncs.qdel( M );
			}
			return new GameMode_Extended();
		}

		// Function from file: configuration.dm
		public void loadsql( string filename = null ) {
			ByTable Lines = null;
			dynamic t = null;
			int pos = 0;
			string name = null;
			string value = null;

			Lines = GlobalFuncs.file2list( filename );

			foreach (dynamic _b in Lang13.Enumerate( Lines )) {
				t = _b;
				

				if ( !Lang13.Bool( t ) ) {
					continue;
				}
				t = GlobalFuncs.trim( t );

				if ( Lang13.Length( t ) == 0 ) {
					continue;
				} else if ( String13.SubStr( t, 1, 2 ) == "#" ) {
					continue;
				}
				pos = String13.FindIgnoreCase( t, " ", 1, 0 );
				name = null;
				value = null;

				if ( pos != 0 ) {
					name = String13.ToLower( String13.SubStr( t, 1, pos ) );
					value = String13.SubStr( t, pos + 1, 0 );
				} else {
					name = String13.ToLower( t );
				}

				if ( !Lang13.Bool( name ) ) {
					continue;
				}

				switch ((string)( name )) {
					case "sql_enabled":
						GlobalVars.config.sql_enabled = true;
						break;
					case "address":
						GlobalVars.sqladdress = value;
						break;
					case "port":
						GlobalVars.sqlport = value;
						break;
					case "feedback_database":
						GlobalVars.sqlfdbkdb = value;
						break;
					case "feedback_login":
						GlobalVars.sqlfdbklogin = value;
						break;
					case "feedback_password":
						GlobalVars.sqlfdbkpass = value;
						break;
					case "feedback_tableprefix":
						GlobalVars.sqlfdbktableprefix = value;
						break;
					default:
						GlobalVars.diary.WriteMsg( "Unknown setting in configuration: '" + name + "'" );
						break;
				}
			}
			return;
		}

		// Function from file: configuration.dm
		public void loadmaplist( string filename = null ) {
			ByTable Lines = null;
			Votablemap currentmap = null;
			dynamic t = null;
			int pos = 0;
			string command = null;
			string data = null;

			Lines = GlobalFuncs.file2list( filename );
			currentmap = null;

			foreach (dynamic _b in Lang13.Enumerate( Lines )) {
				t = _b;
				

				if ( !Lang13.Bool( t ) ) {
					continue;
				}
				t = GlobalFuncs.trim( t );

				if ( Lang13.Length( t ) == 0 ) {
					continue;
				} else if ( String13.SubStr( t, 1, 2 ) == "#" ) {
					continue;
				}
				pos = String13.FindIgnoreCase( t, " ", 1, 0 );
				command = null;
				data = null;

				if ( pos != 0 ) {
					command = String13.ToLower( String13.SubStr( t, 1, pos ) );
					data = String13.SubStr( t, pos + 1, 0 );
				} else {
					command = String13.ToLower( t );
				}

				if ( !Lang13.Bool( command ) ) {
					continue;
				}

				if ( !( currentmap != null ) && command != "map" ) {
					continue;
				}

				switch ((string)( command )) {
					case "map":
						currentmap = new Votablemap( data );
						break;
					case "friendlyname":
						currentmap.friendlyname = data;
						break;
					case "minplayers":
					case "minplayer":
						currentmap.minusers = String13.ParseNumber( data );
						break;
					case "maxplayers":
					case "maxplayer":
						currentmap.maxusers = String13.ParseNumber( data );
						break;
					case "weight":
					case "voteweight":
						currentmap.voteweight = String13.ParseNumber( data );
						break;
					case "default":
					case "defaultmap":
						GlobalVars.config.defaultmap = currentmap;
						break;
					case "endmap":
						GlobalVars.config.maplist[currentmap.name] = currentmap;
						currentmap = null;
						break;
					default:
						GlobalVars.diary.WriteMsg( "Unknown command in map vote config: '" + command + "'" );
						break;
				}
			}
			return;
		}

		// Function from file: configuration.dm
		public void load( string filename = null, string type = null ) {
			type = type ?? "config";

			ByTable Lines = null;
			dynamic t = null;
			int pos = 0;
			string name = null;
			dynamic value = null;
			double? ticklag = null;
			File newlog = null;
			string mode_name = null;
			string mode_name2 = null;
			int prob_pos = 0;
			string prob_name = null;
			string prob_value = null;
			string race_id = null;
			dynamic species_id = null;
			double? BombCap = null;

			Lines = GlobalFuncs.file2list( filename );

			foreach (dynamic _d in Lang13.Enumerate( Lines )) {
				t = _d;
				

				if ( !Lang13.Bool( t ) ) {
					continue;
				}
				t = GlobalFuncs.trim( t );

				if ( Lang13.Length( t ) == 0 ) {
					continue;
				} else if ( String13.SubStr( t, 1, 2 ) == "#" ) {
					continue;
				}
				pos = String13.FindIgnoreCase( t, " ", 1, 0 );
				name = null;
				value = null;

				if ( pos != 0 ) {
					name = String13.ToLower( String13.SubStr( t, 1, pos ) );
					value = String13.SubStr( t, pos + 1, 0 );
				} else {
					name = String13.ToLower( t );
				}

				if ( !Lang13.Bool( name ) ) {
					continue;
				}

				if ( type == "config" ) {
					
					switch ((string)( name )) {
						case "admin_legacy_system":
							GlobalVars.config.admin_legacy_system = true;
							break;
						case "ban_legacy_system":
							GlobalVars.config.ban_legacy_system = true;
							break;
						case "use_age_restriction_for_jobs":
							GlobalVars.config.use_age_restriction_for_jobs = true;
							break;
						case "lobby_countdown":
							GlobalVars.config.lobby_countdown = String13.ParseNumber( value );
							break;
						case "round_end_countdown":
							GlobalVars.config.round_end_countdown = String13.ParseNumber( value );
							break;
						case "log_ooc":
							GlobalVars.config.log_ooc = true;
							break;
						case "log_access":
							GlobalVars.config.log_access = true;
							break;
						case "log_say":
							GlobalVars.config.log_say = true;
							break;
						case "log_admin":
							GlobalVars.config.log_admin = true;
							break;
						case "log_prayer":
							GlobalVars.config.log_prayer = true;
							break;
						case "log_law":
							GlobalVars.config.log_law = true;
							break;
						case "log_game":
							GlobalVars.config.log_game = true;
							break;
						case "log_vote":
							GlobalVars.config.log_vote = true;
							break;
						case "log_whisper":
							GlobalVars.config.log_whisper = true;
							break;
						case "log_attack":
							GlobalVars.config.log_attack = true;
							break;
						case "log_emote":
							GlobalVars.config.log_emote = true;
							break;
						case "log_adminchat":
							GlobalVars.config.log_adminchat = true;
							break;
						case "log_pda":
							GlobalVars.config.log_pda = true;
							break;
						case "log_hrefs":
							GlobalVars.config.log_hrefs = true;
							break;
						case "allow_admin_ooccolor":
							GlobalVars.config.allow_admin_ooccolor = true;
							break;
						case "allow_vote_restart":
							GlobalVars.config.allow_vote_restart = true;
							break;
						case "allow_vote_mode":
							GlobalVars.config.allow_vote_mode = true;
							break;
						case "no_dead_vote":
							GlobalVars.config.vote_no_dead = true;
							break;
						case "default_no_vote":
							GlobalVars.config.vote_no_default = true;
							break;
						case "vote_delay":
							GlobalVars.config.vote_delay = String13.ParseNumber( value );
							break;
						case "vote_period":
							GlobalVars.config.vote_period = String13.ParseNumber( value );
							break;
						case "norespawn":
							GlobalVars.config.respawn = false;
							break;
						case "servername":
							GlobalVars.config.server_name = value;
							break;
						case "stationname":
							GlobalVars.config.station_name = value;
							break;
						case "serversuffix":
							GlobalVars.config.server_suffix = true;
							break;
						case "hostedby":
							GlobalVars.config.hostedby = value;
							break;
						case "server":
							GlobalVars.config.server = value;
							break;
						case "banappeals":
							GlobalVars.config.banappeals = value;
							break;
						case "wikiurl":
							GlobalVars.config.wikiurl = value;
							break;
						case "forumurl":
							GlobalVars.config.forumurl = value;
							break;
						case "rulesurl":
							GlobalVars.config.rulesurl = value;
							break;
						case "githuburl":
							GlobalVars.config.githuburl = value;
							break;
						case "guest_jobban":
							GlobalVars.config.guest_jobban = true;
							break;
						case "guest_ban":
							GlobalVars.guests_allowed = false;
							break;
						case "usewhitelist":
							GlobalVars.config.usewhitelist = true;
							break;
						case "allow_metadata":
							GlobalVars.config.allow_Metadata = true;
							break;
						case "kick_inactive":
							
							if ( Convert.ToDouble( value ) < 1 ) {
								value = 6000;
							}
							GlobalVars.config.kick_inactive = value;
							break;
						case "load_jobs_from_txt":
							this.load_jobs_from_txt = true;
							break;
						case "forbid_singulo_possession":
							this.forbid_singulo_possession = true;
							break;
						case "popup_admin_pm":
							GlobalVars.config.popup_admin_pm = true;
							break;
						case "allow_holidays":
							GlobalVars.config.allow_holidays = true;
							break;
						case "useircbot":
							this.useircbot = true;
							break;
						case "ticklag":
							ticklag = String13.ParseNumber( value );

							if ( ( ticklag ??0) > 0 ) {
								this.fps = 10 / ( ticklag ??0);
							}
							break;
						case "fps":
							this.fps = String13.ParseNumber( value );
							break;
						case "automute_on":
							this.automute_on = true;
							break;
						case "comms_key":
							GlobalVars.comms_key = value;

							if ( value != "default_pwd" && Lang13.Length( value ) > 6 ) {
								GlobalVars.comms_allowed = true;
							}
							break;
						case "see_own_notes":
							GlobalVars.config.see_own_notes = true;
							break;
						case "soft_popcap":
							GlobalVars.config.soft_popcap = String13.ParseNumber( value );
							break;
						case "hard_popcap":
							GlobalVars.config.hard_popcap = String13.ParseNumber( value );
							break;
						case "extreme_popcap":
							GlobalVars.config.extreme_popcap = String13.ParseNumber( value );
							break;
						case "soft_popcap_message":
							GlobalVars.config.soft_popcap_message = value;
							break;
						case "hard_popcap_message":
							GlobalVars.config.hard_popcap_message = value;
							break;
						case "extreme_popcap_message":
							GlobalVars.config.extreme_popcap_message = value;
							break;
						case "panic_bunker":
							GlobalVars.config.panic_bunker = true;
							break;
						case "notify_new_player_age":
							GlobalVars.config.notify_new_player_age = String13.ParseNumber( value );
							break;
						case "irc_first_connection_alert":
							GlobalVars.config.irc_first_connection_alert = true;
							break;
						case "aggressive_changelog":
							GlobalVars.config.aggressive_changelog = true;
							break;
						case "log_runtimes":
							newlog = new File( "data/logs/runtimes/runtime-" + String13.FormatTime( Game13.realtime, "YYYY-MM-DD" ) + ".log" );

							if ( Game13.log != newlog ) {
								Game13.log.WriteMsg( "Now logging runtimes to data/logs/runtimes/runtime-" + String13.FormatTime( Game13.realtime, "YYYY-MM-DD" ) + ".log" );
								Game13.log = newlog;
							}
							break;
						case "autoconvert_notes":
							GlobalVars.config.autoconvert_notes = true;
							break;
						case "allow_webclient":
							GlobalVars.config.allowwebclient = true;
							break;
						case "webclient_only_byond_members":
							GlobalVars.config.webclientmembersonly = true;
							break;
						case "announce_admin_logout":
							GlobalVars.config.announce_admin_logout = true;
							break;
						case "announce_admin_login":
							GlobalVars.config.announce_admin_login = true;
							break;
						case "maprotation":
							GlobalVars.config.maprotation = true;
							break;
						case "maprotationchancedelta":
							GlobalVars.config.maprotatechancedelta = String13.ParseNumber( value );
							break;
						case "autoadmin":
							GlobalVars.protected_config.autoadmin = true;

							if ( Lang13.Bool( value ) ) {
								GlobalVars.protected_config.autoadmin_rank = String13.CKeyPreserveCase( value );
							}
							break;
						default:
							GlobalVars.diary.WriteMsg( "Unknown setting in configuration: '" + name + "'" );
							break;
					}
				} else if ( type == "game_options" ) {
					
					switch ((string)( name )) {
						case "health_threshold_crit":
							GlobalVars.config.health_threshold_crit = String13.ParseNumber( value );
							break;
						case "health_threshold_dead":
							GlobalVars.config.health_threshold_dead = String13.ParseNumber( value );
							break;
						case "revival_pod_plants":
							GlobalVars.config.revival_pod_plants = String13.ParseNumber( value );
							break;
						case "revival_cloning":
							GlobalVars.config.revival_cloning = String13.ParseNumber( value );
							break;
						case "revival_brain_life":
							GlobalVars.config.revival_brain_life = String13.ParseNumber( value );
							break;
						case "rename_cyborg":
							GlobalVars.config.rename_cyborg = true;
							break;
						case "ooc_during_round":
							GlobalVars.config.ooc_during_round = true;
							break;
						case "emojis":
							GlobalVars.config.emojis = true;
							break;
						case "run_delay":
							GlobalVars.config.run_speed = String13.ParseNumber( value );
							break;
						case "walk_delay":
							GlobalVars.config.walk_speed = String13.ParseNumber( value );
							break;
						case "human_delay":
							GlobalVars.config.human_delay = String13.ParseNumber( value );
							break;
						case "robot_delay":
							GlobalVars.config.robot_delay = String13.ParseNumber( value );
							break;
						case "monkey_delay":
							GlobalVars.config.monkey_delay = String13.ParseNumber( value );
							break;
						case "alien_delay":
							GlobalVars.config.alien_delay = String13.ParseNumber( value );
							break;
						case "slime_delay":
							GlobalVars.config.slime_delay = String13.ParseNumber( value );
							break;
						case "animal_delay":
							GlobalVars.config.animal_delay = String13.ParseNumber( value );
							break;
						case "alert_red_upto":
							GlobalVars.config.alert_desc_red_upto = value;
							break;
						case "alert_red_downto":
							GlobalVars.config.alert_desc_red_downto = value;
							break;
						case "alert_blue_downto":
							GlobalVars.config.alert_desc_blue_downto = value;
							break;
						case "alert_blue_upto":
							GlobalVars.config.alert_desc_blue_upto = value;
							break;
						case "alert_green":
							GlobalVars.config.alert_desc_green = value;
							break;
						case "alert_delta":
							GlobalVars.config.alert_desc_delta = value;
							break;
						case "no_intercept_report":
							GlobalVars.config.intercept = false;
							break;
						case "assistants_have_maint_access":
							GlobalVars.config.jobs_have_maint_access |= 1;
							break;
						case "security_has_maint_access":
							GlobalVars.config.jobs_have_maint_access |= 2;
							break;
						case "everyone_has_maint_access":
							GlobalVars.config.jobs_have_maint_access |= 4;
							break;
						case "sec_start_brig":
							GlobalVars.config.sec_start_brig = true;
							break;
						case "gateway_delay":
							GlobalVars.config.gateway_delay = String13.ParseNumber( value );
							break;
						case "continuous":
							mode_name = String13.ToLower( value );

							if ( GlobalVars.config.modes.Contains( mode_name ) ) {
								GlobalVars.config.continuous[mode_name] = 1;
							} else {
								GlobalVars.diary.WriteMsg( "Unknown continuous configuration definition: " + mode_name + "." );
							}
							break;
						case "midround_antag":
							mode_name2 = String13.ToLower( value );

							if ( GlobalVars.config.modes.Contains( mode_name2 ) ) {
								GlobalVars.config.midround_antag[mode_name2] = 1;
							} else {
								GlobalVars.diary.WriteMsg( "Unknown midround antagonist configuration definition: " + mode_name2 + "." );
							}
							break;
						case "midround_antag_time_check":
							GlobalVars.config.midround_antag_time_check = String13.ParseNumber( value );
							break;
						case "midround_antag_life_check":
							GlobalVars.config.midround_antag_life_check = String13.ParseNumber( value );
							break;
						case "shuttle_refuel_delay":
							GlobalVars.config.shuttle_refuel_delay = String13.ParseNumber( value );
							break;
						case "show_game_type_odds":
							GlobalVars.config.show_game_type_odds = true;
							break;
						case "ghost_interaction":
							GlobalVars.config.ghost_interaction = true;
							break;
						case "traitor_scaling_coeff":
							GlobalVars.config.traitor_scaling_coeff = String13.ParseNumber( value );
							break;
						case "changeling_scaling_coeff":
							GlobalVars.config.changeling_scaling_coeff = String13.ParseNumber( value );
							break;
						case "security_scaling_coeff":
							GlobalVars.config.security_scaling_coeff = String13.ParseNumber( value );
							break;
						case "abductor_scaling_coeff":
							GlobalVars.config.abductor_scaling_coeff = String13.ParseNumber( value );
							break;
						case "traitor_objectives_amount":
							GlobalVars.config.traitor_objectives_amount = String13.ParseNumber( value );
							break;
						case "probability":
							prob_pos = String13.FindIgnoreCase( value, " ", 1, 0 );
							prob_name = null;
							prob_value = null;

							if ( prob_pos != 0 ) {
								prob_name = String13.ToLower( String13.SubStr( value, 1, prob_pos ) );
								prob_value = String13.SubStr( value, prob_pos + 1, 0 );

								if ( GlobalVars.config.modes.Contains( prob_name ) ) {
									GlobalVars.config.probabilities[prob_name] = String13.ParseNumber( prob_value );
								} else {
									GlobalVars.diary.WriteMsg( "Unknown game mode probability configuration definition: " + prob_name + "." );
								}
							} else {
								GlobalVars.diary.WriteMsg( "Incorrect probability configuration definition: " + prob_name + "  " + prob_value + "." );
							}
							break;
						case "protect_roles_from_antagonist":
							GlobalVars.config.protect_roles_from_antagonist = true;
							break;
						case "protect_assistant_from_antagonist":
							GlobalVars.config.protect_assistant_from_antagonist = true;
							break;
						case "enforce_human_authority":
							GlobalVars.config.enforce_human_authority = true;
							break;
						case "allow_latejoin_antagonists":
							GlobalVars.config.allow_latejoin_antagonists = true;
							break;
						case "allow_random_events":
							GlobalVars.config.allow_random_events = true;
							break;
						case "minimal_access_threshold":
							GlobalVars.config.minimal_access_threshold = String13.ParseNumber( value );
							break;
						case "jobs_have_minimal_access":
							GlobalVars.config.jobs_have_minimal_access = true;
							break;
						case "humans_need_surnames":
							this.humans_need_surnames = true;
							break;
						case "force_random_names":
							GlobalVars.config.force_random_names = true;
							break;
						case "allow_ai":
							GlobalVars.config.allow_ai = true;
							break;
						case "silent_ai":
							GlobalVars.config.silent_ai = true;
							break;
						case "silent_borg":
							GlobalVars.config.silent_borg = true;
							break;
						case "sandbox_autoclose":
							GlobalVars.config.sandbox_autoclose = true;
							break;
						case "default_laws":
							GlobalVars.config.default_laws = String13.ParseNumber( value );
							break;
						case "silicon_max_law_amount":
							GlobalVars.config.silicon_max_law_amount = String13.ParseNumber( value );
							break;
						case "join_with_mutant_race":
							GlobalVars.config.mutant_races = true;
							break;
						case "roundstart_races":
							
							if ( !this.cleared_default_races ) {
								GlobalVars.roundstart_species = new ByTable();
								this.cleared_default_races = true;
							}
							race_id = String13.ToLower( value );

							foreach (dynamic _b in Lang13.Enumerate( GlobalVars.species_list )) {
								species_id = _b;
								

								if ( species_id == race_id ) {
									GlobalVars.roundstart_species[species_id] = GlobalVars.species_list[species_id];
								}
							}
							break;
						case "join_with_mutant_humans":
							GlobalVars.config.mutant_humans = true;
							break;
						case "assistant_cap":
							GlobalVars.config.assistant_cap = String13.ParseNumber( value );
							break;
						case "starlight":
							GlobalVars.config.starlight = true;
							break;
						case "grey_assistants":
							GlobalVars.config.grey_assistants = true;
							break;
						case "no_summon_guns":
							GlobalVars.config.no_summon_guns = true;
							break;
						case "no_summon_magic":
							GlobalVars.config.no_summon_magic = true;
							break;
						case "no_summon_events":
							GlobalVars.config.no_summon_events = true;
							break;
						case "reactionary_explosions":
							GlobalVars.config.reactionary_explosions = true;
							break;
						case "bombcap":
							BombCap = String13.ParseNumber( value );

							if ( !Lang13.Bool( BombCap ) ) {
								continue;
							}

							if ( ( BombCap ??0) < 4 ) {
								BombCap = 4;
							}

							if ( ( BombCap ??0) > 128 ) {
								BombCap = 128;
							}
							GlobalVars.MAX_EX_DEVESTATION_RANGE = Num13.Floor( ( BombCap ??0) / 4 );
							GlobalVars.MAX_EX_HEAVY_RANGE = Num13.Floor( ( BombCap ??0) / 2 );
							GlobalVars.MAX_EX_LIGHT_RANGE = BombCap;
							GlobalVars.MAX_EX_FLASH_RANGE = BombCap;
							GlobalVars.MAX_EX_FLAME_RANGE = BombCap;
							break;
						default:
							GlobalVars.diary.WriteMsg( "Unknown setting in configuration: '" + name + "'" );
							break;
					}
				}
			}
			this.fps = Num13.Floor( Convert.ToDouble( this.fps ) );

			if ( Convert.ToDouble( this.fps ) <= 0 ) {
				this.fps = Lang13.Initial( this, "fps" );
			}
			return;
		}

	}

}