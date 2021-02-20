//////FRSOTNITE CRACKED BY VITAL JOIN FOR MORE CRACKED SHIT https://discord.gg/eEUZQ7rWeC
//////FRSOTNITE CRACKED BY VITAL JOIN FOR MORE CRACKED SHIT https://discord.gg/eEUZQ7rWeC
//////FRSOTNITE CRACKED BY VITAL JOIN FOR MORE CRACKED SHIT https://discord.gg/eEUZQ7rWeC
//////FRSOTNITE CRACKED BY VITAL JOIN FOR MORE CRACKED SHIT https://discord.gg/eEUZQ7rWeC
//////FRSOTNITE CRACKED BY VITAL JOIN FOR MORE CRACKED SHIT https://discord.gg/eEUZQ7rWeC


using System;
using System.Diagnostics;
using System.Windows.Forms;

namespace FortniteDEVLauncher
{
	// Token: 0x0200000D RID: 13
	internal class Program
	{
		// Token: 0x0600004A RID: 74 RVA: 0x000021C9 File Offset: 0x000003C9
		[STAThread]
		private static void Main(string[] args)
		{
			Application.EnableVisualStyles();
			Application.SetCompatibleTextRenderingDefault(false);
			Application.Run(new GUI());
		}

		// Token: 0x0600004B RID: 75 RVA: 0x000038A4 File Offset: 0x00001AA4
		private static bool Routine(int dwCtrlType)
		{
			bool flag = dwCtrlType == 2 && !Program._clientProcess.HasExited;
			if (flag)
			{
				Program._clientProcess.Kill();
			}
			return false;
		}

		// Token: 0x04000025 RID: 37
		private static Process _clientProcess;

		// Token: 0x04000026 RID: 38
		private static byte _clientAnticheat;
	}
}
