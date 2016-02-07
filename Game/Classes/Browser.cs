// FILE AUTOGENERATED BY SOM13. DO NOT EDIT YET.

using System;
using Somnium.Engine.ByImpl;

namespace Somnium.Game {
	class Browser : Game_Data {

		public dynamic user = null;
		public dynamic title = null;
		public string window_id = null;
		public int? width = 0;
		public int? height = 0;
		public Game_Data v_ref = null;
		public string window_options = "can_close=1;can_minimize=1;can_maximize=0;can_resize=1;titlebar=1;";
		public ByTable stylesheets = new ByTable( 0 );
		public ByTable scripts = new ByTable( 0 );
		public dynamic title_image = null;
		public dynamic head_elements = null;
		public dynamic body_elements = null;
		public string head_content = "";
		public dynamic content = "";

		// Function from file: browser.dm
		public Browser ( dynamic nuser = null, string nwindow_id = null, dynamic ntitle = null, int? nwidth = null, int? nheight = null, Game_Data nref = null ) {
			ntitle = ntitle ?? 0;
			nwidth = nwidth ?? 0;
			nheight = nheight ?? 0;

			this.user = nuser;
			this.window_id = nwindow_id;

			if ( Lang13.Bool( ntitle ) ) {
				this.title = GlobalFuncs.format_text( ntitle );
			}

			if ( Lang13.Bool( nwidth ) ) {
				this.width = nwidth;
			}

			if ( Lang13.Bool( nheight ) ) {
				this.height = nheight;
			}

			if ( nref != null ) {
				this.v_ref = nref;
			}
			this.add_stylesheet( "common", "html/browser/common.css" );
			return;
		}

		// Function from file: browser.dm
		public virtual dynamic close(  ) {
			Interface13.Browse( this.user, null, "window=" + this.window_id );
			return null;
		}

		// Function from file: browser.dm
		public virtual dynamic open( bool? use_onclose = null ) {
			use_onclose = use_onclose ?? true;

			string window_size = null;
			double i = 0;

			window_size = "";

			if ( Lang13.Bool( this.width ) && Lang13.Bool( this.height ) ) {
				window_size = "size=" + this.width + "x" + this.height + ";";
			}
			Interface13.Browse( this.user, this.get_content(), "window=" + this.window_id + ";" + window_size + this.window_options );

			if ( use_onclose == true ) {
				Task13.Schedule( 0, (Task13.Closure)(() => {
					
					foreach (dynamic _a in Lang13.IterateRange( 1, 10 )) {
						i = _a;
						

						if ( Lang13.Bool( this.user ) && Interface13.WindowExists( this.user, this.window_id ) ) {
							GlobalFuncs.onclose( this.user, this.window_id, this.v_ref );
							break;
						}
					}
					return;
				}));
			}
			return null;
		}

		// Function from file: browser.dm
		public string get_content(  ) {
			return "\n	" + this.get_header() + "\n	" + this.content + "\n	" + this.get_footer() + "\n	";
		}

		// Function from file: browser.dm
		public string get_footer(  ) {
			return @"
			</div>
		</div>
	</body>
</html>";
		}

		// Function from file: browser.dm
		public string get_header(  ) {
			dynamic key = null;
			string filename = null;
			string title_attributes = null;

			
			foreach (dynamic _a in Lang13.Enumerate( this.stylesheets )) {
				key = _a;
				
				filename = "" + String13.CKey( key ) + ".css";
				Interface13.CacheBrowseResource( this.user, this.stylesheets[key], filename );
				this.head_content += "<link rel='stylesheet' type='text/css' href='" + filename + "'>";
			}

			foreach (dynamic _b in Lang13.Enumerate( this.scripts )) {
				key = _b;
				
				filename = "" + String13.CKey( key ) + ".js";
				Interface13.CacheBrowseResource( this.user, this.scripts[key], filename );
				this.head_content += "<script type='text/javascript' src='" + filename + "'></script>";
			}
			title_attributes = "class='uiTitle'";

			if ( Lang13.Bool( this.title_image ) ) {
				title_attributes = "class='uiTitle icon' style='background-image: url(" + this.title_image + ");'";
			}
			return @"<!DOCTYPE HTML PUBLIC ""-//W3C//DTD HTML 4.01 Transitional//EN"" ""http://www.w3.org/TR/html4/loose.dtd"">
<html>
	<meta http-equiv=""Content-Type"" content=""text/html; charset=ISO-8859-1"">
	<meta http-equiv=""X-UA-Compatible"" content=""IE=edge"">
	<head>
		" + this.head_content + @"
	</head>
	<body scroll=auto>
		<div class='uiWrapper'>
			" + ( Lang13.Bool( this.title ) ? "<div class='uiTitleWrapper'><div " + title_attributes + "><tt>" + this.title + "</tt></div></div>" : "" ) + "\n			<div class='uiContent'>\n	";
		}

		// Function from file: browser.dm
		public void add_content( dynamic ncontent = null ) {
			this.content += ncontent;
			return;
		}

		// Function from file: browser.dm
		public void set_content( dynamic ncontent = null ) {
			this.content = ncontent;
			return;
		}

		// Function from file: browser.dm
		public void add_script( dynamic name = null, dynamic file = null ) {
			this.scripts[name] = file;
			return;
		}

		// Function from file: browser.dm
		public void add_stylesheet( string name = null, string file = null ) {
			this.stylesheets[name] = file;
			return;
		}

		// Function from file: browser.dm
		public void set_title_image( dynamic ntitle_image = null ) {
			return;
		}

		// Function from file: browser.dm
		public void set_window_options( string nwindow_options = null ) {
			this.window_options = nwindow_options;
			return;
		}

		// Function from file: browser.dm
		public void add_head_content( string nhead_content = null ) {
			this.head_content = nhead_content;
			return;
		}

	}

}