// FILE AUTOGENERATED BY SOMNIUM13.

using System;
using Somnium.Engine.ByImpl;

namespace Somnium.Game {
	class MapGeneratorModule_Border : MapGeneratorModule {

		protected override void __FieldInit() {
			base.__FieldInit();

			this.clusterCheckFlags = 0;
		}

		// Function from file: helpers.dm
		public bool is_border( dynamic T = null ) {
			dynamic direction = null;

			
			foreach (dynamic _a in Lang13.Enumerate( new ByTable(new object [] { GlobalVars.SOUTH, GlobalVars.EAST, GlobalVars.WEST, GlobalVars.NORTH }) )) {
				direction = _a;
				

				if ( this.mother.map.Contains( Map13.GetStep( T, Convert.ToInt32( direction ) ) ) ) {
					continue;
				}
				return true;
			}
			return false;
		}

		// Function from file: helpers.dm
		public override void generate(  ) {
			ByTable map = null;
			dynamic T = null;

			
			if ( !( this.mother != null ) ) {
				return;
			}
			map = this.mother.map;

			foreach (dynamic _a in Lang13.Enumerate( map )) {
				T = _a;
				

				if ( this.is_border( T ) ) {
					this.place( T );
				}
			}
			return;
		}

	}

}