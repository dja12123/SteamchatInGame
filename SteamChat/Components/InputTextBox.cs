using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SteamChat
{
	class InputTextBox : TextBox
	{
		private Label IMELabel;
		private ImeMode lastIMEMode;

		public InputTextBox(Label IMELabel) : base()
		{
			this.IMELabel = IMELabel;
			this.ImeMode = ImeMode.Alpha;
			this.CheckIME();
		}
		protected override void OnKeyDown(KeyEventArgs e)
		{
			this.CheckIME();
			base.OnKeyDown(e);
		}
		private void CheckIME()
		{
			if (this.ImeMode != this.lastIMEMode)
			{
				this.lastIMEMode = this.ImeMode;
				this.IMELabel.Text = "[" + this.ImeMode.ToString() + "]";
			}
		}
	}
}
