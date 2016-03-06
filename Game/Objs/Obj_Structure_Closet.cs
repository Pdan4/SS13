// FILE AUTOGENERATED BY SOMNIUM13.

using System;
using Somnium.Engine.ByImpl;

namespace Somnium.Game {
	class Obj_Structure_Closet : Obj_Structure {

		public string icon_door = null;
		public bool icon_door_override = false;
		public bool secure = false;
		public bool opened = false;
		public bool welded = false;
		public bool locked = false;
		public bool broken = false;
		public bool large = true;
		public bool wall_mounted = false;
		public double health = 100;
		public int breakout_time = 2;
		public int lastbang = 0;
		public bool can_weld_shut = true;
		public bool horizontal = false;
		public bool allow_objects = false;
		public bool allow_dense = false;
		public int max_mob_size = 2;
		public int mob_storage_capacity = 3;
		public int storage_capacity = 30;
		public Type cutting_tool = typeof(Obj_Item_Weapon_Weldingtool);
		public string open_sound = "sound/machines/click.ogg";
		public string close_sound = "sound/machines/click.ogg";
		public string cutting_sound = "sound/items/welder.ogg";
		public Type material_drop = typeof(Obj_Item_Stack_Sheet_Metal);

		protected override void __FieldInit() {
			base.__FieldInit();

			this.icon = "icons/obj/closet.dmi";
			this.icon_state = "generic";
		}

		// Function from file: closets.dm
		public Obj_Structure_Closet ( dynamic loc = null ) : base( (object)(loc) ) {
			// Warning: Super call was HERE! If anything above HERE is needed by the super call, it might break!;
			this.update_icon();
			return;
		}

		// Function from file: closets.dm
		public override double emp_act( int severity = 0 ) {
			Obj O = null;

			
			foreach (dynamic _a in Lang13.Enumerate( this, typeof(Obj) )) {
				O = _a;
				
				O.emp_act( severity );
			}

			if ( this.secure && !this.broken ) {
				
				if ( Rand13.PercentChance( ((int)( 50 / severity )) ) ) {
					this.locked = !this.locked;
					this.update_icon();
				}

				if ( Rand13.PercentChance( ((int)( 20 / severity )) ) && !this.opened ) {
					
					if ( !this.locked ) {
						this.open();
					} else {
						this.req_access = new ByTable();
						this.req_access += Rand13.PickFromTable( GlobalFuncs.get_all_accesses() );
					}
				}
			}
			base.emp_act( severity );
			return 0;
		}

		// Function from file: closets.dm
		public override void get_remote_view_fullscreens( Mob_Living user = null ) {
			
			if ( user.stat == 2 || !( ( user.sight & 12 ) != 0 ) ) {
				user.overlay_fullscreen( "remote_view", typeof(Obj_Screen_Fullscreen_Impaired), 1 );
			}
			return;
		}

		// Function from file: closets.dm
		public override bool emag_act( dynamic user = null ) {
			
			if ( this.secure && !this.broken ) {
				((Ent_Static)user).visible_message( "<span class='warning'>Sparks fly from " + this + "!</span>", "<span class='warning'>You scramble " + this + "'s lock, breaking it open!</span>", "<span class='italics'>You hear a faint electrical spark.</span>" );
				GlobalFuncs.playsound( this.loc, "sound/effects/sparks4.ogg", 50, 1 );
				this.broken = true;
				this.locked = false;
				this.update_icon();
			}
			return false;
		}

		// Function from file: closets.dm
		public override bool AltClick( Mob user = null ) {
			base.AltClick( user );

			if ( !user.canUseTopic( user ) ) {
				user.WriteMsg( "<span class='warning'>You can't do that right now!</span>" );
				return false;
			}

			if ( this.opened || !this.secure || !( Map13.GetDistance( this, user ) <= 1 ) ) {
				return false;
			} else {
				this.togglelock( user );
			}
			return false;
		}

		// Function from file: closets.dm
		public override void container_resist( Mob user = null ) {
			Ent_Static D = null;

			
			if ( this.opened || !this.welded && !this.locked && !( this.loc is Obj_Mecha ) ) {
				return;
			}
			user.changeNext_move( 100 );
			((dynamic)user).last_special = Game13.time + 100;
			user.visible_message( "<span class='warning'>" + this + " begins to shake violently!</span>", "<span class='notice'>You lean on the back of " + this + " and start pushing the door open.</span>" );

			if ( GlobalFuncs.do_after( user, this.breakout_time * 600, null, this ) ) {
				
				if ( !( user != null ) || user.stat != 0 || user.loc != this || this.opened || !this.locked && !this.welded && !( this.loc is Obj_Mecha ) ) {
					return;
				}
				this.welded = false;
				this.locked = false;
				this.broken = true;
				user.visible_message( "<span class='danger'>" + user + " successfully broke out of " + this + "!</span>", "<span class='notice'>You successfully break out of " + this + "!</span>" );

				if ( this.loc is Obj_Structure_BigDelivery ) {
					D = this.loc;
					GlobalFuncs.qdel( D );
				} else if ( this.loc is Obj_Mecha ) {
					this.loc = GlobalFuncs.get_turf( this.loc );
				}
				this.open();
			} else {
				user.WriteMsg( "<span class='warning'>You fail to break out of " + this + "!</span>" );
			}
			return;
		}

		// Function from file: closets.dm
		public override bool Exit( Ent_Dynamic O = null, Ent_Static newloc = null ) {
			this.open();

			if ( O.loc == this ) {
				return false;
			}
			return true;
		}

		// Function from file: closets.dm
		public override dynamic attack_self_tk( dynamic user = null ) {
			return this.attack_hand( user );
		}

		// Function from file: closets.dm
		public override dynamic attack_hand( dynamic a = null, bool? b = null, bool? c = null ) {
			this.add_fingerprint( a );

			if ( Lang13.Bool( a.lying ) && Map13.GetDistance( this, a ) > 0 ) {
				return null;
			}

			if ( !this.toggle() ) {
				this.togglelock( a );
				return null;
			}
			return null;
		}

		// Function from file: closets.dm
		public override bool relaymove( Mob user = null, int? direction = null ) {
			dynamic M = null;

			
			if ( user.stat != 0 || !( this.loc is Tile ) ) {
				return false;
			}

			if ( !this.open() ) {
				this.container_resist();

				if ( Game13.time > this.lastbang + 5 ) {
					this.lastbang = Game13.time;

					foreach (dynamic _a in Lang13.Enumerate( GlobalFuncs.get_hearers_in_view( this, null ) )) {
						M = _a;
						
						M.show_message( "<FONT size=" + Num13.MaxInt( 0, 5 - Map13.GetDistance( this, M ) ) + ">BANG, bang!</FONT>", 2 );
					}
				}
			}
			return false;
		}

		// Function from file: closets.dm
		public override bool MouseDrop_T( Ent_Static dropping = null, Mob user = null ) {
			Ent_Static L = null;

			
			if ( !( dropping is Ent_Dynamic ) || Lang13.Bool( ((dynamic)dropping).anchored ) || dropping is Obj_Screen ) {
				return false;
			}

			if ( user.incapacitated() || Lang13.Bool( user.lying ) ) {
				return false;
			}

			if ( !this.Adjacent( user ) || !user.Adjacent( dropping ) ) {
				return false;
			}

			if ( !this.opened || dropping is Obj_Structure_Closet ) {
				return false;
			}

			if ( user == dropping ) {
				return false;
			}
			this.add_fingerprint( user );
			user.visible_message( "<span class='warning'>" + user + " tries to stuff " + dropping + " into " + this + ".</span>", "<span class='warning'>You try to stuff " + dropping + " into " + this + ".</span>", "<span class='italics'>You hear clanging.</span>" );

			if ( GlobalFuncs.do_after( user, 40, null, this ) ) {
				user.visible_message( "<span class='notice'>" + user + " stuffs " + dropping + " into " + this + ".</span>", "<span class='notice'>You stuff " + dropping + " into " + this + ".</span>", "<span class='italics'>You hear a loud metal bang.</span>" );
				L = dropping;

				if ( L is Mob_Living ) {
					((dynamic)L).Weaken( 2 );
				}
				Map13.StepTowardsSimple( (Ent_Dynamic)(dropping), this.loc );
				this.close();
			}
			return true;
		}

		// Function from file: closets.dm
		public override dynamic attackby( dynamic A = null, dynamic user = null, string _params = null, bool? silent = null, bool? replace_spent = null ) {
			dynamic WT = null;
			dynamic T = null;
			dynamic WT2 = null;

			
			if ( Lang13.Bool( ((dynamic)this).Contains( user ) ) ) {
				return null;
			}

			if ( this.opened ) {
				
				if ( Lang13.Bool( ((dynamic)this.cutting_tool).IsInstanceOfType( A ) ) ) {
					
					if ( A is Obj_Item_Weapon_Weldingtool ) {
						WT = A;

						if ( !((Obj_Item_Weapon_Weldingtool)WT).remove_fuel( 0, user ) ) {
							return null;
						}
						user.WriteMsg( new Txt( "<span class='notice'>You begin cutting " ).the( this ).item().str( " apart...</span>" ).ToString() );
						GlobalFuncs.playsound( this.loc, this.cutting_sound, 40, 1 );

						if ( GlobalFuncs.do_after( user, 40 / WT.toolspeed, true, this ) ) {
							
							if ( !this.opened || !((Obj_Item_Weapon_Weldingtool)WT).isOn() ) {
								return null;
							}
							GlobalFuncs.playsound( this.loc, this.cutting_sound, 50, 1 );
							this.visible_message( new Txt( "<span class='notice'>" ).item( user ).str( " slices apart " ).the( this ).item().str( ".</span>" ).ToString(), new Txt( "<span class='notice'>You cut " ).the( this ).item().str( " apart with " ).the( WT ).item().str( ".</span>" ).ToString(), "<span class='italics'>You hear welding.</span>" );
							T = GlobalFuncs.get_turf( this );
							Lang13.Call( this.material_drop, T );
							GlobalFuncs.qdel( this );
						}
					}
				} else if ( Lang13.Bool( user.drop_item() ) ) {
					A.Move( this.loc );
				}
			} else if ( A is Obj_Item_Stack_PackageWrap ) {
				return null;
			} else if ( A is Obj_Item_Weapon_Weldingtool && this.can_weld_shut ) {
				WT2 = A;

				if ( !((Obj_Item_Weapon_Weldingtool)WT2).remove_fuel( 0, user ) ) {
					return null;
				}
				user.WriteMsg( new Txt( "<span class='notice'>You begin " ).item( ( this.welded ? "unwelding" : "welding" ) ).str( " " ).the( this ).item().str( "...</span>" ).ToString() );
				GlobalFuncs.playsound( this.loc, "sound/items/welder2.ogg", 40, 1 );

				if ( GlobalFuncs.do_after( user, 40 / WT2.toolspeed, true, this ) ) {
					
					if ( this.opened || !((Obj_Item_Weapon_Weldingtool)WT2).isOn() ) {
						return null;
					}
					GlobalFuncs.playsound( this.loc, "sound/items/welder.ogg", 50, 1 );
					this.welded = !this.welded;
					this.visible_message( new Txt( "<span class='notice'>" ).item( user ).str( " " ).item( ( this.welded ? "welds shut" : "unweldeds" ) ).str( " " ).the( this ).item().str( ".</span>" ).ToString(), new Txt( "<span class='notice'>You " ).item( ( this.welded ? "weld" : "unwelded" ) ).str( " " ).the( this ).item().str( " with " ).the( WT2 ).item().str( ".</span>" ).ToString(), "<span class='italics'>You hear welding.</span>" );
					this.update_icon();
				}
			} else {
				this.togglelock( user );
			}
			return null;
		}

		// Function from file: closets.dm
		public override bool blob_act( dynamic severity = null ) {
			
			if ( Rand13.PercentChance( 75 ) ) {
				GlobalFuncs.qdel( this );
			}
			return false;
		}

		// Function from file: closets.dm
		public override bool attack_animal( Mob_Living user = null ) {
			
			if ( Lang13.Bool( ((dynamic)user).environment_smash ) ) {
				user.do_attack_animation( this );
				this.visible_message( new Txt( "<span class='danger'>" ).item( user ).str( " destroys " ).the( this ).item().str( ".</span>" ).ToString() );
				GlobalFuncs.qdel( this );
			}
			return false;
		}

		// Function from file: closets.dm
		public override dynamic bullet_act( dynamic P = null, dynamic def_zone = null ) {
			base.bullet_act( (object)(P), (object)(def_zone) );

			if ( P.damage_type == "brute" || P.damage_type == "fire" ) {
				this.health -= Convert.ToDouble( P.damage );

				if ( this.health <= 0 ) {
					GlobalFuncs.qdel( this );
				}
			}
			return null;
		}

		// Function from file: closets.dm
		public override bool ex_act( double? severity = null, dynamic target = null ) {
			this.contents_explosion( severity, target );

			if ( this.loc != null && this.material_drop is Type && !Lang13.Bool( this.flags & 128 ) ) {
				Lang13.Call( this.material_drop, this.loc );
			}
			GlobalFuncs.qdel( this );
			base.ex_act( severity, (object)(target) );
			return false;
		}

		// Function from file: closets.dm
		public virtual void togglelock( dynamic user = null ) {
			
			if ( this.secure && !this.broken ) {
				
				if ( this.allowed( user ) ) {
					this.add_fingerprint( user );
					this.locked = !this.locked;
					((Ent_Static)user).visible_message( "<span class='notice'>" + user + " " + ( this.locked ? null : "un" ) + "locks " + this + ".</span>", "<span class='notice'>You " + ( this.locked ? null : "un" ) + "locks " + this + ".</span>" );
					this.update_icon();
				} else {
					user.WriteMsg( "<span class='notice'>Access Denied</span>" );
				}
			} else if ( this.secure && this.broken ) {
				user.WriteMsg( new Txt( "<span class='warning'>" ).The( this ).item().str( " is broken!</span>" ).ToString() );
			}
			return;
		}

		// Function from file: closets.dm
		public virtual bool toggle(  ) {
			
			if ( this.opened ) {
				return this.close();
			} else {
				return this.open();
			}
		}

		// Function from file: closets.dm
		public virtual bool close(  ) {
			
			if ( !this.opened || !this.can_close() ) {
				return false;
			}
			this.take_contents();
			GlobalFuncs.playsound( this.loc, this.close_sound, 15, 1, -3 );
			this.opened = false;
			this.density = true;
			this.update_icon();
			return true;
		}

		// Function from file: closets.dm
		public virtual int insert( Ent_Dynamic AM = null ) {
			Ent_Dynamic L = null;
			int mobs_stored = 0;
			Mob_Living M = null;

			
			if ( this.contents.len >= this.storage_capacity ) {
				return -1;
			}
			L = AM;

			if ( L is Mob_Living ) {
				
				if ( Lang13.Bool( ((dynamic)L).buckled ) || Lang13.Bool( L.buckled_mob ) ) {
					return 0;
				}

				if ( Convert.ToDouble( ((dynamic)L).mob_size ) > 0 ) {
					
					if ( this.horizontal && !Lang13.Bool( ((dynamic)L).lying ) ) {
						return 0;
					}

					if ( Convert.ToDouble( ((dynamic)L).mob_size ) > this.max_mob_size ) {
						return 0;
					}
					mobs_stored = 0;

					foreach (dynamic _a in Lang13.Enumerate( this.contents, typeof(Mob_Living) )) {
						M = _a;
						

						if ( ++mobs_stored >= this.mob_storage_capacity ) {
							return 0;
						}
					}
				}
				L.__CallVerb("Stop Pulling" );
			} else if ( AM is Obj_Structure_Closet ) {
				return 0;
			} else if ( AM is Obj ) {
				
				if ( !this.allow_objects && !( AM is Obj_Item ) && !( AM is Obj_Effect_Dummy_Chameleon ) ) {
					return 0;
				}

				if ( !this.allow_dense && AM.density ) {
					return 0;
				}

				if ( Lang13.Bool( AM.anchored ) || Lang13.Bool( AM.buckled_mob ) || Lang13.Bool( AM.flags & 2 ) ) {
					return 0;
				}
			}
			AM.forceMove( this );

			if ( AM.pulledby != null ) {
				AM.pulledby.__CallVerb("Stop Pulling" );
			}
			return 1;
		}

		// Function from file: closets.dm
		public virtual bool open(  ) {
			
			if ( this.opened || !this.can_open() ) {
				return false;
			}
			GlobalFuncs.playsound( this.loc, this.open_sound, 15, 1, -3 );
			this.opened = true;
			this.density = false;
			this.dump_contents();
			this.update_icon();
			return true;
		}

		// Function from file: closets.dm
		public virtual void take_contents(  ) {
			dynamic T = null;
			Ent_Dynamic AM = null;

			T = GlobalFuncs.get_turf( this );

			foreach (dynamic _a in Lang13.Enumerate( T, typeof(Ent_Dynamic) )) {
				AM = _a;
				

				if ( this.insert( AM ) == -1 ) {
					break;
				}
			}
			return;
		}

		// Function from file: closets.dm
		public virtual void dump_contents(  ) {
			dynamic T = null;
			Ent_Dynamic AM = null;

			T = GlobalFuncs.get_turf( this );

			foreach (dynamic _a in Lang13.Enumerate( this, typeof(Ent_Dynamic) )) {
				AM = _a;
				
				AM.forceMove( T );

				if ( this.throwing ) {
					Map13.Step( AM, this.dir );
				}
			}

			if ( this.throwing ) {
				this.throwing = false;
			}
			return;
		}

		// Function from file: closets.dm
		public bool can_close(  ) {
			Obj_Structure_Closet closet = null;

			
			foreach (dynamic _a in Lang13.Enumerate( GlobalFuncs.get_turf( this ), typeof(Obj_Structure_Closet) )) {
				closet = _a;
				

				if ( closet != this && !closet.wall_mounted ) {
					return false;
				}
			}
			return true;
		}

		// Function from file: closets.dm
		public bool can_open(  ) {
			
			if ( this.welded || this.locked ) {
				return false;
			}
			return true;
		}

		// Function from file: closets.dm
		public override bool CanPass( dynamic mover = null, dynamic target = null, double? height = null, bool? air_group = null ) {
			height = height ?? 0;

			
			if ( height == 0 || this.wall_mounted ) {
				return true;
			}
			return !this.density;
		}

		// Function from file: closets.dm
		public override dynamic alter_health(  ) {
			return GlobalFuncs.get_turf( this );
		}

		// Function from file: closets.dm
		public override double examine( dynamic user = null ) {
			base.examine( (object)(user) );

			if ( this.broken ) {
				user.WriteMsg( "<span class='notice'>It appears to be broken.</span>" );
			} else if ( this.secure && !this.opened ) {
				user.WriteMsg( "<span class='notice'>Alt-click to " + ( this.locked ? "unlock" : "lock" ) + ".</span>" );
			}
			return 0;
		}

		// Function from file: closets.dm
		public override bool update_icon( dynamic new_state = null, dynamic new_icon = null, int? new_px = null, int? new_py = null ) {
			this.overlays.Cut();

			if ( !this.opened ) {
				
				if ( Lang13.Bool( this.icon_door ) ) {
					this.overlays.Add( "" + this.icon_door + "_door" );
				} else {
					this.overlays.Add( "" + this.icon_state + "_door" );
				}

				if ( this.welded ) {
					this.overlays.Add( "welded" );
				}

				if ( this.secure ) {
					
					if ( !this.broken ) {
						
						if ( this.locked ) {
							this.overlays.Add( "locked" );
						} else {
							this.overlays.Add( "unlocked" );
						}
					} else {
						this.overlays.Add( "off" );
					}
				}
			} else if ( this.icon_door_override ) {
				this.overlays.Add( "" + this.icon_door + "_open" );
			} else {
				this.overlays.Add( "" + this.icon_state + "_open" );
			}
			return false;
		}

		// Function from file: closets.dm
		public override dynamic Destroy(  ) {
			this.dump_contents();
			return base.Destroy();
		}

		// Function from file: closets.dm
		public override void initialize(  ) {
			base.initialize();

			if ( !this.opened ) {
				this.take_contents();
			}
			return;
		}

		// Function from file: closets.dm
		[Verb]
		[VerbInfo( name: "Toggle Open", group: "Object", access: VerbAccess.InViewExcludeThis, range: 1 )]
		public virtual void verb_toggleopen(  ) {
			
			if ( !Task13.User.canmove || Task13.User.stat != 0 || Task13.User.restrained() ) {
				return;
			}

			if ( Task13.User is Mob_Living_Carbon || Task13.User is Mob_Living_Silicon ) {
				this.attack_hand( Task13.User );
			} else {
				Task13.User.WriteMsg( "<span class='warning'>This mob type can't use this verb.</span>" );
			}
			return;
		}

	}

}