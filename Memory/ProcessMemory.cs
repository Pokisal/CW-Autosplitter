using System;
using System.Diagnostics;
using System.Runtime.InteropServices;
using System.Text;
using System.Windows.Forms;

namespace CWAutosplitter.Memory
{

	internal class ProcessMemory
	{
		[Flags]
		public enum ProcessAccessFlags : uint
		{
			All = 0x1F0FFFu,
			CreateThread = 2u,
			DupHandle = 0x40u,
			QueryInformation = 0x400u,
			SetInformation = 0x200u,
			Synchronize = 0x100000u,
			Terminate = 1u,
			VMOperation = 8u,
			VMRead = 0x10u,
			VMWrite = 0x20u
		}

		protected IntPtr BaseAddress;

		protected Process[] MyProcess;

		protected ProcessModule myProcessModule;

		private const uint PAGE_EXECUTE = 16u;

		private const uint PAGE_EXECUTE_READ = 32u;

		private const uint PAGE_EXECUTE_READWRITE = 64u;

		private const uint PAGE_EXECUTE_WRITECOPY = 128u;

		private const uint PAGE_GUARD = 256u;

		private const uint PAGE_NOACCESS = 1u;

		private const uint PAGE_NOCACHE = 512u;

		private const uint PAGE_READONLY = 2u;

		private const uint PAGE_READWRITE = 4u;

		private const uint PAGE_WRITECOPY = 8u;

		private const uint PROCESS_ALL_ACCESS = 2035711u;

		protected int processHandle;

		protected Process process;

		public ProcessMemory(string pProcessName)
		{
			Process[] processesByName = Process.GetProcessesByName(pProcessName);
			if (processesByName.Length == 0)
			{
				throw new Exception("No processes exist by that name.");
			}
			process = processesByName[0];
		}

		public ProcessMemory(Process pProcess)
		{
			process = pProcess;
		}

		public bool CheckProcess()
		{
			return !process.HasExited;
		}

		[DllImport("kernel32.dll")]
		public static extern bool CloseHandle(int hObject);

		public string CutString(string mystring)
		{
			char[] array = mystring.ToCharArray();
			string text = "";
			for (int i = 0; i < mystring.Length; i++)
			{
				if (array[i] == ' ' && array[i + 1] == ' ')
				{
					return text;
				}
				if (array[i] == '\0')
				{
					return text;
				}
				text += array[i];
			}
			return mystring.TrimEnd('0');
		}

		public IntPtr DllImageAddress(string dllname)
		{
			foreach (ProcessModule module in process.Modules)
			{
				if (dllname == module.ModuleName)
				{
					return module.BaseAddress;
				}
			}
			throw new ArgumentException("Module not found.");
		}

		[DllImport("user32.dll", EntryPoint = "FindWindow", SetLastError = true)]
		public static extern int FindWindowByCaption(int ZeroOnly, string lpWindowName);

		public IntPtr ImageAddress()
		{
			myProcessModule = MyProcess[0].MainModule;
			BaseAddress = myProcessModule.BaseAddress;
			return BaseAddress;
		}

		public IntPtr ImageAddress(int pOffset)
		{
			myProcessModule = MyProcess[0].MainModule;
			BaseAddress = myProcessModule.BaseAddress;
			return IntPtr.Add(BaseAddress, pOffset);
		}

		public string MyProcessName()
		{
			return process.ProcessName;
		}

		[DllImport("kernel32.dll")]
		public static extern int OpenProcess(uint dwDesiredAccess, bool bInheritHandle, int dwProcessId);

		public IntPtr Pointer(string Module, params int[] offsets)
		{
			IntPtr intPtr = DllImageAddress(Module);
			foreach (int offset in offsets)
			{
				intPtr = new IntPtr(ReadLong(IntPtr.Add(intPtr, offset)));
			}
			return intPtr;
		}

		public byte ReadByte(IntPtr pOffset)
		{
			byte[] array = new byte[1];
			ReadProcessMemory(processHandle, pOffset, array, 1, 0);
			return array[0];
		}

		public byte ReadByte(bool AddToImageAddress, int pOffset)
		{
			byte[] array = new byte[1];
			IntPtr lpBaseAddress = (AddToImageAddress ? ImageAddress(pOffset) : new IntPtr(pOffset));
			ReadProcessMemory(processHandle, lpBaseAddress, array, 1, 0);
			return array[0];
		}

		public byte ReadByte(string Module, int pOffset)
		{
			byte[] array = new byte[1];
			ReadProcessMemory(processHandle, IntPtr.Add(DllImageAddress(Module), pOffset), array, 1, 0);
			return array[0];
		}

		public float ReadFloat(IntPtr pOffset)
		{
			return BitConverter.ToSingle(ReadMem(pOffset, 4), 0);
		}

		public float ReadFloat(bool AddToImageAddress, int pOffset)
		{
			return BitConverter.ToSingle(ReadMem(new IntPtr(pOffset), 4, AddToImageAddress), 0);
		}

		public float ReadFloat(string Module, int pOffset)
		{
			return BitConverter.ToSingle(ReadMem(IntPtr.Add(DllImageAddress(Module), pOffset), 4), 0);
		}

		public int ReadInt(IntPtr pOffset)
		{
			return BitConverter.ToInt32(ReadMem(pOffset, 4), 0);
		}

		public int ReadInt(bool AddToImageAddress, IntPtr pOffset)
		{
			return BitConverter.ToInt32(ReadMem(pOffset, 4, AddToImageAddress), 0);
		}

		public int ReadInt(string Module, int pOffset)
		{
			return BitConverter.ToInt32(ReadMem(DllImageAddress(Module) + pOffset, 4), 0);
		}

		public long ReadLong(IntPtr pOffset)
		{
			return BitConverter.ToInt64(ReadMem(pOffset, 8), 0);
		}

		public long ReadLong(string Module, int pOffset)
		{
			return BitConverter.ToInt64(ReadMem(IntPtr.Add(DllImageAddress(Module), pOffset), 8), 0);
		}

		public byte[] ReadMem(IntPtr pOffset, int pSize)
		{
			byte[] array = new byte[pSize];
			ReadProcessMemory(processHandle, pOffset, array, pSize, 0);
			return array;
		}

		public byte[] ReadMem(IntPtr pOffset, int pSize, bool AddToImageAddress)
		{
			byte[] array = new byte[pSize];
			IntPtr lpBaseAddress = (AddToImageAddress ? ImageAddress((int)pOffset) : pOffset);
			ReadProcessMemory(processHandle, lpBaseAddress, array, pSize, 0);
			return array;
		}

		[DllImport("kernel32.dll")]
		public static extern bool ReadProcessMemory(int hProcess, IntPtr lpBaseAddress, byte[] buffer, int size, int lpNumberOfBytesRead);

		public short ReadShort(IntPtr pOffset)
		{
			return BitConverter.ToInt16(ReadMem(pOffset, 2), 0);
		}

		public short ReadShort(bool AddToImageAddress, IntPtr pOffset)
		{
			return BitConverter.ToInt16(ReadMem(pOffset, 2, AddToImageAddress), 0);
		}

		public short ReadShort(string Module, int pOffset)
		{
			return BitConverter.ToInt16(ReadMem(IntPtr.Add(DllImageAddress(Module), pOffset), 2), 0);
		}

		public string ReadStringAscii(IntPtr pOffset, int pSize)
		{
			return CutString(Encoding.ASCII.GetString(ReadMem(pOffset, pSize)));
		}

		public string ReadStringAscii(bool AddToImageAddress, IntPtr pOffset, int pSize)
		{
			return CutString(Encoding.ASCII.GetString(ReadMem(pOffset, pSize, AddToImageAddress)));
		}

		public string ReadStringAscii(string Module, int pOffset, int pSize)
		{
			return CutString(Encoding.ASCII.GetString(ReadMem(IntPtr.Add(DllImageAddress(Module), pOffset), pSize)));
		}

		public string ReadStringUnicode(IntPtr pOffset, int pSize)
		{
			return CutString(Encoding.Unicode.GetString(ReadMem(pOffset, pSize)));
		}

		public string ReadStringUnicode(bool AddToImageAddress, IntPtr pOffset, int pSize)
		{
			return CutString(Encoding.Unicode.GetString(ReadMem(pOffset, pSize, AddToImageAddress)));
		}

		public string ReadStringUnicode(string Module, int pOffset, int pSize)
		{
			return CutString(Encoding.Unicode.GetString(ReadMem(IntPtr.Add(DllImageAddress(Module), pOffset), pSize)));
		}

		public uint ReadUInt(IntPtr pOffset)
		{
			return BitConverter.ToUInt32(ReadMem(pOffset, 4), 0);
		}

		public uint ReadUInt(bool AddToImageAddress, IntPtr pOffset)
		{
			return BitConverter.ToUInt32(ReadMem(pOffset, 4, AddToImageAddress), 0);
		}

		public uint ReadUInt(string Module, int pOffset)
		{
			return BitConverter.ToUInt32(ReadMem(IntPtr.Add(DllImageAddress(Module), pOffset), 4), 0);
		}

		public bool StartProcess()
		{
			if (process.ProcessName != "")
			{
				MyProcess = Process.GetProcessesByName(process.ProcessName);
				if (MyProcess.Length == 0)
				{
					MessageBox.Show(process.ProcessName + " is not running or has not been found. Please check and try again", "Process Not Found", MessageBoxButtons.OK, MessageBoxIcon.Hand);
					return false;
				}
				processHandle = OpenProcess(2035711u, bInheritHandle: false, MyProcess[0].Id);
				if (processHandle == 0)
				{
					MessageBox.Show(process.ProcessName + " is not running or has not been found. Please check and try again", "Process Not Found", MessageBoxButtons.OK, MessageBoxIcon.Hand);
					return false;
				}
				return true;
			}
			MessageBox.Show("Define process name first!");
			return false;
		}

		public bool IsProcessStarted()
		{
			return processHandle != 0;
		}

		[DllImport("kernel32.dll")]
		public static extern bool VirtualProtectEx(int hProcess, int lpAddress, int dwSize, uint flNewProtect, out uint lpflOldProtect);

		public void WriteByte(IntPtr pOffset, byte pBytes)
		{
			WriteMem(pOffset, BitConverter.GetBytes(pBytes));
		}

		public void WriteByte(bool AddToImageAddress, int pOffset, byte pBytes)
		{
			WriteMem(pOffset, BitConverter.GetBytes(pBytes), AddToImageAddress);
		}

		public void WriteByte(string Module, int pOffset, byte pBytes)
		{
			WriteMem(IntPtr.Add(DllImageAddress(Module), pOffset), BitConverter.GetBytes(pBytes));
		}

		public void WriteDouble(IntPtr pOffset, double pBytes)
		{
			WriteMem(pOffset, BitConverter.GetBytes(pBytes));
		}

		public void WriteDouble(bool AddToImageAddress, int pOffset, double pBytes)
		{
			WriteMem(pOffset, BitConverter.GetBytes(pBytes), AddToImageAddress);
		}

		public void WriteDouble(string Module, int pOffset, double pBytes)
		{
			WriteMem(IntPtr.Add(DllImageAddress(Module), pOffset), BitConverter.GetBytes(pBytes));
		}

		public void WriteFloat(IntPtr pOffset, float pBytes)
		{
			WriteMem(pOffset, BitConverter.GetBytes(pBytes));
		}

		public void WriteFloat(bool AddToImageAddress, int pOffset, float pBytes)
		{
			WriteMem(pOffset, BitConverter.GetBytes(pBytes), AddToImageAddress);
		}

		public void WriteFloat(string Module, int pOffset, float pBytes)
		{
			WriteMem(IntPtr.Add(DllImageAddress(Module), pOffset), BitConverter.GetBytes(pBytes));
		}

		public void WriteInt(IntPtr pOffset, int pBytes)
		{
			WriteMem(pOffset, BitConverter.GetBytes(pBytes));
		}

		public void WriteInt(bool AddToImageAddress, int pOffset, int pBytes)
		{
			WriteMem(pOffset, BitConverter.GetBytes(pBytes), AddToImageAddress);
		}

		public void WriteInt(string Module, int pOffset, int pBytes)
		{
			WriteMem(IntPtr.Add(DllImageAddress(Module), pOffset), BitConverter.GetBytes(pBytes));
		}

		public void WriteMem(IntPtr pOffset, byte[] pBytes)
		{
			WriteProcessMemory(processHandle, pOffset, pBytes, pBytes.Length, 0);
		}

		public void WriteMem(int pOffset, byte[] pBytes, bool AddToImageAddress)
		{
			IntPtr lpBaseAddress = (AddToImageAddress ? ImageAddress(pOffset) : new IntPtr(pOffset));
			WriteProcessMemory(processHandle, lpBaseAddress, pBytes, pBytes.Length, 0);
		}

		[DllImport("kernel32.dll")]
		public static extern bool WriteProcessMemory(int hProcess, IntPtr lpBaseAddress, byte[] buffer, int size, int lpNumberOfBytesWritten);

		public void WriteShort(IntPtr pOffset, short pBytes)
		{
			WriteMem(pOffset, BitConverter.GetBytes(pBytes));
		}

		public void WriteShort(bool AddToImageAddress, int pOffset, short pBytes)
		{
			WriteMem(pOffset, BitConverter.GetBytes(pBytes), AddToImageAddress);
		}

		public void WriteShort(string Module, int pOffset, short pBytes)
		{
			WriteMem(IntPtr.Add(DllImageAddress(Module), pOffset), BitConverter.GetBytes(pBytes));
		}

		public void WriteStringAscii(IntPtr pOffset, string pBytes)
		{
			WriteMem(pOffset, Encoding.ASCII.GetBytes(pBytes + "\0"));
		}

		public void WriteStringAscii(bool AddToImageAddress, int pOffset, string pBytes)
		{
			WriteMem(pOffset, Encoding.ASCII.GetBytes(pBytes + "\0"), AddToImageAddress);
		}

		public void WriteStringAscii(string Module, int pOffset, string pBytes)
		{
			WriteMem(IntPtr.Add(DllImageAddress(Module), pOffset), Encoding.ASCII.GetBytes(pBytes + "\0"));
		}

		public void WriteStringUnicode(IntPtr pOffset, string pBytes)
		{
			WriteMem(pOffset, Encoding.Unicode.GetBytes(pBytes + "\0"));
		}

		public void WriteStringUnicode(bool AddToImageAddress, int pOffset, string pBytes)
		{
			WriteMem(pOffset, Encoding.Unicode.GetBytes(pBytes + "\0"), AddToImageAddress);
		}

		public void WriteStringUnicode(string Module, int pOffset, string pBytes)
		{
			WriteMem(IntPtr.Add(DllImageAddress(Module), pOffset), Encoding.Unicode.GetBytes(pBytes + "\0"));
		}

		public void WriteUInt(IntPtr pOffset, uint pBytes)
		{
			WriteMem(pOffset, BitConverter.GetBytes(pBytes));
		}

		public void WriteUInt(bool AddToImageAddress, int pOffset, uint pBytes)
		{
			WriteMem(pOffset, BitConverter.GetBytes(pBytes), AddToImageAddress);
		}

		public void WriteUInt(string Module, int pOffset, uint pBytes)
		{
			WriteMem(IntPtr.Add(DllImageAddress(Module), pOffset), BitConverter.GetBytes(pBytes));
		}
	}
}
