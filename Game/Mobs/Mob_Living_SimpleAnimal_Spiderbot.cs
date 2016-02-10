// FILE AUTOGENERATED BY SOMNIUM13.

using System;
using Somnium.Engine.ByImpl;

namespace Somnium.Game {
	class Mob_Living_SimpleAnimal_Spiderbot : Mob_Living_SimpleAnimal {

		public Obj_Item_Device_Radio_Borg v_radio = null;
		public dynamic connected_ai = null;
		public dynamic cell = null;
		public Obj_Machinery_Camera camera = null;
		public dynamic mmi = null;
		public ByTable v_req_access = new ByTable(new object [] { 29 });
		public dynamic held_item = null;
		public bool emagged = false;
		public bool syndie = false;

		protected override void __FieldInit() {
			base.__FieldInit();

			this.min_oxy = 0;
			this.max_tox = false;
			this.max_co2 = 0;
			this.minbodytemp = 0;
			this.maxbodytemp = 500;
			this.icon_living = "spiderbot-chassis";
			this.icon_dead = "spiderbot-smashed";
			this.wander = false;
			this.health = 10;
			this.maxHealth = 10;
			this.attacktext = "shocks";
			this.melee_damage_lower = 1;
			this.melee_damage_upper = 3;
			this.response_help = "pets";
			this.response_disarm = "shoos";
			this.response_harm = "stomps on";
			this.speed = -1;
			this.speak_emote = new ByTable(new object [] { "beeps", "clicks", "chirps" });
			this.canEnterVentWith = "/obj/item/device/radio/borg=0&/obj/machinery/camera=0&/obj/item/device/mmi=0";
			this.size = 2;
			this.meat_type = null;
			this.icon = "icons/mob/robots.dmi";
			this.icon_state = "spiderbot-chassis";
		}

		// Function from file: spiderbot.dm
		public Mob_Living_SimpleAnimal_Spiderbot ( dynamic loc = null ) : base( (object)(loc) ) {
			this.v_radio = new Obj_Item_Device_Radio_Borg( /* Pruned args, no ctor exists. */ );
			this.camera = new Obj_Machinery_Camera( this );
			this.camera.c_tag = "Spiderbot-" + this.real_name;
			this.camera.network = new ByTable(new object [] { "SS13" });
			// Warning: Super call was HERE! If anything above HERE is needed by the super call, it might break!;
			return;
		}

		// Function from file: spiderbot.dm
		public override dynamic examine( dynamic user = null, string size = null ) {
			base.examine( (object)(user), size );

			if ( Lang13.Bool( this.held_item ) ) {
				GlobalFuncs.to_chat( user, new Txt( "It is carrying " ).a( this.held_item ).item().str( " " ).icon( this.held_item ).str( "." ).ToString() );
			}
			return null;
		}

		// Function from file: spiderbot.dm
		public override void Die( bool? gore = null ) {
			GlobalVars.living_mob_list.Remove( this );
			GlobalVars.dead_mob_list.Add( this );

			if ( this.camera != null ) {
				this.camera.status = false;
			}

			if ( Lang13.Bool( this.held_item ) && !( this.held_item == null ) ) {
				this.held_item.loc = this.loc;
				this.held_item = null;
			}
			GlobalFuncs.robogibs( this.loc, this.viruses );
			GlobalFuncs.qdel( this );
			return;
		}

		// Function from file: spiderbot.dm
		public override dynamic Destroy( dynamic brokenup = null ) {
			this.eject_brain();
			base.Destroy( (object)(brokenup) );
			return null;
		}

		// Function from file: spiderbot.dm
		public override bool? update_icon( dynamic location = null, dynamic target = null ) {
			
			if ( Lang13.Bool( this.mmi ) ) {
				
				if ( this.mmi is Obj_Item_Device_Mmi ) {
					this.icon_state = "spiderbot-chassis-mmi";
					this.icon_living = "spiderbot-chassis-mmi";
				}

				if ( this.mmi is Obj_Item_Device_Mmi_Posibrain ) {
					this.icon_state = "spiderbot-chassis-posi";
					this.icon_living = "spiderbot-chassis-posi";
				}
			} else {
				this.icon_state = "spiderbot-chassis";
				this.icon_living = "spiderbot-chassis";
			}
			return null;
		}

		// Function from file: spiderbot.dm
		public void eject_brain(  ) {
			dynamic T = null;

			
			if ( Lang13.Bool( this.mmi ) ) {
				T = GlobalFuncs.get_turf( this.loc );

				if ( Lang13.Bool( T ) ) {
					this.mmi.loc = T;
				}

				if ( this.mind != null ) {
					this.mind.transfer_to( this.mmi.brainmob );
				}
				this.mmi = null;
				this.name = "Spider-bot";
				this.update_icon();
			}
			return;
		}

		// Function from file: spiderbot.dm
		public void explode(  ) {
			dynamic M = null;

			
			foreach (dynamic _a in Lang13.Enumerate( Map13.FetchViewers( null, this ) )) {
				M = _a;
				

				if ( Lang13.Bool( M.client ) && !Lang13.Bool( M.blinded ) ) {
					M.show_message( "<span class='warning'>" + this + " makes an odd warbling noise, fizzles, and explodes.</span>" );
				}
			}
			GlobalFuncs.explosion( GlobalFuncs.get_turf( this.loc ), -1, -1, 3, 5 );
			this.eject_brain();
			this.Die();
			return;
		}

		// Function from file: spiderbot.dm
		public void transfer_personality( dynamic M = null ) {
			this.mind = M.brainmob.mind;
			this.mind.key = M.brainmob.key;
			this.ckey = M.brainmob.ckey;
			this.name = "Spider-bot (" + M.brainmob.name + ")";
			return;
		}

		// Function from file: spiderbot.dm
		public override dynamic attackby( dynamic a = null, dynamic b = null, dynamic c = null ) {
			dynamic B = null;
			dynamic WT = null;
			dynamic W = null;
			dynamic id_card = null;
			dynamic pda = null;

			
			if ( a is Obj_Item_Device_Mmi || a is Obj_Item_Device_Mmi_Posibrain ) {
				B = a;

				if ( Lang13.Bool( this.mmi ) ) {
					GlobalFuncs.to_chat( b, "<span class='warning'>There's already a brain in " + this + "!</span>" );
					return null;
				}

				if ( !Lang13.Bool( B.brainmob ) ) {
					GlobalFuncs.to_chat( b, "<span class='warning'>Sticking an empty MMI into the frame would sort of defeat the purpose.</span>" );
					return null;
				}

				if ( !Lang13.Bool( B.brainmob.key ) ) {
					
					if ( !( GlobalFuncs.mind_can_reenter( B.brainmob.mind ) == true ) ) {
						GlobalFuncs.to_chat( b, "<span class='notice'>" + a + " is completely unresponsive; there's no point.</span>" );
						return null;
					}
				}

				if ( Convert.ToInt32( B.brainmob.stat ) == 2 ) {
					GlobalFuncs.to_chat( b, "<span class='warning'>" + a + " is dead. Sticking it into the frame would sort of defeat the purpose.</span>" );
					return null;
				}

				if ( Lang13.Bool( GlobalFuncs.jobban_isbanned( B.brainmob, "Cyborg" ) ) ) {
					GlobalFuncs.to_chat( b, "<span class='warning'>" + a + " does not seem to fit.</span>" );
					return null;
				}

				if ( !Lang13.Bool( b.drop_item( a, this ) ) ) {
					b.WriteMsg( new Txt( "<span class='warning'>You can't let go of " ).the( a ).item().str( ".</span>" ).ToString() );
				}
				GlobalFuncs.to_chat( b, "<span class='notice'>You install " + a + " in " + this + "!</span>" );
				this.mmi = a;
				this.transfer_personality( a );
				this.update_icon();
				return 1;
			}

			if ( a is Obj_Item_Weapon_Weldingtool ) {
				WT = a;

				if ( ((Obj_Item_Weapon_Weldingtool)WT).remove_fuel( 0 ) ) {
					
					if ( Convert.ToDouble( this.health ) < Convert.ToDouble( this.maxHealth ) ) {
						this.health += Rand13.Pick(new object [] { 1, 1, 1, 2, 2, 3 });

						if ( Convert.ToDouble( this.health ) > Convert.ToDouble( this.maxHealth ) ) {
							this.health = this.maxHealth;
						}
						this.add_fingerprint( b );

						foreach (dynamic _a in Lang13.Enumerate( Map13.FetchViewers( null, b ) )) {
							W = _a;
							
							W.show_message( "<span class='warning'>" + b + " has spot-welded some of the damage to " + this + "!</span>", 1 );
						}
					} else {
						GlobalFuncs.to_chat( b, "<span class='notice'>" + this + " is undamaged!</span>" );
					}
				} else {
					GlobalFuncs.to_chat( b, "Need more welding fuel!" );
					return null;
				}
			} else if ( a is Obj_Item_Weapon_Card_Id || a is Obj_Item_Device_Pda ) {
				
				if ( !Lang13.Bool( this.mmi ) ) {
					GlobalFuncs.to_chat( b, "<span class='warning'>There's no reason to swipe your ID - the spiderbot has no brain to remove.</span>" );
					return 0;
				}
				id_card = null;

				if ( a is Obj_Item_Weapon_Card_Id ) {
					id_card = a;
				} else {
					pda = a;
					id_card = pda.id;
				}
				Interface13.Stat( null, id_card.access.Contains( GlobalVars.access_robotics ) );

				if ( a is Obj_Item_Weapon_Card_Id ) {
					GlobalFuncs.to_chat( b, "<span class='notice'>You swipe your access card and pop the brain out of " + this + ".</span>" );
					this.eject_brain();

					if ( Lang13.Bool( this.held_item ) ) {
						this.held_item.loc = this.loc;
						this.held_item = null;
					}
					return 1;
				} else {
					GlobalFuncs.to_chat( b, "<span class='warning'>You swipe your card, with no effect.</span>" );
					return 0;
				}
			} else if ( a is Obj_Item_Weapon_Card_Emag ) {
				
				if ( this.emagged ) {
					GlobalFuncs.to_chat( b, "<span class='warning'>" + this + " is already overloaded - better run.</span>" );
					return 0;
				} else {
					this.emagged = true;
					GlobalFuncs.to_chat( b, "<span class='notice'>You short out the security protocols and overload " + this + "'s cell, priming it to explode in a short time.</span>" );
					Task13.Schedule( 100, (Task13.Closure)(() => {
						GlobalFuncs.to_chat( this, "<span class='warning'>Your cell seems to be outputting a lot of power...</span>" );
						return;
					}));
					Task13.Schedule( 200, (Task13.Closure)(() => {
						GlobalFuncs.to_chat( this, "<span class='warning'>Internal heat sensors are spiking! Something is badly wrong with your cell!</span>" );
						return;
					}));
					Task13.Schedule( 300, (Task13.Closure)(() => {
						this.explode();
						return;
					}));
				}
			} else {
				return base.attackby( (object)(a), (object)(b), (object)(c) );
			}
			return null;
		}

		// Function from file: ventcrawl.dm
		public override bool can_ventcrawl(  ) {
			return true;
		}

		// Function from file: spiderbot.dm
		[Verb]
		[VerbInfo( name: "Pick up", group: "Object" )]
		public override dynamic f_verb_pickup( Ent_Static I = null ) {
			return this.__CallVerb("Pick up item" );
		}

		// Function from file: spiderbot.dm
		[Verb]
		[VerbInfo( name: "Pick up item", desc: "Allows you to take a nearby small item.", group: "Spiderbot" )]
		public dynamic get_item(  ) {
			ByTable items = null;
			Obj_Item I = null;
			dynamic selection = null;
			Obj_Item I2 = null;

			
			if ( Lang13.Bool( this.stat ) ) {
				return -1;
			}

			if ( Lang13.Bool( this.held_item ) ) {
				GlobalFuncs.to_chat( this, new Txt( "<span class='warning'>You are already holding " ).the( this.held_item ).item().str( "</span>" ).ToString() );
				return 1;
			}
			items = new ByTable();

			foreach (dynamic _a in Lang13.Enumerate( Map13.FetchInView( this, 1 ), typeof(Obj_Item) )) {
				I = _a;
				

				if ( I.loc != this && Convert.ToDouble( I.w_class ) <= 2 ) {
					items.Add( I );
				}
			}
			selection = Interface13.Input( "Select an item.", "Pickup", null, null, items, InputType.Any );

			if ( Lang13.Bool( selection ) ) {
				
				foreach (dynamic _b in Lang13.Enumerate( Map13.FetchInView( this, 1 ), typeof(Obj_Item) )) {
					I2 = _b;
					

					if ( selection == I2 ) {
						this.held_item = selection;
						selection.loc = this;
						this.visible_message( new Txt( "<span class='notice'>" ).item( this ).str( " scoops up " ).the( this.held_item ).item().str( "!</span>" ).ToString(), new Txt( "<span class='notice'>You grab " ).the( this.held_item ).item().str( "!</span>" ).ToString(), "You hear a skittering noise and a clink." );
						return this.held_item;
					}
				}
				GlobalFuncs.to_chat( this, new Txt( "<span class='warning'>" ).The( selection ).item().str( " is too far away.</span>" ).ToString() );
				return 0;
			}
			GlobalFuncs.to_chat( this, "<span class='warning'>There is nothing of interest to take.</span>" );
			return 0;
		}

		// Function from file: spiderbot.dm
		[Verb]
		[VerbInfo( name: "Drop held item", desc: "Drop the item you're holding.", group: "Spiderbot" )]
		public bool drop_held_item(  ) {
			dynamic G = null;

			
			if ( Lang13.Bool( this.stat ) ) {
				return false;
			}

			if ( !Lang13.Bool( this.held_item ) ) {
				GlobalFuncs.to_chat( Task13.User, "<span class='warning'>You have nothing to drop!</span>" );
				return false;
			}

			if ( this.held_item is Obj_Item_Weapon_Grenade ) {
				this.visible_message( new Txt( "<span class='warning'>" ).item( this ).str( " launches " ).the( this.held_item ).item().str( "!</span>" ).ToString(), new Txt( "<span class='warning'>You launch " ).the( this.held_item ).item().str( "!</span>" ).ToString(), "You hear a skittering noise and a thump!" );
				G = this.held_item;
				G.loc = this.loc;
				((Obj_Item_Weapon_Grenade)G).prime();
				this.held_item = null;
				return true;
			}
			this.visible_message( new Txt( "<span class='notice'>" ).item( this ).str( " drops " ).the( this.held_item ).item().str( "!</span>" ).ToString(), new Txt( "<span class='notice'>You drop " ).the( this.held_item ).item().str( "!</span>" ).ToString(), "You hear a skittering noise and a soft thump." );
			this.held_item.loc = this.loc;
			this.held_item = null;
			return true;
		}

		// Function from file: spiderbot.dm
		[Verb]
		[VerbInfo( name: "Hide", desc: "Allows to hide beneath tables or certain items. Toggled on or off.", group: "Spiderbot" )]
		public void f_hide(  ) {
			
			if ( this.layer != 2.2 ) {
				this.layer = 2.2;
				GlobalFuncs.to_chat( this, "<span class='notice'>You are now hiding.</span>" );
			} else {
				this.layer = GlobalVars.MOB_LAYER;
				GlobalFuncs.to_chat( this, "<span class='notice'>You have stopped hiding.</span>" );
			}
			return;
		}

		// Function from file: spiderbot.dm
		[Verb]
		[VerbInfo( name: "Crawl through Vent", desc: "Enter an air vent and crawl through the pipe system.", group: "Spiderbot" )]
		public void ventcrawl(  ) {
			dynamic pipe = null;

			pipe = this.start_ventcrawl();

			if ( Lang13.Bool( pipe ) ) {
				this.handle_ventcrawl( pipe );
			}
			return;
		}

		// Function from file: suicide.dm
		[Verb]
		[VerbInfo( hidden: true )]
		public override void suicide(  ) {
			string confirm = null;

			
			if ( this.stat == 2 ) {
				GlobalFuncs.to_chat( this, "<span class='warning'>You're already dead!</span>" );
				return;
			}

			if ( this.suiciding == true ) {
				GlobalFuncs.to_chat( this, "<span class='warning'>You're already committing suicide! Be patient!</span>" );
				return;
			}
			confirm = Interface13.Alert( "Are you sure you want to commit suicide?", "Confirm Suicide", "Yes", "No" );

			if ( confirm == "Yes" ) {
				this.suiciding = true;
				this.visible_message( new Txt( "<span class='danger'>" ).item( this ).str( " suddenly topples over and starts thrashing around! It looks like " ).he_she_it_they().str( "'s trying to commit suicide.</span>" ).ToString() );
				this.Die();
			}
			return;
		}

	}

}