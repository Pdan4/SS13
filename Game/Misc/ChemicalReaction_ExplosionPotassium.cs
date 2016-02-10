// FILE AUTOGENERATED BY SOMNIUM13.

using System;
using Somnium.Engine.ByImpl;

namespace Somnium.Game {
	class ChemicalReaction_ExplosionPotassium : ChemicalReaction {

		protected override void __FieldInit() {
			base.__FieldInit();

			this.name = "Explosion";
			this.id = "explosion_potassium";
			this.required_reagents = new ByTable().Set( "water", 1 ).Set( "potassium", 1 );
			this.result_amount = 2;
		}

		// Function from file: Chemistry-Recipes.dm
		public override void on_reaction( Reagents holder = null, int? created_volume = null ) {
			Effect_Effect_System_ReagentsExplosion e = null;
			Ent_Static L = null;

			this.send_admin_alert( holder, "water/potassium explosion" );
			e = new Effect_Effect_System_ReagentsExplosion();
			e.set_up( Num13.Round( ( created_volume ??0) / 10, 1 ), holder.my_atom, 0, 0 );
			e.holder_damage( holder.my_atom );

			if ( holder.my_atom is Mob_Living ) {
				e.amount *= 0.5;
				L = holder.my_atom;

				if ( Convert.ToInt32( ((dynamic)L).stat ) != 2 ) {
					e.amount *= 0.5;
				}
			}
			e.start();
			holder.clear_reagents();
			return;
		}

	}

}