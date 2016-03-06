// FILE AUTOGENERATED BY SOMNIUM13.

using System;
using Somnium.Engine.ByImpl;

namespace Somnium.Game {
	class Obj_Item_Device_Uplink : Obj_Item_Device {

		public int? active = 0;
		public int? lockable = 1;
		public dynamic telecrystals = 20;
		public string owner = null;
		public Type gamemode = null;
		public double spent_telecrystals = 0;
		public string purchase_log = "";

		// Function from file: uplink.dm
		public Obj_Item_Device_Uplink ( dynamic loc = null ) : base( (object)(loc) ) {
			// Warning: Super call was HERE! If anything above HERE is needed by the super call, it might break!;
			GlobalVars.uplinks.Add( this );
			return;
		}

		// Function from file: uplink.dm
		public override Game_Data ui_host(  ) {
			return this.loc;
		}

		// Function from file: uplink.dm
		public override int? ui_act( string action = null, ByTable _params = null, Tgui ui = null, UiState state = null ) {
			int? _default = null;

			dynamic item = null;
			ByTable uplink_items = null;
			ByTable buyable_items = null;
			dynamic category = null;
			dynamic I = null;

			
			if ( !Lang13.Bool( this.active ) ) {
				return _default;
			}

			switch ((string)( action )) {
				case "buy":
					item = _params["item"];
					uplink_items = GlobalFuncs.get_uplink_items( this.gamemode );
					buyable_items = new ByTable();

					foreach (dynamic _a in Lang13.Enumerate( uplink_items )) {
						category = _a;
						
						buyable_items.Add( uplink_items[category] );
					}

					if ( buyable_items.Contains( item ) ) {
						I = buyable_items[item];
						I.buy( Task13.User, this );
						_default = GlobalVars.TRUE;
					}
					break;
				case "lock":
					this.active = GlobalVars.FALSE;
					GlobalVars.SStgui.close_uis( this );
					break;
			}
			return _default;
		}

		// Function from file: uplink.dm
		public override ByTable ui_data( dynamic user = null ) {
			ByTable data = null;
			ByTable uplink_items = null;
			dynamic category = null;
			ByTable cat = null;
			dynamic item = null;
			dynamic I = null;

			data = new ByTable();
			data["telecrystals"] = this.telecrystals;
			data["lockable"] = this.lockable;
			uplink_items = GlobalFuncs.get_uplink_items( this.gamemode );
			data["categories"] = new ByTable();

			foreach (dynamic _b in Lang13.Enumerate( uplink_items )) {
				category = _b;
				
				cat = new ByTable().Set( "name", category ).Set( "items", new ByTable() );

				foreach (dynamic _a in Lang13.Enumerate( uplink_items[category] )) {
					item = _a;
					
					I = uplink_items[category][item];
					cat["items"] += new ByTable(new object [] { new ByTable().Set( "name", I.name ).Set( "cost", I.cost ).Set( "desc", I.desc ) });
				}
				data["categories"] += new ByTable(new object [] { cat });
			}
			return data;
		}

		// Function from file: uplink.dm
		public override int ui_interact( dynamic user = null, string ui_key = null, Tgui ui = null, bool? force_open = null, Tgui master_ui = null, UiState state = null ) {
			ui_key = ui_key ?? "main";
			force_open = force_open ?? false;
			state = state ?? GlobalVars.inventory_state;

			ui = GlobalVars.SStgui.try_update_ui( user, this, ui_key, ui, force_open );

			if ( !( ui != null ) ) {
				ui = new Tgui( user, this, ui_key, "uplink", this.name, 450, 750, master_ui, state );
				ui.set_autoupdate( GlobalVars.FALSE );
				ui.set_style( "syndicate" );
				ui.open();
			}
			return 0;
		}

		// Function from file: uplink.dm
		public override dynamic interact( dynamic user = null, bool? flag1 = null ) {
			this.active = GlobalVars.TRUE;
			this.ui_interact( user );
			return null;
		}

		// Function from file: uplink.dm
		public override dynamic Destroy(  ) {
			GlobalVars.uplinks.Remove( this );
			return base.Destroy();
		}

	}

}