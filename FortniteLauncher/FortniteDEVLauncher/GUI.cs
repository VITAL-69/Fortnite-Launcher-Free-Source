//////FRSOTNITE CRACKED BY VITAL JOIN FOR MORE CRACKED SHIT https://discord.gg/eEUZQ7rWeC
//////FRSOTNITE CRACKED BY VITAL JOIN FOR MORE CRACKED SHIT https://discord.gg/eEUZQ7rWeC
//////FRSOTNITE CRACKED BY VITAL JOIN FOR MORE CRACKED SHIT https://discord.gg/eEUZQ7rWeC
//////FRSOTNITE CRACKED BY VITAL JOIN FOR MORE CRACKED SHIT https://discord.gg/eEUZQ7rWeC
//////FRSOTNITE CRACKED BY VITAL JOIN FOR MORE CRACKED SHIT https://discord.gg/eEUZQ7rWeC

using System;
using System.ComponentModel;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.Net;
using System.Reflection;
using System.Runtime.InteropServices;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading;
using System.Windows.Forms;
using FortniteDEVLauncher.Properties;
using MaterialSkin;
using MaterialSkin.Controls;
using Microsoft.Win32;
using Newtonsoft.Json;

namespace FortniteDEVLauncher
{
	// Token: 0x0200000A RID: 10
	public partial class GUI : MaterialForm
	{
		// Token: 0x0600002C RID: 44 RVA: 0x0000258C File Offset: 0x0000078C
		private static void SplashDL()
		{
			using (WebClient webClient = new WebClient())
			{
				webClient.DownloadFile("https://cdn.discordapp.com/attachments/703292986292830380/807103404265701396/Splash.bmp", "Splash.bmp");
				Thread.Sleep(4000);
				string path = "Splash.bmp";
				string currentDirectory = Directory.GetCurrentDirectory();
				string text = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.CommonApplicationData), "FortniteGame\\Content\\Splash");
				string sourceFileName = Path.Combine(currentDirectory, path);
				string destFileName = Path.Combine(text, path);
				Directory.CreateDirectory(text);
				File.Copy(sourceFileName, destFileName, true);
			}
		}

		// Token: 0x0600002D RID: 45 RVA: 0x00002614 File Offset: 0x00000814
		private void DLLDownload()
		{
			using (WebClient webClient = new WebClient())
			{
				webClient.DownloadFile("https://github.com/ExcelLeaks/FortDLL/blob/main/Era.dll", "Frost.dll");
			}
		}

		// Token: 0x0600002F RID: 47 RVA: 0x00002654 File Offset: 0x00000854
		public GUI()
		{
			this.InitializeComponent();
			MaterialSkinManager instance = MaterialSkinManager.Instance;
			instance.AddFormToManage(this);
			instance.Theme = MaterialSkinManager.Themes.DARK;
			instance.ColorScheme = new ColorScheme(Primary.Blue900, Primary.Blue600, Primary.Red900, Accent.Red200, TextShade.WHITE);
			this.materialTextBox1.Text = Settings.Default.Username;
			this.materialTextBox2.Text = Settings.Default.Path;
			if (File.Exists(GUI._installedPath))
			{
				foreach (GUI.Installed.Installation installation in JsonConvert.DeserializeObject<GUI.Installed>(File.ReadAllText(GUI._installedPath)).InstallationList)
				{
					if (installation.AppName == "Fortnite")
					{
						this.materialTextBox2.Text = installation.InstallLocation;
					}
				}
				return;
			}
			this.materialTextBox2.Text = "Couldn't find Fortnite path, please use the \"...\" button to specify your Fortnite path!";
		}

		// Token: 0x06000030 RID: 48
		[DllImport("wininet.dll")]
		public static extern bool InternetSetOption(IntPtr hInternet, int dwOption, IntPtr lpBuffer, int dwBufferLength);

		// Token: 0x06000031 RID: 49
		[DllImport("user32.dll")]
		public new static extern int SendMessage(IntPtr hWnd, int Msg, int wParam, int lParam);

		// Token: 0x06000032 RID: 50
		[DllImport("user32.dll")]
		public new static extern bool ReleaseCapture();

		// Token: 0x06000033 RID: 51
		[DllImport("user32.dll", SetLastError = true)]
		private static extern uint GetWindowThreadProcessId(IntPtr hWnd, out int processId);

		// Token: 0x06000036 RID: 54 RVA: 0x00002F38 File Offset: 0x00001138
		private bool IsValidPath(string path)
		{
			bool result;
			if (new Regex("^[a-zA-Z]:\\\\$").IsMatch(path.Substring(0, 3)))
			{
				string text = new string(Path.GetInvalidPathChars());
				text += ":/?*\"";
				result = !new Regex("[" + Regex.Escape(text) + "]").IsMatch(path.Substring(3, path.Length - 3));
			}
			else
			{
				result = false;
			}
			return result;
		}

		// Token: 0x06000037 RID: 55 RVA: 0x0000213E File Offset: 0x0000033E
		private void GUI_Load(object sender, EventArgs e)
		{
		}

		// Token: 0x06000038 RID: 56 RVA: 0x0000213E File Offset: 0x0000033E
		private void materialTextBox1_TextChanged(object sender, EventArgs e)
		{
		}

		// Token: 0x06000039 RID: 57 RVA: 0x00002140 File Offset: 0x00000340
		private void materialButton2_Click(object sender, EventArgs e)
		{
			if (this.folderBrowserDialogBrowse.ShowDialog() == DialogResult.OK)
			{
				this.materialTextBox2.Text = this.folderBrowserDialogBrowse.SelectedPath;
			}
		}

		// Token: 0x0600003A RID: 58 RVA: 0x00002FAC File Offset: 0x000011AC
		private void materialButton1_Click(object sender, EventArgs e)
		{
			int num = Convert.ToInt32(Console.ReadLine());
			Registry.CurrentUser.OpenSubKey("Software\\Microsoft\\Windows\\CurrentVersion\\Internet Settings", true);
			if (!new Regex("^([a-zA-Z0-9])*$").IsMatch(this.materialTextBox1.Text))
			{
				MessageBox.Show("Invalid Username. usernames cannot contain any special characters.");
				return;
			}
			if (string.IsNullOrEmpty(this.materialTextBox2.Text) || this.materialTextBox1.Text.Length < 3)
			{
				MessageBox.Show("Username cannot be empty or below 3 characters.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Hand);
				return;
			}
			try
			{
				if (!this.IsValidPath(this.materialTextBox2.Text))
				{
					MessageBox.Show("Invalid Fortnite path.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Hand);
					return;
				}
			}
			catch
			{
				MessageBox.Show("Invalid Fortnite path.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Hand);
				return;
			}
			string text = Path.Combine(this.materialTextBox2.Text, "FortniteGame\\Binaries\\Win64\\FortniteClient-Win64-Shipping.exe");
			if (!File.Exists(text))
			{
				MessageBox.Show("\"FortniteClient-Win64-Shipping.exe\" was not found, please make sure it exists.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Hand);
				return;
			}
			Settings.Default.Path = this.materialTextBox2.Text;
			Settings.Default.Save();
			string text2 = Path.Combine(Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location), "Platanium.dll");
			if (!File.Exists(text2))
			{
				MessageBox.Show("\"Platanium.dll\" was not found, please make sure it exists.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Hand);
				return;
			}
			string text3 = "-AUTH_LOGIN=\"" + this.materialTextBox1.Text + "@unused.com\" -AUTH_PASSWORD=unused -AUTH_TYPE=epic";
			GUI._clientAnticheat = 2;
			if (GUI._clientAnticheat == 0)
			{
				text3 += " -epicapp=Fortnite -epicenv=Prod -epiclocale=en-us -epicportal -noeac -nobe -fltoken=none";
			}
			else if (GUI._clientAnticheat == 1)
			{
				text3 += " -epicapp=Fortnite -epicenv=Prod -epiclocale=en-us -epicportal -noeac -fromfl=be -fltoken=f7b9gah4h5380d10f721dd6a";
			}
			else if (GUI._clientAnticheat == 2)
			{
				text3 += " -epicapp=Fortnite -epicenv=Prod -epiclocale=en-us -epicportal -noeac -nobe -fltoken=8c4aa8a9b77acdcbd918874b";
			}
			GUI._clientProcess = new Process
			{
				StartInfo = new ProcessStartInfo(text, text3)
				{
					UseShellExecute = false,
					RedirectStandardOutput = true,
					CreateNoWindow = false
				}
			};
			Process process = new Process();
			string fileName = Path.Combine(this.materialTextBox2.Text, "FortniteGame\\Binaries\\Win64\\FortniteLauncher.exe");
			process.StartInfo.FileName = fileName;
			process.Start();
			foreach (object obj in process.Threads)
			{
				ProcessThread processThread = (ProcessThread)obj;
				Win32.SuspendThread(Win32.OpenThread(2, false, processThread.Id));
			}
			Process process2 = new Process();
			string fileName2 = Path.Combine(this.materialTextBox2.Text, "FortniteGame\\Binaries\\Win64\\FortniteClient-Win64-Shipping_EAC.exe");
			process2.StartInfo.FileName = fileName2;
			process2.StartInfo.Arguments = "-epicapp=Fortnite -epicenv=Prod -epiclocale=en-us -epicportal -noeac -nobe -fltoken=8c4aa8a9b77acdcbd918874b";
			process2.Start();
			foreach (object obj2 in process2.Threads)
			{
				ProcessThread processThread2 = (ProcessThread)obj2;
				Win32.SuspendThread(Win32.OpenThread(2, false, processThread2.Id));
			}
			GUI._clientProcess.Start();
			if (num != 0)
			{
				Console.WriteLine("Invalid Argument!");
				Console.ReadKey();
				return;
			}
			GUI.InternetSetOption(IntPtr.Zero, 39, IntPtr.Zero, 0);
			GUI.InternetSetOption(IntPtr.Zero, 37, IntPtr.Zero, 0);
			IntPtr hProcess = Win32.OpenProcess(1082, false, GUI._clientProcess.Id);
			IntPtr procAddress = Win32.GetProcAddress(Win32.GetModuleHandle("kernel32.dll"), "LoadLibraryA");
			uint num2 = (uint)((text2.Length + 1) * Marshal.SizeOf(typeof(char)));
			IntPtr intPtr = Win32.VirtualAllocEx(hProcess, IntPtr.Zero, num2, 12288U, 4U);
			UIntPtr uintPtr;
			Win32.WriteProcessMemory(hProcess, intPtr, Encoding.Default.GetBytes(text2), num2, out uintPtr);
			Win32.CreateRemoteThread(hProcess, IntPtr.Zero, 0U, procAddress, intPtr, 0U, IntPtr.Zero);
		}

		// Token: 0x0600003B RID: 59 RVA: 0x00003398 File Offset: 0x00001598
		private void materialButton69_Click(object sender, EventArgs e)
		{
			string path = "Splash.bmp";
			string currentDirectory = Directory.GetCurrentDirectory();
			string text = Path.Combine(this.materialTextBox2.Text, "FortniteGame\\Content\\Splash");
			string sourceFileName = Path.Combine(currentDirectory, path);
			string destFileName = Path.Combine(text, path);
			Directory.CreateDirectory(text);
			File.Copy(sourceFileName, destFileName, true);
			int num = Convert.ToInt32(Console.ReadLine());
			Registry.CurrentUser.OpenSubKey("Software\\Microsoft\\Windows\\CurrentVersion\\Internet Settings", true);
			if (string.IsNullOrEmpty(this.materialTextBox2.Text) || this.materialTextBox1.Text.Length < 3)
			{
				MessageBox.Show("Username cannot be empty or below 3 characters.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Hand);
				return;
			}
			try
			{
				if (!this.IsValidPath(this.materialTextBox2.Text))
				{
					MessageBox.Show("Invalid Fortnite path.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Hand);
					return;
				}
			}
			catch
			{
				MessageBox.Show("Invalid Fortnite path.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Hand);
				return;
			}
			string text2 = Path.Combine(this.materialTextBox2.Text, "FortniteGame\\Binaries\\Win64\\FortniteClient-Win64-Shipping.exe");
			if (!File.Exists(text2))
			{
				MessageBox.Show("\"FortniteClient-Win64-Shipping.exe\" was not found, please make sure it exists.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Hand);
				return;
			}
			Settings.Default.Path = this.materialTextBox2.Text;
			Settings.Default.Save();
			string text3 = Path.Combine(Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location), "Platanium.dll");
			if (!File.Exists(text3))
			{
				MessageBox.Show("\"Platanium.dll\" was not found, please make sure it exists.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Hand);
				return;
			}
			string text4 = "-AUTH_LOGIN=\"" + this.materialTextBox1.Text + ".frost\" -AUTH_PASSWORD=unused -AUTH_TYPE=epic";
			GUI._clientAnticheat = 2;
			if (GUI._clientAnticheat == 0)
			{
				text4 += " -epicapp=Fortnite -epicenv=Prod -epiclocale=en-us -epicportal -noeac -nobe -fltoken=none";
			}
			else if (GUI._clientAnticheat == 1)
			{
				text4 += " -epicapp=Fortnite -epicenv=Prod -epiclocale=en-us -epicportal -noeac -fromfl=be -fltoken=f7b9gah4h5380d10f721dd6a";
			}
			else if (GUI._clientAnticheat == 2)
			{
				text4 += " -epicapp=Fortnite -epicenv=Prod -epiclocale=en-us -epicportal -noeac -nobe -fltoken=8c4aa8a9b77acdcbd918874b";
			}
			GUI._clientProcess = new Process
			{
				StartInfo = new ProcessStartInfo(text2, text4)
				{
					UseShellExecute = false,
					RedirectStandardOutput = true,
					CreateNoWindow = false
				}
			};
			Process process = new Process();
			string fileName = Path.Combine(this.materialTextBox2.Text, "FortniteGame\\Binaries\\Win64\\FortniteClient-Win64-Shipping.exe");
			process.StartInfo.FileName = fileName;
			process.Start();
			foreach (object obj in process.Threads)
			{
				ProcessThread processThread = (ProcessThread)obj;
				Win32.SuspendThread(Win32.OpenThread(2, false, processThread.Id));
			}
			Process process2 = new Process();
			string fileName2 = Path.Combine(this.materialTextBox2.Text, "FortniteGame\\Binaries\\Win64\\FortniteClient-Win64-Shipping_BE.exe");
			process2.StartInfo.FileName = fileName2;
			process2.StartInfo.Arguments = "-epicapp=Fortnite -epicenv=Prod -epiclocale=en-us -epicportal -noeac -nobe -fltoken=8c4aa8a9b77acdcbd918874b";
			process2.Start();
			foreach (object obj2 in process2.Threads)
			{
				ProcessThread processThread2 = (ProcessThread)obj2;
				Win32.SuspendThread(Win32.OpenThread(2, false, processThread2.Id));
			}
			GUI._clientProcess.Start();
			if (num != 0)
			{
				Console.WriteLine("Invalid Argument!");
				Console.ReadKey();
				return;
			}
			GUI.InternetSetOption(IntPtr.Zero, 39, IntPtr.Zero, 0);
			GUI.InternetSetOption(IntPtr.Zero, 37, IntPtr.Zero, 0);
			IntPtr hProcess = Win32.OpenProcess(1082, false, GUI._clientProcess.Id);
			IntPtr procAddress = Win32.GetProcAddress(Win32.GetModuleHandle("kernel32.dll"), "LoadLibraryA");
			uint num2 = (uint)((text3.Length + 1) * Marshal.SizeOf(typeof(char)));
			IntPtr intPtr = Win32.VirtualAllocEx(hProcess, IntPtr.Zero, num2, 12288U, 4U);
			UIntPtr uintPtr;
			Win32.WriteProcessMemory(hProcess, intPtr, Encoding.Default.GetBytes(text3), num2, out uintPtr);
			Win32.CreateRemoteThread(hProcess, IntPtr.Zero, 0U, procAddress, intPtr, 0U, IntPtr.Zero);
		}

		// Token: 0x0600003C RID: 60 RVA: 0x000037AC File Offset: 0x000019AC
		private void materialButton420_Click(object sender, EventArgs e)
		{
			Convert.ToInt32(Console.ReadLine());
			string text = Path.Combine(Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location), "Frost.dll");
			if (!File.Exists(text))
			{
				MessageBox.Show("\"Frost.dll\" was not found, please make sure it exists.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Hand);
				return;
			}
			GUI.InternetSetOption(IntPtr.Zero, 39, IntPtr.Zero, 0);
			GUI.InternetSetOption(IntPtr.Zero, 37, IntPtr.Zero, 0);
			IntPtr hProcess = Win32.OpenProcess(1082, false, GUI._clientProcess.Id);
			IntPtr procAddress = Win32.GetProcAddress(Win32.GetModuleHandle("kernel32.dll"), "LoadLibraryA");
			uint num = (uint)((text.Length + 1) * Marshal.SizeOf(typeof(char)));
			IntPtr intPtr = Win32.VirtualAllocEx(hProcess, IntPtr.Zero, num, 12288U, 4U);
			UIntPtr uintPtr;
			Win32.WriteProcessMemory(hProcess, intPtr, Encoding.Default.GetBytes(text), num, out uintPtr);
			Win32.CreateRemoteThread(hProcess, IntPtr.Zero, 0U, procAddress, intPtr, 0U, IntPtr.Zero);
		}

		// Token: 0x0600003D RID: 61 RVA: 0x00002168 File Offset: 0x00000368
		private void materialButton3_Click_1(object sender, EventArgs e)
		{
			Process.Start("https://discord.gg/45MWShbdhR");
		}

		// Token: 0x0600003E RID: 62 RVA: 0x00002175 File Offset: 0x00000375
		private void materialButton4_Click(object sender, EventArgs e)
		{
			new Browser();
		}

		// Token: 0x0600003F RID: 63 RVA: 0x0000213E File Offset: 0x0000033E
		private void materialTextBox2_TextChanged(object sender, EventArgs e)
		{
		}

		// Token: 0x04000011 RID: 17
		public new const int WM_NCLBUTTONDOWN = 161;

		// Token: 0x04000012 RID: 18
		public new const int HT_CAPTION = 2;

		// Token: 0x04000013 RID: 19
		public const int INTERNET_OPTION_SETTINGS_CHANGED = 39;

		// Token: 0x04000014 RID: 20
		public const int INTERNET_OPTION_REFRESH = 37;

		// Token: 0x04000015 RID: 21
		private static readonly string _installedPath = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.CommonApplicationData), "Epic\\UnrealEngineLauncher\\LauncherInstalled.dat");

		// Token: 0x04000016 RID: 22
		private static Process _clientProcess;

		// Token: 0x04000017 RID: 23
		private static byte _clientAnticheat;

		// Token: 0x0200000B RID: 11
		private class Installed
		{
			// Token: 0x1700000A RID: 10
			// (get) Token: 0x06000040 RID: 64 RVA: 0x0000217D File Offset: 0x0000037D
			// (set) Token: 0x06000041 RID: 65 RVA: 0x00002185 File Offset: 0x00000385
			public GUI.Installed.Installation[] InstallationList { get; set; }

			// Token: 0x0200000C RID: 12
			public class Installation
			{
				// Token: 0x1700000B RID: 11
				// (get) Token: 0x06000043 RID: 67 RVA: 0x00002196 File Offset: 0x00000396
				// (set) Token: 0x06000044 RID: 68 RVA: 0x0000219E File Offset: 0x0000039E
				public string AppName { get; set; }

				// Token: 0x1700000C RID: 12
				// (get) Token: 0x06000045 RID: 69 RVA: 0x000021A7 File Offset: 0x000003A7
				// (set) Token: 0x06000046 RID: 70 RVA: 0x000021AF File Offset: 0x000003AF
				public string AppVersion { get; set; }

				// Token: 0x1700000D RID: 13
				// (get) Token: 0x06000047 RID: 71 RVA: 0x000021B8 File Offset: 0x000003B8
				// (set) Token: 0x06000048 RID: 72 RVA: 0x000021C0 File Offset: 0x000003C0
				public string InstallLocation { get; set; }
			}
		}

        private void pictureBox1_Click(object sender, EventArgs e)
        {
			
		}

        private void button1_Click(object sender, EventArgs e)
        {
			Process.Start("http://frostnite.tk/");
		}

        private void button2_Click(object sender, EventArgs e)
        {
			Process.Start("https://discord.gg/45MWShbdhR");
		}
    }
}
