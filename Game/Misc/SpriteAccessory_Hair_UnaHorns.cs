// FILE AUTOGENERATED BY SOMNIUM13.

using System;
using Somnium.Engine.ByImpl;

namespace Somnium.Game {
	class SpriteAccessory_Hair_UnaHorns : SpriteAccessory_Hair {

		protected override void __FieldInit() {
			base.__FieldInit();

			this.name = "Unathi Horns";
			this.icon_state = "soghun_horns";
			this.species_allowed = new ByTable(new object [] { "Unathi" });
			this.do_colouration = false;
		}

	}

}