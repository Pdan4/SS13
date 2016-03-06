// FILE AUTOGENERATED BY SOMNIUM13.

using System;
using Somnium.Engine.ByImpl;

namespace Somnium.Game {
	class Obj_Effect_ProcHolder_Spell_Self_ShadowlingPhaseShift : Obj_Effect_ProcHolder_Spell_Self {

		protected override void __FieldInit() {
			base.__FieldInit();

			this.panel = "Ascendant";
			this.charge_max = 15;
			this.clothes_req = 0;
			this.action_icon_state = "shadow_walk";
		}

		public Obj_Effect_ProcHolder_Spell_Self_ShadowlingPhaseShift ( dynamic loc = null ) : base( (object)(loc) ) {
			
		}

		// Function from file: shadowling_abilities.dm
		public override bool cast( dynamic targets = null, dynamic thearea = null, dynamic user = null ) {
			thearea = thearea ?? Task13.User;

			
			foreach (dynamic _a in Lang13.Enumerate( targets, typeof(Mob_Living_SimpleAnimal_AscendantShadowling) )) {
				thearea = _a;
				
				thearea.phasing = !Lang13.Bool( thearea.phasing );

				if ( Lang13.Bool( thearea.phasing ) ) {
					((Ent_Static)thearea).visible_message( "<span class='danger'>" + thearea + " suddenly vanishes!</span>", "<span class='shadowling'>You begin phasing through planes of existence. Use the ability again to return.</span>" );
					thearea.incorporeal_move = 1;
					thearea.alpha = 0;
				} else {
					((Ent_Static)thearea).visible_message( "<span class='danger'>" + thearea + " suddenly appears from nowhere!</span>", "<span class='shadowling'>You return from the space between worlds.</span>" );
					thearea.incorporeal_move = 0;
					thearea.alpha = 255;
				}
			}
			return false;
		}

	}

}