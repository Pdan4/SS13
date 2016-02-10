// FILE AUTOGENERATED BY SOMNIUM13.

using System;
using Somnium.Engine.ByImpl;

namespace Somnium.Game {
	class Mob_Living_SimpleAnimal_Cow : Mob_Living_SimpleAnimal {

		public Reagents udder = null;

		protected override void __FieldInit() {
			base.__FieldInit();

			this.icon_living = "cow";
			this.icon_dead = "cow_dead";
			this.icon_gib = "cow_gib";
			this.speak = new ByTable(new object [] { "moo?", "moo", "MOOOOOO" });
			this.speak_emote = new ByTable(new object [] { "moos", "moos hauntingly" });
			this.emote_hear = new ByTable(new object [] { "brays" });
			this.emote_see = new ByTable(new object [] { "shakes its head" });
			this.speak_chance = 1;
			this.turns_per_move = 5;
			this.response_help = "pets";
			this.response_disarm = "gently pushes aside";
			this.response_harm = "kicks";
			this.attacktext = "kicks";
			this.health = 50;
			this.size = 4;
			this.holder_type = typeof(Obj_Item_Weapon_Holder_Animal_Cow);
			this.icon_state = "cow";
			this.see_in_dark = 6;
		}

		// Function from file: farm_animals.dm
		public Mob_Living_SimpleAnimal_Cow ( dynamic loc = null ) : base( (object)(loc) ) {
			this.udder = new Reagents( 50 );
			this.udder.my_atom = this;
			// Warning: Super call was HERE! If anything above HERE is needed by the super call, it might break!;
			return;
		}

		// Function from file: farm_animals.dm
		public override dynamic attack_hand( dynamic a = null, dynamic b = null, dynamic c = null ) {
			ByTable responses = null;

			
			if ( !Lang13.Bool( this.stat ) && a.a_intent == "disarm" && this.icon_state != this.icon_dead ) {
				((Ent_Static)a).visible_message( "<span class='warning'>" + a + " tips over " + this + ".</span>", "<span class='notice'>You tip over " + this + ".</span>" );
				this.Weaken( 30 );
				this.icon_state = this.icon_dead;
				Task13.Schedule( Rand13.Int( 20, 50 ), (Task13.Closure)(() => {
					
					if ( !Lang13.Bool( this.stat ) && Lang13.Bool( a ) ) {
						this.icon_state = this.icon_living;
						responses = new ByTable(new object [] { 
							"" + this + " looks at you imploringly.", 
							"" + this + " looks at you pleadingly", 
							"" + this + " looks at you with a resigned expression.", 
							"" + this + " seems resigned to its fate."
						 });
						GlobalFuncs.to_chat( a, Rand13.PickFromTable( responses ) );
					}
					return;
				}));
			} else {
				base.attack_hand( (object)(a), (object)(b), (object)(c) );
			}
			return null;
		}

		// Function from file: farm_animals.dm
		public override bool Life(  ) {
			bool _default = false;

			
			if ( this.timestopped ) {
				return false;
			}
			_default = base.Life();

			if ( this.stat == 0 ) {
				
				if ( this.udder != null && Rand13.PercentChance( 5 ) ) {
					this.udder.add_reagent( "milk", Rand13.Int( 5, 10 ) );
				}
			}
			return _default;
		}

		// Function from file: farm_animals.dm
		public override dynamic attackby( dynamic a = null, dynamic b = null, dynamic c = null ) {
			dynamic G = null;
			dynamic transfered = null;

			
			if ( this.stat == 0 && a is Obj_Item_Weapon_ReagentContainers_Glass ) {
				((Ent_Static)b).visible_message( new Txt( "<span class='notice'>" ).item( b ).str( " milks " ).item( this ).str( " using " ).the( a ).item().str( ".</span>" ).ToString() );
				G = a;
				transfered = this.udder.trans_id_to( G, "milk", Rand13.Int( 5, 10 ) );

				if ( ( G.reagents.total_volume ??0) >= Convert.ToDouble( G.volume ) ) {
					GlobalFuncs.to_chat( b, "<span class='warning'>" + a + " is full.</span>" );
				}

				if ( !Lang13.Bool( transfered ) ) {
					GlobalFuncs.to_chat( b, "<span class='warning'>The udder is dry. Wait a bit longer...</span>" );
				}
			} else {
				base.attackby( (object)(a), (object)(b), (object)(c) );
			}
			return null;
		}

	}

}