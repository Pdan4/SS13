// FILE AUTOGENERATED BY SOM13. DO NOT EDIT YET.

using System;
using Somnium.Engine.ByImpl;

namespace Somnium.Game {
	class Obj_Effect_Blob_Factory : Obj_Effect_Blob {

		public ByTable spores = new ByTable();
		public int max_spores = 3;
		public int spore_delay = 0;

		protected override void __FieldInit() {
			base.__FieldInit();

			this.health = 200;
			this.maxhealth = 200;
			this.point_return = 25;
			this.icon_state = "blob_factory";
		}

		public Obj_Effect_Blob_Factory ( dynamic loc = null ) : base( (object)(loc) ) {
			
		}

		// Function from file: factory.dm
		public override bool run_action(  ) {
			Mob_Living_SimpleAnimal_Hostile_Blob_Blobspore BS = null;

			
			if ( this.spores.len >= this.max_spores ) {
				return false;
			}

			if ( this.spore_delay > Game13.time ) {
				return false;
			}
			this.spore_delay = Game13.time + 100;
			this.PulseAnimation( true );
			BS = new Mob_Living_SimpleAnimal_Hostile_Blob_Blobspore( this.loc, this );

			if ( this.overmind != null ) {
				BS.overmind = this.overmind;
				BS.update_icons();
				this.overmind.blob_mobs.Add( BS );
			}
			return false;
		}

		// Function from file: factory.dm
		public override void PulseAnimation( bool? activate = null ) {
			activate = activate ?? false;

			
			if ( activate == true ) {
				base.PulseAnimation( activate );
			}
			return;
		}

		// Function from file: factory.dm
		public override dynamic Destroy(  ) {
			Mob_Living_SimpleAnimal_Hostile_Blob_Blobspore spore = null;

			
			foreach (dynamic _a in Lang13.Enumerate( this.spores, typeof(Mob_Living_SimpleAnimal_Hostile_Blob_Blobspore) )) {
				spore = _a;
				

				if ( spore.factory == this ) {
					spore.factory = null;
				}
			}
			this.spores = null;
			return base.Destroy();
		}

	}

}