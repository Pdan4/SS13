// FILE AUTOGENERATED BY SOMNIUM13.

using System;
using Somnium.Engine.ByImpl;

namespace Somnium.Game {
	class Obj_Item_Organ_Internal_BodyEgg_ChangelingEgg : Obj_Item_Organ_Internal_BodyEgg {

		public Mind origin = null;
		public int time = 0;

		protected override void __FieldInit() {
			base.__FieldInit();

			this.origin_tech = "biotech=7";
		}

		public Obj_Item_Organ_Internal_BodyEgg_ChangelingEgg ( dynamic loc = null ) : base( (object)(loc) ) {
			
		}

		// Function from file: headcrab.dm
		public void Pop(  ) {
			Mob_Living_Carbon_Monkey M = null;
			Obj_Item_Organ_Internal I = null;

			M = new Mob_Living_Carbon_Monkey( this.owner );
			this.owner.stomach_contents.Add( M );

			foreach (dynamic _a in Lang13.Enumerate( this, typeof(Obj_Item_Organ_Internal) )) {
				I = _a;
				
				I.Insert( M, 1 );
			}

			if ( this.origin != null && Lang13.Bool( this.origin.current ) && Convert.ToInt32( this.origin.current.stat ) == 2 ) {
				this.origin.transfer_to( M );

				if ( !( this.origin.changeling != null ) ) {
					M.make_changeling();
				}

				if ( this.origin.changeling.can_absorb_dna( M, this.owner ) ) {
					this.origin.changeling.add_new_profile( this.owner, M );
				}
				this.origin.changeling.purchasedpowers.Add( new Obj_Effect_ProcHolder_Changeling_Humanform( null ) );
				M.key = this.origin.key;
			}
			((Mob)this.owner).gib();
			return;
		}

		// Function from file: headcrab.dm
		public override void egg_process(  ) {
			this.time++;

			if ( this.time >= 120 ) {
				this.Pop();
				this.Remove( this.owner );
				GlobalFuncs.qdel( this );
			}
			return;
		}

	}

}