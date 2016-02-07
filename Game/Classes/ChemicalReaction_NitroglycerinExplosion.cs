// FILE AUTOGENERATED BY SOM13. DO NOT EDIT YET.

using System;
using Somnium.Engine.ByImpl;

namespace Somnium.Game {
	class ChemicalReaction_NitroglycerinExplosion : ChemicalReaction {

		protected override void __FieldInit() {
			base.__FieldInit();

			this.name = "Nitroglycerin explosion";
			this.id = "nitroglycerin_explosion";
			this.required_reagents = new ByTable().Set( "nitroglycerin", 1 );
			this.result_amount = 1;
			this.required_temp = 474;
		}

		// Function from file: pyrotechnics.dm
		public override void on_reaction( Reagents holder = null, double? created_volume = null ) {
			dynamic location = null;
			EffectSystem_ReagentsExplosion e = null;

			location = GlobalFuncs.get_turf( holder.my_atom );
			e = new EffectSystem_ReagentsExplosion();
			e.set_up( Num13.Round( ( created_volume ??0) / 2, 1 ), location, 0, 0 );
			e.start();
			holder.clear_reagents();
			return;
		}

	}

}