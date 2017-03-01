using System;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Drawing.Text;
using System.Runtime.InteropServices;
using System.Configuration;

namespace SteamChat
{
	public delegate void DestroyHandler(MessageLabel chat);

	public class MessageLabel : Label
	{
		private readonly int showTime;
		public static readonly int MessagePadding = 3;
		private DateTime createTime;
		public DateTime CreateTime { get { return createTime; } }
		private bool forcedShow = false;
		private System.Timers.Timer timer;
		public MessageLabel(string msg, Color color, bool focus) : base()
		{//폰트 관련 버그 확인
			this.Font = new Font(this.Font.FontFamily, float.Parse(ConfigurationManager.AppSettings["MsgFontSize"]), FontStyle.Bold);
			this.showTime = int.Parse(ConfigurationManager.AppSettings["MsgShowtime"]) * 1000;
			this.AutoSize = true;
			this.Text = msg;
			this.ForeColor = color;
			this.createTime = DateTime.Now;
			this.timer = new System.Timers.Timer();
			this.timer.Interval = showTime;
			this.timer.Elapsed += this.timerTick;
			this.timer.Start();
			this.forcedShow = focus;
			this.Padding = new Padding(0, MessagePadding, 0, MessagePadding);
		}
		private void timerTick(object sender, EventArgs e)
		{
			this.Invoke(new MethodInvoker(delegate ()
			{
				if (!this.forcedShow)
				{
					this.Visible = false;
				}
			}));
			this.timer.Stop();
			this.timer.Dispose();
		}
		protected override void Dispose(bool disposing)
		{
			this.timer.Stop();
			this.timer.Dispose();
			base.Dispose(disposing);
		}
		public void setForcedShow(bool option)
		{
			if(option != this.forcedShow)
			{
				if (option)
				{
					this.Visible = true;
				}
				else
				{
					this.Visible = DateTime.Now.Subtract(this.createTime).TotalMilliseconds <= showTime;
				}
				this.forcedShow = option;
			}
		}
		protected override void OnPaint(PaintEventArgs e)
		{
			TextFormatFlags option = TextFormatFlags.Left | TextFormatFlags.TextBoxControl | TextFormatFlags.WordBreak | TextFormatFlags.EndEllipsis;
			TextRenderer.DrawText(e.Graphics, this.Text, this.Font, new Rectangle(1, 1, this.Width, Int32.MaxValue), Color.Black, option);
			TextRenderer.DrawText(e.Graphics, this.Text, this.Font, new Rectangle(0, 0, this.Width, Int32.MaxValue), this.ForeColor, option);
			//Size size = TextRenderer.MeasureText(this.Text, this.Font, this.Size, option);
			//Size size1 = TextRenderer.MeasureText("TestString", this.Font, this.Size, option);
			//Console.WriteLine(size.Width);
			//TextRenderer.DrawText(e.Graphics, "TestString", this.Font, new Rectangle(size.Width - size1.Width, size.Height - size1.Height, this.Width, Int32.MaxValue), Color.BlueViolet, option);
		}
	}
}

