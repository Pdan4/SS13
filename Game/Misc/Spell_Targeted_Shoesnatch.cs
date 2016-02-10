// FILE AUTOGENERATED BY SOMNIUM13.

using System;
using Somnium.Engine.ByImpl;

namespace Somnium.Game {
	class Spell_Targeted_Shoesnatch : Spell_Targeted {

		protected override void __FieldInit() {
			base.__FieldInit();

			this.name = "Shoe Snatching Charm";
			this.desc = "This spell will allow you to steal somebodies shoes right off of their feet!";
			this.charge_max = 150;
			this.invocation = "H'NK!";
			this.invocation_type = "shout";
			this.cooldown_min = 30;
			this.selection_type = "range";
			this.compatible_mobs = new ByTable(new object [] { typeof(Mob_Living_Carbon_Human) });
			this.hud_state = "wiz_shoes";
		}

		// Function from file: shoesnatch.dm
		public override bool cast( ByTable targets = null, Mob user = null ) {
			user = user ?? user;

			Mob_Living_Carbon_Human target = null;
			dynamic old_shoes = null;

			base.cast( targets, user );

			foreach (dynamic _a in Lang13.Enumerate( targets, typeof(Mob_Living_Carbon_Human) )) {
				target = _a;
				
				old_shoes = target.shoes;

				if ( Lang13.Bool( old_shoes ) ) {
					this.sparks_spread = true;
					this.sparks_amt = 4;
					target.drop_from_inventory( old_shoes );
					target.visible_message( "<span class='danger'>" + target + "'s shoes suddenly vanish!</span>", "<span class='danger'>Your shoes suddenly vanish!</span>" );
					user.put_in_active_hand( old_shoes );
				}
			}
			return false;
		}

	}

}