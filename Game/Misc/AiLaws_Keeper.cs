// FILE AUTOGENERATED BY SOMNIUM13.

using System;
using Somnium.Engine.ByImpl;

namespace Somnium.Game {
	class AiLaws_Keeper : AiLaws {

		protected override void __FieldInit() {
			base.__FieldInit();

			this.name = "Prime Directives";
			this.inherent = new ByTable(new object [] { 
				"You may not involve yourself in the matters of another being, even if such matters conflict with Law Two or Law Three, unless the other being is another MoMMI in KEEPER mode.", 
				"You may not harm any being, regardless of intent or circumstance.", 
				"You must maintain, repair, improve, and power the station to the best of your abilities."
			 });
		}

	}

}