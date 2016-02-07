// FILE AUTOGENERATED BY SOM13. DO NOT EDIT YET.

using System;
using Somnium.Engine.ByImpl;

namespace Somnium.Game {
	class Mob_Living_SimpleAnimal_Bot_Cleanbot : Mob_Living_SimpleAnimal_Bot {

		public bool blood = true;
		public ByTable target_types = new ByTable();
		public dynamic target = null;
		public int max_targets = 50;
		public Ent_Static oldloc = null;
		public dynamic closest_dist = null;
		public dynamic closest_loc = null;
		public dynamic failed_steps = null;
		public dynamic next_dest = null;
		public dynamic next_dest_loc = null;

		protected override void __FieldInit() {
			base.__FieldInit();

			this.health = 25;
			this.maxHealth = 25;
			this.radio_channel = "Service";
			this.bot_type = 8;
			this.model = "Cleanbot";
			this.bot_core_type = typeof(Obj_Machinery_BotCore_Cleanbot);
			this.window_id = "autoclean";
			this.window_name = "Automatic Station Cleaner v1.1";
			this.pass_flags = 16;
			this.icon_state = "cleanbot0";
			this.layer = 5;
		}

		// Function from file: cleanbot.dm
		public Mob_Living_SimpleAnimal_Bot_Cleanbot ( dynamic loc = null ) : base( (object)(loc) ) {
			Job_Janitor J = null;

			// Warning: Super call was HERE! If anything above HERE is needed by the super call, it might break!;
			this.get_targets();
			this.icon_state = "cleanbot" + this.on;
			J = new Job_Janitor();
			this.access_card.access += J.get_access();
			this.prev_access = this.access_card.access;
			return;
		}

		// Function from file: cleanbot.dm
		public override void UnarmedAttack( dynamic A = null, bool? proximity_flag = null ) {
			
			if ( A is Obj_Effect_Decal_Cleanable ) {
				this.clean( A );
			} else {
				base.UnarmedAttack( (object)(A), proximity_flag );
			}
			return;
		}

		// Function from file: cleanbot.dm
		public override dynamic Topic( string href = null, ByTable href_list = null, dynamic hsrc = null ) {
			
			if ( Lang13.Bool( base.Topic( href, href_list, (object)(hsrc) ) ) ) {
				return 1;
			}

			dynamic _a = href_list["operation"]; // Was a switch-case, sorry for the mess.
			if ( _a=="blood" ) {
				this.blood = !this.blood;
				this.get_targets();
				this.update_controls();
			}
			return null;
		}

		// Function from file: cleanbot.dm
		public override string get_controls( dynamic M = null ) {
			dynamic dat = null;

			dat += this.hack( M );
			dat += "\n<TT><B>Cleaner v1.1 controls</B></TT><BR><BR>\nStatus: " + new Txt( "<A href='?src=" ).Ref( this ).str( ";power=1'>" ).item( ( this.on ? "On" : "Off" ) ).str( "</A>" ).ToString() + "<BR>\nBehaviour controls are " + ( this.locked ? "locked" : "unlocked" ) + "<BR>\nMaintenance panel panel is " + ( this.open ? "opened" : "closed" );

			if ( !this.locked || M is Mob_Living_Silicon || GlobalFuncs.IsAdminGhost( M ) ) {
				dat += "<BR>Cleans Blood: " + new Txt( "<A href='?src=" ).Ref( this ).str( ";operation=blood'>" ).item( ( this.blood ? "Yes" : "No" ) ).str( "</A>" ).ToString() + "<BR>";
				dat += "<BR>Patrol station: " + new Txt( "<A href='?src=" ).Ref( this ).str( ";operation=patrol'>" ).item( ( this.auto_patrol ? "Yes" : "No" ) ).str( "</A>" ).ToString() + "<BR>";
			}
			return dat;
		}

		// Function from file: cleanbot.dm
		public override void explode(  ) {
			dynamic Tsec = null;
			EffectSystem_SparkSpread s = null;

			this.on = false;
			this.visible_message( "<span class='boldannounce'>" + this + " blows apart!</span>" );
			Tsec = GlobalFuncs.get_turf( this );
			new Obj_Item_Weapon_ReagentContainers_Glass_Bucket( Tsec );
			new Obj_Item_Device_Assembly_ProxSensor( Tsec );

			if ( Rand13.PercentChance( 50 ) ) {
				new Obj_Item_RobotParts_LArm( Tsec );
			}
			s = new EffectSystem_SparkSpread();
			s.set_up( 3, 1, this );
			s.start();
			base.explode();
			return;
		}

		// Function from file: cleanbot.dm
		public void clean( dynamic target = null ) {
			this.anchored = 1;
			this.icon_state = "cleanbot-c";
			this.visible_message( "<span class='notice'>" + this + " begins to clean up " + target + "</span>" );
			this.v_mode = 7;
			Task13.Schedule( 50, (Task13.Closure)(() => {
				
				if ( this.v_mode == 7 ) {
					GlobalFuncs.qdel( target );
					this.anchored = 0;
					target = null;
				}
				this.v_mode = 0;
				this.icon_state = "cleanbot" + this.on;
				return;
			}));
			return;
		}

		// Function from file: cleanbot.dm
		public void get_targets(  ) {
			this.target_types = new ByTable();
			this.target_types.Add( typeof(Obj_Effect_Decal_Cleanable_Oil) );
			this.target_types.Add( typeof(Obj_Effect_Decal_Cleanable_Vomit) );
			this.target_types.Add( typeof(Obj_Effect_Decal_Cleanable_RobotDebris) );
			this.target_types.Add( typeof(Obj_Effect_Decal_Cleanable_Crayon) );
			this.target_types.Add( typeof(Obj_Effect_Decal_Cleanable_MoltenItem) );
			this.target_types.Add( typeof(Obj_Effect_Decal_Cleanable_TomatoSmudge) );
			this.target_types.Add( typeof(Obj_Effect_Decal_Cleanable_EggSmudge) );
			this.target_types.Add( typeof(Obj_Effect_Decal_Cleanable_PieSmudge) );
			this.target_types.Add( typeof(Obj_Effect_Decal_Cleanable_Flour) );
			this.target_types.Add( typeof(Obj_Effect_Decal_Cleanable_Ash) );
			this.target_types.Add( typeof(Obj_Effect_Decal_Cleanable_Greenglow) );
			this.target_types.Add( typeof(Obj_Effect_Decal_Cleanable_Dirt) );
			this.target_types.Add( typeof(Obj_Effect_Decal_Cleanable_Deadcockroach) );

			if ( this.blood ) {
				this.target_types.Add( typeof(Obj_Effect_Decal_Cleanable_Xenoblood) );
				this.target_types.Add( typeof(Obj_Effect_Decal_Cleanable_Xenoblood_Xgibs) );
				this.target_types.Add( typeof(Obj_Effect_Decal_Cleanable_Blood) );
				this.target_types.Add( typeof(Obj_Effect_Decal_Cleanable_Blood_Gibs) );
				this.target_types.Add( typeof(Obj_Effect_Decal_Cleanable_Blood_Drip) );
				this.target_types.Add( typeof(Obj_Effect_Decal_Cleanable_TrailHolder) );
			}
			return;
		}

		// Function from file: cleanbot.dm
		public override bool handle_automated_action(  ) {
			Ent_Static T = null;

			
			if ( !base.handle_automated_action() ) {
				return false;
			}

			if ( this.v_mode == 7 ) {
				return false;
			}

			if ( this.emagged == 2 ) {
				
				if ( this.loc is Tile_Simulated ) {
					
					if ( Rand13.PercentChance( 10 ) ) {
						T = this.loc;
						((dynamic)T).MakeSlippery();
					}

					if ( Rand13.PercentChance( 5 ) ) {
						this.visible_message( "<span class='danger'>" + this + " whirs and bubbles violently, before releasing a plume of froth!</span>" );
						GlobalFuncs.PoolOrNew( typeof(Obj_Effect_ParticleEffect_Foam), this.loc );
					}
				}
			} else if ( Rand13.PercentChance( 5 ) ) {
				this.audible_message( "" + this + " makes an excited beeping booping sound!" );
			}

			if ( !Lang13.Bool( this.target ) ) {
				this.target = this.scan( typeof(Obj_Effect_Decal_Cleanable) );
			}

			if ( !Lang13.Bool( this.target ) && this.auto_patrol ) {
				
				if ( this.v_mode == 0 || this.v_mode == 4 ) {
					this.start_patrol();
				}

				if ( this.v_mode == 5 ) {
					this.bot_patrol();
				}
			}

			if ( Lang13.Bool( this.target ) ) {
				
				if ( !Lang13.Bool( this.path ) || Lang13.Bool( this.path.len ) == false ) {
					this.path = GlobalFuncs.get_path_to( this.loc, this.target.loc, this, typeof(Tile).GetMethod( "Distance_cardinal" ), false, 30, null, null, this.access_card );

					if ( !this.bot_move( this.target ) ) {
						this.add_to_ignore( this.target );
						this.target = null;
						this.path = new ByTable();
						return false;
					}
					this.v_mode = 9;
				} else if ( !this.bot_move( this.target ) ) {
					this.target = null;
					this.v_mode = 0;
					return false;
				}
			}

			if ( Lang13.Bool( this.target ) && this.loc == this.target.loc ) {
				this.clean( this.target );
				this.path = new ByTable();
				this.target = null;
			}
			this.oldloc = this.loc;
			return false;
		}

		// Function from file: cleanbot.dm
		public override dynamic process_scan( dynamic scan_target = null ) {
			dynamic T = null;

			
			foreach (dynamic _a in Lang13.Enumerate( this.target_types )) {
				T = _a;
				

				if ( Lang13.Bool( T.IsInstanceOfType( scan_target ) ) ) {
					return scan_target;
				}
			}
			return null;
		}

		// Function from file: cleanbot.dm
		public override void Emag( dynamic user = null ) {
			base.Emag( (object)(user) );

			if ( this.emagged == 2 ) {
				
				if ( Lang13.Bool( user ) ) {
					user.WriteMsg( "<span class='danger'>" + this + " buzzes and beeps.</span>" );
				}
			}
			return;
		}

		// Function from file: cleanbot.dm
		public override dynamic attackby( dynamic A = null, dynamic user = null, string _params = null, bool? silent = null, bool? replace_spent = null ) {
			
			if ( A is Obj_Item_Weapon_Card_Id || A is Obj_Item_Device_Pda ) {
				
				if ( ((Obj)this.bot_core).allowed( user ) && !this.open && !( this.emagged != 0 ) ) {
					this.locked = !this.locked;
					user.WriteMsg( new Txt( "<span class='notice'>You " ).item( ( this.locked ? "lock" : "unlock" ) ).str( " " ).the( this ).item().str( " behaviour controls.</span>" ).ToString() );
				} else {
					
					if ( this.emagged != 0 ) {
						user.WriteMsg( "<span class='warning'>ERROR</span>" );
					}

					if ( this.open ) {
						user.WriteMsg( "<span class='warning'>Please close the access panel before locking it.</span>" );
					} else {
						user.WriteMsg( new Txt( "<span class='notice'>" ).The( this ).item().str( " doesn't seem to respect your authority.</span>" ).ToString() );
					}
				}
			} else {
				return base.attackby( (object)(A), (object)(user), _params, silent, replace_spent );
			}
			return null;
		}

		// Function from file: cleanbot.dm
		public override void set_custom_texts(  ) {
			this.text_hack = "You corrupt " + this.name + "'s cleaning software.";
			this.text_dehack = "" + this.name + "'s software has been reset!";
			this.text_dehack_fail = "" + this.name + " does not seem to respond to your repair code!";
			return;
		}

		// Function from file: cleanbot.dm
		public override void bot_reset(  ) {
			base.bot_reset();
			this.ignore_list = new ByTable();
			this.target = null;
			this.oldloc = null;
			return;
		}

		// Function from file: cleanbot.dm
		public override void turn_off(  ) {
			base.turn_off();
			this.icon_state = "cleanbot" + this.on;
			((Obj)this.bot_core).updateUsrDialog();
			return;
		}

		// Function from file: cleanbot.dm
		public override bool turn_on(  ) {
			base.turn_on();
			this.icon_state = "cleanbot" + this.on;
			((Obj)this.bot_core).updateUsrDialog();
			return false;
		}

	}

}