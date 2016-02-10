// FILE AUTOGENERATED BY SOMNIUM13.

using System;
using Somnium.Engine.ByImpl;

namespace Somnium.Game {
	class Power_Changeling_BoostRange : Power_Changeling {

		protected override void __FieldInit() {
			base.__FieldInit();

			this.name = "Boost Range";
			this.desc = "We evolve the ability to shoot our stingers at humans, with some preperation.";
			this.genomecost = 2;
			this.allowduringlesserform = true;
			this.verbpath = typeof(Mob).GetMethod( "changeling_boost_range" );
		}

	}

}