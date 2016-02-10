// FILE AUTOGENERATED BY SOMNIUM13.

using System;
using Somnium.Engine.ByImpl;

namespace Somnium.Game {
	class Obj_Item_Device_MiningScanner : Obj_Item_Device {

		public bool cooldown = false;

		protected override void __FieldInit() {
			base.__FieldInit();

			this.item_state = "analyzer";
			this.w_class = 2;
			this.flags = 0;
			this.slot_flags = 512;
			this.icon_state = "mining";
		}

		public Obj_Item_Device_MiningScanner ( dynamic loc = null ) : base( (object)(loc) ) {
			
		}

		// Function from file: mine_items.dm
		public override dynamic attack_self( dynamic user = null, dynamic flag = null, bool? emp = null ) {
			Base_Client C = null;
			ByTable L = null;
			Tile_Unsimulated_Mineral M = null;
			dynamic T = null;
			Image I = null;

			
			if ( !Lang13.Bool( user.client ) ) {
				return null;
			}

			if ( !this.cooldown ) {
				this.cooldown = true;
				Task13.Schedule( 40, (Task13.Closure)(() => {
					this.cooldown = false;
					return;
				}));
				C = user.client;
				L = new ByTable();

				foreach (dynamic _a in Lang13.Enumerate( Map13.FetchInRange( user, 7 ), typeof(Tile_Unsimulated_Mineral) )) {
					M = _a;
					

					if ( Lang13.Bool( M.scan_state ) ) {
						L.Add( M );
					}
				}

				if ( !( L.len != 0 ) ) {
					GlobalFuncs.to_chat( user, new Txt( "<span class='notice'>" ).The( this ).item().str( " reports that nothing was detected nearby.</span>" ).ToString() );
					return null;
				} else {
					
					foreach (dynamic _b in Lang13.Enumerate( L, typeof(Tile_Unsimulated_Mineral) )) {
						M = _b;
						
						T = GlobalFuncs.get_turf( M );
						I = new Image( "icons/turf/walls.dmi", T, M.scan_state, 18 );
						C.images.Add( I );
						Task13.Schedule( 30, (Task13.Closure)(() => {
							
							if ( C != null ) {
								C.images.Remove( I );
							}
							return;
						}));
					}
				}
			}
			return null;
		}

	}

}