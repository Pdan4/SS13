// FILE AUTOGENERATED BY SOMNIUM13.

using System;
using Somnium.Engine.ByImpl;

namespace Somnium.Game {
	class Obj_Item_Weapon_ReagentContainers_Food_Drinks_Mug : Obj_Item_Weapon_ReagentContainers_Food_Drinks {

		protected override void __FieldInit() {
			base.__FieldInit();

			this.amount_per_transfer_from_this = 10;
			this.starting_materials = new ByTable().Set( "$iron", 500 );
			this.icon = "icons/obj/cafe.dmi";
			this.icon_state = "mug_empty";
		}

		public Obj_Item_Weapon_ReagentContainers_Food_Drinks_Mug ( dynamic loc = null ) : base( (object)(loc) ) {
			
		}

		// Function from file: vgstation13.dme
		public override void on_reagent_change(  ) {
			
			if ( this.reagents.reagent_list.len > 0 ) {
				
				switch ((string)( ((Reagents)this.reagents).get_master_reagent_id() )) {
					case "tea":
						this.icon_state = "tea";
						this.name = "Tea";
						this.desc = "A warm mug of tea.";
						break;
					case "greentea":
						this.icon_state = "greentea";
						this.name = "Green Tea";
						this.desc = "Green Tea served in a traditional Japanese tea cup, just like in your Chinese cartoons!";
						break;
					case "redtea":
						this.icon_state = "redtea";
						this.name = "Red Tea";
						this.desc = "Red Tea served in a traditional Chinese tea cup, just like in your Malaysian movies!";
						break;
					case "acidtea":
						this.icon_state = "acidtea";
						this.name = "Earl's Grey Tea";
						this.desc = "A sizzling mug of tea made just for Greys.";
						break;
					case "yinyang":
						this.icon_state = "yinyang";
						this.name = "Zen Tea";
						this.desc = "Enjoy inner peace and ignore the watered down taste";
						break;
					case "dantea":
						this.icon_state = "dantea";
						this.name = "Discount Dans Green Flavor Tea";
						this.desc = "Tea probably shouldn't be sizzling like that...";
						break;
					case "singularitea":
						this.icon_state = "singularitea";
						this.name = "Singularitea";
						this.desc = "Brewed under intense radiation to be extra flavorful!";
						break;
					case "mint":
						this.icon_state = "mint";
						this.name = "Groans Tea: Minty Delight Flavor";
						this.desc = "Groans knows mint might not be the kind of flavor our fans expect from us, but we've made sure to give it that patented Groans zing.";
						break;
					case "chamomile":
						this.icon_state = "chamomile";
						this.name = "Groans Tea: Chamomile Flavor";
						this.desc = "Groans presents the perfect cure for insomnia; Chamomile!";
						break;
					case "exchamomile":
						this.icon_state = "exchamomile";
						this.name = "Groans Banned Tea: EXTREME Chamomile Flavor";
						this.desc = "Banned literally everywhere.";
						break;
					case "fancydan":
						this.icon_state = "fancydan";
						this.name = "Groans Banned Tea: Fancy Dan Flavor";
						this.desc = "Banned literally everywhere.";
						break;
					case "gyro":
						this.icon_state = "gyro";
						this.name = "Gyro";
						this.desc = "Nyo ho ho~";
						break;
					case "chifir":
						this.icon_state = "chifir";
						this.name = "Chifir";
						this.desc = "Russian style of tea, not for those with weak stomachs.";
						break;
					case "plasmatea":
						this.icon_state = "plasmatea";
						this.name = "Plasma Pekoe";
						this.desc = "You can practically taste the science, or maybe that's just the horrible plasma burns.";
						break;
					case "coffee":
						this.icon_state = "coffee";
						this.name = "Coffee";
						this.desc = "A warm mug of coffee.";
						break;
					case "cafe_latte":
						this.icon_state = "latte";
						this.name = "Latte";
						this.desc = "Coffee made with espresso and milk.";
						break;
					case "soy_latte":
						this.icon_state = "soylatte";
						this.name = "Soy Latte";
						this.desc = "Latte made with soy milk.";
						break;
					case "espresso":
						this.icon_state = "espresso";
						this.name = "Espresso";
						this.desc = "Coffee made with water.";
						break;
					case "cappuccino":
						this.icon_state = "cappuccino";
						this.name = "Cappuccino";
						this.desc = "coffee made with espresso, milk, and steamed milk.";
						break;
					case "doppio":
						this.icon_state = "doppio";
						this.name = "Doppio";
						this.desc = "Ring ring ring";
						break;
					case "tonio":
						this.icon_state = "tonio";
						this.name = "Tonio";
						this.desc = "Delicious, and it'll help you out if you get in a Jam.";
						break;
					case "passione":
						this.icon_state = "passione";
						this.name = "Passione";
						this.desc = "Sometimes referred to as a 'Venti Aureo'";
						break;
					case "seccoffee":
						this.icon_state = "seccoffee";
						this.name = "Wake up call";
						this.desc = "The perfect start for any Sec officer's day.";
						break;
					case "medcoffee":
						this.icon_state = "medcoffee";
						this.name = "Lifeline";
						this.desc = "Some days, the only thing that keeps you going is cryo and caffeine.";
						break;
					case "detcoffee":
						this.icon_state = "detcoffee";
						this.name = "Joe";
						this.desc = "The lights, the smoke, the grime, the station itself felt alive that day as I stepped into my office, mug in hand. It was another one of those days. Some Nurse got smoked in one of the tunnels, and it came down to me to catch the guy did it. I got up to close the blinds of my office, when an officer burst through my door. There had been another one offed in the tunnels, this time an assistant. I grumbled and downed some of my joe. It was bitter, tasteless, but it was what kept me going. I remember back when I was a rookie, this stuff used to taste so great to me. I guess that's just another sign of how this station changes people. I put my mug back down on my desk, dusted off my jacket, and lit my last cigar. I checked to make sure my faithful revolver was loaded, and stepped out, back into the cold halls of the station.";
						break;
					case "etank":
						this.icon_state = "etank";
						this.name = "Recharger";
						this.desc = "Helps you get back on your feet after a long day of robot maintenance. Can also be used as a substitute for motor oil.";
						break;
					case "greytea":
						this.icon_state = "greytea";
						this.name = "Tide";
						this.desc = "This probably shouldn't be considered tea...";
						break;
					default:
						this.icon_state = "mug_what";
						this.name = "mug of ..something?";
						this.desc = "You aren't really sure what this is.";
						break;
				}
			} else {
				this.icon_state = "mug_empty";
				this.name = "mug";
				this.desc = "A simple mug.";
				return;
			}
			return;
		}

	}

}