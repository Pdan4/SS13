// FILE AUTOGENERATED BY SOMNIUM13.

using System;
using Somnium.Engine.ByImpl;

namespace Somnium.Game {
	class Mob_Living_SimpleAnimal_Mouse_Black_Dessert : Mob_Living_SimpleAnimal_Mouse_Black {

		protected override void __FieldInit() {
			base.__FieldInit();

			this.response_help = "pets";
			this.response_disarm = "gently pushes aside";
			this.response_harm = "tenderizes";
		}

		public Mob_Living_SimpleAnimal_Mouse_Black_Dessert ( dynamic loc = null ) : base( (object)(loc) ) {
			
		}

	}

}