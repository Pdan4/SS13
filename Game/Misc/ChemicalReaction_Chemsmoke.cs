// FILE AUTOGENERATED BY SOMNIUM13.

using System;
using Somnium.Engine.ByImpl;

namespace Somnium.Game {
	class ChemicalReaction_Chemsmoke : ChemicalReaction {

		protected override void __FieldInit() {
			base.__FieldInit();

			this.name = "Chemsmoke";
			this.id = "chemsmoke";
			this.required_reagents = new ByTable().Set( "potassium", 1 ).Set( "sugar", 1 ).Set( "phosphorus", 1 );
			this.result_amount = null;
			this.secondary = true;
		}

		// Function from file: Chemistry-Recipes.dm
		public override void on_reaction( Reagents holder = null, int? created_volume = null ) {
			dynamic location = null;
			Effect_Effect_System_SmokeSpread_Chem S = null;

			location = GlobalFuncs.get_turf( holder.my_atom );
			S = new Effect_Effect_System_SmokeSpread_Chem();
			S.attach( location );
			S.set_up( holder, 10, 0, location );
			GlobalFuncs.playsound( location, "sound/effects/smoke.ogg", 50, 1, -3 );
			Task13.Schedule( 0, (Task13.Closure)(() => {
				S.start();
				Task13.Sleep( 10 );
				S.start();
				return;
			}));
			holder.clear_reagents();
			return;
		}

	}

}