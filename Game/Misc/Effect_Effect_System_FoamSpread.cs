// FILE AUTOGENERATED BY SOMNIUM13.

using System;
using Somnium.Engine.ByImpl;

namespace Somnium.Game {
	class Effect_Effect_System_FoamSpread : Effect_Effect_System {

		public double amount = 5;
		public ByTable carried_reagents = null;
		public dynamic metal = 0;

		// Function from file: effect_system.dm
		public override void start(  ) {
			dynamic F = null;
			dynamic id = null;

			Task13.Schedule( 0, (Task13.Closure)(() => {
				F = Lang13.FindIn( typeof(Obj_Effect_Effect_Foam), this.location );

				if ( Lang13.Bool( F ) ) {
					F.amount += this.amount;
					return;
				}
				F = new Obj_Effect_Effect_Foam( this.location, this.metal );
				F.amount = this.amount;

				if ( !Lang13.Bool( this.metal ) ) {
					((Ent_Static)F).create_reagents( 10 );

					if ( this.carried_reagents != null ) {
						
						foreach (dynamic _a in Lang13.Enumerate( this.carried_reagents )) {
							id = _a;
							
							((Reagents)F.reagents).add_reagent( id, 1 );
						}
					} else {
						((Reagents)F.reagents).add_reagent( "water", 1 );
					}
				}
				return;
			}));
			return;
		}

		// Function from file: effect_system.dm
		public override void set_up( dynamic carry = null, dynamic n = null, dynamic c = null, dynamic loca = null, dynamic direct = null ) {
			carry = carry ?? 5;
			loca = loca ?? 0;

			Reagent R = null;

			this.amount = Num13.Round( Math.Sqrt( Convert.ToDouble( carry / 3 ) ), 1 );

			if ( n is Tile ) {
				this.location = n;
			} else {
				this.location = GlobalFuncs.get_turf( n );
			}
			this.carried_reagents = new ByTable();
			this.metal = loca;

			if ( Lang13.Bool( c ) && !Lang13.Bool( this.metal ) ) {
				
				foreach (dynamic _a in Lang13.Enumerate( c.reagent_list, typeof(Reagent) )) {
					R = _a;
					
					this.carried_reagents.Add( R.id );
				}
			}
			return;
		}

	}

}