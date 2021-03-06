// FILE AUTOGENERATED BY SOMNIUM13.

using System;
using Somnium.Engine.ByImpl;

namespace Somnium.Game {
	class Mutation_Human_Elvis : Mutation_Human {

		protected override void __FieldInit() {
			base.__FieldInit();

			this.name = "Elvis";
			this.quality = 3;
			this.dna_block = -1;
			this.text_gain_indication = "<span class='notice'>You feel pretty good, honeydoll.</span>";
			this.text_lose_indication = "<span class='notice'>You feel a little less conversation would be great.</span>";
		}

		// Function from file: mutations.dm
		public override dynamic say_mod( dynamic message = null ) {
			
			if ( Lang13.Bool( message ) ) {
				message = " " + message + " ";
				message = GlobalFuncs.replacetext( message, " i'm not ", " I aint " );
				message = GlobalFuncs.replacetext( message, " girl ", Rand13.Pick(new object [] { " honey ", " baby ", " baby doll " }) );
				message = GlobalFuncs.replacetext( message, " man ", Rand13.Pick(new object [] { " son ", " buddy ", " brother", " pal ", " friendo " }) );
				message = GlobalFuncs.replacetext( message, " out of ", " outta " );
				message = GlobalFuncs.replacetext( message, " thank you ", " thank you, thank you very much " );
				message = GlobalFuncs.replacetext( message, " what are you ", " whatcha " );
				message = GlobalFuncs.replacetext( message, " yes ", Rand13.Pick(new object [] { " sure", "yea " }) );
				message = GlobalFuncs.replacetext( message, " faggot ", " square " );
				message = GlobalFuncs.replacetext( message, " muh valids ", " getting my kicks " );
			}
			return GlobalFuncs.trim( message );
		}

		// Function from file: mutations.dm
		public override void on_life( Mob_Living owner = null ) {
			ByTable dancetypes = null;
			dynamic dancemoves = null;

			
			dynamic _a = Rand13.Pick(new object [] { 1, 2 }); // Was a switch-case, sorry for the mess.
			if ( _a==1 ) {
				
				if ( Rand13.PercentChance( 15 ) ) {
					dancetypes = new ByTable(new object [] { "swinging", "fancy", "stylish", "20'th century", "jivin'", "rock and roller", "cool", "salacious", "bashing", "smashing" });
					dancemoves = Rand13.PickFromTable( dancetypes );
					owner.visible_message( "<b>" + owner + "</b> busts out some " + dancemoves + " moves!" );
				}
			} else if ( _a==2 ) {
				
				if ( Rand13.PercentChance( 15 ) ) {
					owner.visible_message( "<b>" + owner + "</b> " + Rand13.Pick(new object [] { "jiggles their hips", "rotates their hips", "gyrates their hips", "taps their foot", "dances to an imaginary song", "jiggles their legs", "snaps their fingers" }) + "!" );
				}
			}
			return;
		}

	}

}