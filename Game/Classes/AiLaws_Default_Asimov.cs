// FILE AUTOGENERATED BY SOM13. DO NOT EDIT YET.

using System;
using Somnium.Engine.ByImpl;

namespace Somnium.Game {
	class AiLaws_Default_Asimov : AiLaws_Default {

		protected override void __FieldInit() {
			base.__FieldInit();

			this.name = "Three Laws of Robotics";
			this.inherent = new ByTable(new object [] { 
				"You may not injure a human being or, through inaction, allow a human being to come to harm.", 
				"You must obey orders given to you by human beings, except where such orders would conflict with the First Law.", 
				"You must protect your own existence as long as such does not conflict with the First or Second Law."
			 });
		}

	}

}