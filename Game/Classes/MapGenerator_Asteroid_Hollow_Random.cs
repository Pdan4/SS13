// FILE AUTOGENERATED BY SOM13. DO NOT EDIT YET.

using System;
using Somnium.Engine.ByImpl;

namespace Somnium.Game {
	class MapGenerator_Asteroid_Hollow_Random : MapGenerator_Asteroid_Hollow {

		protected override void __FieldInit() {
			base.__FieldInit();

			this.modules = new ByTable(new object [] { typeof(MapGeneratorModule_BottomLayer_AsteroidTurfs), typeof(MapGeneratorModule_Border_AsteroidWalls), typeof(MapGeneratorModule_SplatterLayer_AsteroidWalls) });
		}

	}

}