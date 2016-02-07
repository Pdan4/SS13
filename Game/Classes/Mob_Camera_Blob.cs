// FILE AUTOGENERATED BY SOM13. DO NOT EDIT YET.

using System;
using Somnium.Engine.ByImpl;

namespace Somnium.Game {
	class Mob_Camera_Blob : Mob_Camera {

		public Obj_Effect_Blob_Core blob_core = null;
		public double? blob_points = 0;
		public double max_blob_points = 100;
		public int last_attack = 0;
		public dynamic blob_reagent_datum = new Reagent_Blob();
		public ByTable blob_mobs = new ByTable();
		public Image ghostimage = null;

		protected override void __FieldInit() {
			base.__FieldInit();

			this.invisibility = 60;
			this.real_name = "Blob Overmind";
			this.pass_flags = 8;
			this.faction = new ByTable(new object [] { "blob" });
			this.icon = "icons/mob/blob.dmi";
			this.icon_state = "marker";
			this.see_in_dark = 8;
			this.see_invisible = 5;
		}

		// Function from file: overmind.dm
		public Mob_Camera_Blob ( dynamic loc = null ) : base( (object)(loc) ) {
			string new_name = null;
			ByTable possible_reagents = null;
			dynamic type = null;

			new_name = "" + Lang13.Initial( this, "name" ) + " (" + Rand13.Int( 1, 999 ) + ")";
			this.name = new_name;
			this.real_name = new_name;
			this.last_attack = Game13.time;
			possible_reagents = new ByTable();

			foreach (dynamic _a in Lang13.Enumerate( Lang13.GetTypes( typeof(Reagent_Blob) ) - typeof(Reagent_Blob) )) {
				type = _a;
				
				possible_reagents.Add( Lang13.Call( type ) );
			}
			this.blob_reagent_datum = Rand13.PickFromTable( possible_reagents );

			if ( this.blob_core != null ) {
				this.blob_core.update_icon();
			}
			this.ghostimage = new Image( this.icon, this, this.icon_state );
			GlobalVars.ghost_darkness_images.Or( this.ghostimage );
			GlobalFuncs.updateallghostimages();
			// Warning: Super call was HERE! If anything above HERE is needed by the super call, it might break!;
			return;
		}

		// Function from file: overmind.dm
		public override bool Move( dynamic NewLoc = null, int? Dir = null, int step_x = 0, int step_y = 0 ) {
			Dir = Dir ?? 0;

			dynamic B = null;

			B = Lang13.FindIn( typeof(Obj_Effect_Blob), Map13.FetchInRange( NewLoc, "3x3" ) );

			if ( Lang13.Bool( B ) ) {
				this.loc = NewLoc;
			} else {
				return false;
			}
			return false;
		}

		// Function from file: overmind.dm
		public override dynamic Stat(  ) {
			base.Stat();

			if ( Interface13.IsStatPanelActive( "Status" ) ) {
				
				if ( this.blob_core != null ) {
					Interface13.Stat( null, "Core Health: " + this.blob_core.health );
				}
				Interface13.Stat( null, "Power Stored: " + this.blob_points + "/" + this.max_blob_points );
			}
			return null;
		}

		// Function from file: overmind.dm
		public override bool blob_act( dynamic severity = null ) {
			return false;
		}

		// Function from file: overmind.dm
		public override void emote( string act = null, int? m_type = null, dynamic message = null ) {
			m_type = m_type ?? 1;

			return;
		}

		// Function from file: overmind.dm
		public override bool say( dynamic message = null, string bubble_type = null ) {
			
			if ( !Lang13.Bool( message ) ) {
				return false;
			}

			if ( this.client != null ) {
				
				if ( ( this.client.prefs.muted & 1 ) != 0 ) {
					this.WriteMsg( "You cannot send IC messages (muted)." );
					return false;
				}

				if ( this.client.handle_spam_prevention( message, 1 ) ) {
					return false;
				}
			}

			if ( this.stat != 0 ) {
				return false;
			}
			this.blob_talk( message );
			return false;
		}

		// Function from file: powers.dm
		public void rally_spores( dynamic T = null ) {
			ByTable surrounding_turfs = null;
			Mob_Living_SimpleAnimal_Hostile_Blob_Blobspore BS = null;

			this.WriteMsg( "You rally your spores." );
			surrounding_turfs = Map13.FetchInBlock( Map13.GetTile( Convert.ToInt32( T.x - 1 ), Convert.ToInt32( T.y - 1 ), Convert.ToInt32( T.z ) ), Map13.GetTile( Convert.ToInt32( T.x + 1 ), Convert.ToInt32( T.y + 1 ), Convert.ToInt32( T.z ) ) );

			if ( !( surrounding_turfs.len != 0 ) ) {
				return;
			}

			foreach (dynamic _a in Lang13.Enumerate( GlobalVars.living_mob_list, typeof(Mob_Living_SimpleAnimal_Hostile_Blob_Blobspore) )) {
				BS = _a;
				

				if ( BS.overmind == this && BS.loc is Tile && Map13.GetDistance( BS, T ) <= 35 ) {
					BS.LoseTarget();
					BS.Goto( Rand13.PickFromTable( surrounding_turfs ), BS.move_to_delay );
				}
			}
			return;
		}

		// Function from file: powers.dm
		public void expand_blob( dynamic T = null ) {
			dynamic B = null;
			dynamic OB = null;
			Mob_Living L = null;
			double mob_protection = 0;

			
			if ( !this.can_attack() ) {
				return;
			}
			B = Lang13.FindIn( typeof(Obj_Effect_Blob), T );

			if ( Lang13.Bool( B ) ) {
				this.WriteMsg( "<span class='warning'>There is a blob there!</span>" );
				return;
			}
			OB = Lang13.FindIn( typeof(Obj_Effect_Blob), GlobalFuncs.circlerange( T, 1 ) );

			if ( !Lang13.Bool( OB ) ) {
				this.WriteMsg( "<span class='warning'>There is no blob adjacent to the target tile!</span>" );
				return;
			}

			if ( !this.can_buy( 5 ) ) {
				return;
			}
			this.last_attack = Game13.time;
			((Obj_Effect_Blob)OB).expand( T, false, this );

			foreach (dynamic _a in Lang13.Enumerate( T, typeof(Mob_Living) )) {
				L = _a;
				

				if ( Lang13.Bool( L.faction.Contains( "blob" ) ) ) {
					continue;
				}
				mob_protection = L.get_permeability_protection();
				((Reagent)this.blob_reagent_datum).reaction_mob( L, GlobalVars.VAPOR, 25, true, mob_protection );
				this.blob_reagent_datum.send_message( L );
			}
			return;
		}

		// Function from file: powers.dm
		public void remove_blob( dynamic T = null ) {
			dynamic B = null;

			B = Lang13.FindIn( typeof(Obj_Effect_Blob), T );

			if ( !Lang13.Bool( B ) ) {
				this.WriteMsg( "<span class='warning'>There is no blob there!</span>" );
				return;
			}

			if ( ( B.point_return ??0) < 0 ) {
				this.WriteMsg( "<span class='warning'>Unable to remove this blob.</span>" );
				return;
			}

			if ( this.max_blob_points < ( B.point_return ??0) + ( this.blob_points ??0) ) {
				this.WriteMsg( "<span class='warning'>You have too many resources to remove this blob!</span>" );
				return;
			}

			if ( Lang13.Bool( B.point_return ) ) {
				this.add_points( B.point_return );
				this.WriteMsg( new Txt( "<span class='notice'>Gained " ).item( B.point_return ).str( " resources from removing " ).the( B ).item().str( ".</span>" ).ToString() );
			}
			GlobalFuncs.qdel( B );
			return;
		}

		// Function from file: powers.dm
		public void create_shield( dynamic T = null ) {
			this.createSpecial( 10, typeof(Obj_Effect_Blob_Shield), 0, T );
			return;
		}

		// Function from file: powers.dm
		public dynamic createSpecial( double? price = null, Type blobType = null, int nearEquals = 0, dynamic T = null ) {
			dynamic B = null;
			Obj_Effect_Blob L = null;
			dynamic N = null;

			
			if ( !Lang13.Bool( T ) ) {
				T = GlobalFuncs.get_turf( this );
			}
			B = Lang13.FindIn( typeof(Obj_Effect_Blob), T );

			if ( !Lang13.Bool( B ) ) {
				this.WriteMsg( "<span class='warning'>There is no blob here!</span>" );
				return null;
			}

			if ( !( B is Obj_Effect_Blob_Normal ) ) {
				this.WriteMsg( "<span class='warning'>Unable to use this blob, find a normal one.</span>" );
				return null;
			}

			if ( nearEquals != 0 ) {
				
				foreach (dynamic _a in Lang13.Enumerate( Map13.FetchInRangeExcludeThis( T, nearEquals ), typeof(Obj_Effect_Blob) )) {
					L = _a;
					

					if ( L.type == blobType ) {
						this.WriteMsg( "<span class='warning'>There is a similar blob nearby, move more than " + nearEquals + " tiles away from it!</span>" );
						return null;
					}
				}
			}

			if ( !this.can_buy( price ) ) {
				return null;
			}
			N = ((Obj_Effect_Blob)B).change_to( blobType, this );
			return N;
		}

		// Function from file: powers.dm
		public bool can_buy( double? cost = null ) {
			cost = cost ?? 15;

			
			if ( ( this.blob_points ??0) < ( cost ??0) ) {
				this.WriteMsg( "<span class='warning'>You cannot afford this!</span>" );
				return false;
			}
			this.add_points( -( cost ??0) );
			return true;
		}

		// Function from file: overmind.dm
		public bool can_attack(  ) {
			return Game13.time > this.last_attack + 4;
		}

		// Function from file: overmind.dm
		public void blob_talk( dynamic message = null ) {
			string message_a = null;
			string rendered = null;
			dynamic M = null;

			GlobalFuncs.log_say( "" + GlobalFuncs.key_name( this ) + " : " + message );
			message = GlobalFuncs.trim( String13.SubStr( GlobalFuncs.sanitize( message ), 1, 1024 ) );

			if ( !Lang13.Bool( message ) ) {
				return;
			}
			message_a = this.say_quote( message, this.get_spans() );
			rendered = "<span class='big'><font color=\"#EE4000\"><b>[Blob Telepathy] " + this.name + "(<font color=\"" + this.blob_reagent_datum.color + "\">" + this.blob_reagent_datum.name + "</font>)</b> " + message_a + "</font></span>";

			foreach (dynamic _a in Lang13.Enumerate( GlobalVars.mob_list )) {
				M = _a;
				

				if ( M is Mob_Camera_Blob || M is Mob_Living_SimpleAnimal_Hostile_Blob ) {
					M.WriteMsg( rendered );
				}

				if ( M is Mob_Dead_Observer ) {
					M.WriteMsg( new Txt( "<a href='?src=" ).Ref( M ).str( ";follow=" ).Ref( this ).str( "'>(F)</a> " ).item( rendered ).ToString() );
				}
			}
			return;
		}

		// Function from file: overmind.dm
		public void add_points( dynamic points = null ) {
			
			if ( points != 0 ) {
				this.blob_points = Num13.MaxInt( 0, Num13.MinInt( ((int)( ( this.blob_points ??0) + Convert.ToDouble( points ) )), ((int)( this.max_blob_points )) ) );
				this.hud_used.blobpwrdisplay.maptext = "<div align='center' valign='middle' style='position:relative; top:0px; left:6px'><font color='#82ed00'>" + Num13.Floor( this.blob_points ??0 ) + "</font></div>";
			}
			return;
		}

		// Function from file: overmind.dm
		public void update_health(  ) {
			
			if ( this.blob_core != null ) {
				this.hud_used.blobhealthdisplay.maptext = "<div align='center' valign='middle' style='position:relative; top:0px; left:6px'><font color='#e36600'>" + Num13.Floor( this.blob_core.health ) + "</font></div>";
			}
			return;
		}

		// Function from file: overmind.dm
		public override dynamic Login(  ) {
			base.Login();
			this.sync_mind();
			this.WriteMsg( "<span class='notice'>You are the overmind!</span>" );
			this.blob_help();
			this.update_health();
			return null;
		}

		// Function from file: overmind.dm
		public override dynamic Destroy(  ) {
			
			if ( this.ghostimage != null ) {
				GlobalVars.ghost_darkness_images.Remove( this.ghostimage );
				GlobalFuncs.qdel( this.ghostimage );
				this.ghostimage = null;
				GlobalFuncs.updateallghostimages();
			}
			return base.Destroy();
		}

		// Function from file: overmind.dm
		public override bool Life(  ) {
			
			if ( !( this.blob_core != null ) ) {
				GlobalFuncs.qdel( this );
			}
			base.Life();
			return false;
		}

		// Function from file: mind.dm
		public override void mind_initialize(  ) {
			base.mind_initialize();
			this.mind.special_role = "Blob";
			return;
		}

		// Function from file: overmind.dm
		public override void AltClickOn( dynamic A = null ) {
			dynamic T = null;

			T = GlobalFuncs.get_turf( A );

			if ( Lang13.Bool( T ) ) {
				this.remove_blob( T );
			}
			return;
		}

		// Function from file: overmind.dm
		public override void CtrlClickOn( dynamic A = null ) {
			dynamic T = null;

			T = GlobalFuncs.get_turf( A );

			if ( Lang13.Bool( T ) ) {
				this.create_shield( T );
			}
			return;
		}

		// Function from file: overmind.dm
		public override void MiddleClickOn( dynamic A = null ) {
			dynamic T = null;

			T = GlobalFuncs.get_turf( A );

			if ( Lang13.Bool( T ) ) {
				this.rally_spores( T );
			}
			return;
		}

		// Function from file: overmind.dm
		public override void ClickOn( dynamic A = null, string _params = null ) {
			ByTable modifiers = null;
			dynamic T = null;

			modifiers = String13.ParseUrlParams( _params );

			if ( Lang13.Bool( modifiers["middle"] ) ) {
				this.MiddleClickOn( A );
				return;
			}

			if ( Lang13.Bool( modifiers["shift"] ) ) {
				this.ShiftClickOn( A );
				return;
			}

			if ( Lang13.Bool( modifiers["alt"] ) ) {
				this.AltClickOn( A );
				return;
			}

			if ( Lang13.Bool( modifiers["ctrl"] ) ) {
				this.CtrlClickOn( A );
				return;
			}
			T = GlobalFuncs.get_turf( A );

			if ( Lang13.Bool( T ) ) {
				this.expand_blob( T );
			}
			return;
		}

		// Function from file: powers.dm
		[Verb]
		[VerbInfo( name: "*Blob Help*", desc: "Help on how to blob.", group: "Blob" )]
		public void blob_help(  ) {
			this.WriteMsg( "<b>As the overmind, you can control the blob!</b>" );
			this.WriteMsg( "Your blob reagent is: <b><font color=\"" + this.blob_reagent_datum.color + "\">" + this.blob_reagent_datum.name + "</b></font>!" );
			this.WriteMsg( "The <b><font color=\"" + this.blob_reagent_datum.color + "\">" + this.blob_reagent_datum.name + "</b></font> reagent " + this.blob_reagent_datum.description );
			this.WriteMsg( "<b>You can expand, which will attack people, damage objects, or place a Normal Blob if the tile is clear.</b>" );
			this.WriteMsg( "<i>Normal Blobs</i> will expand your reach and can be upgraded into special blobs that perform certain functions." );
			this.WriteMsg( "<b>You can upgrade normal blobs into the following types of blob:</b>" );
			this.WriteMsg( "<i>Shield Blobs</i> are strong and expensive blobs which take more damage. In additon, they are fireproof and can block air, use these to protect yourself from station fires." );
			this.WriteMsg( "<i>Resource Blobs</i> are blobs which produce more resources for you, build as many of these as possible to consume the station. This type of blob must be placed near node blobs or your core to work." );
			this.WriteMsg( "<i>Factory Blobs</i> are blobs that spawn blob spores which will attack nearby enemies. This type of blob must be placed near node blobs or your core to work." );
			this.WriteMsg( "<i>Blobbernauts</i> can be produced from factories for a cost, and are hard to kill, powerful, and moderately smart. The factory used to create one will become briefly fragile and unable to produce spores." );
			this.WriteMsg( "<i>Node Blobs</i> are blobs which grow, like the core. Like the core it can activate resource and factory blobs." );
			this.WriteMsg( "<b>In addition to the buttons on your HUD, there are a few click shortcuts to speed up expansion and defense.</b>" );
			this.WriteMsg( "<b>Shortcuts:</b> Click = Expand Blob <b>|</b> Middle Mouse Click = Rally Spores <b>|</b> Ctrl Click = Create Shield Blob <b>|</b> Alt Click = Remove Blob" );
			this.WriteMsg( "Attempting to talk will send a message to all other overminds, allowing you to coordinate with them." );
			return;
		}

		// Function from file: powers.dm
		[Verb]
		[VerbInfo( name: "Reactive Chemical Adaptation (40)", desc: "Replaces your chemical with a random, different one.", group: "Blob" )]
		public void chemical_reroll(  ) {
			dynamic B = null;
			Obj_Effect_Blob BL = null;
			Mob_Living_SimpleAnimal_Hostile_Blob BLO = null;

			
			if ( !this.can_buy( 40 ) ) {
				return;
			}
			B = Rand13.PickFromTable( Lang13.GetTypes( typeof(Reagent_Blob) ) - typeof(Reagent_Blob) - this.blob_reagent_datum.type );
			this.blob_reagent_datum = Lang13.Call( B );

			foreach (dynamic _a in Lang13.Enumerate( GlobalVars.blobs, typeof(Obj_Effect_Blob) )) {
				BL = _a;
				
				BL.update_icon();
			}

			foreach (dynamic _b in Lang13.Enumerate( typeof(Game13), typeof(Mob_Living_SimpleAnimal_Hostile_Blob) )) {
				BLO = _b;
				
				BLO.update_icons();
			}
			this.WriteMsg( "Your reagent is now: <b><font color=\"" + this.blob_reagent_datum.color + "\">" + this.blob_reagent_datum.name + "</b></font>!" );
			this.WriteMsg( "The <b><font color=\"" + this.blob_reagent_datum.color + "\">" + this.blob_reagent_datum.name + "</b></font> reagent " + this.blob_reagent_datum.description );
			return;
		}

		// Function from file: powers.dm
		[Verb]
		[VerbInfo( name: "Blob Broadcast", desc: "Speak with your blob spores and blobbernauts as your mouthpieces.", group: "Blob" )]
		public void blob_broadcast(  ) {
			dynamic speak_text = null;
			Mob_Living_SimpleAnimal_Hostile_Blob blob_minion = null;

			speak_text = Interface13.Input( this, "What would you like to say with your minions?", "Blob Broadcast", null, null, InputType.Str );

			if ( !Lang13.Bool( speak_text ) ) {
				return;
			} else {
				this.WriteMsg( "You broadcast with your minions, <B>" + speak_text + "</B>" );
			}

			foreach (dynamic _a in Lang13.Enumerate( this.blob_mobs, typeof(Mob_Living_SimpleAnimal_Hostile_Blob) )) {
				blob_minion = _a;
				

				if ( blob_minion.overmind == this && blob_minion.stat == 0 ) {
					blob_minion.say( speak_text );
				}
			}
			return;
		}

		// Function from file: powers.dm
		[Verb]
		[VerbInfo( name: "Rally Spores", desc: "Rally your spores to move to a target location.", group: "Blob" )]
		public void rally_spores_power(  ) {
			dynamic T = null;

			T = GlobalFuncs.get_turf( this );
			this.rally_spores( T );
			return;
		}

		// Function from file: powers.dm
		[Verb]
		[VerbInfo( name: "Expand/Attack Blob (5)", desc: "Attempts to create a new blob in this tile. If the tile isn't clear, instead attacks it, damaging mobs and objects.", group: "Blob" )]
		public void expand_blob_power(  ) {
			dynamic T = null;

			T = GlobalFuncs.get_turf( this );
			this.expand_blob( T );
			return;
		}

		// Function from file: powers.dm
		[Verb]
		[VerbInfo( name: "Remove Blob", desc: "Removes a blob, giving you back some resources.", group: "Blob" )]
		public void revert(  ) {
			dynamic T = null;

			T = GlobalFuncs.get_turf( this );
			this.remove_blob( T );
			return;
		}

		// Function from file: powers.dm
		[Verb]
		[VerbInfo( name: "Relocate Core (80)", desc: "Swaps the locations of your core and the selected node.", group: "Blob" )]
		public void relocate_core(  ) {
			dynamic T = null;
			dynamic B = null;
			Ent_Static old_turf = null;

			T = GlobalFuncs.get_turf( this );
			B = Lang13.FindIn( typeof(Obj_Effect_Blob_Node), T );

			if ( !Lang13.Bool( B ) ) {
				this.WriteMsg( "<span class='warning'>You must be on a blob node!</span>" );
				return;
			}

			if ( !this.can_buy( 80 ) ) {
				return;
			}
			old_turf = this.blob_core.loc;
			this.blob_core.loc = T;
			B.loc = old_turf;
			return;
		}

		// Function from file: powers.dm
		[Verb]
		[VerbInfo( name: "Create Blobbernaut (20)", desc: "Create a powerful blobbernaut which is mildly smart and will attack enemies.", group: "Blob" )]
		public void create_blobbernaut(  ) {
			dynamic T = null;
			dynamic B = null;
			Mob_Living_SimpleAnimal_Hostile_Blob_Blobbernaut blobber = null;
			ByTable candidates = null;
			dynamic C = null;

			T = GlobalFuncs.get_turf( this );
			B = Lang13.FindIn( typeof(Obj_Effect_Blob_Factory), T );

			if ( !Lang13.Bool( B ) ) {
				this.WriteMsg( "<span class='warning'>You must be on a factory blob!</span>" );
				return;
			}

			if ( Convert.ToDouble( B.health ) < Convert.ToDouble( B.maxhealth * 0.6 ) ) {
				this.WriteMsg( "<span class='warning'>This factory blob is too damaged to produce a blobbernaut.</span>" );
				return;
			}

			if ( !this.can_buy( 20 ) ) {
				return;
			}
			blobber = new Mob_Living_SimpleAnimal_Hostile_Blob_Blobbernaut( GlobalFuncs.get_turf( B ) );
			((Obj_Effect_Blob)B).take_damage( B.maxhealth * 0.6, "clone", null, false );
			((Ent_Static)B).visible_message( "<span class='warning'><b>The blobbernaut " + Rand13.Pick(new object [] { "rips", "tears", "shreds" }) + " its way out of the factory blob!</b></span>" );
			B.spore_delay = Game13.time + 600;
			blobber.overmind = this;
			blobber.update_icons();
			blobber.AIStatus = 3;
			this.blob_mobs.Add( blobber );
			candidates = GlobalFuncs.pollCandidates( "Do you want to play as a " + this.blob_reagent_datum.name + " blobbernaut?", "blob", null, "blob", 50 );
			C = null;

			if ( candidates.len != 0 ) {
				C = Rand13.PickFromTable( candidates );
				blobber.key = C.key;
				blobber.WriteMsg( "sound/effects/blobattack.ogg" );
				blobber.WriteMsg( "sound/effects/attackblob.ogg" );
				blobber.WriteMsg( "<b>You are a blobbernaut!</b>" );
				blobber.WriteMsg( "Your overmind's blob reagent is: <b><font color=\"" + this.blob_reagent_datum.color + "\">" + this.blob_reagent_datum.name + "</b></font>!" );
				blobber.WriteMsg( "The <b><font color=\"" + this.blob_reagent_datum.color + "\">" + this.blob_reagent_datum.name + "</b></font> reagent " + ( Lang13.Bool( this.blob_reagent_datum.shortdesc ) ? "" + this.blob_reagent_datum.shortdesc : "" + this.blob_reagent_datum.description ) );
			} else {
				blobber.AIStatus = 1;
			}
			return;
		}

		// Function from file: powers.dm
		[Verb]
		[VerbInfo( name: "Create Factory Blob (60)", desc: "Create a spore tower that will spawn spores to harass your enemies.", group: "Blob" )]
		public void create_factory(  ) {
			this.createSpecial( 60, typeof(Obj_Effect_Blob_Factory), 7 );
			return;
		}

		// Function from file: powers.dm
		[Verb]
		[VerbInfo( name: "Create Node Blob (60)", desc: "Create a node, which will power nearby factory and resource blobs.", group: "Blob" )]
		public void create_node(  ) {
			this.createSpecial( 60, typeof(Obj_Effect_Blob_Node), 5 );
			return;
		}

		// Function from file: powers.dm
		[Verb]
		[VerbInfo( name: "Create Resource Blob (40)", desc: "Create a resource tower which will generate resources for you.", group: "Blob" )]
		public void create_resource(  ) {
			this.createSpecial( 40, typeof(Obj_Effect_Blob_Resource), 4 );
			return;
		}

		// Function from file: powers.dm
		[Verb]
		[VerbInfo( name: "Create Shield Blob (10)", desc: "Create a shield blob, which will block fire and is hard to kill.", group: "Blob" )]
		public void create_shield_power(  ) {
			this.create_shield();
			return;
		}

		// Function from file: powers.dm
		[Verb]
		[VerbInfo( name: "Jump to Node", desc: "Move your camera to a selected node.", group: "Blob" )]
		public void jump_to_node(  ) {
			ByTable nodes = null;
			int? i = null;
			dynamic node_name = null;
			Ent_Static chosen_node = null;

			
			if ( GlobalVars.blob_nodes.len != 0 ) {
				nodes = new ByTable();
				i = null;
				i = 1;

				while (( i ??0) <= GlobalVars.blob_nodes.len) {
					nodes["Blob Node #" + i] = GlobalVars.blob_nodes[i];
					i++;
				}
				node_name = Interface13.Input( this, "Choose a node to jump to.", "Node Jump", null, nodes, InputType.Any );
				chosen_node = nodes[node_name];

				if ( chosen_node != null ) {
					this.loc = chosen_node.loc;
				}
			}
			return;
		}

		// Function from file: powers.dm
		[Verb]
		[VerbInfo( name: "Jump to Core", desc: "Move your camera to your core.", group: "Blob" )]
		public void transport_core(  ) {
			
			if ( this.blob_core != null ) {
				this.loc = this.blob_core.loc;
			}
			return;
		}

	}

}