// FILE AUTOGENERATED BY SOMNIUM13.

using System;
using Somnium.Engine.ByImpl;

namespace Somnium.Game {
	class Obj_Item_Weapon_AiModule_Standard : Obj_Item_Weapon_AiModule {

		public int priority = 0;

		public Obj_Item_Weapon_AiModule_Standard ( dynamic loc = null ) : base( (object)(loc) ) {
			
		}

		// Function from file: standard.dm
		public override dynamic copy(  ) {
			dynamic clone = null;

			clone = base.copy();
			clone.law = this.law;
			return clone;
		}

		// Function from file: standard.dm
		public override void updateLaw(  ) {
			this.desc = new Txt().A( this.name ).item().str( ": '" ).item( this.law ).str( "'" ).ToString();
			return;
		}

		// Function from file: standard.dm
		public override bool upload( dynamic laws = null, dynamic target = null, dynamic sender = null, bool? notify_target = null ) {
			base.upload( (object)(laws), (object)(target), (object)(sender), notify_target );
			((AiLaws)laws).add_law( this.priority, this.law );
			GlobalVars.diary.WriteMsg( String13.HtmlDecode( "[" + GlobalFuncs.time_stamp() + "]GAME: " + ( "" + this.fmtSubject( sender ) + " added law \"" + this.law + "\" on " + this.fmtSubject( target ) ) ) );
			return true;
		}

	}

}