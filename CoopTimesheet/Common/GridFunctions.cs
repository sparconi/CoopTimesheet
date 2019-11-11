using System.Drawing;
using System.Web.UI.WebControls;

namespace CoopTimesheet.Common
{
	public class GridFunctions
	{
		public static Color GetRagBackColor(object o)
		{
			string rag = o.ToString();

			switch (rag)
			{
				case "R":
					return (Color.Red);
				case "A":
					return (Color.FromArgb(255, 153, 0));
				case "G":
					return (Color.Green);
				default:
					return (Color.White);
			}
		}
		public static Color GetRagForeColor(object o)
		{
			string rag = o.ToString();

			switch (rag)
			{
				case "R":
					return (Color.White);
				case "A":
					return (Color.Black);
				case "G":
					return (Color.White);
				default:
					return (Color.Black);
			}
		}
		public static Color GetColorFromHtml(object o)
		{
			string strColor = o.ToString().Trim();
			return (strColor == "") ? Color.White : ColorTranslator.FromHtml("#" + strColor);
		}
		public static void SetGridView(ref GridView gv)
		{
			gv.AllowPaging = true;
			gv.AllowSorting = true;
			gv.RowStyle.BackColor = Color.White;
			gv.RowStyle.ForeColor = ColorTranslator.FromHtml("#333333");
			gv.RowStyle.BorderStyle = BorderStyle.Solid;
			gv.RowStyle.BorderColor = Color.LightGray;
			gv.RowStyle.BorderWidth = Unit.Pixel(1);
			gv.AlternatingRowStyle.BackColor = Color.WhiteSmoke; //  ColorTranslator.FromHtml("#FFFFDD"); // #F7F7DE
			gv.SelectedRowStyle.BackColor = ColorTranslator.FromHtml("#E2DED6");
			gv.SelectedRowStyle.ForeColor = ColorTranslator.FromHtml("#333333");
			gv.CssClass = "GRIDVIEW";
			gv.GridLines = GridLines.None;
			gv.RowStyle.Height = 18;
			gv.PagerSettings.Mode = PagerButtons.NumericFirstLast;
			gv.PagerSettings.Position = PagerPosition.TopAndBottom;
			gv.PagerStyle.BackColor = ColorTranslator.FromHtml("#284775");
			gv.PagerStyle.ForeColor = Color.White;
			gv.PagerStyle.HorizontalAlign = HorizontalAlign.Left;
			//gv.PageSize = 20;
			gv.CellPadding = 0;
			gv.CellSpacing = 3;
			gv.ShowFooter = false;
			gv.ShowHeader = true;
			gv.HeaderStyle.CssClass = "GRIDHEADER";
			//
			if (gv.Columns.Count > 0)
				gv.Columns[0].ItemStyle.HorizontalAlign = HorizontalAlign.Left;
		}
		public static string GetRecordId(ref GridView gv)
		{
			int index = gv.SelectedIndex;
// ReSharper disable PossibleNullReferenceException
			return gv.DataKeys[index].Value.ToString();
// ReSharper restore PossibleNullReferenceException
		}
		public static void SetRowAttributes(ref GridView gv, GridViewRowEventArgs e)
		{
			foreach (TableCell tc in e.Row.Cells)
			{
				tc.Attributes["style"] = "border-color:#2E4D7B";
			}
			e.Row.Attributes["onmouseover"] = "javascript:setMouseOverColor(this);";
			e.Row.Attributes["onmouseout"] = "javascript:setMouseOutColor(this);";
			e.Row.Attributes["onclick"] = gv.Parent.Page.ClientScript.GetPostBackClientHyperlink(gv, "Select$" + e.Row.RowIndex);
		}
		public static string GetToolTip(int taskId, int allocatedTaskId, bool outOfHours, bool canEdit)
		{
			string prefix = (outOfHours) ? "(Out of Hours) " : "";
			if (taskId == allocatedTaskId)
			{
				return prefix + "This slot is allocated to this Task" + ((canEdit) ? " - Click to remove from this Task" : "");
			}
			if (allocatedTaskId > 0 && taskId != allocatedTaskId)
			{
				return prefix + "This slot is allocated to another Task";
			}
			return string.Format("{0}This slot is free{1}", prefix, ((canEdit) ? " - Click to allocate to this Task" : ""));
		}
		public static void SetDateReadonly(ref TextBox txt)
		{
			txt.Attributes.Add("readonly", "readonly");
		}
		public static int IndexOfInt(int[] array, int value)
		{
			for (int i = 0; i < array.Length; i++)
			{
				if (array[i] == value)
					return i;
			}
			return -1;
		}
	}
}