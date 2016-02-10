// FILE AUTOGENERATED BY SOMNIUM13.

using System;
using Somnium.Engine.ByImpl;

namespace Somnium.Game {
	class Obj_Structure_Grille_Cult : Obj_Structure_Grille {

		protected override void __FieldInit() {
			base.__FieldInit();

			this.health = 40;
			this.icon_state = "grillecult";
		}

		public Obj_Structure_Grille_Cult ( dynamic loc = null ) : base( (object)(loc) ) {
			
		}

		// Function from file: grille.dm
		public override bool CanPass( dynamic mover = null, dynamic target = null, double? height = null, bool? air_group = null ) {
			height = height ?? 1.5;
			air_group = air_group ?? false;

			
			if ( air_group == true || !this.broken ) {
				return false;
			}
			base.CanPass( (object)(mover), (object)(target), height, air_group );
			return false;
		}

	}

}