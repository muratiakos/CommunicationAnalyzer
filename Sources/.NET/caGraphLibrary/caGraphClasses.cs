using System;
using caCoreLibrary;
using Microsoft.Glee.Drawing;
using System.Collections.Generic;
using System.Linq;

namespace caGraphLibrary
{
	public enum caRelationGraphNodeTypeDisplayMode
	{
		UsersOnly,
		GroupsOnly,
		Both
	}

	public class caNodeFormat
	{
		public static void FormatAsUser(Node n, caGraphGleeColorService m_colorService)
		{
			try { n.Attr.Label = n.Attr.Label.Substring(0, 12) + "\n..."; }
			catch { }
			n.Attr.LabelMargin = 2;
			//n.Attr.Padding = 2;
			if (n.Attr.Fillcolor == caGraphGleeColorService.baseColor) n.Attr.Fillcolor = m_colorService.getNewColor();
			n.Attr.Shape = Microsoft.Glee.Drawing.Shape.Circle;
		}

		public static void FormatAsGroup(Node n, caGraphGleeColorService m_colorService)
		{
			try { n.Attr.Label = n.Attr.Label.Substring(0, 14) + "\n..."; }
			catch { }
			n.Attr.LabelMargin = 0;
			if (n.Attr.Fillcolor == caGraphGleeColorService.baseColor) n.Attr.Fillcolor = m_colorService.getNewColor();
			n.Attr.Shape = Microsoft.Glee.Drawing.Shape.DoubleCircle;
		}

		public static void FormatAsTag(Node n, caGraphGleeColorService m_colorService)
		{
			n.Attr.LabelMargin = 3;
			n.Attr.Fontsize = 22;
			n.Attr.XRad = 3;
			n.Attr.YRad = 3;
			if (n.Attr.Fillcolor == caGraphGleeColorService.baseColor) n.Attr.Fillcolor = m_colorService.getNewColor();
			n.Attr.Shape = Microsoft.Glee.Drawing.Shape.Box;
		}
	}

	public class caGraphGleeColorService
	{

		public static Microsoft.Glee.Drawing.Color baseColor = Microsoft.Glee.Drawing.Color.Transparent;

		public class caGraphGleeColor
		{
			public Microsoft.Glee.Drawing.Color color;
			public bool available = true;

			public caGraphGleeColor(Microsoft.Glee.Drawing.Color c)
			{
				color = c;
				available = true;
			}
		}
		List<caGraphGleeColor> emaGraphPalette = new List<caGraphGleeColor>();

		public caGraphGleeColorService()
		{
			emaGraphPalette.Add(new caGraphGleeColor(Microsoft.Glee.Drawing.Color.Gray));
			emaGraphPalette.Add(new caGraphGleeColor(Microsoft.Glee.Drawing.Color.Yellow));
			emaGraphPalette.Add(new caGraphGleeColor(Microsoft.Glee.Drawing.Color.Green));
			emaGraphPalette.Add(new caGraphGleeColor(Microsoft.Glee.Drawing.Color.Blue));
			emaGraphPalette.Add(new caGraphGleeColor(Microsoft.Glee.Drawing.Color.Red));
			emaGraphPalette.Add(new caGraphGleeColor(Microsoft.Glee.Drawing.Color.Orange));
			emaGraphPalette.Add(new caGraphGleeColor(Microsoft.Glee.Drawing.Color.Purple));
			emaGraphPalette.Add(new caGraphGleeColor(Microsoft.Glee.Drawing.Color.Pink));
			emaGraphPalette.Add(new caGraphGleeColor(Microsoft.Glee.Drawing.Color.Brown));
			emaGraphPalette.Add(new caGraphGleeColor(Microsoft.Glee.Drawing.Color.Maroon));
			emaGraphPalette.Add(new caGraphGleeColor(Microsoft.Glee.Drawing.Color.Lime));
			emaGraphPalette.Add(new caGraphGleeColor(Microsoft.Glee.Drawing.Color.AliceBlue));
			emaGraphPalette.Add(new caGraphGleeColor(Microsoft.Glee.Drawing.Color.AntiqueWhite));
			emaGraphPalette.Add(new caGraphGleeColor(Microsoft.Glee.Drawing.Color.Aqua));
			emaGraphPalette.Add(new caGraphGleeColor(Microsoft.Glee.Drawing.Color.Aquamarine));
			emaGraphPalette.Add(new caGraphGleeColor(Microsoft.Glee.Drawing.Color.Azure));
			emaGraphPalette.Add(new caGraphGleeColor(Microsoft.Glee.Drawing.Color.Beige));
			emaGraphPalette.Add(new caGraphGleeColor(Microsoft.Glee.Drawing.Color.Bisque));
			emaGraphPalette.Add(new caGraphGleeColor(Microsoft.Glee.Drawing.Color.BlueViolet));
			emaGraphPalette.Add(new caGraphGleeColor(Microsoft.Glee.Drawing.Color.BlanchedAlmond));
			emaGraphPalette.Add(new caGraphGleeColor(Microsoft.Glee.Drawing.Color.Brown));
			emaGraphPalette.Add(new caGraphGleeColor(Microsoft.Glee.Drawing.Color.BurlyWood));
			emaGraphPalette.Add(new caGraphGleeColor(Microsoft.Glee.Drawing.Color.CadetBlue));
			emaGraphPalette.Add(new caGraphGleeColor(Microsoft.Glee.Drawing.Color.Chartreuse));
			emaGraphPalette.Add(new caGraphGleeColor(Microsoft.Glee.Drawing.Color.Chocolate));
			emaGraphPalette.Add(new caGraphGleeColor(Microsoft.Glee.Drawing.Color.Coral));
			emaGraphPalette.Add(new caGraphGleeColor(Microsoft.Glee.Drawing.Color.CornflowerBlue));
			emaGraphPalette.Add(new caGraphGleeColor(Microsoft.Glee.Drawing.Color.Cornsilk));
			emaGraphPalette.Add(new caGraphGleeColor(Microsoft.Glee.Drawing.Color.Crimson));
			emaGraphPalette.Add(new caGraphGleeColor(Microsoft.Glee.Drawing.Color.Cyan));
			emaGraphPalette.Add(new caGraphGleeColor(Microsoft.Glee.Drawing.Color.DarkBlue));
			emaGraphPalette.Add(new caGraphGleeColor(Microsoft.Glee.Drawing.Color.DarkCyan));
			emaGraphPalette.Add(new caGraphGleeColor(Microsoft.Glee.Drawing.Color.DarkGoldenrod));
			emaGraphPalette.Add(new caGraphGleeColor(Microsoft.Glee.Drawing.Color.DarkGray));
			emaGraphPalette.Add(new caGraphGleeColor(Microsoft.Glee.Drawing.Color.DarkGreen));
			emaGraphPalette.Add(new caGraphGleeColor(Microsoft.Glee.Drawing.Color.DarkKhaki));
			emaGraphPalette.Add(new caGraphGleeColor(Microsoft.Glee.Drawing.Color.DarkMagenta));
			emaGraphPalette.Add(new caGraphGleeColor(Microsoft.Glee.Drawing.Color.DarkOliveGreen));
			emaGraphPalette.Add(new caGraphGleeColor(Microsoft.Glee.Drawing.Color.DarkOrange));
			emaGraphPalette.Add(new caGraphGleeColor(Microsoft.Glee.Drawing.Color.DarkOrchid));
			emaGraphPalette.Add(new caGraphGleeColor(Microsoft.Glee.Drawing.Color.DarkRed));
			emaGraphPalette.Add(new caGraphGleeColor(Microsoft.Glee.Drawing.Color.DarkSalmon));
			emaGraphPalette.Add(new caGraphGleeColor(Microsoft.Glee.Drawing.Color.DarkSlateBlue));
			emaGraphPalette.Add(new caGraphGleeColor(Microsoft.Glee.Drawing.Color.DarkSeaGreen));
			emaGraphPalette.Add(new caGraphGleeColor(Microsoft.Glee.Drawing.Color.DarkSlateGray));
			emaGraphPalette.Add(new caGraphGleeColor(Microsoft.Glee.Drawing.Color.DarkTurquoise));
			emaGraphPalette.Add(new caGraphGleeColor(Microsoft.Glee.Drawing.Color.DarkViolet));
			emaGraphPalette.Add(new caGraphGleeColor(Microsoft.Glee.Drawing.Color.DeepPink));
			emaGraphPalette.Add(new caGraphGleeColor(Microsoft.Glee.Drawing.Color.DeepSkyBlue));
			emaGraphPalette.Add(new caGraphGleeColor(Microsoft.Glee.Drawing.Color.DimGray));
			emaGraphPalette.Add(new caGraphGleeColor(Microsoft.Glee.Drawing.Color.DodgerBlue));
			emaGraphPalette.Add(new caGraphGleeColor(Microsoft.Glee.Drawing.Color.Firebrick));
			emaGraphPalette.Add(new caGraphGleeColor(Microsoft.Glee.Drawing.Color.FloralWhite));
			emaGraphPalette.Add(new caGraphGleeColor(Microsoft.Glee.Drawing.Color.ForestGreen));
			emaGraphPalette.Add(new caGraphGleeColor(Microsoft.Glee.Drawing.Color.Fuchsia));
			emaGraphPalette.Add(new caGraphGleeColor(Microsoft.Glee.Drawing.Color.Gainsboro));
			emaGraphPalette.Add(new caGraphGleeColor(Microsoft.Glee.Drawing.Color.GhostWhite));
			emaGraphPalette.Add(new caGraphGleeColor(Microsoft.Glee.Drawing.Color.Gold));
			emaGraphPalette.Add(new caGraphGleeColor(Microsoft.Glee.Drawing.Color.Goldenrod));
			emaGraphPalette.Add(new caGraphGleeColor(Microsoft.Glee.Drawing.Color.Gray));

		}

		public void removeObsoloteColor(Microsoft.Glee.Drawing.Color c)
		{
			try
			{
				var nc = from col in emaGraphPalette
						 where col.color == c && col.available == false
						 select col;
				nc.First<caGraphGleeColor>().available = true;
			}
			catch { }
		}

		public Microsoft.Glee.Drawing.Color getNewColor()
		{
			caGraphGleeColor c = new caGraphGleeColor(baseColor);
			try
			{
				var nc = from col in emaGraphPalette
						 where col.available == true
						 select col;
				c = nc.First<caGraphGleeColor>();
			}
			catch { c.color = Microsoft.Glee.Drawing.Color.Gray; }

			c.available = false;
			c.color.A = 160;
			return c.color;
		}
	}
}
