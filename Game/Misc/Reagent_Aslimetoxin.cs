// FILE AUTOGENERATED BY SOMNIUM13.

using System;
using Somnium.Engine.ByImpl;

namespace Somnium.Game {
	class Reagent_Aslimetoxin : Reagent {

		protected override void __FieldInit() {
			base.__FieldInit();

			this.name = "Advanced Mutation Toxin";
			this.id = "amutationtoxin";
			this.description = "An advanced corruptive toxin produced by slimes.";
			this.reagent_state = 2;
			this.color = "#13BC5E";
			this.overdose = 30;
		}

		// Function from file: Chemistry-Reagents.dm
		public override bool on_mob_life( Mob_Living M = null, int? alien = null ) {
			Mob_Living C = null;
			Obj_Item W = null;
			Mob_Living_Carbon_Slime new_mob = null;

			
			if ( base.on_mob_life( M, alien ) ) {
				return true;
			}

			if ( M is Mob_Living_Carbon && M.stat != 2 ) {
				C = M;

				if ( C is Mob_Living_Carbon_Human_Manifested ) {
					GlobalFuncs.to_chat( C, "<span class='warning'>You can feel intriguing reagents seeping into your body, but they don't seem to react at all.</span>" );
					((Reagents)C.reagents).del_reagent( "amutationtoxin" );
				} else {
					
					if ( C.monkeyizing ) {
						return false;
					}
					GlobalFuncs.to_chat( M, "<span class='warning'>Your flesh rapidly mutates!</span>" );
					C.monkeyizing = true;
					C.canmove = false;
					C.icon = null;
					C.overlays.len = 0;
					C.invisibility = 101;

					foreach (dynamic _a in Lang13.Enumerate( C, typeof(Obj_Item) )) {
						W = _a;
						

						if ( W is Obj_Item_Weapon_Implant ) {
							GlobalFuncs.qdel( W );
							continue;
						}
						W.layer = Convert.ToDouble( Lang13.Initial( W, "layer" ) );
						W.loc = C.loc;
						W.dropped( C );
					}
					new_mob = new Mob_Living_Carbon_Slime( C.loc );
					new_mob.a_intent = "hurt";

					if ( C.mind != null ) {
						C.mind.transfer_to( new_mob );
					} else {
						new_mob.key = C.key;
					}
					GlobalFuncs.qdel( C );
				}
			}
			return false;
		}

	}

}