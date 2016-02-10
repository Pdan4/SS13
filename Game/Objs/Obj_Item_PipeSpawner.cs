// FILE AUTOGENERATED BY SOMNIUM13.

using System;
using Somnium.Engine.ByImpl;

namespace Somnium.Game {
	class Obj_Item_PipeSpawner : Obj_Item {

		public int pipe_type = 0;

		protected override void __FieldInit() {
			base.__FieldInit();

			this.item_state = "buildpipe";
			this.icon = "icons/obj/pipe-item.dmi";
			this.icon_state = "simple";
		}

		// Function from file: construction.dm
		public Obj_Item_PipeSpawner ( dynamic loc = null ) : base( (object)(loc) ) {
			Game_Data P = null;

			// Warning: Super call was HERE! If anything above HERE is needed by the super call, it might break!;
			P = GlobalFuncs.getFromPool( typeof(Obj_Item_Pipe), this.loc );
			new ByTable().Set( 1, this.loc ).Set( "pipe_type", this.pipe_type ).Set( "dir", this.dir ).Apply( Lang13.BindFunc( P, "New" ) );
			((Obj_Item_Pipe)P).update();
			GlobalFuncs.qdel( this );
			return;
		}

	}

}