// FILE AUTOGENERATED BY SOM13. DO NOT EDIT YET.

using System;
using Somnium.Engine.ByImpl;

namespace Somnium.Game {
	class Mob_Living_Carbon_Alien_Larva : Mob_Living_Carbon_Alien {

		public int amount_grown = 0;
		public int max_grown = 200;
		public dynamic time_of_birth = null;

		protected override void __FieldInit() {
			base.__FieldInit();

			this.real_name = "alien larva";
			this.pass_flags = 17;
			this.mob_size = 1;
			this.maxHealth = 25;
			this.health = 25;
			this.rotate_on_lying = false;
			this.icon_state = "larva0";
		}

		// Function from file: larva.dm
		public Mob_Living_Carbon_Alien_Larva ( dynamic loc = null ) : base( (object)(loc) ) {
			this.regenerate_icons();
			this.internal_organs.Add( new Obj_Item_Organ_Internal_Alien_Plasmavessel_Small_Tiny() );
			this.AddAbility( new Obj_Effect_ProcHolder_Alien_Hide( null ) );
			this.AddAbility( new Obj_Effect_ProcHolder_Alien_LarvaEvolve( null ) );
			// Warning: Super call was HERE! If anything above HERE is needed by the super call, it might break!;
			return;
		}

		// Function from file: tgstation.dme
		public override bool update_inv_handcuffed(  ) {
			return false;
		}

		// Function from file: update_icons.dm
		public override void update_transform(  ) {
			base.update_transform();
			this.update_icons(); return;
		}

		// Function from file: update_icons.dm
		public override void update_icons(  ) {
			int state = 0;

			state = 0;

			if ( this.amount_grown > 150 ) {
				state = 2;
			} else if ( this.amount_grown > 50 ) {
				state = 1;
			}

			if ( this.stat == 2 ) {
				this.icon_state = "larva" + state + "_dead";
			} else if ( Lang13.Bool( this.handcuffed ) || Lang13.Bool( this.legcuffed ) ) {
				this.icon_state = "larva" + state + "_cuff";
			} else if ( this.stat == 1 || Lang13.Bool( this.lying ) || this.resting != 0 ) {
				this.icon_state = "larva" + state + "_sleep";
			} else if ( this.stunned != 0 ) {
				this.icon_state = "larva" + state + "_stun";
			} else {
				this.icon_state = "larva" + state;
			}
			return;
		}

		// Function from file: update_icons.dm
		public override bool regenerate_icons(  ) {
			this.overlays = new ByTable();
			this.update_icons();
			return false;
		}

		// Function from file: life.dm
		public override bool handle_regular_status_updates(  ) {
			
			if ( base.handle_regular_status_updates() ) {
				
				if ( Convert.ToDouble( this.health ) <= Convert.ToDouble( -this.maxHealth ) ) {
					this.death();
					return false;
				}
				return true;
			}
			return false;
		}

		// Function from file: life.dm
		public override void handle_hud_icons_health(  ) {
			
			if ( this.healths != null ) {
				
				if ( this.stat != 2 ) {
					
					dynamic _a = this.health; // Was a switch-case, sorry for the mess.
					if ( 25<=_a&&_a<=Double.PositiveInfinity ) {
						this.healths.icon_state = "health0";
					} else if ( 20<=_a&&_a<=25 ) {
						this.healths.icon_state = "health1";
					} else if ( 15<=_a&&_a<=20 ) {
						this.healths.icon_state = "health2";
					} else if ( 10<=_a&&_a<=15 ) {
						this.healths.icon_state = "health3";
					} else if ( 5<=_a&&_a<=10 ) {
						this.healths.icon_state = "health4";
					} else if ( 0<=_a&&_a<=5 ) {
						this.healths.icon_state = "health5";
					} else {
						this.healths.icon_state = "health6";
					}
				} else {
					this.healths.icon_state = "health7";
				}
			}
			return;
		}

		// Function from file: life.dm
		public override bool Life(  ) {
			
			if ( this.notransform == true ) {
				return false;
			}

			if ( base.Life() ) {
				
				if ( this.amount_grown < this.max_grown ) {
					this.amount_grown++;
				}
			}
			this.update_icons();
			return false;
		}

		// Function from file: larva.dm
		public override bool stripPanelEquip( dynamic what = null, Mob who = null, double? where = null, bool? child_override = null ) {
			this.WriteMsg( "<span class='warning'>You don't have the dexterity to do this!</span>" );
			return false;
		}

		// Function from file: larva.dm
		public override void stripPanelUnequip( dynamic what = null, Mob who = null, double? where = null, bool? child_override = null ) {
			this.WriteMsg( "<span class='warning'>You don't have the dexterity to do this!</span>" );
			return;
		}

		// Function from file: larva.dm
		public override void start_pulling( dynamic AM = null ) {
			return;
		}

		// Function from file: larva.dm
		public override void toggle_throw_mode(  ) {
			return;
		}

		// Function from file: larva.dm
		public override void show_inv( Ent_Static user = null ) {
			return;
		}

		// Function from file: larva.dm
		public override bool restrained(  ) {
			return false;
		}

		// Function from file: larva.dm
		public override dynamic attack_hand( dynamic a = null, bool? b = null, bool? c = null ) {
			double damage = 0;

			
			if ( Lang13.Bool( base.attack_hand( (object)(a), b, c ) ) ) {
				damage = Rand13.Int( 1, 9 );

				if ( Rand13.PercentChance( 90 ) ) {
					GlobalFuncs.playsound( this.loc, "punch", 25, 1, -1 );
					GlobalFuncs.add_logs( a, this, "attacked" );
					this.visible_message( "<span class='danger'>" + a + " has kicked " + this + "!</span>", "<span class='userdanger'>" + a + " has kicked " + this + "!</span>" );

					if ( this.stat != 2 && damage > 4.9 ) {
						this.Paralyse( Rand13.Int( 5, 10 ) );
					}
					this.adjustBruteLoss( damage );
					this.updatehealth();
				} else {
					GlobalFuncs.playsound( this.loc, "sound/weapons/punchmiss.ogg", 25, 1, -1 );
					this.visible_message( "<span class='danger'>" + a + " has attempted to kick " + this + "!</span>", "<span class='userdanger'>" + a + " has attempted to kick " + this + "!</span>" );
				}
			}
			return null;
		}

		// Function from file: larva.dm
		public override bool attack_hulk( Mob_Living_Carbon_Human hulk = null, bool? do_attack_animation = null ) {
			
			if ( hulk.a_intent == "harm" ) {
				base.attack_hulk( hulk, true );
				this.adjustBruteLoss( Rand13.Int( 1, 9 ) + 5 );
				this.Paralyse( 1 );
				Task13.Schedule( 0, (Task13.Closure)(() => {
					Map13.StepAway( this, hulk, 15 );
					Task13.Sleep( 1 );
					Map13.StepAway( this, hulk, 15 );
					return;
				}));
				return true;
			}
			return false;
		}

		// Function from file: larva.dm
		public override bool attack_ui( int slot = 0 ) {
			return false;
		}

		// Function from file: larva.dm
		public override bool adjustPlasma( dynamic amount = null ) {
			
			if ( this.stat != 2 && Convert.ToDouble( amount ) > 0 ) {
				this.amount_grown = Num13.MinInt( this.amount_grown + 1, this.max_grown );
			}
			base.adjustPlasma( (object)(amount) );
			return false;
		}

		// Function from file: larva.dm
		public override dynamic Stat(  ) {
			base.Stat();

			if ( Interface13.IsStatPanelActive( "Status" ) ) {
				Interface13.Stat( null, "Progress: " + this.amount_grown + "/" + this.max_grown );
			}
			return null;
		}

		// Function from file: tgstation.dme
		public override bool unEquip( dynamic I = null, bool? force = null ) {
			return false;
		}

		// Function from file: emote.dm
		public override void emote( string act = null, int? m_type = null, dynamic message = null ) {
			m_type = m_type ?? 1;

			string param = null;
			int t1 = 0;
			bool muzzled = false;

			param = null;

			if ( String13.FindIgnoreCase( act, "-", 1, 0 ) != 0 ) {
				t1 = String13.FindIgnoreCase( act, "-", 1, 0 );
				param = String13.SubStr( act, t1 + 1, Lang13.Length( act ) + 1 );
				act = String13.SubStr( act, 1, t1 );
			}
			muzzled = this.is_muzzled();

			switch ((string)( act )) {
				case "burp":
				case "burps":
					
					if ( !muzzled ) {
						message = "<span class='name'>" + this + "</span> burps.";
						m_type = 2;
					}
					break;
				case "choke":
				case "chokes":
					message = "<span class='name'>" + this + "</span> chokes.";
					m_type = 2;
					break;
				case "collapse":
				case "collapses":
					this.Paralyse( 2 );
					message = "<span class='name'>" + this + "</span> collapses!";
					m_type = 2;
					break;
				case "dance":
				case "dances":
					
					if ( !this.restrained() ) {
						message = "<span class='name'>" + this + "</span> dances around happily.";
						m_type = 1;
					}
					break;
				case "deathgasp":
				case "deathgasps":
					message = "<span class='name'>" + this + "</span> lets out a sickly hiss of air and falls limply to the floor...";
					m_type = 2;
					break;
				case "drool":
				case "drools":
					message = "<span class='name'>" + this + "</span> drools.";
					m_type = 1;
					break;
				case "gasp":
				case "gasps":
					message = "<span class='name'>" + this + "</span> gasps.";
					m_type = 2;
					break;
				case "gnarl":
				case "gnarls":
					
					if ( !muzzled ) {
						message = "<span class='name'>" + this + "</span> gnarls and shows its teeth..";
						m_type = 2;
					}
					break;
				case "hiss":
				case "hisses":
					message = "<span class='name'>" + this + "</span> hisses softly.";
					m_type = 1;
					break;
				case "jump":
				case "jumps":
					message = "<span class='name'>" + this + "</span> jumps!";
					m_type = 1;
					break;
				case "me":
					base.emote( act, m_type, (object)(message) );
					return;
					break;
				case "moan":
				case "moans":
					message = "<span class='name'>" + this + "</span> moans!";
					m_type = 2;
					break;
				case "nod":
				case "nods":
					message = "<span class='name'>" + this + "</span> nods its head.";
					m_type = 1;
					break;
				case "roar":
				case "roars":
					
					if ( !muzzled ) {
						message = "<span class='name'>" + this + "</span> softly roars.";
						m_type = 2;
					}
					break;
				case "roll":
				case "rolls":
					
					if ( !this.restrained() ) {
						message = "<span class='name'>" + this + "</span> rolls.";
						m_type = 1;
					}
					break;
				case "scratch":
				case "scratches":
					
					if ( !this.restrained() ) {
						message = "<span class='name'>" + this + "</span> scratches.";
						m_type = 1;
					}
					break;
				case "screech":
				case "screeches":
					
					if ( !muzzled ) {
						message = "<span class='name'>" + this + "</span> screeches.";
						m_type = 2;
					}
					break;
				case "shake":
				case "shakes":
					message = "<span class='name'>" + this + "</span> shakes its head.";
					m_type = 1;
					break;
				case "shiver":
				case "shivers":
					message = "<span class='name'>" + this + "</span> shivers.";
					m_type = 2;
					break;
				case "sign":
				case "signs":
					
					if ( !this.restrained() ) {
						message = "<span class='name'>" + this + "</span> signs" + ( Lang13.Bool( String13.ParseNumber( param ) ) ? " the number " + String13.ParseNumber( param ) : null ) + ".";
						m_type = 1;
					}
					break;
				case "snore":
				case "snores":
					message = "<B>" + this + "</B> snores.";
					m_type = 2;
					break;
				case "sulk":
				case "sulks":
					message = "<span class='name'>" + this + "</span> sulks down sadly.";
					m_type = 1;
					break;
				case "sway":
				case "sways":
					message = "<span class='name'>" + this + "</span> sways around dizzily.";
					m_type = 1;
					break;
				case "tail":
					message = "<span class='name'>" + this + "</span> waves its tail.";
					m_type = 1;
					break;
				case "twitch":
					message = "<span class='name'>" + this + "</span> twitches violently.";
					m_type = 1;
					break;
				case "whimper":
				case "whimpers":
					
					if ( !muzzled ) {
						message = "<span class='name'>" + this + "</span> whimpers.";
						m_type = 2;
					}
					break;
				case "help":
					this.WriteMsg( "Help for larva emotes. You can use these emotes with say \"*emote\":\n\nburp, choke, collapse, dance, deathgasp, drool, gasp, gnarl, hiss, jump, me, moan, nod, roll, roar, scratch, screech, shake, shiver, sign-#, sulk, sway, tail, twitch, whimper" );
					break;
				default:
					this.WriteMsg( "<span class='info'>Unusable emote '" + act + "'. Say *help for a list.</span>" );
					break;
			}

			if ( Lang13.Bool( message ) && this.stat == 0 ) {
				GlobalFuncs.log_emote( "" + this.name + "/" + this.key + " : " + message );

				if ( ( ( m_type ??0) & 1 ) != 0 ) {
					this.visible_message( message );
				} else {
					this.audible_message( message );
				}
			}
			return;
		}

		// Function from file: death.dm
		public override bool death( bool? gibbed = null, bool? toast = null ) {
			
			if ( this.stat == 2 ) {
				return false;
			}

			if ( this.healths != null ) {
				this.healths.icon_state = "health6";
			}
			this.stat = 2;
			this.icon_state = "larva_dead";

			if ( !( gibbed == true ) ) {
				this.visible_message( "<span class='name'>" + this + "</span> lets out a waning high-pitched cry." );
				this.update_canmove();

				if ( this.client != null ) {
					this.blind.layer = 0;
				}
			}
			this.tod = GlobalFuncs.worldtime2text();

			if ( this.mind != null ) {
				this.mind.store_memory( "Time of death: " + this.tod );
			}
			GlobalVars.living_mob_list.Remove( this );
			return base.death( gibbed, toast );
		}

		// Function from file: tgstation.dme
		public override void updatePlasmaDisplay(  ) {
			return;
		}

		// Function from file: mind.dm
		public override void mind_initialize(  ) {
			base.mind_initialize();
			this.mind.special_role = "Larva";
			return;
		}

		// Function from file: other_mobs.dm
		public override void UnarmedAttack( dynamic A = null, bool? proximity_flag = null ) {
			((Ent_Static)A).attack_larva( this );
			return;
		}

	}

}