// FILE AUTOGENERATED BY SOMNIUM13.

using System;
using Somnium.Engine.ByImpl;

namespace Somnium.Game {
	class Obj_Item_Weapon_Storage_Book : Obj_Item_Weapon_Storage {

		public dynamic title = "book";

		protected override void __FieldInit() {
			base.__FieldInit();

			this.throw_range = 5;
			this.burn_state = 0;
			this.icon = "icons/obj/library.dmi";
			this.icon_state = "book";
		}

		public Obj_Item_Weapon_Storage_Book ( dynamic loc = null ) : base( (object)(loc) ) {
			
		}

		// Function from file: book.dm
		public override dynamic attack_self( dynamic user = null, dynamic flag = null, bool? emp = null ) {
			user.WriteMsg( "<span class='notice'>The pages of " + this.title + " have been cut out!</span>" );
			return null;
		}

	}

}