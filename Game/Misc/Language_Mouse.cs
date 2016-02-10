// FILE AUTOGENERATED BY SOMNIUM13.

using System;
using Somnium.Engine.ByImpl;

namespace Somnium.Game {
	class Language_Mouse : Language {

		protected override void __FieldInit() {
			base.__FieldInit();

			this.name = "Mouse";
			this.desc = "Literally just squeaks";
			this.speech_verb = "squeaks";
			this.colour = "say_quote";
			this.key = "9";
			this.space_chance = 80;
			this.syllables = new ByTable(new object [] { "squeak" });
			this.flags = 2;
		}

	}

}