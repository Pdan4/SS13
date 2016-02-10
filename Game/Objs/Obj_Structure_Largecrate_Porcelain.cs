// FILE AUTOGENERATED BY SOMNIUM13.

using System;
using Somnium.Engine.ByImpl;

namespace Somnium.Game {
	class Obj_Structure_Largecrate_Porcelain : Obj_Structure_Largecrate {

		public Obj_Structure_Largecrate_Porcelain ( dynamic loc = null ) : base( (object)(loc) ) {
			
		}

		// Function from file: largecrate.dm
		public override dynamic attackby( dynamic a = null, dynamic b = null, dynamic c = null ) {
			Obj_Structure_Toilet T = null;
			Obj_Structure_Sink S = null;

			
			if ( a is Obj_Item_Weapon_Crowbar ) {
				T = new Obj_Structure_Toilet( this.loc );
				T.anchored = 0;
				S = new Obj_Structure_Sink( this.loc );
				S.anchored = 0;
			}
			base.attackby( (object)(a), (object)(b), (object)(c) );
			return null;
		}

	}

}