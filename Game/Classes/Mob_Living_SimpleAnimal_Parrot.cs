// FILE AUTOGENERATED BY SOM13. DO NOT EDIT YET.

using System;
using Somnium.Engine.ByImpl;

namespace Somnium.Game {
	class Mob_Living_SimpleAnimal_Parrot : Mob_Living_SimpleAnimal {

		public int parrot_damage_upper = 10;
		public dynamic parrot_state = 4;
		public int parrot_sleep_max = 25;
		public int parrot_sleep_dur = 25;
		public ByTable parrot_dam_zone = new ByTable(new object [] { "chest", "head", "l_arm", "l_leg", "r_arm", "r_leg" });
		public int parrot_speed = 5;
		public Ent_Static parrot_lastmove = null;
		public int parrot_stuck = 0;
		public int parrot_stuck_threshold = 10;
		public ByTable speech_buffer = new ByTable();
		public ByTable available_channels = new ByTable();
		public dynamic ears = null;
		public dynamic parrot_interest = null;
		public Ent_Dynamic parrot_perch = null;
		public ByTable desired_perches = new ByTable(new object [] { 
											typeof(Obj_Structure_Computerframe), 
											typeof(Obj_Structure_Displaycase), 
											typeof(Obj_Structure_Filingcabinet), 
											typeof(Obj_Machinery_Teleport), 
											typeof(Obj_Machinery_Computer), 
											typeof(Obj_Machinery_Clonepod), 
											typeof(Obj_Machinery_DnaScannernew), 
											typeof(Obj_Machinery_Telecomms), 
											typeof(Obj_Machinery_Nuclearbomb), 
											typeof(Obj_Machinery_ParticleAccelerator), 
											typeof(Obj_Machinery_RechargeStation), 
											typeof(Obj_Machinery_Smartfridge), 
											typeof(Obj_Machinery_SuitStorageUnit)
										 });
		public dynamic held_item = null;

		protected override void __FieldInit() {
			base.__FieldInit();

			this.icon_living = "parrot_fly";
			this.icon_dead = "parrot_dead";
			this.pass_flags = 17;
			this.speak = new ByTable(new object [] { "Hi!", "Hello!", "Cracker?", "BAWWWWK george mellons griffing me!" });
			this.speak_emote = new ByTable(new object [] { "squawks", "says", "yells" });
			this.emote_hear = new ByTable(new object [] { "squawks.", "bawks!" });
			this.emote_see = new ByTable(new object [] { "flutters its wings." });
			this.speak_chance = 1;
			this.turns_per_move = 5;
			this.butcher_results = new ByTable().Set( typeof(Obj_Item_Weapon_ReagentContainers_Food_Snacks_Cracker), 1 );
			this.melee_damage_upper = 10;
			this.melee_damage_lower = 5;
			this.response_help = "pets";
			this.response_disarm = "gently moves aside";
			this.response_harm = "swats";
			this.stop_automated_movement = true;
			this.a_intent = "harm";
			this.attacktext = "chomps";
			this.friendly = "grooms";
			this.mob_size = 1;
			this.flying = true;
			this.gold_core_spawnable = 2;
			this.icon_state = "parrot_fly";
		}

		// Function from file: parrot.dm
		public Mob_Living_SimpleAnimal_Parrot ( dynamic loc = null ) : base( (object)(loc) ) {
			dynamic headset = null;

			// Warning: Super call was HERE! If anything above HERE is needed by the super call, it might break!;

			if ( !Lang13.Bool( this.ears ) ) {
				headset = Rand13.Pick(new object [] { typeof(Obj_Item_Device_Radio_Headset_HeadsetSec), typeof(Obj_Item_Device_Radio_Headset_HeadsetEng), typeof(Obj_Item_Device_Radio_Headset_HeadsetMed), typeof(Obj_Item_Device_Radio_Headset_HeadsetSci), typeof(Obj_Item_Device_Radio_Headset_HeadsetCargo) });
				this.ears = Lang13.Call( headset, this );
			}
			this.parrot_sleep_dur = this.parrot_sleep_max;
			this.verbs.Add( typeof(Mob_Living_SimpleAnimal_Parrot).GetMethod( "steal_from_ground" ), typeof(Mob_Living_SimpleAnimal_Parrot).GetMethod( "steal_from_mob" ), typeof(Mob_Living_SimpleAnimal_Parrot).GetMethod( "drop_held_item_player" ), typeof(Mob_Living_SimpleAnimal_Parrot).GetMethod( "perch_player" ), typeof(Mob_Living_SimpleAnimal_Parrot).GetMethod( "toggle_mode" ), typeof(Mob_Living_SimpleAnimal_Parrot).GetMethod( "perch_mob_player" ) );
			return;
		}

		// Function from file: parrot.dm
		[VerbInfo( name: "Toggle mode", desc: "Time to bear those claws!", group: "Parrot" )]
		public void toggle_mode(  ) {
			
			if ( this.stat != 0 || !( this.client != null ) ) {
				return;
			}

			if ( Lang13.Bool( this.melee_damage_upper ) ) {
				this.melee_damage_upper = 0;
				this.a_intent = "help";
			} else {
				this.melee_damage_upper = this.parrot_damage_upper;
				this.a_intent = "harm";
			}
			this.WriteMsg( "You will now " + this.a_intent + " others..." );
			return;
		}

		// Function from file: parrot.dm
		public void perch_on_human( Mob_Living_Carbon_Human H = null ) {
			
			if ( !( H != null ) ) {
				return;
			}
			this.loc = GlobalFuncs.get_turf( H );
			H.buckle_mob( this, true );
			this.pixel_y = 9;
			this.pixel_x = Convert.ToInt32( Rand13.Pick(new object [] { -8, 8 }) );
			this.icon_state = "parrot_sit";
			this.parrot_state = 1;
			this.WriteMsg( "<span class='notice'>You sit on " + H + "'s shoulder.</span>" );
			return;
		}

		// Function from file: parrot.dm
		[VerbInfo( name: "Sit on Human's Shoulder", desc: "Sit on a nice comfy human being!", group: "Parrot" )]
		public void perch_mob_player(  ) {
			Mob_Living_Carbon_Human H = null;

			
			if ( this.stat != 0 || !( this.client != null ) ) {
				return;
			}

			if ( this.icon_state == "parrot_fly" ) {
				
				foreach (dynamic _a in Lang13.Enumerate( Map13.FetchInView( 1, this ), typeof(Mob_Living_Carbon_Human) )) {
					H = _a;
					

					if ( Lang13.Bool( H.buckled_mob ) ) {
						continue;
					}
					this.perch_on_human( H );
					return;
				}
				this.WriteMsg( "<span class='warning'>There is nobody nearby that you can sit on!</span>" );
			} else {
				this.icon_state = "parrot_fly";
				this.parrot_state = 4;

				if ( this.buckled != null ) {
					this.WriteMsg( "<span class='notice'>You are no longer sitting on " + this.buckled + "'s shoulder.</span>" );
					this.buckled.buckled_mob = null;
				}
				this.buckled = null;
				this.pixel_x = Convert.ToInt32( Lang13.Initial( this, "pixel_x" ) );
				this.pixel_y = Convert.ToInt32( Lang13.Initial( this, "pixel_y" ) );
			}
			return;
		}

		// Function from file: parrot.dm
		[VerbInfo( name: "Sit", desc: "Sit on a nice comfy perch.", group: "Parrot" )]
		public void perch_player(  ) {
			Ent_Dynamic AM = null;
			dynamic perch_path = null;

			
			if ( this.stat != 0 || !( this.client != null ) ) {
				return;
			}

			if ( this.icon_state == "parrot_fly" ) {
				
				foreach (dynamic _b in Lang13.Enumerate( Map13.FetchInView( 1, this ), typeof(Ent_Dynamic) )) {
					AM = _b;
					

					foreach (dynamic _a in Lang13.Enumerate( this.desired_perches )) {
						perch_path = _a;
						

						if ( Lang13.Bool( perch_path.IsInstanceOfType( AM ) ) ) {
							this.loc = AM.loc;
							this.icon_state = "parrot_sit";
							return;
						}
					}
				}
			}
			this.WriteMsg( "<span class='warning'>There is no perch nearby to sit on!</span>" );
			return;
		}

		// Function from file: parrot.dm
		[VerbInfo( name: "Drop held item", desc: "Drop the item you're holding.", group: "Parrot" )]
		public int drop_held_item( bool? drop_gently = null ) {
			drop_gently = drop_gently ?? true;

			dynamic G = null;

			
			if ( this.stat != 0 ) {
				return -1;
			}

			if ( !Lang13.Bool( this.held_item ) ) {
				
				if ( this == Task13.User ) {
					this.WriteMsg( "<span class='danger'>You have nothing to drop!</span>" );
				}
				return 0;
			}

			if ( this.held_item is Obj_Item_Weapon_ReagentContainers_Food_Snacks_Cracker && drop_gently == true ) {
				GlobalFuncs.qdel( this.held_item );
				this.held_item = null;

				if ( Convert.ToDouble( this.health ) < Convert.ToDouble( this.maxHealth ) ) {
					this.adjustBruteLoss( -10 );
				}
				this.emote( "me", 1, "" + this + " eagerly downs the cracker." );
				return 1;
			}

			if ( !( drop_gently == true ) ) {
				
				if ( this.held_item is Obj_Item_Weapon_Grenade ) {
					G = this.held_item;
					G.loc = this.loc;
					((Obj_Item_Weapon_Grenade)G).prime();
					this.WriteMsg( "You let go of " + this.held_item + "!" );
					this.held_item = null;
					return 1;
				}
			}
			this.WriteMsg( "You drop " + this.held_item + "." );
			this.held_item.loc = this.loc;
			this.held_item = null;
			return 1;
		}

		// Function from file: parrot.dm
		[VerbInfo( name: "Steal from mob", desc: "Steals an item right out of a person's hand!", group: "Parrot" )]
		public dynamic steal_from_mob(  ) {
			dynamic stolen_item = null;
			Mob_Living_Carbon C = null;

			
			if ( this.stat != 0 ) {
				return -1;
			}

			if ( Lang13.Bool( this.held_item ) ) {
				this.WriteMsg( "<span class='warning'>You are already holding " + this.held_item + "!</span>" );
				return 1;
			}
			stolen_item = null;

			foreach (dynamic _a in Lang13.Enumerate( Map13.FetchInView( this, 1 ), typeof(Mob_Living_Carbon) )) {
				C = _a;
				

				if ( Lang13.Bool( C.l_hand ) && Convert.ToDouble( C.l_hand.w_class ) <= 2 ) {
					stolen_item = C.l_hand;
				}

				if ( Lang13.Bool( C.r_hand ) && Convert.ToDouble( C.r_hand.w_class ) <= 2 ) {
					stolen_item = C.r_hand;
				}

				if ( Lang13.Bool( stolen_item ) ) {
					C.unEquip( stolen_item );
					this.held_item = stolen_item;
					stolen_item.loc = this;
					this.visible_message( "" + this + " grabs " + this.held_item + " out of " + C + "'s hand!", "<span class='notice'>You snag " + this.held_item + " out of " + C + "'s hand!</span>", "<span class='italics'>You hear the sounds of wings flapping furiously.</span>" );
					return this.held_item;
				}
			}
			this.WriteMsg( "<span class='warning'>There is nothing of interest to take!</spawn>" );
			return 0;
		}

		// Function from file: parrot.dm
		[VerbInfo( name: "Steal from ground", desc: "Grabs a nearby item.", group: "Parrot" )]
		public dynamic steal_from_ground(  ) {
			Obj_Item I = null;

			
			if ( this.stat != 0 ) {
				return -1;
			}

			if ( Lang13.Bool( this.held_item ) ) {
				this.WriteMsg( "<span class='warning'>You are already holding " + this.held_item + "!</span>" );
				return 1;
			}

			foreach (dynamic _a in Lang13.Enumerate( Map13.FetchInView( this, 1 ), typeof(Obj_Item) )) {
				I = _a;
				

				if ( I.loc != this && Convert.ToDouble( I.w_class ) <= 2 ) {
					
					if ( !( this.client != null ) && this.parrot_perch != null && I.loc == this.parrot_perch.loc ) {
						continue;
					}
					this.held_item = I;
					I.loc = this;
					this.visible_message( "" + this + " grabs " + this.held_item + "!", "<span class='notice'>You grab " + this.held_item + "!</span>", "<span class='italics'>You hear the sounds of wings flapping furiously.</span>" );
					return this.held_item;
				}
			}
			this.WriteMsg( "<span class='warning'>There is nothing of interest to take!</span>" );
			return 0;
		}

		// Function from file: parrot.dm
		public Ent_Dynamic search_for_perch_and_item(  ) {
			Ent_Dynamic AM = null;
			dynamic perch_path = null;
			Ent_Dynamic I = null;
			Ent_Dynamic C = null;

			
			foreach (dynamic _b in Lang13.Enumerate( Map13.FetchInView( null, this ), typeof(Ent_Dynamic) )) {
				AM = _b;
				

				foreach (dynamic _a in Lang13.Enumerate( this.desired_perches )) {
					perch_path = _a;
					

					if ( Lang13.Bool( perch_path.IsInstanceOfType( AM ) ) ) {
						return AM;
					}
				}

				if ( this.parrot_perch != null && AM.loc == this.parrot_perch.loc || AM.loc == this ) {
					continue;
				}

				if ( AM is Obj_Item ) {
					I = AM;

					if ( Convert.ToDouble( ((dynamic)I).w_class ) <= 2 ) {
						return I;
					}
				}

				if ( AM is Mob_Living_Carbon ) {
					C = AM;

					if ( Lang13.Bool( ((dynamic)C).l_hand ) && Convert.ToDouble( ((dynamic)C).l_hand.w_class ) <= 2 || Lang13.Bool( ((dynamic)C).r_hand ) && Convert.ToDouble( ((dynamic)C).r_hand.w_class ) <= 2 ) {
						return C;
					}
				}
			}
			return null;
		}

		// Function from file: parrot.dm
		public Obj search_for_perch(  ) {
			Obj O = null;
			dynamic path = null;

			
			foreach (dynamic _b in Lang13.Enumerate( Map13.FetchInView( null, this ), typeof(Obj) )) {
				O = _b;
				

				foreach (dynamic _a in Lang13.Enumerate( this.desired_perches )) {
					path = _a;
					

					if ( Lang13.Bool( path.IsInstanceOfType( O ) ) ) {
						return O;
					}
				}
			}
			return null;
		}

		// Function from file: parrot.dm
		public Ent_Dynamic search_for_item(  ) {
			Ent_Dynamic item = null;
			Ent_Dynamic AM = null;
			Ent_Dynamic I = null;
			Ent_Dynamic C = null;

			
			foreach (dynamic _a in Lang13.Enumerate( Map13.FetchInView( null, this ), typeof(Ent_Dynamic) )) {
				AM = _a;
				

				if ( this.parrot_perch != null && AM.loc == this.parrot_perch.loc || AM.loc == this ) {
					continue;
				}

				if ( AM is Obj_Item ) {
					I = AM;

					if ( Convert.ToDouble( ((dynamic)I).w_class ) < 2 ) {
						item = I;
					}
				} else if ( AM is Mob_Living_Carbon ) {
					C = AM;

					if ( Lang13.Bool( ((dynamic)C).l_hand ) && Convert.ToDouble( ((dynamic)C).l_hand.w_class ) <= 2 || Lang13.Bool( ((dynamic)C).r_hand ) && Convert.ToDouble( ((dynamic)C).r_hand.w_class ) <= 2 ) {
						item = C;
					}
				}

				if ( item != null ) {
					
					if ( !Lang13.Bool( GlobalFuncs.AStar( this.loc, GlobalFuncs.get_turf( item ), this, typeof(Tile).GetMethod( "Distance_cardinal" ) ) ) ) {
						item = null;
						continue;
					}
					return item;
				}
			}
			return null;
		}

		// Function from file: parrot.dm
		public bool isStuck(  ) {
			
			if ( this.parrot_lastmove != null ) {
				
				if ( this.parrot_lastmove == this.loc ) {
					
					if ( this.parrot_stuck_threshold >= ++this.parrot_stuck ) {
						this.parrot_state = 4;
						this.parrot_stuck = 0;
						this.parrot_lastmove = null;
						return true;
					}
				} else {
					this.parrot_lastmove = null;
				}
			} else {
				this.parrot_lastmove = this.loc;
			}
			return false;
		}

		// Function from file: parrot.dm
		public override dynamic movement_delay(  ) {
			
			if ( this.client != null && this.stat == 0 && this.parrot_state != "parrot_fly" ) {
				this.icon_state = "parrot_fly";
			}
			return base.movement_delay();
		}

		// Function from file: parrot.dm
		public override bool handle_automated_movement(  ) {
			ByTable newspeak = null;
			dynamic possible_phrase = null;
			bool useradio = false;
			dynamic possible_phrase2 = null;
			Ent_Dynamic AM = null;
			dynamic L = null;

			
			if ( !( this.loc is Tile ) || !this.canmove || this.buckled != null ) {
				return false;
			}

			if ( this.parrot_state == 1 ) {
				
				if ( this.parrot_perch != null && this.parrot_perch.loc != this.loc ) {
					
					if ( Map13.FetchInView( null, this ).Contains( this.parrot_perch ) ) {
						this.parrot_state = 34;
						this.icon_state = "parrot_fly";
						return false;
					} else {
						this.parrot_state = 4;
						this.icon_state = "parrot_fly";
						return false;
					}
				}

				if ( --this.parrot_sleep_dur != 0 ) {
					return false;
				} else {
					this.parrot_sleep_dur = this.parrot_sleep_max;

					if ( this.speak.len != 0 ) {
						newspeak = new ByTable();

						if ( this.available_channels.len != 0 && Lang13.Bool( this.ears ) ) {
							
							foreach (dynamic _a in Lang13.Enumerate( this.speak )) {
								possible_phrase = _a;
								
								useradio = false;

								if ( Rand13.PercentChance( 50 ) ) {
									useradio = true;
								}

								if ( GlobalVars.department_radio_keys.Contains( String13.SubStr( possible_phrase, 1, 3 ) ) ) {
									possible_phrase = "" + ( useradio ? Rand13.PickFromTable( this.available_channels ) : ((dynamic)( "" )) ) + String13.SubStr( possible_phrase, 3, 0 );
								} else {
									possible_phrase = "" + ( useradio ? Rand13.PickFromTable( this.available_channels ) : ((dynamic)( "" )) ) + possible_phrase;
								}
								newspeak.Add( possible_phrase );
							}
						} else {
							
							foreach (dynamic _b in Lang13.Enumerate( this.speak )) {
								possible_phrase2 = _b;
								

								if ( GlobalVars.department_radio_keys.Contains( String13.SubStr( possible_phrase2, 1, 3 ) ) ) {
									possible_phrase2 = "" + String13.SubStr( possible_phrase2, 3, Lang13.Length( possible_phrase2 ) + 1 );
								}
								newspeak.Add( possible_phrase2 );
							}
						}
						this.speak = newspeak;
					}
					this.parrot_interest = this.search_for_item();

					if ( Lang13.Bool( this.parrot_interest ) ) {
						this.emote( "me", 1, "looks in " + this.parrot_interest + "'s direction and takes flight." );
						this.parrot_state = 10;
						this.icon_state = "parrot_fly";
					}
					return false;
				}
			} else if ( this.parrot_state == 4 ) {
				Map13.Walk( this, 0, 0 );
				this.parrot_interest = null;

				if ( Rand13.PercentChance( 90 ) ) {
					Map13.Step( this, Convert.ToInt32( Rand13.PickFromTable( GlobalVars.cardinal ) ) );
					return false;
				}

				if ( !Lang13.Bool( this.held_item ) && !( this.parrot_perch != null ) ) {
					AM = this.search_for_perch_and_item();

					if ( AM != null ) {
						
						if ( AM is Obj_Item || AM is Mob_Living ) {
							this.parrot_interest = AM;
							this.emote( "me", 1, "turns and flies towards " + this.parrot_interest + "." );
							this.parrot_state = 10;
							return false;
						} else {
							this.parrot_perch = AM;
							this.parrot_state = 34;
							return false;
						}
					}
					return false;
				}

				if ( Map13.FetchInView( null, this ).Contains( Lang13.Bool( this.parrot_interest ) && Lang13.Bool( this.parrot_interest ) ) ) {
					this.parrot_state = 10;
					return false;
				}

				if ( Map13.FetchInView( null, this ).Contains( this.parrot_perch != null && this.parrot_perch != null ) ) {
					this.parrot_state = 34;
					return false;
				} else {
					this.parrot_perch = this.search_for_perch();

					if ( this.parrot_perch != null ) {
						this.parrot_state = 34;
						return false;
					}
				}
			} else if ( this.parrot_state == 10 ) {
				Map13.Walk( this, 0, 0 );

				if ( !Lang13.Bool( this.parrot_interest ) || Lang13.Bool( this.held_item ) ) {
					this.parrot_state = 34;
					return false;
				}

				if ( !Map13.FetchInView( null, this ).Contains( this.parrot_interest ) ) {
					this.parrot_state = 34;
					return false;
				}

				if ( this.Adjacent( this.parrot_interest ) ) {
					
					if ( this.parrot_interest is Mob_Living ) {
						this.steal_from_mob();
					} else if ( !( this.parrot_perch != null ) || this.parrot_interest.loc != this.parrot_perch.loc ) {
						this.held_item = this.parrot_interest;
						this.parrot_interest.loc = this;
						this.visible_message( "" + this + " grabs " + this.held_item + "!", "<span class='notice'>You grab " + this.held_item + "!</span>", "<span class='italics'>You hear the sounds of wings flapping furiously.</span>" );
					}
					this.parrot_interest = null;
					this.parrot_state = 34;
					return false;
				}
				Map13.WalkTowards( this, this.parrot_interest, 1, this.parrot_speed );

				if ( this.isStuck() ) {
					return false;
				}
				return false;
			} else if ( this.parrot_state == 34 ) {
				Map13.Walk( this, 0, 0 );

				if ( !( this.parrot_perch != null ) || !( this.parrot_perch.loc is Tile ) ) {
					this.parrot_perch = null;
					this.parrot_state = 4;
					return false;
				}

				if ( this.Adjacent( this.parrot_perch ) ) {
					this.loc = this.parrot_perch.loc;
					this.drop_held_item_player();
					this.parrot_state = 1;
					this.icon_state = "parrot_sit";
					return false;
				}
				Map13.WalkTowards( this, this.parrot_perch, 1, this.parrot_speed );

				if ( this.isStuck() ) {
					return false;
				}
				return false;
			} else if ( this.parrot_state == 66 ) {
				Map13.Walk( this, 0, 0 );

				if ( !Lang13.Bool( this.parrot_interest ) || !( this.parrot_interest is Mob_Living ) ) {
					this.parrot_state = 4;
				}
				Map13.WalkAway( this, this.parrot_interest, 1, this.parrot_speed );

				if ( this.isStuck() ) {
					return false;
				}
				return false;
			} else if ( this.parrot_state == 18 ) {
				
				if ( !Lang13.Bool( this.parrot_interest ) || !( this.parrot_interest is Mob_Living ) ) {
					this.parrot_interest = null;
					this.parrot_state = 4;
					return false;
				}
				L = this.parrot_interest;

				if ( this.melee_damage_upper == 0 ) {
					this.melee_damage_upper = this.parrot_damage_upper;
					this.a_intent = "harm";
				}

				if ( this.Adjacent( this.parrot_interest ) ) {
					
					if ( Lang13.Bool( L.stat ) ) {
						this.parrot_interest = null;

						if ( !Lang13.Bool( this.held_item ) ) {
							this.held_item = this.steal_from_ground();

							if ( !Lang13.Bool( this.held_item ) ) {
								this.held_item = this.steal_from_mob();
							}
						}

						if ( Map13.FetchInView( null, this ).Contains( this.parrot_perch ) ) {
							this.parrot_state = 34;
						} else {
							this.parrot_state = 4;
						}
						return false;
					}
					this.attacktext = Rand13.Pick(new object [] { "claws at", "chomps" });
					((Ent_Static)L).attack_animal( this );
				} else {
					Map13.WalkTowards( this, this.parrot_interest, 1, this.parrot_speed );

					if ( this.isStuck() ) {
						return false;
					}
				}
				return false;
			} else {
				Map13.Walk( this, 0, 0 );
				this.parrot_interest = null;
				this.parrot_perch = null;
				this.drop_held_item_player();
				this.parrot_state = 4;
				return false;
			}
			return false;
		}

		// Function from file: parrot.dm
		public override void handle_automated_speech(  ) {
			base.handle_automated_speech();

			if ( this.speech_buffer.len != 0 && Rand13.PercentChance( 10 ) ) {
				
				if ( this.speak.len != 0 ) {
					this.speak.Remove( Rand13.PickFromTable( this.speak ) );
				}
				this.speak.Add( Rand13.PickFromTable( this.speech_buffer ) );
				GlobalFuncs.clearlist( this.speech_buffer );
			}
			return;
		}

		// Function from file: parrot.dm
		public override bool Life(  ) {
			base.Life();

			if ( this.pulledby != null && this.stat == 0 ) {
				this.icon_state = "parrot_fly";

				if ( !( this.client != null ) ) {
					this.parrot_state = 4;
				}
				return false;
			}
			return false;
		}

		// Function from file: parrot.dm
		public override dynamic bullet_act( dynamic P = null, dynamic def_zone = null ) {
			base.bullet_act( (object)(P), (object)(def_zone) );

			if ( !( this.stat != 0 ) && !( this.client != null ) ) {
				
				if ( this.parrot_state == 1 ) {
					this.parrot_sleep_dur = this.parrot_sleep_max;
				}
				this.parrot_interest = null;
				this.parrot_state = 68;
				this.icon_state = "parrot_fly";
				this.drop_held_item( false );
			}
			return null;
		}

		// Function from file: parrot.dm
		public override dynamic attackby( dynamic A = null, dynamic user = null, string _params = null, bool? silent = null, bool? replace_spent = null ) {
			
			if ( !( this.stat != 0 ) && !( this.client != null ) && !( A is Obj_Item_Stack_Medical ) && !( A is Obj_Item_Weapon_ReagentContainers_Food_Snacks_Cracker ) ) {
				
				if ( Lang13.Bool( A.force ) ) {
					
					if ( this.parrot_state == 1 ) {
						this.parrot_sleep_dur = this.parrot_sleep_max;
					}
					this.parrot_interest = user;
					this.parrot_state = 2;

					if ( Convert.ToDouble( user.health ) < 50 ) {
						this.parrot_state |= 16;
					} else {
						this.parrot_state |= 64;
					}
					this.icon_state = "parrot_fly";
					this.drop_held_item( false );
				}
			} else if ( A is Obj_Item_Weapon_ReagentContainers_Food_Snacks_Cracker ) {
				GlobalFuncs.qdel( A );
				user.drop_item();

				if ( Convert.ToDouble( this.health ) < Convert.ToDouble( this.maxHealth ) ) {
					this.adjustBruteLoss( -10 );
				}
				user.WriteMsg( "<span class='notice'>" + this + " eagerly devours the cracker.</span>" );
			}
			base.attackby( (object)(A), (object)(user), _params, silent, replace_spent );
			return null;
		}

		// Function from file: parrot.dm
		public override bool attack_animal( Mob_Living user = null ) {
			base.attack_animal( user );

			if ( this.client != null ) {
				return false;
			}

			if ( this.parrot_state == 1 ) {
				this.parrot_sleep_dur = this.parrot_sleep_max;
			}

			if ( Convert.ToDouble( ((dynamic)user).melee_damage_upper ) > 0 && !( this.stat != 0 ) ) {
				this.parrot_interest = user;
				this.parrot_state = 18;
				this.icon_state = "parrot_fly";
			}
			return false;
		}

		// Function from file: parrot.dm
		public override bool attack_alien( dynamic user = null ) {
			this.attack_hand( user );
			return false;
		}

		// Function from file: parrot.dm
		public override dynamic attack_paw( dynamic a = null, dynamic b = null, dynamic c = null ) {
			this.attack_hand( a );
			return null;
		}

		// Function from file: parrot.dm
		public override dynamic attack_hand( dynamic a = null, bool? b = null, bool? c = null ) {
			base.attack_hand( (object)(a), b, c );

			if ( this.client != null ) {
				return null;
			}

			if ( !( this.stat != 0 ) && a.a_intent == "harm" ) {
				this.icon_state = "parrot_fly";

				if ( this.parrot_state == 1 ) {
					this.parrot_sleep_dur = this.parrot_sleep_max;
				}
				this.parrot_interest = a;
				this.parrot_state = 2;

				if ( Convert.ToDouble( a.health ) < 50 ) {
					this.parrot_state |= 16;
				} else {
					this.parrot_state |= 64;
					this.drop_held_item( false );
				}
			}
			return null;
		}

		// Function from file: parrot.dm
		public override dynamic Topic( string href = null, ByTable href_list = null, dynamic hsrc = null ) {
			dynamic remove_from = null;
			dynamic possible_phrase = null;
			dynamic add_to = null;
			dynamic item_to_add = null;
			dynamic headset_to_add = null;
			dynamic ch = null;

			
			if ( Task13.User.incapacitated() || !Task13.User.Adjacent( this.loc ) ) {
				return null;
			}

			if ( Task13.User is Mob_Living_Carbon_Human || Task13.User is Mob_Living_Carbon_Monkey || Task13.User is Mob_Living_Silicon_Robot || Task13.User is Mob_Living_Carbon_Alien_Humanoid ) {
				
				if ( Lang13.Bool( href_list["remove_inv"] ) ) {
					remove_from = href_list["remove_inv"];

					dynamic _b = remove_from; // Was a switch-case, sorry for the mess.
					if ( _b=="ears" ) {
						
						if ( Lang13.Bool( this.ears ) ) {
							
							if ( !( this.stat != 0 ) ) {
								
								if ( this.available_channels.len != 0 ) {
									this.say( "" + Rand13.PickFromTable( this.available_channels ) + " BAWWWWWK LEAVE THE HEADSET BAWKKKKK!" );
								} else {
									this.say( "BAWWWWWK LEAVE THE HEADSET BAWKKKKK!" );
								}
							}
							this.ears.loc = this.loc;
							this.ears = null;

							foreach (dynamic _a in Lang13.Enumerate( this.speak )) {
								possible_phrase = _a;
								

								if ( GlobalVars.department_radio_keys.Contains( String13.SubStr( possible_phrase, 1, 3 ) ) ) {
									possible_phrase = String13.SubStr( possible_phrase, 3, 0 );
								}
							}
						} else {
							Task13.User.WriteMsg( "<span class='warning'>There is nothing to remove from its " + remove_from + "!</span>" );
							return null;
						}
					}
				} else if ( Lang13.Bool( href_list["add_inv"] ) ) {
					add_to = href_list["add_inv"];

					if ( !Lang13.Bool( Task13.User.get_active_hand() ) ) {
						Task13.User.WriteMsg( "<span class='warning'>You have nothing in your hand to put on its " + add_to + "!</span>" );
						return null;
					}

					dynamic _e = add_to; // Was a switch-case, sorry for the mess.
					if ( _e=="ears" ) {
						
						if ( Lang13.Bool( this.ears ) ) {
							Task13.User.WriteMsg( "<span class='warning'>It's already wearing something!</span>" );
							return null;
						} else {
							item_to_add = Task13.User.get_active_hand();

							if ( !Lang13.Bool( item_to_add ) ) {
								return null;
							}

							if ( !( item_to_add is Obj_Item_Device_Radio_Headset ) ) {
								Task13.User.WriteMsg( "<span class='warning'>This object won't fit!</span>" );
								return null;
							}
							headset_to_add = item_to_add;
							Task13.User.drop_item();
							headset_to_add.loc = this;
							this.ears = headset_to_add;
							Task13.User.WriteMsg( "<span class='notice'>You fit the headset onto " + this + ".</span>" );
							GlobalFuncs.clearlist( this.available_channels );

							foreach (dynamic _d in Lang13.Enumerate( headset_to_add.channels )) {
								ch = _d;
								

								dynamic _c = ch; // Was a switch-case, sorry for the mess.
								if ( _c=="Engineering" ) {
									this.available_channels.Add( ":e" );
								} else if ( _c=="Command" ) {
									this.available_channels.Add( ":c" );
								} else if ( _c=="Security" ) {
									this.available_channels.Add( ":s" );
								} else if ( _c=="Science" ) {
									this.available_channels.Add( ":n" );
								} else if ( _c=="Medical" ) {
									this.available_channels.Add( ":m" );
								} else if ( _c=="Supply" ) {
									this.available_channels.Add( ":u" );
								} else if ( _c=="Service" ) {
									this.available_channels.Add( ":v" );
								}
							}

							if ( Lang13.Bool( headset_to_add.translate_binary ) ) {
								this.available_channels.Add( ":b" );
							}
						}
					}
				} else {
					base.Topic( href, href_list, (object)(hsrc) );
				}
			}
			return null;
		}

		// Function from file: parrot.dm
		public override void show_inv( Ent_Static user = null ) {
			string dat = null;

			((Mob)user).set_machine( this );
			dat = "<div align='center'><b>Inventory of " + this.name + "</b></div><p>";

			if ( Lang13.Bool( this.ears ) ) {
				dat += new Txt( "<br><b>Headset:</b> " ).item( this.ears ).str( " (<a href='?src=" ).Ref( this ).str( ";remove_inv=ears'>Remove</a>)" ).ToString();
			} else {
				dat += new Txt( "<br><b>Headset:</b> <a href='?src=" ).Ref( this ).str( ";add_inv=ears'>Nothing</a>" ).ToString();
			}
			Interface13.Browse( user, dat, "window=mob" + this.real_name + ";size=325x500" );
			GlobalFuncs.onclose( user, "mob" + this.real_name );
			return;
		}

		// Function from file: parrot.dm
		public override int radio( dynamic message = null, string message_mode = null, ByTable spans = null ) {
			int _default = 0;

			_default = base.radio( (object)(message), message_mode, spans );

			if ( _default != 0 ) {
				return _default;
			}

			switch ((string)( message_mode )) {
				case "headset":
					
					if ( Lang13.Bool( this.ears ) ) {
						((Obj_Item)this.ears).talk_into( this, message, null, spans );
					}
					return 3;
					break;
				case "department":
					
					if ( Lang13.Bool( this.ears ) ) {
						((Obj_Item)this.ears).talk_into( this, message, message_mode, spans );
					}
					return 3;
					break;
			}

			if ( GlobalVars.radiochannels.Contains( message_mode ) ) {
				
				if ( Lang13.Bool( this.ears ) ) {
					((Obj_Item)this.ears).talk_into( this, message, message_mode, spans );
					return 3;
				}
			}
			return 0;
		}

		// Function from file: parrot.dm
		public override string Hear( string message = null, dynamic speaker = null, int message_langs = 0, dynamic raw_message = null, dynamic radio_freq = null, ByTable spans = null ) {
			
			if ( speaker != this && Rand13.PercentChance( 20 ) ) {
				
				if ( this.speech_buffer.len >= 20 ) {
					this.speech_buffer.Remove( Rand13.PickFromTable( this.speech_buffer ) );
				}
				this.speech_buffer.Or( String13.HtmlDecode( raw_message ) );
			}
			base.Hear( message, (object)(speaker), message_langs, (object)(raw_message), (object)(radio_freq), spans );
			return null;
		}

		// Function from file: parrot.dm
		public override dynamic Stat(  ) {
			base.Stat();

			if ( Interface13.IsStatPanelActive( "Status" ) ) {
				Interface13.Stat( "Held Item", this.held_item );
				Interface13.Stat( "Mode", this.a_intent );
			}
			return null;
		}

		// Function from file: parrot.dm
		public override bool death( bool? gibbed = null, bool? toast = null ) {
			
			if ( Lang13.Bool( this.held_item ) ) {
				this.held_item.loc = this.loc;
				this.held_item = null;
			}
			Map13.Walk( this, 0, 0 );

			if ( this.buckled != null ) {
				this.buckled.buckled_mob = null;
			}
			this.buckled = null;
			this.pixel_x = Convert.ToInt32( Lang13.Initial( this, "pixel_x" ) );
			this.pixel_y = Convert.ToInt32( Lang13.Initial( this, "pixel_y" ) );
			base.death( gibbed, toast );
			return false;
		}

		// Function from file: parrot.dm
		[Verb]
		[VerbInfo( name: "Drop held item", desc: "Drop the item you're holding.", group: "Parrot" )]
		public void drop_held_item_player(  ) {
			
			if ( this.stat != 0 ) {
				return;
			}
			this.drop_held_item_player();
			return;
		}

	}

}