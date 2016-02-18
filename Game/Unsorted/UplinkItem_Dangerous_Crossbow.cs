// FILE AUTOGENERATED BY SOMNIUM13.

using System;
using Somnium.Engine.ByImpl;

namespace Somnium.Game {
	class UplinkItem_Dangerous_Crossbow : UplinkItem_Dangerous {

		protected override void __FieldInit() {
			base.__FieldInit();

			this.name = "Miniature Energy Crossbow";
			this.desc = "A short bow mounted across a tiller in miniature. Small enough to fit into a pocket or slip into a bag unnoticed. It will synthesize and fire bolts tipped with a paralyzing toxin that will briefly stun targets and cause them to slur as if inebriated. It can produce an infinite amount of bolts, but must be manually recharged with each shot.";
			this.item = typeof(Obj_Item_Weapon_Gun_Energy_KineticAccelerator_Crossbow);
			this.cost = 12;
			this.surplus = 50;
			this.exclude_modes = new ByTable(new object [] { typeof(GameMode_Nuclear), typeof(GameMode_Gang) });
		}

	}

}