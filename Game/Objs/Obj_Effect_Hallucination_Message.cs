// FILE AUTOGENERATED BY SOMNIUM13.

using System;
using Somnium.Engine.ByImpl;

namespace Somnium.Game {
	class Obj_Effect_Hallucination_Message : Obj_Effect_Hallucination {

		// Function from file: Hallucination.dm
		public Obj_Effect_Hallucination_Message ( dynamic loc = null, Mob_Living_Carbon T = null ) : base( (object)(loc) ) {
			dynamic chosen = null;

			this.target = T;
			chosen = Rand13.Pick(new object [] { "<span class='userdanger'>The light burns you!</span>", "<span class='danger'>You don't feel like yourself.</span>", "<span class='userdanger'>Unknown has punched " + this.target + "!</span>", "<span class='notice'>You hear something squeezing through the ducts...</span>", "<span class='notice'>You hear a distant scream.</span>", "<span class='notice'>You feel invincible, nothing can hurt you!</span>", "<B>" + this.target + "</B> sneezes.", "<span class='warning'>You feel faint.</span>", "<span class='noticealien'>You hear a strange, alien voice in your head...</span>" + Rand13.Pick(new object [] { "Hiss", "Ssss" }), "<span class='notice'>You can see...everything!</span>" });
			((dynamic)this.target).WriteMsg( chosen );
			GlobalFuncs.qdel( this );
			return;
		}

	}

}