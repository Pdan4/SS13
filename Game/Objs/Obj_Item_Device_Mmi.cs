// FILE AUTOGENERATED BY SOMNIUM13.

using System;
using Somnium.Engine.ByImpl;

namespace Somnium.Game {
	class Obj_Item_Device_Mmi : Obj_Item_Device {

		public ByTable mommi_assembly_parts = new ByTable()
											.Set( typeof(Obj_Item_Weapon_Cell), 1 )
											.Set( typeof(Obj_Item_RobotParts_LLeg), 2 )
											.Set( typeof(Obj_Item_RobotParts_RLeg), 2 )
											.Set( typeof(Obj_Item_RobotParts_RArm), 1 )
											.Set( typeof(Obj_Item_RobotParts_LArm), 1 )
										;
		public int locked = 0;
		public Mob_Living_Carbon_Brain brainmob = null;
		public dynamic robot = null;
		public Obj_Mecha mecha = null;

		protected override void __FieldInit() {
			base.__FieldInit();

			this.origin_tech = "biotech=3";
			this.req_access = new ByTable(new object [] { 29 });
			this.icon = "icons/obj/assemblies.dmi";
			this.icon_state = "mmi_empty";
		}

		public Obj_Item_Device_Mmi ( dynamic loc = null ) : base( (object)(loc) ) {
			
		}

		// Function from file: MMI.dm
		public override void OnMobDeath( Mob holder = null ) {
			this.icon_state = "mmi_dead";
			this.visible_message( "<span class='danger'>" + holder + "'s MMI flatlines!</span>", null, "<span class='warning'>You hear something flatline.</span>" );
			return;
		}

		// Function from file: MMI.dm
		public override dynamic examine( dynamic user = null, string size = null ) {
			GlobalFuncs.to_chat( user, "<span class='info'>*---------*</span>" );
			base.examine( (object)(user), size );

			if ( this.locked != 2 ) {
				
				if ( this.brainmob != null ) {
					
					if ( this.brainmob.stat == 2 ) {
						GlobalFuncs.to_chat( user, "<span class='deadsay'>It appears the brain has suffered irreversible tissue degeneration</span>" );
					} else if ( !( this.brainmob.client != null ) ) {
						GlobalFuncs.to_chat( user, "<span class='notice'>It appears to be lost in its own thoughts</span>" );
					} else if ( !Lang13.Bool( this.brainmob.key ) ) {
						GlobalFuncs.to_chat( user, "<span class='warning'>It seems to be in a deep dream-state</span>" );
					}
				}
				GlobalFuncs.to_chat( user, "<span class='info'>It's interface is " + ( this.locked != 0 ? "locked" : "unlocked" ) + " </span>" );
			}
			GlobalFuncs.to_chat( user, "<span class='info'>*---------*</span>" );
			return null;
		}

		// Function from file: MMI.dm
		public override dynamic emp_act( int severity = 0 ) {
			
			if ( !( this.brainmob != null ) ) {
				return null;
			} else {
				
				switch ((int)( severity )) {
					case 1:
						this.brainmob.emp_damage += Rand13.Int( 20, 30 );
						break;
					case 2:
						this.brainmob.emp_damage += Rand13.Int( 10, 20 );
						break;
					case 3:
						this.brainmob.emp_damage += Rand13.Int( 0, 10 );
						break;
				}
			}
			base.emp_act( severity );
			return null;
		}

		// Function from file: MMI.dm
		public override dynamic attack_self( dynamic user = null, dynamic flag = null, bool? emp = null ) {
			Obj_Item_Organ_Brain brain = null;

			
			if ( !( this.brainmob != null ) ) {
				GlobalFuncs.to_chat( user, new Txt( "<span class='warning'>You upend " ).the( this ).item().str( ", but there's nothing in it." ).ToString() );
			} else if ( this.locked != 0 ) {
				GlobalFuncs.to_chat( user, new Txt( "<span class='warning'>You upend " ).the( this ).item().str( ", but the brain is clamped into place." ).ToString() );
			} else {
				GlobalFuncs.to_chat( user, new Txt( "<span class='notice'>You upend " ).the( this ).item().str( ", spilling the brain onto the floor.</span>" ).ToString() );
				brain = new Obj_Item_Organ_Brain( user.loc );
				this.brainmob.container = null;
				this.brainmob.loc = brain;
				GlobalVars.living_mob_list.Remove( this.brainmob );
				brain.brainmob = this.brainmob;
				this.brainmob = null;
				this.icon_state = "mmi_empty";
				this.name = Lang13.Initial( this, "name" );
			}
			return null;
		}

		// Function from file: MMI.dm
		public override dynamic attackby( dynamic a = null, dynamic b = null, dynamic c = null ) {
			dynamic BO = null;
			dynamic BM = null;

			
			if ( this.try_handling_mommi_construction( a, b ) == true ) {
				return null;
			}

			if ( a is Obj_Item_Organ_Brain && !( this.brainmob != null ) ) {
				
				if ( a is Obj_Item_Organ_Brain_Mami ) {
					GlobalFuncs.to_chat( b, "<span class='warning'>You are only able to fit organic brains on a MMI. " + this + " won't work.</span>" );
					return null;
				}
				BO = a;

				if ( !Lang13.Bool( BO.brainmob ) ) {
					GlobalFuncs.to_chat( b, "<span class='warning'>You aren't sure where this brain came from, but you're pretty sure it's a useless brain.</span>" );
					return null;
				}
				BM = BO.brainmob;

				if ( !Lang13.Bool( BM.client ) ) {
					GlobalFuncs.to_chat( b, new Txt( "<span class='notice'>" ).The( this ).item().str( " indicates that their mind is completely unresponsive; there's no point.</span>" ).ToString() );
					return null;
				}

				if ( !Lang13.Bool( b.drop_item( a ) ) ) {
					GlobalFuncs.to_chat( b, new Txt( "<span class='warning'>You can't let go of " ).the( a ).item().str( "!</span>" ).ToString() );
					return null;
				}
				this.visible_message( new Txt( "<span class='notice'>" ).item( b ).str( " sticks " ).a( a ).item().str( " into " ).the( this ).item().str( ".</span>" ).ToString() );
				this.brainmob = BO.brainmob;
				BO.brainmob = null;
				this.brainmob.loc = this;
				this.brainmob.container = this;
				this.brainmob.stat = 0;
				this.brainmob.resurrect();
				GlobalFuncs.qdel( a );
				a = null;
				this.name = "" + Lang13.Initial( this, "name" ) + ": " + this.brainmob.real_name;
				this.icon_state = "mmi_full";
				this.locked = 1;
				GlobalFuncs.feedback_inc( "cyborg_mmis_filled", 1 );
				return null;
			}

			if ( ( a is Obj_Item_Weapon_Card_Id || a is Obj_Item_Device_Pda ) && this.brainmob != null ) {
				
				if ( this.allowed( b ) ) {
					this.locked = !( this.locked != 0 ) ?1:0;
					GlobalFuncs.to_chat( b, new Txt( "<span class='notice'>You " ).item( ( this.locked != 0 ? "lock" : "unlock" ) ).str( " " ).the( this ).item().str( ".</span>" ).ToString() );
				} else {
					GlobalFuncs.to_chat( b, "<span class='warning'>Access denied.</span>" );
				}
				return null;
			}

			if ( a is Obj_Item_Weapon_Implanter ) {
				return null;
			}

			if ( this.brainmob != null ) {
				a.attack( this.brainmob, b );
				return null;
			}
			base.attackby( (object)(a), (object)(b), (object)(c) );
			return null;
		}

		// Function from file: MMI.dm
		public int contents_count( dynamic type = null ) {
			int c = 0;
			dynamic O = null;

			c = 0;

			foreach (dynamic _a in Lang13.Enumerate( this.contents )) {
				O = _a;
				

				if ( Lang13.Bool( type.IsInstanceOfType( O ) ) ) {
					c++;
				}
			}
			return c;
		}

		// Function from file: MMI.dm
		public void transfer_identity( dynamic H = null ) {
			this.brainmob = new Mob_Living_Carbon_Brain( this );
			this.brainmob.name = H.real_name;
			this.brainmob.real_name = H.real_name;

			if ( H is Mob_Living_Carbon_Human && Lang13.Bool( H.dna ) ) {
				this.brainmob.dna = ((Dna)H.dna).Clone();
			}
			this.brainmob.container = this;
			this.name = "Man-Machine Interface: " + this.brainmob.real_name;
			this.icon_state = "mmi_full";
			this.locked = 1;
			return;
		}

		// Function from file: MMI.dm
		public bool? try_handling_mommi_construction( dynamic O = null, dynamic user = null ) {
			dynamic t = null;
			int cc = 0;
			int req = 0;
			dynamic temppart = null;
			Mob_Living_Silicon_Robot_Mommi M = null;
			dynamic t2 = null;
			int cc2 = 0;

			
			if ( O is Obj_Item_Weapon_Screwdriver ) {
				
				foreach (dynamic _a in Lang13.Enumerate( this.mommi_assembly_parts )) {
					t = _a;
					
					cc = this.contents_count( t );
					req = Convert.ToInt32( this.mommi_assembly_parts[t] );

					if ( cc < req ) {
						temppart = Lang13.Call( t, this );
						GlobalFuncs.to_chat( user, new Txt( "<span class='warning'>You're short " ).item( req - cc ).str( " " ).item( temppart ).s().str( ".</span>" ).ToString() );
						GlobalFuncs.qdel( temppart );
						temppart = null;
						return GlobalVars.TRUE;
					}
				}

				if ( !( this.loc is Tile ) ) {
					GlobalFuncs.to_chat( user, new Txt( "<span class='warning'>You can't assemble the MoMMI, " ).the( this ).item().str( " has to be standing on the ground (or a table) to be perfectly precise.</span>" ).ToString() );
					return GlobalVars.TRUE;
				}

				if ( !( this.brainmob != null ) ) {
					GlobalFuncs.to_chat( user, "<span class='warning'>What are you doing oh god put the brain back in.</span>" );
					return GlobalVars.TRUE;
				}

				if ( !Lang13.Bool( this.brainmob.key ) ) {
					
					if ( !( GlobalFuncs.mind_can_reenter( this.brainmob.mind ) == true ) ) {
						GlobalFuncs.to_chat( user, new Txt( "<span class='notice'>" ).The( this ).item().str( " indicates that their mind is completely unresponsive; there's no point.</span>" ).ToString() );
						return GlobalVars.TRUE;
					}
				}

				if ( this.brainmob.stat == 2 ) {
					GlobalFuncs.to_chat( user, "<span class='warning'>Yeah, good idea. Give something deader than the pizza in your fridge legs.  Mom would be so proud.</span>" );
					return GlobalVars.TRUE;
				}
				Interface13.Stat( null, GlobalVars.ticker.mode.head_revolutionaries.Contains( this.brainmob.mind ) );

				if ( this.brainmob.stat == 2 ) {
					GlobalFuncs.to_chat( user, "<span class='warning'>The " + this + "'s firmware lets out a shrill sound, and flashes 'Abnormal Memory Engram'. It refuses to accept the brain.</span>" );
					return GlobalVars.TRUE;
				}

				if ( Lang13.Bool( GlobalFuncs.jobban_isbanned( this.brainmob, "Mobile MMI" ) ) ) {
					GlobalFuncs.to_chat( user, "<span class='warning'>This brain does not seem to fit.</span>" );
					return GlobalVars.TRUE;
				}
				this.icon = null;
				this.invisibility = 101;
				M = new Mob_Living_Silicon_Robot_Mommi( GlobalFuncs.get_turf( this.loc ) );

				if ( !( M != null ) ) {
					return null;
				}
				M.invisibility = 0;
				M.__CallVerb("Namepick" );
				M.updatename();
				this.brainmob.mind.transfer_to( M );

				if ( M.mind != null && Lang13.Bool( M.mind.special_role ) ) {
					M.mind.store_memory( "In case you look at this after being borged, the objectives are only here until I find a way to make them not show up for you, as I can't simply delete them without screwing up round-end reporting. --NeoFite" );
				}
				M.job = "MoMMI";
				M.cell = Lang13.FindIn( typeof(Obj_Item_Weapon_Cell), this.contents );
				M.cell.loc = M;
				this.loc = M;
				M.mmi = this;
				return GlobalVars.TRUE;
			}

			foreach (dynamic _b in Lang13.Enumerate( this.mommi_assembly_parts )) {
				t2 = _b;
				

				if ( Lang13.Bool( t2.IsInstanceOfType( O ) ) ) {
					cc2 = this.contents_count( t2 );

					if ( cc2 < Convert.ToDouble( this.mommi_assembly_parts[t2] ) ) {
						
						if ( !( this.brainmob != null ) ) {
							GlobalFuncs.to_chat( user, "<span class='warning'>Why are you sticking robot legs on an empty " + this + ", you idiot?</span>" );
							return GlobalVars.TRUE;
						}

						if ( !Lang13.Bool( user.drop_item( O, this ) ) ) {
							GlobalFuncs.to_chat( user, new Txt( "<span class='warning'>You can't let go of " ).the( this ).item().str( "!</span>" ).ToString() );
							return GlobalVars.FALSE;
						}
						this.contents.Add( O );
						GlobalFuncs.to_chat( user, new Txt( "<span class='notice'>You successfully add " ).the( O ).item().str( " to the contraption,</span>" ).ToString() );
						return GlobalVars.TRUE;
					} else if ( cc2 == Convert.ToInt32( this.mommi_assembly_parts[t2] ) ) {
						GlobalFuncs.to_chat( user, "<span class='warning'>You have enough of these.</span>" );
						return GlobalVars.TRUE;
					}
				}
			}
			return GlobalVars.FALSE;
		}

		// Function from file: MMI.dm
		public override dynamic Destroy( dynamic brokenup = null ) {
			
			if ( this.brainmob != null ) {
				this.brainmob.ghostize();
			}
			base.Destroy( (object)(brokenup) );
			return null;
		}

	}

}