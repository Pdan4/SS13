// FILE AUTOGENERATED BY SOMNIUM13.

using System;
using Somnium.Engine.ByImpl;

namespace Somnium.Game {
	class Obj_Item_Device_Rcd : Obj_Item_Device {

		public RcdSchematic selected = null;
		public dynamic schematics = new ByTable(new object [] { typeof(RcdSchematic_Test) });
		public bool sparky = true;
		public bool busy = false;
		public HtmlInterface_Rcd v_interface = null;
		public Effect_Effect_System_SparkSpread spark_system = null;
		public dynamic closer = null;

		protected override void __FieldInit() {
			base.__FieldInit();

			this.force = 10;
			this.throwforce = 10;
			this.throw_speed = 1;
			this.throw_range = 5;
			this.starting_materials = new ByTable().Set( "$iron", 50000 );
			this.w_type = 5;
			this.melt_temperature = 1783.1500244140625;
			this.origin_tech = "engineering=4;materials=2";
			this.icon = "icons/obj/RCD.dmi";
			this.icon_state = "rcd";
		}

		// Function from file: RCD.dm
		public Obj_Item_Device_Rcd ( dynamic loc = null ) : base( (object)(loc) ) {
			// Warning: Super call was HERE! If anything above HERE is needed by the super call, it might break!;
			this.v_interface = new HtmlInterface_Rcd( this, GlobalFuncs.sanitize( this.name ) );
			this.init_schematics();
			this.rebuild_ui();
			this.spark_system = new Effect_Effect_System_SparkSpread();
			this.spark_system.set_up( 5, 0, this );
			this.spark_system.attach( this );
			return;
		}

		// Function from file: RCD.dm
		public override bool afterattack( dynamic A = null, dynamic user = null, bool? flag = null, dynamic _params = null, bool? struggle = null ) {
			dynamic t = null;

			
			if ( !( this.selected != null ) ) {
				return true;
			}

			if ( ( this.selected.flags ^ 5 ) != 0 && !( ((Ent_Static)user).Adjacent( A ) && ((Ent_Static)A).Adjacent( user ) ) ) {
				return true;
			}

			if ( ( this.selected.flags & 4 ) != 0 && ( this.selected.flags ^ 1 ) != 0 && Map13.GetDistance( A, user ) > 1 ) {
				return true;
			}

			if ( ( this.selected.flags & 2 ) != 0 ) {
				A = GlobalFuncs.get_turf( A );
			}

			if ( ( this.selected.flags ^ 1 ) != 0 && this.get_energy( user ) < this.selected.energy_cost ) {
				return true;
			}
			this.busy = true;
			t = this.selected.attack( A, user );

			if ( !Lang13.Bool( t ) ) {
				
				if ( ( this.selected.flags ^ 8 ) != 0 ) {
					this.use_energy( this.selected.energy_cost, user );
				}
			} else if ( t is string ) {
				GlobalFuncs.to_chat( user, new Txt( "<span class='warning'>" ).the( this ).item().str( "'s error light flickers: " ).item( t ).str( "</span>" ).ToString() );
			} else {
				GlobalFuncs.to_chat( user, new Txt( "<span class='warning'>" ).the( this ).item().str( "'s error light flickers.</span>" ).ToString() );
			}
			this.busy = false;
			return true;
		}

		// Function from file: RCD.dm
		public override dynamic Topic( string href = null, ByTable href_list = null, dynamic hclient = null, HtmlInterface currui = null ) {
			dynamic _default = null;

			dynamic L = null;
			RcdSchematic C = null;

			_default = base.Topic( href, href_list, (object)(hclient) );

			if ( Lang13.Bool( _default ) ) {
				return _default;
			}

			if ( Lang13.Bool( href_list["cat"] ) && Lang13.Bool( href_list["index"] ) && !this.busy ) {
				L = this.schematics[href_list["cat"]];

				if ( !Lang13.Bool( L ) ) {
					return 1;
				}
				C = L[( ( String13.ParseNumber( href_list["index"] ) ??0) <= 1 ? 1 : ( ( String13.ParseNumber( href_list["index"] ) ??0) >= L.len ? L.len : String13.ParseNumber( href_list["index"] ) ) )];

				if ( !( C is RcdSchematic ) ) {
					return 1;
				}

				if ( this.selected != null && !this.selected.deselect( Task13.User, C ) ) {
					return 1;
				}

				if ( !C.select( Task13.User, this.selected ) ) {
					return 1;
				}
				this.spark();
				this.selected = C;
				this.update_options_menu();
				this.v_interface.updateContent( "selectedname", this.selected.name );
				return 1;
			} else if ( this.selected != null ) {
				return this.selected.Topic( href, href_list );
			}
			return _default;
		}

		// Function from file: RCD.dm
		public override dynamic attack_self( dynamic user = null, dynamic flag = null, bool? emp = null ) {
			this.v_interface.show( user );
			return null;
		}

		// Function from file: RCD.dm
		public override dynamic dropped( dynamic user = null ) {
			base.dropped( (object)(user) );

			if ( user is Mob_Living ) {
				user.hud_used.toggle_show_schematics_display( null, true, this );
			}
			return null;
		}

		// Function from file: RCD.dm
		public override dynamic Destroy( dynamic brokenup = null ) {
			dynamic _default = null;

			dynamic cat = null;
			RcdSchematic C = null;

			
			foreach (dynamic _b in Lang13.Enumerate( this.schematics )) {
				cat = _b;
				

				foreach (dynamic _a in Lang13.Enumerate( this.schematics[cat], typeof(RcdSchematic) )) {
					C = _a;
					
					GlobalFuncs.qdel( C );
				}
			}
			this.schematics = null;
			GlobalFuncs.qdel( this.v_interface );
			GlobalFuncs.qdel( this.spark_system );
			this.v_interface = null;
			this.spark_system = null;
			_default = base.Destroy( (object)(brokenup) );
			return _default;
		}

		// Function from file: RCD.dm
		public void show_default( Mob user = null ) {
			
			if ( this.selected != null ) {
				
				if ( this.selected.show( user, true ) ) {
					return;
				}
			}
			user.hud_used.toggle_show_schematics_display( null, true, this );
			return;
		}

		// Function from file: RCD.dm
		public void update_options_menu( params object[] _ ) {
			ByTable _args = new ByTable( new object[] {  } ).Extend(_);

			dynamic client = null;

			
			if ( this.selected != null ) {
				
				foreach (dynamic _a in Lang13.Enumerate( this.v_interface.clients )) {
					client = _a;
					

					if ( !Lang13.Bool( ((dynamic)typeof(Client)).IsInstanceOfType( client ) ) ) {
						continue;
					}
					this.selected.send_assets( client );
				}
				this.v_interface.updateContent( "schematic_options", this.selected.get_HTML( _args ) );
			} else {
				this.v_interface.updateContent( "schematic_options", " " );
			}
			return;
		}

		// Function from file: RCD.dm
		public virtual void use_energy( double amount = 0, dynamic user = null ) {
			return;
		}

		// Function from file: RCD.dm
		public virtual double get_energy( dynamic user = null ) {
			return Double.PositiveInfinity;
		}

		// Function from file: RCD.dm
		public void spark(  ) {
			
			if ( this.sparky ) {
				this.spark_system.start();
			}
			return;
		}

		// Function from file: RCD.dm
		public virtual void rebuild_ui(  ) {
			string dat = null;
			dynamic cat = null;
			ByTable L = null;
			double i = 0;
			dynamic C = null;

			dat = "";
			dat += @"
	<b>Selected:</b> <span id=""selectedname""></span>
	<h2>Options</h2>
	<div id=""schematic_options"">
	</div>
	<h2>Available schematics</h2>
	";

			foreach (dynamic _b in Lang13.Enumerate( this.schematics )) {
				cat = _b;
				
				dat += "<b>" + cat + ":</b><ul style='list-style-type:disc'>";
				L = this.schematics[cat];

				foreach (dynamic _a in Lang13.IterateRange( 1, L.len )) {
					i = _a;
					
					C = L[i];
					dat += new Txt( "<li><a href='?src=" ).Ref( this.v_interface ).str( ";cat=" ).item( cat ).str( ";index=" ).item( i ).str( "'>" ).item( C.name ).str( "</a></li>" ).ToString();
				}
				dat += "</ul>";
			}
			this.v_interface.updateLayout( dat );

			if ( this.selected != null ) {
				this.update_options_menu();
				this.v_interface.updateContent( "selectedname", this.selected.name );
			}
			return;
		}

		// Function from file: RCD.dm
		public void init_schematics(  ) {
			dynamic old_schematics = null;
			dynamic path = null;
			dynamic C = null;

			old_schematics = this.schematics;
			this.schematics = new ByTable();

			foreach (dynamic _a in Lang13.Enumerate( old_schematics )) {
				path = _a;
				
				C = Lang13.Call( path, this );

				if ( !Lang13.Bool( this.schematics[C.category] ) ) {
					this.schematics[C.category] = new ByTable();
				}
				this.schematics[C.category] += C;
			}
			return;
		}

	}

}