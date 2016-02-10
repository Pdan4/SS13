// FILE AUTOGENERATED BY SOMNIUM13.

using System;
using Somnium.Engine.ByImpl;

namespace Somnium.Game {
	class RcdSchematic_Pipe : RcdSchematic {

		public int pipe_id = 0;
		public int pipe_type = 0;
		public double? selected_dir = 1;
		public int layer = 3;

		protected override void __FieldInit() {
			base.__FieldInit();

			this.name = "Pipe";
			this.category = "Regular pipes";
			this.flags = 6;
		}

		// Function from file: pipe.dm
		public RcdSchematic_Pipe ( dynamic n_master = null ) : base( (object)(n_master) ) {
			// Warning: Super call was HERE! If anything above HERE is needed by the super call, it might break!;

			if ( Lang13.Bool( n_master ) ) {
				this.selected_dir = this.get_base_dir();
			}
			return;
		}

		// Function from file: pipe.dm
		public override bool select( Mob user = null, RcdSchematic old_schematic = null ) {
			RcdSchematic P = null;

			
			if ( !( old_schematic is RcdSchematic_Pipe ) ) {
				return base.select( user, old_schematic );
			}
			P = old_schematic;

			if ( Lang13.Bool( ((dynamic)P).layer ) ) {
				this.layer = Convert.ToInt32( ((dynamic)P).layer );
			}
			return base.select( user, old_schematic );
		}

		// Function from file: pipe.dm
		public override dynamic attack( dynamic A = null, dynamic user = null ) {
			int thislayer = 0;
			double? thisdir = null;
			Game_Data P = null;

			GlobalFuncs.to_chat( user, "Building Pipes ..." );
			GlobalFuncs.playsound( GlobalFuncs.get_turf( user ), "sound/machines/click.ogg", 50, 1 );
			thislayer = this.layer;
			thisdir = this.selected_dir;

			if ( !GlobalFuncs.do_after( user, A, 20 ) ) {
				return 1;
			}
			GlobalFuncs.playsound( GlobalFuncs.get_turf( user ), "sound/items/Deconstruct.ogg", 50, 1 );
			P = GlobalFuncs.getFromPool( typeof(Obj_Item_Pipe), A, this.pipe_id, thisdir );
			((dynamic)P).setPipingLayer( thislayer );
			((Obj_Item_Pipe)P).update();
			((Ent_Static)P).add_fingerprint( user );
			return null;
		}

		// Function from file: pipe.dm
		public override dynamic Topic( string href = null, ByTable href_list = null, dynamic hclient = null, HtmlInterface currui = null ) {
			double? dir = null;
			int n_layer = 0;

			
			if ( Lang13.Bool( href_list["set_dir"] ) ) {
				dir = String13.ParseNumber( href_list["set_dir"] );
				Interface13.Stat( null, GlobalVars.alldirs.Contains( dir ) );

				if ( !false || this.selected_dir == dir ) {
					return 1;
				}
				this.selected_dir = dir;
				this.master.update_options_menu();
				return 1;
			}

			if ( Lang13.Bool( href_list["set_layer"] ) && this.layer != 0 ) {
				n_layer = ( Num13.Floor( String13.ParseNumber( href_list["set_layer"] ) ??0 ) <= 1 ? 1 : ( Num13.Floor( String13.ParseNumber( href_list["set_layer"] ) ??0 ) >= 5 ? 5 : Num13.Floor( String13.ParseNumber( href_list["set_layer"] ) ??0 ) ) );

				if ( this.layer == n_layer ) {
					return 1;
				}
				this.layer = n_layer;
				this.master.update_options_menu();
			}
			return null;
		}

		// Function from file: pipe.dm
		public override dynamic get_HTML( dynamic D = null ) {
			dynamic _default = null;

			_default += "<p>";
			_default += "<h4>Layers</h4>";

			if ( this.layer != 0 ) {
				_default += new Txt( "\n		<div class=\"layer_holder\">\n			<a class=\"no_dec\" href=\"?src=" ).Ref( this.master.v_interface ).str( ";set_layer=1\"><div class=\"layer vertical one 			" ).item( ( this.layer == 1 ? "selected" : "" ) ).str( "\"></div></a>\n			<a class=\"no_dec\" href=\"?src=" ).Ref( this.master.v_interface ).str( ";set_layer=2\"><div class=\"layer vertical two 			" ).item( ( this.layer == 2 ? "selected" : "" ) ).str( "\"></div></a>\n			<a class=\"no_dec\" href=\"?src=" ).Ref( this.master.v_interface ).str( ";set_layer=3\"><div class=\"layer vertical three 		" ).item( ( this.layer == 3 ? "selected" : "" ) ).str( "\"></div></a>\n			<a class=\"no_dec\" href=\"?src=" ).Ref( this.master.v_interface ).str( ";set_layer=4\"><div class=\"layer vertical four 			" ).item( ( this.layer == 4 ? "selected" : "" ) ).str( "\"></div></a>\n			<a class=\"no_dec\" href=\"?src=" ).Ref( this.master.v_interface ).str( ";set_layer=5\"><div class=\"layer vertical five 			" ).item( ( this.layer == 5 ? "selected" : "" ) ).str( @"""></div></a>
		</div>

		<div class=""layer_holder"" style=""left: 200px;"">
			<a class=""no_dec"" href=""?src=" ).Ref( this.master.v_interface ).str( ";set_layer=1\"><div class=\"layer horizontal one		" ).item( ( this.layer == 1 ? "selected" : "" ) ).str( "\"></div></a>\n			<a class=\"no_dec\" href=\"?src=" ).Ref( this.master.v_interface ).str( ";set_layer=2\"><div class=\"layer horizontal two		" ).item( ( this.layer == 2 ? "selected" : "" ) ).str( "\"></div></a>\n			<a class=\"no_dec\" href=\"?src=" ).Ref( this.master.v_interface ).str( ";set_layer=3\"><div class=\"layer horizontal three		" ).item( ( this.layer == 3 ? "selected" : "" ) ).str( "\"></div></a>\n			<a class=\"no_dec\" href=\"?src=" ).Ref( this.master.v_interface ).str( ";set_layer=4\"><div class=\"layer horizontal four		" ).item( ( this.layer == 4 ? "selected" : "" ) ).str( "\"></div></a>\n			<a class=\"no_dec\" href=\"?src=" ).Ref( this.master.v_interface ).str( ";set_layer=5\"><div class=\"layer horizontal five		" ).item( ( this.layer == 5 ? "selected" : "" ) ).str( "\"></div></a>\n		</div>\n\n	" ).ToString();
			}
			_default += "<h4>Directions</h4>";

			switch ((int)( this.pipe_type )) {
				case 0:
					_default += this.render_dir_image( GlobalVars.NORTH, "Vertical" );
					_default += this.render_dir_image( GlobalVars.EAST, "Horizontal" );
					break;
				case 4:
					_default += this.render_dir_image( GlobalVars.NORTH, "North" );
					_default += this.render_dir_image( GlobalVars.EAST, "East" );
					_default += this.render_dir_image( GlobalVars.SOUTH, "South" );
					_default += this.render_dir_image( GlobalVars.WEST, "West" );
					break;
				case 1:
					_default += this.render_dir_image( GlobalVars.NORTHWEST, "West to North" );
					_default += this.render_dir_image( GlobalVars.NORTHEAST, "North to East" );
					_default += "<br/>";
					_default += this.render_dir_image( GlobalVars.SOUTHWEST, "South to West" );
					_default += this.render_dir_image( GlobalVars.SOUTHEAST, "East to South" );
					break;
				case 2:
					_default += this.render_dir_image( GlobalVars.NORTH, "West South East" );
					_default += this.render_dir_image( GlobalVars.EAST, "North West South" );
					_default += "<br/>";
					_default += this.render_dir_image( GlobalVars.SOUTH, "East North West" );
					_default += this.render_dir_image( GlobalVars.WEST, "South East North" );
					break;
				case 3:
					_default += this.render_dir_image( GlobalVars.NORTH, "West South East" );
					_default += this.render_dir_image( GlobalVars.EAST, "North West South" );
					_default += "<br/>";
					_default += this.render_dir_image( GlobalVars.SOUTH, "East North West" );
					_default += this.render_dir_image( GlobalVars.WEST, "South East North" );
					_default += "<br/>";
					_default += this.render_dir_image( 6, "West South East" );
					_default += this.render_dir_image( 5, "North West South" );
					_default += "<br/>";
					_default += this.render_dir_image( 9, "East North West" );
					_default += this.render_dir_image( 10, "South East North" );
					break;
			}
			_default += "</p>";
			return _default;
		}

		// Function from file: pipe.dm
		public override void send_assets( dynamic client = null ) {
			ByTable dir_list = null;
			dynamic dir = null;

			dir_list = this.get_dirs();

			foreach (dynamic _a in Lang13.Enumerate( dir_list )) {
				dir = _a;
				
				this.send_icon( client, dir );
			}
			GlobalFuncs.send_asset( client, "RPD-layer-blended-1.png" );
			GlobalFuncs.send_asset( client, "RPD-layer-blended-4.png" );
			GlobalFuncs.send_asset( client, "RPD_0_4.png" );
			GlobalFuncs.send_asset( client, "RPD_0_1.png" );
			return;
		}

		// Function from file: pipe.dm
		public override void register_assets(  ) {
			ByTable dir_list = null;
			dynamic dir = null;

			dir_list = this.get_dirs();

			foreach (dynamic _a in Lang13.Enumerate( dir_list )) {
				dir = _a;
				
				this.register_icon( dir );
			}
			return;
		}

		// Function from file: pipe.dm
		public virtual string render_dir_image( double? dir = null, string title = null ) {
			string selected = null;

			selected = "";

			if ( this.selected_dir == dir ) {
				selected = " class='selected'";
			}
			return new Txt( "<a href='?src=" ).Ref( this.master.v_interface ).str( ";set_dir=" ).item( dir ).str( "'" ).item( selected ).str( " title='" ).item( title ).str( "'><img src='RPD_" ).item( this.pipe_id ).str( "_" ).item( dir ).str( ".png'/></a>" ).ToString();
		}

		// Function from file: pipe.dm
		public virtual void send_icon( dynamic client = null, dynamic dir = null ) {
			GlobalFuncs.send_asset( client, "RPD_" + this.pipe_id + "_" + dir + ".png" );
			return;
		}

		// Function from file: pipe.dm
		public virtual void register_icon( dynamic dir = null ) {
			GlobalFuncs.register_asset( "RPD_" + this.pipe_id + "_" + dir + ".png", new Icon( "icons/obj/pipe-item.dmi", GlobalVars.pipeID2State[this.pipe_id + 1], dir ) );
			return;
		}

		// Function from file: pipe.dm
		public ByTable get_dirs(  ) {
			ByTable _default = null;

			
			switch ((int)( this.pipe_type )) {
				case 4:
				case 2:
					_default = GlobalVars.cardinal;
					break;
				case 0:
					_default = new ByTable(new object [] { GlobalVars.NORTH, GlobalVars.EAST });
					break;
				case 1:
					_default = GlobalVars.diagonal;
					break;
				case 3:
					_default = GlobalVars.alldirs;
					break;
				default:
					_default = new ByTable();
					break;
			}
			return _default;
		}

		// Function from file: pipe.dm
		public double? get_base_dir(  ) {
			
			if ( this.pipe_type == 1 ) {
				return GlobalVars.NORTHEAST;
			}
			return GlobalVars.NORTH;
		}

	}

}