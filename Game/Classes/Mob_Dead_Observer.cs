// FILE AUTOGENERATED BY SOM13. DO NOT EDIT YET.

using System;
using Somnium.Engine.ByImpl;

namespace Somnium.Game {
	class Mob_Dead_Observer : Mob_Dead {

		public bool? can_reenter_corpse = null;
		public dynamic hud = null;
		public int bootime = 0;
		public bool started_as_observer = false;
		public dynamic following = null;
		public bool fun_verbs = false;
		public Image ghostimage = null;
		public bool ghostvision = true;
		public bool seedarkness = true;
		public bool ghost_hud_enabled = true;
		public int data_hud_seen = 0;
		public dynamic ghost_orbit = "circle";

		protected override void __FieldInit() {
			base.__FieldInit();

			this.invisibility = 60;
			this.stat = 2;
			this.canmove = false;
			this.anchored = 1;
			this.languages = 65535;
			this.icon = "icons/mob/mob.dmi";
			this.icon_state = "ghost";
			this.layer = 5;
		}

		// Function from file: observer.dm
		public Mob_Dead_Observer ( dynamic body = null ) : base( (object)(body) ) {
			dynamic T = null;

			this.sight |= 60;
			this.see_invisible = 60;
			this.see_in_dark = 100;
			this.verbs.Add( typeof(Mob_Dead_Observer).GetMethod( "dead_tele" ) );
			this.stat = 2;
			this.ghostimage = new Image( this.icon, this, this.icon_state );
			GlobalVars.ghost_darkness_images.Or( this.ghostimage );
			GlobalFuncs.updateallghostimages();

			if ( body is Mob ) {
				T = GlobalFuncs.get_turf( body );
				this.attack_log = body.attack_log;
				this.gender = body.gender;

				if ( Lang13.Bool( body.mind ) && Lang13.Bool( body.mind.name ) ) {
					this.name = body.mind.name;
				} else if ( Lang13.Bool( body.real_name ) ) {
					this.name = body.real_name;
				} else {
					this.name = GlobalFuncs.random_unique_name( this.gender );
				}
				this.mind = body.mind;
			}

			if ( !Lang13.Bool( T ) ) {
				T = Rand13.PickFromTable( GlobalVars.latejoin );
			}
			this.loc = T;

			if ( !Lang13.Bool( this.name ) ) {
				this.name = GlobalFuncs.random_unique_name( this.gender );
			}
			this.real_name = this.name;

			if ( !this.fun_verbs ) {
				this.verbs.Remove( typeof(Mob_Dead_Observer).GetMethod( "boo" ) );
				this.verbs.Remove( typeof(Mob_Dead_Observer).GetMethod( "possess" ) );
			}
			Icon13.Animate( new ByTable().Set( 1, this ).Set( "pixel_y", 2 ).Set( "time", 10 ).Set( "loop", -1 ) );
			// Warning: Super call was HERE! If anything above HERE is needed by the super call, it might break!;
			return;
		}

		// Function from file: say.dm
		public override string Hear( string message = null, dynamic speaker = null, int message_langs = 0, dynamic raw_message = null, dynamic radio_freq = null, ByTable spans = null ) {
			dynamic V = null;
			dynamic S = null;

			
			if ( Lang13.Bool( radio_freq ) ) {
				V = speaker;

				if ( V.source is Mob_Living_Silicon_Ai ) {
					S = V.source;
					speaker = S.eyeobj;
				} else {
					speaker = V.source;
				}
			}
			this.WriteMsg( new Txt( "<a href=?src=" ).Ref( this ).str( ";follow=" ).Ref( speaker ).str( ">(F)</a> " ).item( message ).ToString() );
			return null;
		}

		// Function from file: say.dm
		public override bool say( dynamic message = null, string bubble_type = null ) {
			bool _default = false;

			message = GlobalFuncs.trim( String13.SubStr( GlobalFuncs.sanitize( message ), 1, 1024 ) );

			if ( !Lang13.Bool( message ) ) {
				return _default;
			}
			GlobalFuncs.log_say( "Ghost/" + this.key + " : " + message );

			if ( this.client != null ) {
				
				if ( ( this.client.prefs.muted & 16 ) != 0 ) {
					this.WriteMsg( "<span class='danger'>You cannot talk in deadchat (muted).</span>" );
					return _default;
				}

				if ( this.client.handle_spam_prevention( message, 16 ) ) {
					return _default;
				}
			}
			_default = this.say_dead( message ) != null;
			return _default;
		}

		// Function from file: tgstation.dme
		public override bool canUseTopic( dynamic M = null, bool? be_close = null, bool? no_dextery = null ) {
			
			if ( GlobalFuncs.check_rights( 2, false ) ) {
				return true;
			}
			return false;
		}

		// Function from file: observer.dm
		public override void mind_initialize(  ) {
			return;
		}

		// Function from file: observer.dm
		public override dynamic Topic( string href = null, ByTable href_list = null, dynamic hsrc = null ) {
			dynamic target = null;

			base.Topic( href, href_list, (object)(hsrc) );

			if ( Task13.User == this ) {
				
				if ( Lang13.Bool( href_list["follow"] ) ) {
					target = Lang13.FindObj( href_list["follow"] );

					if ( target is Ent_Dynamic && target != this ) {
						this.ManualFollow( target );
					}
				}

				if ( Lang13.Bool( href_list["reenter"] ) ) {
					this.__CallVerb("Re-enter Corpse" );
				}
			}
			return null;
		}

		// Function from file: observer.dm
		public override dynamic MouseDrop( dynamic over = null, dynamic src_location = null, dynamic over_location = null, string src_control = null, dynamic over_control = null, string _params = null ) {
			
			if ( !( Task13.User != null ) || !Lang13.Bool( over ) ) {
				return null;
			}

			if ( Task13.User is Mob_Dead_Observer && Task13.User.client.holder != null && over is Mob_Living ) {
				
				if ( Task13.User.client.holder.cmd_ghost_drag( this, over ) ) {
					return null;
				}
			}
			return base.MouseDrop( (object)(over), (object)(src_location), (object)(over_location), src_control, (object)(over_control), _params );
		}

		// Function from file: observer.dm
		public override void orbit( dynamic A = null, double? radius = null, bool? clockwise = null, double? rotation_speed = null, int? rotation_segments = null, bool? pre_rotation = null, bool? lockinorbit = null ) {
			base.orbit( (object)(A), radius, clockwise, rotation_speed, rotation_segments, pre_rotation, lockinorbit );
			Task13.Sleep( 2 );

			if ( !Lang13.Bool( this.orbiting ) ) {
				this.pixel_y = 0;
				Icon13.Animate( new ByTable().Set( 1, this ).Set( "pixel_y", 2 ).Set( "time", 10 ).Set( "loop", -1 ) );
			}
			return;
		}

		// Function from file: observer.dm
		public void show_me_the_hud( int hud_index = 0 ) {
			AtomHud H = null;

			H = GlobalVars.huds[hud_index];
			H.add_hud_to( this );
			this.data_hud_seen = hud_index;
			return;
		}

		// Function from file: observer.dm
		public void updateghostimages(  ) {
			
			if ( !( this.client != null ) ) {
				return;
			}

			if ( this.seedarkness || !this.ghostvision ) {
				this.client.images.Remove( GlobalVars.ghost_darkness_images );
			} else {
				this.client.images.Or( GlobalVars.ghost_darkness_images );

				if ( this.ghostimage != null ) {
					this.client.images.Remove( this.ghostimage );
				}
			}
			return;
		}

		// Function from file: observer.dm
		public void updateghostsight(  ) {
			
			if ( !this.seedarkness ) {
				this.see_invisible = 15;
			} else {
				this.see_invisible = 60;

				if ( !this.ghostvision ) {
					this.see_invisible = 25;
				}
			}
			this.updateghostimages();
			return;
		}

		// Function from file: observer.dm
		public void ManualFollow( dynamic target = null ) {
			Icon I = null;
			double? orbitsize = null;
			int? rot_seg = null;

			
			if ( !( target is Ent_Dynamic ) ) {
				return;
			}
			I = new Icon( target.icon, target.icon_state, Lang13.DoubleNullable( target.dir ) );
			orbitsize = ( I.Width() + I.Height() ) * 0.5;
			orbitsize -= ( orbitsize ??0) / Game13.icon_size * Game13.icon_size * 0.25;

			if ( this.orbiting != target ) {
				this.WriteMsg( "<span class='notice'>Now orbiting " + target + ".</span>" );
			}

			dynamic _a = this.ghost_orbit; // Was a switch-case, sorry for the mess.
			if ( _a=="triangle" ) {
				rot_seg = 3;
			} else if ( _a=="square" ) {
				rot_seg = 4;
			} else if ( _a=="pentagon" ) {
				rot_seg = 5;
			} else if ( _a=="hexagon" ) {
				rot_seg = 6;
			} else {
				rot_seg = 36;
			}
			this.orbit( target, orbitsize, GlobalVars.FALSE, 20, rot_seg );
			return;
		}

		// Function from file: observer.dm
		[VerbInfo( name: "Teleport", desc: "Teleport to a location", group: "Ghost" )]
		public void dead_tele(  ) {
			dynamic A = null;
			dynamic thearea = null;
			ByTable L = null;
			dynamic T = null;

			
			if ( !( Task13.User is Mob_Dead_Observer ) ) {
				Task13.User.WriteMsg( "Not when you're not dead!" );
				return;
			}
			A = Interface13.Input( "Area to jump to", "BOOYEA", A, null, GlobalVars.sortedAreas, InputType.Null | InputType.Any );
			thearea = A;

			if ( !Lang13.Bool( thearea ) ) {
				return;
			}
			L = new ByTable();

			foreach (dynamic _a in Lang13.Enumerate( GlobalFuncs.get_area_turfs( thearea.type ) )) {
				T = _a;
				
				L.Add( T );
			}

			if ( !( L != null ) || !( L.len != 0 ) ) {
				Task13.User.WriteMsg( "No area available." );
			}
			Task13.User.loc = Rand13.PickFromTable( L );
			return;
		}

		// Function from file: observer.dm
		public void notify_cloning( string message = null, string sound = null, dynamic source = null ) {
			dynamic A = null;
			double old_layer = 0;

			
			if ( Lang13.Bool( message ) ) {
				this.WriteMsg( "<span class='ghostalert'>" + message + "</span>" );

				if ( Lang13.Bool( source ) ) {
					A = this.throw_alert( new Txt().Ref( source ).str( "_notify_cloning" ).ToString(), typeof(Obj_Screen_Alert_NotifyCloning) );

					if ( Lang13.Bool( A ) ) {
						A.desc = message;
						old_layer = Convert.ToDouble( source.layer );
						source.layer = GlobalVars.FLOAT_LAYER;
						A.overlays += source;
						source.layer = old_layer;
					}
				}
			}
			this.WriteMsg( new Txt( "<span class='ghostalert'><a href=?src=" ).Ref( this ).str( ";reenter=1>(Click to re-enter)</a></span>" ).ToString() );

			if ( Lang13.Bool( sound ) ) {
				this.WriteMsg( new Sound( sound ) );
			}
			return;
		}

		// Function from file: observer.dm
		public override dynamic Stat(  ) {
			Gang G = null;

			base.Stat();

			if ( Interface13.IsStatPanelActive( "Status" ) ) {
				Interface13.Stat( null, "Station Time: " + GlobalFuncs.worldtime2text() );

				if ( GlobalVars.ticker != null ) {
					
					if ( Lang13.Bool( GlobalVars.ticker.mode ) ) {
						
						foreach (dynamic _a in Lang13.Enumerate( GlobalVars.ticker.mode.gangs, typeof(Gang) )) {
							G = _a;
							

							if ( Lang13.Bool( Lang13.IsNumber( G.dom_timer ) ) ) {
								Interface13.Stat( null, "" + G.name + " Gang Takeover: " + Num13.MaxInt( Convert.ToInt32( G.dom_timer ), 0 ) );
							}
						}
					}
				}
			}
			return null;
		}

		// Function from file: observer.dm
		public override bool is_active(  ) {
			return false;
		}

		// Function from file: observer.dm
		public override bool Move( dynamic NewLoc = null, int? Dir = null, int step_x = 0, int step_y = 0 ) {
			Obj_Effect_StepTrigger S = null;
			Obj_Effect_StepTrigger S2 = null;

			
			if ( Lang13.Bool( NewLoc ) ) {
				this.loc = NewLoc;

				foreach (dynamic _a in Lang13.Enumerate( NewLoc, typeof(Obj_Effect_StepTrigger) )) {
					S = _a;
					
					S.Crossed( this );
				}
				return false;
			}
			this.loc = GlobalFuncs.get_turf( this );

			if ( ( ( Dir ??0) & 1 ) != 0 && this.y < Game13.map_size_y ) {
				this.y++;
			} else if ( ( ( Dir ??0) & 2 ) != 0 && this.y > 1 ) {
				this.y--;
			}

			if ( ( ( Dir ??0) & 4 ) != 0 && this.x < Game13.map_size_x ) {
				this.x++;
			} else if ( ( ( Dir ??0) & 8 ) != 0 && this.x > 1 ) {
				this.x--;
			}

			foreach (dynamic _b in Lang13.Enumerate( Map13.GetTile( this.x, this.y, this.z ), typeof(Obj_Effect_StepTrigger) )) {
				S2 = _b;
				
				S2.Crossed( this );
			}
			return false;
		}

		// Function from file: observer.dm
		public override dynamic Destroy(  ) {
			
			if ( this.ghostimage != null ) {
				GlobalVars.ghost_darkness_images.Remove( this.ghostimage );
				GlobalFuncs.qdel( this.ghostimage );
				this.ghostimage = null;
				GlobalFuncs.updateallghostimages();
			}
			return base.Destroy();
		}

		// Function from file: logout.dm
		public override bool Logout(  ) {
			
			if ( this.client != null ) {
				this.client.images.Remove( GlobalVars.ghost_darkness_images );
			}
			base.Logout();
			Task13.Schedule( 0, (Task13.Closure)(() => {
				
				if ( this != null && !Lang13.Bool( this.key ) ) {
					GlobalFuncs.qdel( this );
				}
				return;
			}));
			return false;
		}

		// Function from file: login.dm
		public override dynamic Login(  ) {
			base.Login();

			if ( GlobalFuncs.check_rights( 2, false ) ) {
				this.has_unlimited_silicon_privilege = true;
			}

			if ( Lang13.Bool( this.client.prefs.unlock_content ) ) {
				this.icon_state = this.client.prefs.ghost_form;

				if ( this.ghostimage != null ) {
					this.ghostimage.icon_state = this.icon_state;
				}
				this.ghost_orbit = this.client.prefs.ghost_orbit;
			}
			this.updateghostimages();
			this.update_interface();
			return null;
		}

		// Function from file: mind.dm
		public override void sync_mind(  ) {
			return;
		}

		// Function from file: observer.dm
		public override void ClickOn( dynamic A = null, string _params = null ) {
			ByTable modifiers = null;

			
			if ( this.client.buildmode != 0 ) {
				GlobalFuncs.build_click( this, this.client.buildmode, _params, A );
				return;
			}
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

			if ( Game13.time <= this.next_move ) {
				return;
			}
			((Ent_Static)A).attack_ghost( this );
			return;
		}

		// Function from file: observer.dm
		public override void DblClickOn( Ent_Static A = null, string _params = null ) {
			
			if ( this.client.buildmode != 0 ) {
				GlobalFuncs.build_click( this, this.client.buildmode, _params, A );
				return;
			}

			if ( this.can_reenter_corpse == true && this.mind != null && Lang13.Bool( this.mind.current ) ) {
				
				if ( A == this.mind.current || Lang13.Bool( ((dynamic)A).Contains( this.mind.current ) ) ) {
					this.reenter_corpse();
					return;
				}
			}

			if ( A is Ent_Dynamic ) {
				this.ManualFollow( A );
			} else if ( A.loc != null ) {
				this.loc = GlobalFuncs.get_turf( A );
			}
			return;
		}

		// Function from file: observer.dm
		[Verb]
		[VerbInfo( name: "Point To", group: "Object" )]
		[VerbArg( 1, InputType.Mob | InputType.Obj | InputType.Tile )]
		public override bool pointed( dynamic A = null ) {
			
			if ( !Lang13.Bool( Lang13.SuperCall( A ) ) ) {
				return false;
			}
			Task13.User.visible_message( "<span class='deadsay'><b>" + this + "</b> points to " + A + ".</span>" );
			return true;
		}

		// Function from file: observer.dm
		[Verb]
		[VerbInfo( name: "Add Note", group: "IC", hidden: true )]
		public override void add_memory( string msg = null ) {
			this.WriteMsg( "<span class='danger'>You are dead! You have no mind to store memory!</span>" );
			return;
		}

		// Function from file: observer.dm
		[Verb]
		[VerbInfo( name: "Notes", group: "IC", hidden: true )]
		public override void f_memory(  ) {
			this.WriteMsg( "<span class='danger'>You are dead! You have no mind to store memory!</span>" );
			return;
		}

		// Function from file: observer.dm
		[Verb]
		[VerbInfo( name: "Toggle Sec/Med/Diag HUD", desc: "Toggles whether you see medical/security/diagnostic HUDs", group: "Ghost" )]
		public void toggle_ghost_med_sec_diag_hud(  ) {
			AtomHud H = null;

			
			if ( this.data_hud_seen != 0 ) {
				H = GlobalVars.huds[this.data_hud_seen];
				H.remove_hud_from( this );
			}

			switch ((int)( this.data_hud_seen )) {
				case 0:
					this.show_me_the_hud( 1 );
					this.WriteMsg( "<span class='notice'>Security HUD set.</span>" );
					break;
				case 1:
					this.show_me_the_hud( 4 );
					this.WriteMsg( "<span class='notice'>Medical HUD set.</span>" );
					break;
				case 4:
					this.show_me_the_hud( 5 );
					this.WriteMsg( "<span class='notice'>Diagnostic HUD set.</span>" );
					break;
				case 5:
					this.data_hud_seen = 0;
					this.WriteMsg( "<span class='notice'>HUDs disabled.</span>" );
					break;
			}
			return;
		}

		// Function from file: observer.dm
		[Verb]
		[VerbInfo( name: "View Crew Manifest", group: "Ghost" )]
		public void view_manifest(  ) {
			dynamic dat = null;

			dat += "<h4>Crew Manifest</h4>";
			dat += GlobalVars.data_core.get_manifest();
			Interface13.Browse( this, dat, "window=manifest;size=387x420;can_close=1" );
			return;
		}

		// Function from file: observer.dm
		[Verb]
		[VerbInfo( name: "Possess!", desc: "Take over the body of a mindless creature!", group: "Ghost" )]
		public bool possess(  ) {
			ByTable possessible = null;
			Mob_Living L = null;
			dynamic target = null;

			possessible = new ByTable();

			foreach (dynamic _a in Lang13.Enumerate( GlobalVars.living_mob_list, typeof(Mob_Living) )) {
				L = _a;
				

				if ( !GlobalVars.player_list.Contains( L ) && !( L.mind != null ) ) {
					possessible.Add( L );
				}
			}
			target = Interface13.Input( "Your new life begins today!", "Possess Mob", null, null, possessible, InputType.Null | InputType.Any );

			if ( !Lang13.Bool( target ) ) {
				return false;
			}

			if ( this.can_reenter_corpse == true || this.mind != null && Lang13.Bool( this.mind.current ) ) {
				
				if ( Interface13.Alert( this, "Your soul is still tied to your former life as " + this.mind.current.name + ", if you go foward there is no going back to that life. Are you sure you wish to continue?", "Move On", "Yes", "No" ) == "No" ) {
					return false;
				}
			}

			if ( Lang13.Bool( target.key ) ) {
				this.WriteMsg( "<span class='warning'>Someone has taken this body while you were choosing!</span>" );
				return false;
			}
			target.key = this.key;
			return true;
		}

		// Function from file: observer.dm
		[Verb]
		[VerbInfo( name: "Toggle Darkness", group: "Ghost" )]
		public void toggle_darkness(  ) {
			this.seedarkness = !this.seedarkness;
			this.updateghostsight();
			return;
		}

		// Function from file: observer.dm
		[Verb]
		[VerbInfo( name: "Toggle Ghost Vision", desc: "Toggles your ability to see things only ghosts can see, like other ghosts", group: "Ghost" )]
		public void toggle_ghostsee(  ) {
			this.ghostvision = !this.ghostvision;
			this.updateghostsight();
			Task13.User.WriteMsg( "You " + ( this.ghostvision ? "now" : "no longer" ) + " have ghost vision." );
			return;
		}

		// Function from file: observer.dm
		[Verb]
		[VerbInfo( name: "Boo!", desc: "Scare your crew members because of boredom!", group: "Ghost" )]
		public void boo(  ) {
			dynamic L = null;

			
			if ( this.bootime > Game13.time ) {
				return;
			}
			L = Lang13.FindIn( typeof(Obj_Machinery_Light), Map13.FetchInView( this, 1 ) );

			if ( Lang13.Bool( L ) ) {
				((Obj_Machinery_Light)L).flicker();
				this.bootime = Game13.time + 600;
				return;
			}
			return;
		}

		// Function from file: observer.dm
		[Verb]
		[VerbInfo( name: "Jump to Mob", desc: "Teleport to a mob", group: "Ghost" )]
		public void jumptomob(  ) {
			ByTable dest = null;
			dynamic target = null;
			dynamic M = null;
			Mob_Dead_Observer A = null;
			dynamic T = null;

			
			if ( Task13.User is Mob_Dead_Observer ) {
				dest = new ByTable();
				target = null;
				dest.Add( GlobalFuncs.getpois( true ) );
				target = Interface13.Input( "Please, select a player!", "Jump to Mob", null, null, dest, InputType.Null | InputType.Any );

				if ( !Lang13.Bool( target ) ) {
					return;
				} else {
					M = dest[target];
					A = this;
					T = GlobalFuncs.get_turf( M );

					if ( Lang13.Bool( T ) && T is Tile ) {
						A.loc = T;
					} else {
						A.WriteMsg( "This mob is not located in the game world." );
					}
				}
			}
			return;
		}

		// Function from file: observer.dm
		[Verb]
		[VerbInfo( name: "Orbit", desc: "Follow and orbit a mob.", group: "Ghost" )]
		public void follow(  ) {
			ByTable mobs = null;
			dynamic input = null;
			dynamic target = null;

			mobs = GlobalFuncs.getpois( null, true );
			input = Interface13.Input( "Please, select a mob!", "Haunt", null, null, mobs, InputType.Null | InputType.Any );
			target = mobs[input];
			this.ManualFollow( target );
			return;
		}

		// Function from file: observer.dm
		[Verb]
		[VerbInfo( name: "Re-enter Corpse", group: "Ghost" )]
		public bool reenter_corpse(  ) {
			
			if ( !( this.client != null ) ) {
				return false;
			}

			if ( !( this.mind != null && Lang13.Bool( this.mind.current ) ) ) {
				this.WriteMsg( "<span class='warning'>You have no body.</span>" );
				return false;
			}

			if ( !( this.can_reenter_corpse == true ) ) {
				this.WriteMsg( "<span class='warning'>You cannot re-enter your body.</span>" );
				return false;
			}

			if ( Lang13.Bool( this.mind.current.key ) && String13.SubStr( this.mind.current.key, 1, 2 ) != "@" ) {
				Task13.User.WriteMsg( "<span class='warning'>Another consciousness is in your body...It is resisting you.</span>" );
				return false;
			}
			GlobalVars.SStgui.on_transfer( this, this.mind.current );
			this.mind.current.key = this.key;
			return true;
		}

	}

}