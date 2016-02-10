// FILE AUTOGENERATED BY SOMNIUM13.

using System;
using Somnium.Engine.ByImpl;

namespace Somnium.Game {
	class Obj_Item_Commstone : Obj_Item {

		public Obj_Machinery_Communication commdevice = null;
		public dynamic number = null;

		protected override void __FieldInit() {
			base.__FieldInit();

			this.w_class = 2;
			this.icon = "icons/obj/xenoarchaeology.dmi";
			this.icon_state = "crystal1";
		}

		// Function from file: artifact_communication.dm
		public Obj_Item_Commstone ( dynamic remaining = null ) : base( (object)(remaining) ) {
			// Warning: Super call was HERE! If anything above HERE is needed by the super call, it might break!;
			this.number = remaining;
			this.update_icon();
			return;
		}

		// Function from file: vgstation13.dme
		public override bool? update_icon( dynamic location = null, dynamic target = null ) {
			this.icon_state = "crystal" + this.number;
			return null;
		}

		// Function from file: artifact_communication.dm
		public override dynamic examine( dynamic user = null, string size = null ) {
			base.examine( (object)(user), size );

			if ( !( this.commdevice != null ) || ( this.commdevice.stat & 2 ) != 0 ) {
				GlobalFuncs.to_chat( user, "<span class='info'>It seems to have lost its luster, perhaps the device it is connected to isn't functional." );
			}
			return null;
		}

	}

}