// FILE AUTOGENERATED BY SOMNIUM13.

using System;
using Somnium.Engine.ByImpl;

namespace Somnium.Game {
	class Obj_Item_Weapon_Kitchen_Rollingpin : Obj_Item_Weapon_Kitchen {

		protected override void __FieldInit() {
			base.__FieldInit();

			this.hitsound = "sound/weapons/smash.ogg";
			this.force = 8;
			this.throwforce = 10;
			this.autoignition_temperature = 573.1500244140625;
			this.attack_verb = new ByTable(new object [] { "bashed", "battered", "bludgeoned", "thrashed", "whacked" });
			this.icon_state = "rolling_pin";
		}

		public Obj_Item_Weapon_Kitchen_Rollingpin ( dynamic loc = null ) : base( (object)(loc) ) {
			
		}

		// Function from file: kitchen.dm
		public override bool? attack( dynamic M = null, dynamic user = null, string def_zone = null, bool? eat_override = null ) {
			string t = null;
			dynamic H = null;
			int time = 0;

			Interface13.Stat( null, user.mutations.Contains( 5 ) );

			if ( false && Rand13.PercentChance( 50 ) ) {
				GlobalFuncs.to_chat( user, "<span class='warning'>The " + this + " slips out of your hand and hits your head.</span>" );
				((Mob_Living)user).take_organ_damage( 10 );
				((Mob)user).Paralyse( 2 );
				return null;
			}
			M.attack_log.Add( "[" + GlobalFuncs.time_stamp() + "] <font color='orange'>Has been attacked with " + this.name + " by " + user.name + " (" + user.ckey + ")</font>" );
			user.attack_log.Add( "[" + GlobalFuncs.time_stamp() + "] <font color='red'>Used the " + this.name + " to attack " + M.name + " (" + M.ckey + ")</font>" );
			GlobalVars.diaryofmeanpeople.WriteMsg( String13.HtmlDecode( "[" + GlobalFuncs.time_stamp() + "]ATTACK: " + ( "<font color='red'>" + user.name + " (" + user.ckey + ") used the " + this.name + " to attack " + M.name + " (" + M.ckey + ")</font>" ) ) );

			if ( !( user is Mob_Living_Carbon ) ) {
				M.LAssailant = null;
			} else {
				M.LAssailant = user;
			}
			t = ((dynamic)user.zone_sel).selecting;

			if ( t == "head" ) {
				
				if ( M is Mob_Living_Carbon_Human ) {
					H = M;

					if ( Convert.ToDouble( H.stat ) < 2 && Convert.ToDouble( H.health ) < 50 && Rand13.PercentChance( 90 ) ) {
						
						if ( H is Obj_Item_Clothing_Head && Lang13.Bool( H.flags & 8 ) && Rand13.PercentChance( 80 ) ) {
							GlobalFuncs.to_chat( H, "<span class='warning'>The helmet protects you from being hit hard in the head!</span>" );
							return null;
						}
						time = Rand13.Int( 2, 6 );

						if ( Rand13.PercentChance( 75 ) ) {
							((Mob)H).Paralyse( time );
						} else {
							((Mob)H).Stun( time );
						}

						if ( Convert.ToInt32( H.stat ) != 2 ) {
							H.stat = 1;
						}
						((Ent_Static)user).visible_message( "<span class='danger'><B>" + H + " has been knocked unconscious!</B>", "<span class='warning'>You knock " + H + " unconscious!</span></span>" );
						return null;
					} else {
						((Ent_Static)H).visible_message( "<span class='warning'>" + user + " tried to knock " + H + " unconscious!</span>", "<span class='warning'>" + user + " tried to knock you unconscious!</span>" );
						H.eye_blurry += 3;
					}
				}
			}
			return base.attack( (object)(M), (object)(user), def_zone, eat_override );
		}

	}

}