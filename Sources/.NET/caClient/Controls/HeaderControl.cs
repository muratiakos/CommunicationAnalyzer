using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace caClient.Controls
{
	public partial class HeaderControl : UserControl
	{
		public HeaderControl()
		{
			InitializeComponent();
		}

		public String HeaderText
		{
			get { return head.Text; }
			set { head.Text = value; }
		}
	}
}
