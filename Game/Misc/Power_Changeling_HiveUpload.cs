// FILE AUTOGENERATED BY SOMNIUM13.

using System;
using Somnium.Engine.ByImpl;

namespace Somnium.Game {
	class Power_Changeling_HiveUpload : Power_Changeling {

		protected override void __FieldInit() {
			base.__FieldInit();

			this.name = "Hive Channel";
			this.desc = "We can channel a DNA into the airwaves, allowing our fellow changelings to absorb it and transform into it as if they acquired the DNA themselves.";
			this.helptext = "Allows other changelings to absorb the DNA you channel from the airwaves. Will not help them towards their absorb objectives.";
			this.genomecost = 0;
			this.verbpath = typeof(Mob).GetMethod( "changeling_hiveupload" );
		}

	}

}