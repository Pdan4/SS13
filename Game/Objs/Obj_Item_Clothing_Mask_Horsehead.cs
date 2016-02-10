// FILE AUTOGENERATED BY SOMNIUM13.

using System;
using Somnium.Engine.ByImpl;

namespace Somnium.Game {
	class Obj_Item_Clothing_Mask_Horsehead : Obj_Item_Clothing_Mask {

		public bool voicechange = false;

		protected override void __FieldInit() {
			base.__FieldInit();

			this.item_state = "horsehead";
			this.body_parts_covered = 38912;
			this.w_class = 2;
			this.siemens_coefficient = 081;
			this.icon_state = "horsehead";
		}

		public Obj_Item_Clothing_Mask_Horsehead ( dynamic loc = null ) : base( (object)(loc) ) {
			
		}

		// Function from file: miscellaneous.dm
		public override void treat_mask_speech( Game_Data speech = null ) {
			
			if ( this.voicechange ) {
				((dynamic)speech).message = Rand13.Pick(new object [] { "NEEIIGGGHHHH!", "NEEEIIIIGHH!", "NEIIIGGHH!", "HAAWWWWW!", "HAAAWWW!" });
			}
			return;
		}

	}

}