// FILE AUTOGENERATED BY SOMNIUM13.

using System;
using Somnium.Engine.ByImpl;

namespace Somnium.Game {
	class Obj_Machinery_Computer_Libraryconsole : Obj_Machinery_Computer {

		public int screenstate = 0;
		public string title = null;
		public string category = "Any";
		public string author = null;
		public string SQLquery = null;

		protected override void __FieldInit() {
			base.__FieldInit();

			this.icon_screen = "library";
			this.icon_keyboard = null;
			this.circuit = typeof(Obj_Item_Weapon_Circuitboard_Libraryconsole);
			this.icon_state = "oldcomp";
		}

		public Obj_Machinery_Computer_Libraryconsole ( dynamic location = null, dynamic C = null ) : base( (object)(location), (object)(C) ) {
			
		}

		// Function from file: lib_machines.dm
		public override dynamic Topic( string href = null, ByTable href_list = null, dynamic hsrc = null ) {
			dynamic _default = null;

			dynamic newtitle = null;
			dynamic newcategory = null;
			dynamic newauthor = null;

			_default = base.Topic( href, href_list, (object)(hsrc) );

			if ( Lang13.Bool( base.Topic( href, href_list, (object)(hsrc) ) ) ) {
				Interface13.Browse( Task13.User, null, "window=publiclibrary" );
				GlobalFuncs.onclose( Task13.User, "publiclibrary" );
				return _default;
			}

			if ( Lang13.Bool( href_list["settitle"] ) ) {
				newtitle = Interface13.Input( "Enter a title to search for:", null, null, null, null, InputType.Str | InputType.Null );

				if ( Lang13.Bool( newtitle ) ) {
					this.title = GlobalFuncs.sanitize( newtitle );
				} else {
					this.title = null;
				}
				this.title = GlobalFuncs.sanitizeSQL( this.title );
			}

			if ( Lang13.Bool( href_list["setcategory"] ) ) {
				newcategory = Interface13.Input( "Choose a category to search for:", null, null, null, new ByTable(new object [] { "Any", "Fiction", "Non-Fiction", "Adult", "Reference", "Religion" }), InputType.Any );

				if ( Lang13.Bool( newcategory ) ) {
					this.category = GlobalFuncs.sanitize( newcategory );
				} else {
					this.category = "Any";
				}
				this.category = GlobalFuncs.sanitizeSQL( this.category );
			}

			if ( Lang13.Bool( href_list["setauthor"] ) ) {
				newauthor = Interface13.Input( "Enter an author to search for:", null, null, null, null, InputType.Str | InputType.Null );

				if ( Lang13.Bool( newauthor ) ) {
					this.author = GlobalFuncs.sanitize( newauthor );
				} else {
					this.author = null;
				}
				this.author = GlobalFuncs.sanitizeSQL( this.author );
			}

			if ( Lang13.Bool( href_list["search"] ) ) {
				this.SQLquery = "SELECT author, title, category, id FROM " + GlobalFuncs.format_table_name( "library" ) + " WHERE isnull(deleted) AND ";

				if ( this.category == "Any" ) {
					this.SQLquery += "author LIKE '%" + this.author + "%' AND title LIKE '%" + this.title + "%'";
				} else {
					this.SQLquery += "author LIKE '%" + this.author + "%' AND title LIKE '%" + this.title + "%' AND category='" + this.category + "'";
				}
				this.screenstate = 1;
			}

			if ( Lang13.Bool( href_list["back"] ) ) {
				this.screenstate = 0;
			}
			this.add_fingerprint( Task13.User );
			this.updateUsrDialog();
			return _default;
		}

		// Function from file: lib_machines.dm
		public override dynamic interact( dynamic user = null, bool? flag1 = null ) {
			string dat = null;
			DBQuery query = null;
			dynamic author = null;
			dynamic title = null;
			dynamic category = null;
			dynamic id = null;
			Browser popup = null;

			((Mob)user).set_machine( this );
			dat = "";

			switch ((int)( this.screenstate )) {
				case 0:
					dat += "<h2>Search Settings</h2><br>";
					dat += new Txt( "<A href='?src=" ).Ref( this ).str( ";settitle=1'>Filter by Title: " ).item( this.title ).str( "</A><BR>" ).ToString();
					dat += new Txt( "<A href='?src=" ).Ref( this ).str( ";setcategory=1'>Filter by Category: " ).item( this.category ).str( "</A><BR>" ).ToString();
					dat += new Txt( "<A href='?src=" ).Ref( this ).str( ";setauthor=1'>Filter by Author: " ).item( this.author ).str( "</A><BR>" ).ToString();
					dat += new Txt( "<A href='?src=" ).Ref( this ).str( ";search=1'>[Start Search]</A><BR>" ).ToString();
					break;
				case 1:
					GlobalFuncs.establish_db_connection();

					if ( !GlobalVars.dbcon.IsConnected() ) {
						dat += "<font color=red><b>ERROR</b>: Unable to contact External Archive. Please contact your system administrator for assistance.</font><BR>";
					} else if ( !Lang13.Bool( this.SQLquery ) ) {
						dat += "<font color=red><b>ERROR</b>: Malformed search request. Please contact your system administrator for assistance.</font><BR>";
					} else {
						dat += "<table>";
						dat += "<tr><td>AUTHOR</td><td>TITLE</td><td>CATEGORY</td><td>SS<sup>13</sup>BN</td></tr>";
						query = GlobalVars.dbcon.NewQuery( this.SQLquery );
						query.Execute();

						while (query.NextRow()) {
							author = query.item[1];
							title = query.item[2];
							category = query.item[3];
							id = query.item[4];
							dat += "<tr><td>" + author + "</td><td>" + title + "</td><td>" + category + "</td><td>" + id + "</td></tr>";
						}
						dat += "</table><BR>";
					}
					dat += new Txt( "<A href='?src=" ).Ref( this ).str( ";back=1'>[Go Back]</A><BR>" ).ToString();
					break;
			}
			popup = new Browser( user, "publiclibrary", this.name, 600, 400 );
			popup.set_content( dat );
			popup.set_title_image( ((Mob)user).browse_rsc_icon( this.icon, this.icon_state ) );
			popup.open();
			return null;
		}

		// Function from file: lib_machines.dm
		public override dynamic attack_hand( dynamic a = null, bool? b = null, bool? c = null ) {
			
			if ( Lang13.Bool( base.attack_hand( (object)(a), b, c ) ) ) {
				return null;
			}
			this.interact( a );
			return null;
		}

	}

}