// FILE AUTOGENERATED BY SOMNIUM13.

using System;
using Somnium.Engine.ByImpl;

namespace Somnium.Game {
	class Obj_Item_Verbs_Borer_Beheaded : Obj_Item_Verbs_Borer {

		public Obj_Item_Verbs_Borer_Beheaded ( dynamic loc = null ) : base( (object)(loc) ) {
			
		}

		// Function from file: verbs_beheaded.dm
		[Verb]
		[VerbInfo( name: "Borer Speak", desc: "Communicate with your bretheren", group: "Alien" )]
		[VerbArg( 1, InputType.Str )]
		public void borer_speak( string message = null ) {
			Ent_Static B = null;

			
			if ( !Lang13.Bool( message ) ) {
				return;
			}
			message = GlobalFuncs.trim( String13.SubStr( GlobalFuncs.sanitize( message ), 1, 1024 ) );
			message = GlobalFuncs.capitalize( message );
			B = this.loc;

			if ( !( B is Mob_Living_SimpleAnimal_Borer ) ) {
				return;
			}
			((Mob_Living_SimpleAnimal_Borer)B).borer_speak( message );
			return;
		}

		// Function from file: verbs_beheaded.dm
		[Verb]
		[VerbInfo( name: "Abandon Host", desc: "Slither out of your host.", group: "Alien" )]
		public void abandon_host(  ) {
			Ent_Static B = null;

			B = this.loc;

			if ( !( B is Mob_Living_SimpleAnimal_Borer ) ) {
				return;
			}
			((Mob_Living_SimpleAnimal_Borer)B).abandon_host();
			return;
		}

	}

}