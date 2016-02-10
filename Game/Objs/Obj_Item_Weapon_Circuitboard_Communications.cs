// FILE AUTOGENERATED BY SOMNIUM13.

using System;
using Somnium.Engine.ByImpl;

namespace Somnium.Game {
	class Obj_Item_Weapon_Circuitboard_Communications : Obj_Item_Weapon_Circuitboard {

		protected override void __FieldInit() {
			base.__FieldInit();

			this.build_path = "/obj/machinery/computer/communications";
			this.origin_tech = "programming=2;magnets=2";
		}

		public Obj_Item_Weapon_Circuitboard_Communications ( dynamic loc = null ) : base( (object)(loc) ) {
			
		}

		// Function from file: communications.dm
		public override dynamic Destroy( dynamic brokenup = null ) {
			Obj_Machinery_Computer_Communications commconsole = null;
			Obj_Item_Weapon_Circuitboard_Communications commboard = null;
			Mob_Living_Silicon_Ai shuttlecaller = null;

			
			foreach (dynamic _a in Lang13.Enumerate( GlobalVars.machines, typeof(Obj_Machinery_Computer_Communications) )) {
				commconsole = _a;
				

				if ( commconsole.loc is Tile ) {
					return base.Destroy( (object)(brokenup) );
				}
			}

			foreach (dynamic _b in Lang13.Enumerate( typeof(Game13), typeof(Obj_Item_Weapon_Circuitboard_Communications) )) {
				commboard = _b;
				

				if ( ( commboard.loc is Tile || commboard.loc is Obj_Item_Weapon_Storage ) && commboard != this ) {
					return base.Destroy( (object)(brokenup) );
				}
			}

			foreach (dynamic _c in Lang13.Enumerate( GlobalVars.player_list, typeof(Mob_Living_Silicon_Ai) )) {
				shuttlecaller = _c;
				

				if ( !Lang13.Bool( shuttlecaller.stat ) && shuttlecaller.client != null && shuttlecaller.loc is Tile ) {
					return base.Destroy( (object)(brokenup) );
				}
			}

			if ( GlobalVars.ticker.mode.name == "revolution" || GlobalVars.ticker.mode.name == "AI malfunction" || GlobalVars.sent_strike_team ) {
				return base.Destroy( (object)(brokenup) );
			}
			GlobalVars.emergency_shuttle.incall( 2 );
			GlobalVars.diary.WriteMsg( String13.HtmlDecode( "[" + GlobalFuncs.time_stamp() + "]GAME: " + "All the AIs, comm consoles and boards are destroyed. Shuttle called." ) );
			GlobalFuncs.message_admins( "All the AIs, comm consoles and boards are destroyed. Shuttle called." );
			GlobalFuncs.captain_announce( "The emergency shuttle has been called. It will arrive in " + Num13.Floor( GlobalVars.emergency_shuttle.timeleft() / 60 ) + " minutes." );
			GlobalFuncs.to_chat( typeof(Game13), new Sound( "sound/AI/shuttlecalled.ogg" ) );
			base.Destroy( (object)(brokenup) );
			return null;
		}

	}

}