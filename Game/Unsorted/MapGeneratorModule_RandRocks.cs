// FILE AUTOGENERATED BY SOMNIUM13.

using System;
using Somnium.Engine.ByImpl;

namespace Somnium.Game {
	class MapGeneratorModule_RandRocks : MapGeneratorModule {

		protected override void __FieldInit() {
			base.__FieldInit();

			this.spawnableAtoms = new ByTable().Set( typeof(Obj_Structure_Flora_Rock), 40 ).Set( typeof(Obj_Structure_Flora_Rock_Pile), 20 );
		}

	}

}