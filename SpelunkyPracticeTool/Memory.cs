using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Diagnostics;
using System.Runtime.InteropServices;

namespace SpelunkyPracticeTool
{
    class Memory
    {
        #region dllimport
        [Flags]
        public enum ProcessAccessFlags : uint
        {
            All = 0x001F0FFF,
            Terminate = 0x00000001,
            CreateThread = 0x00000002,
            VMOperation = 0x00000008,
            VMRead = 0x00000010,
            VMWrite = 0x00000020,
            DupHandle = 0x00000040,
            SetInformation = 0x00000200,
            QueryInformation = 0x00000400,
            Synchronize = 0x00100000
        }

        [DllImport("kernel32.dll")]
        static extern int OpenProcess(ProcessAccessFlags dwDesiredAccess, [MarshalAs(UnmanagedType.Bool)] bool bInheritHandle, int dwProcessId);

        [DllImport("kernel32.dll", SetLastError = true)]
        static extern bool WriteProcessMemory(int hProcess, IntPtr lpBaseAddress, byte[] lpBuffer, int nSize, out int lpNumberOfBytesWritten);

        [DllImport("kernel32.dll")]
        public static extern bool ReadProcessMemory(int hProcess, IntPtr lpBaseAddress, byte[] lpBuffer, int dwSize, ref int lpNumberOfBytesRead);

        [DllImport("kernel32.dll")]
        public static extern Int32 CloseHandle(int hProcess);
        #endregion


        public static int hProc;
        public static Process Process;

        public static int BaseAddress;
        public static void LoadProcess(Process proc)
        {
            if (proc == null || proc.HasExited) return;

            Process = proc;
            BaseAddress = Process.MainModule.BaseAddress.ToInt32();
            hProc = OpenProcess(ProcessAccessFlags.All, false, proc.Id);
        }

        public static void CloseHandle()
        {
            if(Process != null && !Process.HasExited)
                CloseHandle(hProc);
        }

        public static bool WriteBytes(byte[] value, int address, params int[] offsets)
        {
            if (Process.HasExited) return false;
            int disposethis = 0;

            return WriteProcessMemory(hProc, (IntPtr)getPointerAddress(address,offsets), value, value.Length,out disposethis);
        }

        public static bool WriteInt(int value, int address, params int[] offsets)
        {
            return WriteBytes(BitConverter.GetBytes(value),address,offsets);
        }

        public static bool WriteFloat(float value, int address, params int[] offsets)
        {
            return WriteBytes(BitConverter.GetBytes(value), address, offsets);
        }

        public static bool WriteDouble(double value, int address, params int[] offsets)
        {
            return WriteBytes(BitConverter.GetBytes(value), address, offsets);
        }

        public static bool WriteBool(bool value, int address, params int[] offsets)
        {
            return WriteBytes(BitConverter.GetBytes(value), address, offsets);
        }

        public static byte[] ReadBytes(int address, int length, params int[] offsets)
        {
            byte[] buffer = new byte[length];
            int n = 0;
            ReadProcessMemory(hProc, (IntPtr)Memory.getPointerAddress(address, offsets), buffer, length, ref n);

            return buffer;
        }

        public static int ReadInt32(int address, params int[] offsets)
        {
            if (Process.HasExited) return 0;

            return BitConverter.ToInt32(ReadBytes(address,4, offsets),0);
        }

        public static float ReadFloat(int address, params int[] offsets)
        {
            if (Process.HasExited) return 0;

            return BitConverter.ToSingle(ReadBytes(address, 4, offsets), 0);
        }

        public static double ReadDouble(int address, params int[] offsets)
        {
            if (Process.HasExited) return 0;

            return BitConverter.ToDouble(ReadBytes(address,sizeof(double),offsets), 0);
        }


        public static bool ReadBool(int address,params int[] offsets)
        {
            if (Process.HasExited) return false;

            return ReadBytes(address, 1, offsets)[0] > 0;
        }

        public static int getPointerAddress(int start, params int[] offsets)
        {
            int addr = start;

            foreach (var offset in offsets)
                addr = ReadInt32(addr) + offset;

            return addr;
        }

    }
}
