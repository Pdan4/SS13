// FILE AUTOGENERATED BY SOMNIUM13.

using System;
using Somnium.Engine.ByImpl;

namespace Somnium.Game {
	class MapGenerator_Nature : MapGenerator {

		protected override void __FieldInit() {
			base.__FieldInit();

			this.modules = new ByTable(new object [] { 
				typeof(MapGeneratorModule_BottomLayer_GrassTurfs), 
				typeof(MapGeneratorModule_PineTrees), 
				typeof(MapGeneratorModule_DeadTrees), 
				typeof(MapGeneratorModule_RandBushes), 
				typeof(MapGeneratorModule_RandRocks), 
				typeof(MapGeneratorModule_DenseLayer_GrassTufts)
			 });
		}

	}

}