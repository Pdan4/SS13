// FILE AUTOGENERATED BY SOMNIUM13.

using System;
using Somnium.Engine.ByImpl;

namespace Somnium.Game {
	class Obj_Effect_Gibspawner_Generic : Obj_Effect_Gibspawner {

		protected override void __FieldInit() {
			base.__FieldInit();

			this.gibtypes = new ByTable(new object [] { typeof(Obj_Effect_Decal_Cleanable_Blood_Gibs), typeof(Obj_Effect_Decal_Cleanable_Blood_Gibs), typeof(Obj_Effect_Decal_Cleanable_Blood_Gibs_Core) });
			this.gibamounts = new ByTable(new object [] { 2, 2, 1 });
		}

		// Function from file: gibspawner.dm
		public Obj_Effect_Gibspawner_Generic ( dynamic location = null, ByTable viruses = null, Dna MobDNA = null ) : base( (object)(location), viruses, MobDNA ) {
			GlobalFuncs.playsound( this, "sound/effects/blobattack.ogg", 40, 1 );
			this.gibdirections = new ByTable(new object [] { 
				new ByTable(new object [] { GlobalVars.WEST, GlobalVars.NORTHWEST, GlobalVars.SOUTHWEST, GlobalVars.NORTH }), 
				new ByTable(new object [] { GlobalVars.EAST, GlobalVars.NORTHEAST, GlobalVars.SOUTHEAST, GlobalVars.SOUTH }), 
				new ByTable()
			 });
			// Warning: Super call was HERE! If anything above HERE is needed by the super call, it might break!;
			return;
		}

	}

}