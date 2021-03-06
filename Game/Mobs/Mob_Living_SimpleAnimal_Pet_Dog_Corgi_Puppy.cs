// FILE AUTOGENERATED BY SOMNIUM13.

using System;
using Somnium.Engine.ByImpl;

namespace Somnium.Game {
	class Mob_Living_SimpleAnimal_Pet_Dog_Corgi_Puppy : Mob_Living_SimpleAnimal_Pet_Dog_Corgi {

		protected override void __FieldInit() {
			base.__FieldInit();

			this.icon_living = "puppy";
			this.icon_dead = "puppy_dead";
			this.pass_flags = 16;
			this.icon_state = "puppy";
		}

		public Mob_Living_SimpleAnimal_Pet_Dog_Corgi_Puppy ( dynamic loc = null ) : base( (object)(loc) ) {
			
		}

		// Function from file: dog.dm
		public override dynamic Topic( string href = null, ByTable href_list = null, dynamic hsrc = null ) {
			
			if ( Lang13.Bool( href_list["remove_inv"] ) || Lang13.Bool( href_list["add_inv"] ) ) {
				Task13.User.WriteMsg( "<span class='warning'>You can't fit this on " + this + "!</span>" );
				return null;
			}
			base.Topic( href, href_list, (object)(hsrc) );
			return null;
		}

	}

}