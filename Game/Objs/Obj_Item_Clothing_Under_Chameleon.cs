// FILE AUTOGENERATED BY SOMNIUM13.

using System;
using Somnium.Engine.ByImpl;

namespace Somnium.Game {
	class Obj_Item_Clothing_Under_Chameleon : Obj_Item_Clothing_Under {

		public ByTable clothing_choices = new ByTable();

		protected override void __FieldInit() {
			base.__FieldInit();

			this.item_state = "bl_suit";
			this._color = "black";
			this.origin_tech = "syndicate=3";
			this.siemens_coefficient = 0.8;
			this.icon_state = "black";
		}

		// Function from file: chameleon.dm
		public Obj_Item_Clothing_Under_Chameleon ( dynamic loc = null ) : base( (object)(loc) ) {
			dynamic U = null;
			dynamic V = null;
			dynamic U2 = null;
			dynamic V2 = null;

			// Warning: Super call was HERE! If anything above HERE is needed by the super call, it might break!;

			foreach (dynamic _a in Lang13.Enumerate( Lang13.GetTypes( typeof(Obj_Item_Clothing_Under_Color) ) - typeof(Obj_Item_Clothing_Under_Color) )) {
				U = _a;
				
				V = Lang13.Call( U );
				this.clothing_choices.Add( V );
			}

			foreach (dynamic _b in Lang13.Enumerate( Lang13.GetTypes( typeof(Obj_Item_Clothing_Under_Rank) ) - typeof(Obj_Item_Clothing_Under_Rank) )) {
				U2 = _b;
				
				V2 = Lang13.Call( U2 );
				this.clothing_choices.Add( V2 );
			}
			return;
		}

		// Function from file: chameleon.dm
		public override dynamic emp_act( int severity = 0 ) {
			this.name = "psychedelic";
			this.desc = "Groovy!";
			this.icon_state = "psyche";
			this._color = "psyche";
			Task13.Schedule( 200, (Task13.Closure)(() => {
				this.name = "Black Jumpsuit";
				this.icon_state = "bl_suit";
				this._color = "black";
				this.desc = null;
				return;
			}));
			base.emp_act( severity );
			return null;
		}

		// Function from file: chameleon.dm
		public override dynamic attackby( dynamic a = null, dynamic b = null, dynamic c = null ) {
			base.attackby( (object)(a), (object)(b), (object)(c) );

			if ( a is Obj_Item_Clothing_Under_Chameleon ) {
				GlobalFuncs.to_chat( b, "<span class='warning'>Nothing happens.</span>" );
				return null;
			}

			if ( a is Obj_Item_Clothing_Under ) {
				
				if ( this.clothing_choices.Find( a ) != 0 ) {
					GlobalFuncs.to_chat( b, "<span class='warning'>Pattern is already recognised by the suit.</span>" );
					return null;
				}
				this.clothing_choices.Add( a );
				GlobalFuncs.to_chat( b, "<span class='warning'>Pattern absorbed by the suit.</span>" );
			}
			return null;
		}

		// Function from file: chameleon.dm
		[Verb]
		[VerbInfo( name: "Change Color", group: "Object", access: VerbAccess.InUserContents, range: 127 )]
		public void change(  ) {
			dynamic A = null;

			
			if ( this.icon_state == "psyche" ) {
				GlobalFuncs.to_chat( Task13.User, "<span class='warning'>Your suit is malfunctioning</span>" );
				return;
			}
			A = Interface13.Input( "Select Colour to change it to", "BOOYEA", A, null, this.clothing_choices, InputType.Any );

			if ( !Lang13.Bool( A ) ) {
				return;
			}
			this.desc = null;
			this.permeability_coefficient = 081;
			this.desc = A.desc;
			this.name = A.name;
			this.icon_state = A.icon_state;
			this.item_state = A.item_state;
			this._color = A._color;
			Task13.User.update_inv_w_uniform();
			return;
		}

	}

}