// FILE AUTOGENERATED BY SOMNIUM13.

using System;
using Somnium.Engine.ByImpl;

namespace Somnium.Game {
	class MapGeneratorModule_DenseLayer_GrassTufts : MapGeneratorModule_DenseLayer {

		protected override void __FieldInit() {
			base.__FieldInit();

			this.spawnableTurfs = new ByTable();
			this.spawnableAtoms = new ByTable().Set( typeof(Obj_Structure_Flora_Ausbushes_Grassybush), 75 );
		}

	}

}