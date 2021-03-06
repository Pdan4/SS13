// FILE AUTOGENERATED BY SOMNIUM13.

using System;
using Somnium.Engine.ByImpl;

namespace Somnium.Game {
	class Obj_Machinery_Airalarm_Server : Obj_Machinery_Airalarm {

		protected override void __FieldInit() {
			base.__FieldInit();

			this.TLV = new ByTable()
				.Set( "pressure", new Tlv( -1, -1, -1, -1 ) )
				.Set( "temperature", new Tlv( -1, -1, -1, -1 ) )
				.Set( "o2", new Tlv( -1, -1, -1, -1 ) )
				.Set( "n2", new Tlv( -1, -1, -1, -1 ) )
				.Set( "co2", new Tlv( -1, -1, -1, -1 ) )
				.Set( "plasma", new Tlv( -1, -1, -1, -1 ) )
				.Set( "n2o", new Tlv( -1, -1, -1, -1 ) )
			;
		}

		public Obj_Machinery_Airalarm_Server ( dynamic loc = null, dynamic ndir = null, dynamic nbuild = null ) : base( (object)(loc), (object)(ndir), (object)(nbuild) ) {
			
		}

	}

}