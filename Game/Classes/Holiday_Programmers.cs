// FILE AUTOGENERATED BY SOM13. DO NOT EDIT YET.

using System;
using Somnium.Engine.ByImpl;

namespace Somnium.Game {
	class Holiday_Programmers : Holiday {

		protected override void __FieldInit() {
			base.__FieldInit();

			this.name = "Programmers' Day";
		}

		// Function from file: holidays.dm
		public override string getStationPrefix(  ) {
			return Rand13.Pick(new object [] { "span>", "DEBUG: ", "null", "/list", "EVENT PREFIX NOT FOUND" });
		}

		// Function from file: holidays.dm
		public override bool shouldCelebrate( double? dd = null, double? mm = null, double? yy = null ) {
			
			if ( mm == 9 ) {
				
				if ( ( yy ??0) / 4 == Num13.Floor( ( yy ??0) / 4 ) ) {
					
					if ( dd == 12 ) {
						return true;
					}
				} else if ( dd == 13 ) {
					return true;
				}
			}
			return false;
		}

	}

}