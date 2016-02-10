// FILE AUTOGENERATED BY SOMNIUM13.

using System;
using Somnium.Engine.ByImpl;

namespace Somnium.Game {
	class DBConnection : Game_Data {

		public DB13_CONNECTION _db_con = null;
		public dynamic dbi = null;
		public string user = null;
		public string password = null;
		public dynamic default_cursor = null;
		public string server = "localhost";
		public int port = 3306;

		// Function from file: core.dm
		public DBConnection ( dynamic dbi_handler = null, dynamic username = null, dynamic password_handler = null, dynamic cursor_handler = null ) {
			this.dbi = dbi_handler;
			this.user = username;
			this.password = password_handler;
			this.default_cursor = cursor_handler;
			this._db_con = DB13.new_con();
			return;
		}

		// Function from file: core.dm
		public DBQuery NewQuery( string sql_query = null, dynamic cursor_handler = null ) {
			cursor_handler = cursor_handler ?? this.default_cursor;

			return new DBQuery( sql_query, this, cursor_handler );
		}

		// Function from file: core.dm
		public bool SelectDB( dynamic database_name = null, dynamic dbi = null ) {
			
			if ( this.IsConnected() ) {
				this.Disconnect();
			}
			return this.Connect( "" + ( Lang13.Bool( dbi ) ? "" + dbi : "dbi:mysql:" + database_name + ":" + GlobalVars.sqladdress + ":" + GlobalVars.sqlport ), this.user, this.password );
		}

		// Function from file: core.dm
		public string ErrorMsg(  ) {
			return DB13.error_msg( this._db_con );
		}

		// Function from file: core.dm
		public string Quote( dynamic str = null ) {
			return DB13.quote( this._db_con, str );
		}

		// Function from file: core.dm
		public bool IsConnected(  ) {
			return ( !GlobalVars.sqllogging ? false : DB13.is_connected( this._db_con ) );
		}

		// Function from file: core.dm
		public bool Disconnect(  ) {
			return DB13.close( this._db_con );
		}

		// Function from file: core.dm
		public bool Connect( string dbi_handler = null, string user_handler = null, string password_handler = null, bool? cursor_handler = null ) {
			dbi_handler = dbi_handler ?? this.dbi;
			user_handler = user_handler ?? this.user;
			password_handler = password_handler ?? this.password;

			
			if ( !GlobalVars.sqllogging || !( this != null ) ) {
				return false;
			}
			cursor_handler = Lang13.BoolNullable( this.default_cursor );

			if ( !( cursor_handler == true ) ) {
				cursor_handler = false;
			}
			return DB13.connect( this._db_con, dbi_handler, user_handler, password_handler, cursor_handler, null );
		}

	}

}