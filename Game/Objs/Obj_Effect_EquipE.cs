// FILE AUTOGENERATED BY SOMNIUM13.

using System;
using Somnium.Engine.ByImpl;

namespace Somnium.Game {
	class Obj_Effect_EquipE : Obj_Effect {

		public dynamic source = null;
		public Ent_Static s_loc = null;
		public Ent_Static t_loc = null;
		public dynamic item = null;
		public string place = null;
		public bool pickpocket = false;

		// Function from file: inventory.dm
		public Obj_Effect_EquipE ( dynamic loc = null ) : base( (object)(loc) ) {
			
			if ( !( GlobalVars.ticker != null ) ) {
				GlobalFuncs.qdel( this );
			}
			Task13.Schedule( 100, (Task13.Closure)(() => {
				GlobalFuncs.qdel( this );
				return;
			}));
			// Warning: Super call was HERE! If anything above HERE is needed by the super call, it might break!;
			return;
		}

		// Function from file: inventory.dm
		public virtual void done(  ) {
			return;
		}

		// Function from file: inventory.dm
		public override dynamic process(  ) {
			return null;
		}

	}

}