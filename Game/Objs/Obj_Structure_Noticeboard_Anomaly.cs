// FILE AUTOGENERATED BY SOMNIUM13.

using System;
using Somnium.Engine.ByImpl;

namespace Somnium.Game {
	class Obj_Structure_Noticeboard_Anomaly : Obj_Structure_Noticeboard {

		protected override void __FieldInit() {
			base.__FieldInit();

			this.notices = 5;
			this.icon_state = "nboard05";
		}

		// Function from file: misc.dm
		public Obj_Structure_Noticeboard_Anomaly ( dynamic loc = null ) : base( (object)(loc) ) {
			Obj_Item_Weapon_Paper P = null;

			P = new Obj_Item_Weapon_Paper();
			P.name = "Memo RE: proper analysis procedure";
			P.info = "<br>We keep test dummies in pens here for a reason, so standard procedure should be to activate newfound alien artifacts and place the two in close proximity. Promising items I might even approve monkey testing on.";
			P.stamped = new ByTable(new object [] { typeof(Obj_Item_Weapon_Stamp_Rd) });
			P.overlays = new ByTable(new object [] { "paper_stamped_rd" });
			this.contents.Add( P );
			P = new Obj_Item_Weapon_Paper();
			P.name = "Memo RE: materials gathering";
			P.info = "Corasang,<br>the hands-on approach to gathering our samples may very well be slow at times, but it's safer than allowing the blundering miners to roll willy-nilly over our dig sites in their mechs, destroying everything in the process. And don't forget the escavation tools on your way out there!<br>- R.W";
			P.stamped = new ByTable(new object [] { typeof(Obj_Item_Weapon_Stamp_Rd) });
			P.overlays = new ByTable(new object [] { "paper_stamped_rd" });
			this.contents.Add( P );
			P = new Obj_Item_Weapon_Paper();
			P.name = "Memo RE: ethical quandaries";
			P.info = "Darion-<br><br>I don't care what his rank is, our business is that of science and knowledge - questions of moral application do not come into this. Sure, so there are those who would employ the energy-wave particles my modified device has managed to abscond for their own personal gain, but I can hardly see the practical benefits of some of these artifacts our benefactors left behind. Ward--";
			P.stamped = new ByTable(new object [] { typeof(Obj_Item_Weapon_Stamp_Rd) });
			P.overlays = new ByTable(new object [] { "paper_stamped_rd" });
			this.contents.Add( P );
			P = new Obj_Item_Weapon_Paper();
			P.name = "READ ME! Before you people destroy any more samples";
			P.info = "how many times do i have to tell you people, these xeno-arch samples are del-i-cate, and should be handled so! careful application of a focussed, concentrated heat or some corrosive liquids should clear away the extraneous carbon matter, while application of an energy beam will most decidedly destroy it entirely - like someone did to the chemical dispenser! W, <b>the one who signs your paychecks</b>";
			P.stamped = new ByTable(new object [] { typeof(Obj_Item_Weapon_Stamp_Rd) });
			P.overlays = new ByTable(new object [] { "paper_stamped_rd" });
			this.contents.Add( P );
			P = new Obj_Item_Weapon_Paper();
			P.name = "Reminder regarding the anomalous material suits";
			P.info = "Do you people think the anomaly suits are cheap to come by? I'm about a hair trigger away from instituting a log book for the damn things. Only wear them if you're going out for a dig, and for god's sake don't go tramping around in them unless you're field testing something, R";
			P.stamped = new ByTable(new object [] { typeof(Obj_Item_Weapon_Stamp_Rd) });
			P.overlays = new ByTable(new object [] { "paper_stamped_rd" });
			this.contents.Add( P );
			return;
		}

	}

}