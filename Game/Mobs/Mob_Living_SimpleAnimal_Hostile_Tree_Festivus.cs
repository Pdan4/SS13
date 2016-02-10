// FILE AUTOGENERATED BY SOMNIUM13.

using System;
using Somnium.Engine.ByImpl;

namespace Somnium.Game {
	class Mob_Living_SimpleAnimal_Hostile_Tree_Festivus : Mob_Living_SimpleAnimal_Hostile_Tree {

		protected override void __FieldInit() {
			base.__FieldInit();

			this.icon_living = "festivus_pole";
			this.icon_dead = "festivus_pole";
			this.icon_gib = "festivus_pole";
			this.icon_state = "festivus_pole";
		}

		public Mob_Living_SimpleAnimal_Hostile_Tree_Festivus ( dynamic loc = null ) : base( (object)(loc) ) {
			
		}

		// Function from file: tree.dm
		public override void Die( bool? gore = null ) {
			this.visible_message( "<span class='warning'><b>" + this + "</b> is hacked into pieces!</span>" );
			new Obj_Item_Weapon_Nullrod( this.loc );
			GlobalFuncs.qdel( this );
			return;
		}

	}

}