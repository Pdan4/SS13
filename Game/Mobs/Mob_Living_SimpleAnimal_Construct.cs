// FILE AUTOGENERATED BY SOMNIUM13.

using System;
using Somnium.Engine.ByImpl;

namespace Somnium.Game {
	class Mob_Living_SimpleAnimal_Construct : Mob_Living_SimpleAnimal {

		public bool nullblock = false;
		public ByTable construct_spells = new ByTable();

		protected override void __FieldInit() {
			base.__FieldInit();

			this.real_name = "Construct";
			this.speak_emote = new ByTable(new object [] { "hisses" });
			this.emote_hear = new ByTable(new object [] { "wails", "screeches" });
			this.response_help = "thinks better of touching";
			this.response_disarm = "flails at";
			this.response_harm = "punches";
			this.icon_dead = "shade_dead";
			this.speed = -1;
			this.a_intent = "hurt";
			this.stop_automated_movement = true;
			this.status_flags = 8;
			this.attack_sound = "sound/weapons/spiderlunge.ogg";
			this.min_oxy = 0;
			this.max_tox = false;
			this.max_co2 = 0;
			this.minbodytemp = 0;
			this.show_stat_health = false;
			this.faction = "cult";
			this.supernatural = true;
			this.flying = true;
			this.treadmill_speed = 0;
			this.mob_swap_flags = 51;
			this.mob_push_flags = 63;
			this.meat_type = typeof(Obj_Item_Weapon_Ectoplasm);
		}

		// Function from file: constructs.dm
		public Mob_Living_SimpleAnimal_Construct ( dynamic loc = null ) : base( (object)(loc) ) {
			dynamic spell = null;

			// Warning: Super call was HERE! If anything above HERE is needed by the super call, it might break!;
			this.name = "" + Lang13.Initial( this, "name" ) + " (" + Rand13.Int( 1, 1000 ) + ")";
			this.real_name = this.name;
			this.add_language( "Cult" );
			this.default_language = GlobalVars.all_languages["Cult"];

			foreach (dynamic _a in Lang13.Enumerate( this.construct_spells )) {
				spell = _a;
				
				this.add_spell( Lang13.Call( spell ), "const_spell_ready" );
			}
			this.updateicon();
			return;
		}

		// Function from file: constructs.dm
		public override bool Life(  ) {
			bool _default = false;

			
			if ( this.timestopped ) {
				return false;
			}
			_default = base.Life();

			if ( _default ) {
				
				if ( this.fire != null ) {
					
					if ( this.fire_alert != 0 ) {
						((dynamic)this.fire).icon_state = "fire1";
					} else {
						((dynamic)this.fire).icon_state = "fire0";
					}
				}

				if ( this.pullin != null ) {
					
					if ( this.pulling != null ) {
						((dynamic)this.pullin).icon_state = "pull1";
					} else {
						((dynamic)this.pullin).icon_state = "pull0";
					}
				}

				if ( this.purged != null ) {
					
					if ( ( this.purge ??0) > 0 ) {
						((dynamic)this.purged).icon_state = "purge1";
					} else {
						((dynamic)this.purged).icon_state = "purge0";
					}
				}
				this.silence_spells( this.purge );
			}
			return _default;
		}

		// Function from file: constructs.dm
		public void updateicon(  ) {
			double overlay_layer = 0;

			this.overlays = 0;
			overlay_layer = 11;

			if ( this.layer != GlobalVars.MOB_LAYER ) {
				overlay_layer = 2.2;
			}
			this.overlays.Add( new Image( this.icon, "glow-" + this.icon_state, overlay_layer ) );
			return;
		}

		// Function from file: constructs.dm
		public override dynamic attackby( dynamic a = null, dynamic b = null, dynamic c = null ) {
			dynamic damage = null;

			((Mob)b).delayNextAttack( 8 );

			if ( Lang13.Bool( a.force ) ) {
				damage = a.force;

				if ( a.damtype == "halloss" ) {
					damage = 0;
				}

				if ( a is Obj_Item_Weapon_Nullrod ) {
					damage *= 2;
					this.purge = 3;
				}
				this.adjustBruteLoss( damage );
				((Ent_Static)b).visible_message( "<span class='danger'>" + this + " has been attacked with " + a + " by " + b + ". </span>" );
			} else {
				GlobalFuncs.to_chat( Task13.User, "<span class='warning'>This weapon is ineffective, it does no damage.</span>" );
				((Ent_Static)b).visible_message( "<span class='warning'>" + b + " gently taps " + this + " with " + a + ". </span>" );
			}
			return null;
		}

		// Function from file: constructs.dm
		public override dynamic attack_animal( Mob_Living user = null ) {
			int damage = 0;

			
			if ( user is Mob_Living_SimpleAnimal_Construct_Builder ) {
				
				if ( Convert.ToDouble( this.health ) >= Convert.ToDouble( this.maxHealth ) ) {
					GlobalFuncs.to_chat( user, "<span class='notice'>" + this + " has nothing to mend.</span>" );
					return null;
				}
				this.health = Num13.MinInt( Convert.ToInt32( this.maxHealth ), Convert.ToInt32( this.health + 5 ) );
				user.visible_message( new Txt().item( user ).str( " mends some of " ).the( this ).str( "<EM>" ).item().str( "'s</EM> wounds." ).ToString(), new Txt( "You mend some of " ).the( this ).str( "<em>" ).item().str( "'s</em> wounds." ).ToString() );
			} else {
				user.attack_log.Add( "[" + GlobalFuncs.time_stamp() + "] <font color='red'>" + ((dynamic)user).attacktext + " " + this.name + " (" + this.ckey + ")</font>" );
				this.attack_log.Add( "[" + GlobalFuncs.time_stamp() + "] <font color='orange'>Has been " + ((dynamic)user).attacktext + " by " + user.name + " (" + user.ckey + ")</font>" );

				if ( Convert.ToDouble( ((dynamic)user).melee_damage_upper ) <= 0 ) {
					user.emote( new Txt().item( ((dynamic)user).friendly ).str( " " ).the( this ).str( "<EM>" ).item().str( "</EM>" ).ToString() );
				} else {
					
					if ( Lang13.Bool( ((dynamic)user).attack_sound ) ) {
						GlobalFuncs.playsound( this.loc, ((dynamic)user).attack_sound, 50, 1, 1 );
					}
					user.visible_message( new Txt( "<span class='attack'>" ).The( user ).str( "<EM>" ).item().str( "</EM> " ).item( ((dynamic)user).attacktext ).str( " " ).the( this ).str( "<EM>" ).item().str( "</EM>!</span>" ).ToString() );
					GlobalFuncs.add_logs( user, this, "attacked", true );
					damage = Rand13.Int( Convert.ToInt32( ((dynamic)user).melee_damage_lower ), Convert.ToInt32( ((dynamic)user).melee_damage_upper ) );
					this.adjustBruteLoss( damage );
				}
			}
			return null;
		}

		// Function from file: constructs.dm
		public override dynamic examine( dynamic user = null, string size = null ) {
			string msg = null;

			msg = new Txt( "<span cass='info'>*---------*\nThis is " ).icon( this ).str( " " ).a( this ).str( "<EM>" ).item().str( "</EM>!\n" ).ToString();

			if ( Convert.ToDouble( this.health ) < Convert.ToDouble( this.maxHealth ) ) {
				msg += "<span class='warning'>";

				if ( Convert.ToDouble( this.health ) >= Convert.ToDouble( this.maxHealth / 2 ) ) {
					msg += "It looks slightly dented.\n";
				} else {
					msg += "<B>It looks severely dented!</B>\n";
				}
				msg += "</span>";
			}
			msg += "*---------*</span>";
			GlobalFuncs.to_chat( user, msg );
			return null;
		}

		// Function from file: constructs.dm
		public override void Die( bool? gore = null ) {
			int? i = null;
			dynamic M = null;

			base.Die( gore );
			i = null;
			i = 0;

			while (( i ??0) < 3) {
				new Obj_Item_Weapon_Ectoplasm( this.loc );
				i++;
			}

			foreach (dynamic _a in Lang13.Enumerate( Map13.FetchViewers( null, this ) )) {
				M = _a;
				

				if ( Lang13.Bool( M.client ) && !Lang13.Bool( M.blinded ) ) {
					M.show_message( "<span class='warning'>" + this + " collapses in a shattered heap. </span>" );
				}
			}
			this.ghostize();
			GlobalFuncs.qdel( this );
			return;
		}

		// Function from file: constructs.dm
		public override dynamic cultify(  ) {
			return null;
		}

		// Function from file: constructs.dm
		public override dynamic gib( bool? animation = null, bool? meat = null ) {
			this.death( true );
			this.monkeyizing = true;
			this.canmove = false;
			this.icon = null;
			this.invisibility = 101;
			GlobalVars.dead_mob_list.Remove( this );
			GlobalFuncs.qdel( this );
			return null;
		}

		// Function from file: constructs.dm
		public override bool handle_inherent_channels( Game_Data speech = null, string message_mode = null ) {
			dynamic T = null;
			dynamic M = null;

			
			if ( base.handle_inherent_channels( speech, message_mode ) ) {
				return true;
			}

			if ( message_mode == "headset" && this.construct_chat_check( 0 ) ) {
				T = GlobalFuncs.get_turf( this );
				GlobalVars.diary.WriteMsg( String13.HtmlDecode( "[" + GlobalFuncs.time_stamp() + "]SAY: " + ( "" + GlobalFuncs.key_name( this ) + " (@" + T.x + "," + T.y + "," + T.z + ") Cult channel: " + String13.HtmlEncode( ((dynamic)speech).message ) ) ) );

				foreach (dynamic _a in Lang13.Enumerate( GlobalVars.mob_list )) {
					M = _a;
					

					if ( ((Mob)M).construct_chat_check( 2 ) || false && !( M is Mob_NewPlayer ) ) {
						GlobalFuncs.to_chat( M, "<span class='sinister'><b>" + this.name + ":</b> " + String13.HtmlEncode( ((dynamic)speech).message ) + "</span>" );
					}
				}
				return true;
			}
			return false;
		}

		// Function from file: constructs.dm
		public override bool construct_chat_check( int? setting = null ) {
			
			if ( !( this.mind != null ) ) {
				return false;
			}
			Interface13.Stat( null, GlobalVars.ticker.mode.cult.Contains( this.mind ) );

			if ( !( this.mind != null ) ) {
				return true;
			}
			return false;
		}

		// Function from file: other_mobs.dm
		public override void RangedAttack( Ent_Static A = null, string _params = null ) {
			A.attack_construct( this );
			return;
		}

		// Function from file: other_mobs.dm
		public override void UnarmedAttack( Ent_Static A = null, bool proximity_flag = false, string _params = null ) {
			
			if ( A is Mob ) {
				this.delayNextAttack( 10 );
			}

			if ( !A.attack_construct( this ) ) {
				A.attack_animal( this );
			}
			return;
		}

	}

}