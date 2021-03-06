// FILE AUTOGENERATED BY SOMNIUM13.

using System;
using Somnium.Engine.ByImpl;

namespace Somnium.Game {
	class Obj_Item_Weapon_Holo_Esword : Obj_Item_Weapon_Holo {

		public bool active = false;

		protected override void __FieldInit() {
			base.__FieldInit();

			this.force = 3;
			this.throw_range = 5;
			this.w_class = 2;
			this.hitsound = "swing_hit";
			this.armour_penetration = 50;
			this.icon_state = "sword0";
		}

		// Function from file: items.dm
		public Obj_Item_Weapon_Holo_Esword ( dynamic loc = null ) : base( (object)(loc) ) {
			this.item_color = Rand13.Pick(new object [] { "red", "blue", "green", "purple" });
			return;
		}

		// Function from file: items.dm
		public override dynamic attack_self( dynamic user = null, dynamic flag = null, bool? emp = null ) {
			this.active = !this.active;

			if ( this.active ) {
				this.force = 30;
				this.icon_state = "sword" + this.item_color;
				this.w_class = 4;
				this.hitsound = "sound/weapons/blade1.ogg";
				GlobalFuncs.playsound( user, "sound/weapons/saberon.ogg", 20, 1 );
				user.WriteMsg( "<span class='warning'>" + this + " is now active.</span>" );
			} else {
				this.force = 3;
				this.icon_state = "sword0";
				this.w_class = 2;
				this.hitsound = "swing_hit";
				GlobalFuncs.playsound( user, "sound/weapons/saberoff.ogg", 20, 1 );
				user.WriteMsg( "<span class='warning'>" + this + " can now be concealed.</span>" );
			}
			return null;
		}

		// Function from file: items.dm
		public override bool attack( dynamic M = null, dynamic user = null, bool? def_zone = null ) {
			base.attack( (object)(M), (object)(user), def_zone );
			return false;
		}

		// Function from file: items.dm
		public override bool hit_reaction( Mob_Living_Carbon owner = null, string attack_text = null, int? final_block_chance = null, dynamic damage = null, int? attack_type = null ) {
			
			if ( this.active ) {
				return base.hit_reaction( owner, attack_text, final_block_chance, (object)(damage), attack_type );
			}
			return false;
		}

	}

}