// FILE AUTOGENERATED BY SOMNIUM13.

using System;
using Somnium.Engine.ByImpl;

namespace Somnium.Game {
	class Action_Generic : Action {

		public dynamic procname = null;

		public Action_Generic ( Obj_Item_Weapon_Tank Target = null ) : base( Target ) {
			
		}

		// Function from file: action.dm
		public override bool Trigger(  ) {
			
			if ( !base.Trigger() ) {
				return false;
			}

			if ( Lang13.Bool( this.target ) && Lang13.Bool( this.procname ) ) {
				Lang13.Call( Lang13.BindFunc( this.target, this.procname ), Task13.User );
			}
			return true;
		}

	}

}