// FILE AUTOGENERATED BY SOMNIUM13.

using System;
using Somnium.Engine.ByImpl;

namespace Somnium.Game {
	class Obj_Effect_ProcHolder_Alien_Sneak : Obj_Effect_ProcHolder_Alien {

		public bool active = false;

		protected override void __FieldInit() {
			base.__FieldInit();

			this.action_icon_state = "alien_sneak";
		}

		public Obj_Effect_ProcHolder_Alien_Sneak ( dynamic loc = null ) : base( (object)(loc) ) {
			
		}

		// Function from file: alien_powers.dm
		public override bool fire( Mob user = null ) {
			
			if ( !this.active ) {
				user.alpha = 75;
				((dynamic)user).sneaking = 1;
				this.active = true;
				user.WriteMsg( "<span class='noticealien'>You blend into the shadows...</span>" );
			} else {
				user.alpha = Convert.ToInt32( Lang13.Initial( user, "alpha" ) );
				((dynamic)user).sneaking = 0;
				this.active = false;
				user.WriteMsg( "<span class='noticealien'>You reveal yourself!</span>" );
			}
			return false;
		}

	}

}