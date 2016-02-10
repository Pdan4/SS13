// FILE AUTOGENERATED BY SOMNIUM13.

using System;
using Somnium.Engine.ByImpl;

namespace Somnium.Game {
	class MigrationController_Mysql : MigrationController {

		public DBConnection db = null;

		protected override void __FieldInit() {
			base.__FieldInit();

			this.id = "mysql";
		}

		// Function from file: mysql_controller.dm
		public override bool? hasTable( string tableName = null ) {
			return this.hasResult( "SHOW TABLES LIKE '" + tableName );
		}

		// Function from file: mysql_controller.dm
		public override dynamic execute( string sql = null ) {
			DBQuery query = null;

			query = this.db.NewQuery( sql );
			query.Execute();
			return query;
		}

		// Function from file: mysql_controller.dm
		public override bool? hasResult( string sql = null ) {
			dynamic query = null;

			query = this.execute( sql );

			if ( Lang13.Bool( query.NextRow() ) ) {
				return GlobalVars.TRUE;
			}
			return GlobalVars.FALSE;
		}

		// Function from file: mysql_controller.dm
		public override ByTable query( string sql = null ) {
			dynamic query = null;
			ByTable rows = null;

			query = this.execute( sql );
			rows = new ByTable();

			while (Lang13.Bool( query.NextRow() )) {
				rows.Add( new ByTable(new object [] { query.item }) );
			}
			return rows;
		}

		// Function from file: mysql_controller.dm
		public override bool? createMigrationTable(  ) {
			string tableSQL = null;

			tableSQL = "\nCREATE TABLE IF NOT EXISTS " + this.TABLE_NAME + @" (
	pkgID VARCHAR(15) PRIMARY KEY, -- Implies NOT NULL
	version INT(11) NOT NULL
);
	";
			this.execute( tableSQL );
			return null;
		}

		// Function from file: mysql_controller.dm
		public override bool? setup(  ) {
			DBQuery Q = null;

			
			if ( !( GlobalVars.dbcon != null ) || !( GlobalVars.dbcon is DBConnection ) || !GlobalVars.dbcon.IsConnected() ) {
				Game13.log.WriteMsg( "## TESTING: " + "Something wrong with dbcon." );
				return GlobalVars.FALSE;
			}
			Q = GlobalVars.dbcon.NewQuery();

			if ( !( Q != null ) ) {
				Game13.log.WriteMsg( "## TESTING: " + "Something wrong with dbcon.NewQuery()" );
				return GlobalVars.FALSE;
			}
			Q.Close();
			Game13.log.WriteMsg( "## TESTING: " + "MySQL is okay" );
			this.db = GlobalVars.dbcon;
			return GlobalVars.TRUE;
		}

	}

}