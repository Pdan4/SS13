// FILE AUTOGENERATED BY SOMNIUM13.

using System;
using Somnium.Engine.ByImpl;

namespace Somnium.Game {
	class Obj_Item_Weapon_Stamp : Obj_Item_Weapon {

		protected override void __FieldInit() {
			base.__FieldInit();

			this.item_state = "stamp";
			this.w_class = 1;
			this.throw_speed = 3;
			this.materials = new ByTable().Set( "$metal", 60 );
			this.item_color = "cargo";
			this.pressure_resistance = 2;
			this.attack_verb = new ByTable(new object [] { "stamped" });
			this.icon = "icons/obj/bureaucracy.dmi";
			this.icon_state = "stamp-ok";
		}

		public Obj_Item_Weapon_Stamp ( dynamic loc = null ) : base( (object)(loc) ) {
			
		}

		// Function from file: stamps.dm
		public override dynamic attack_paw( dynamic a = null, dynamic b = null, dynamic c = null ) {
			return this.attack_hand( a );
		}

		// Function from file: stamps.dm
		public override int suicide_act( Mob_Living_Carbon_Human user = null ) {
			user.visible_message( new Txt( "<span class='suicide'>" ).item( user ).str( " stamps 'VOID' on " ).his_her_its_their().str( " forehead, then promptly falls over, dead.</span>" ).ToString() );
			return 8;
		}

	}

}