using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SpelunkyPracticeTool
{
    static class Values
    {
        static int ba { get { return Memory.BaseAddress; } }


        public static class Level
        {
            public static bool ForceBM
            {
                get { return Memory.ReadBool(0x1384B4 + ba, 0x4405FF); }
                set { Memory.WriteBool(value, 0x1384B4 + ba, 0x4405FF); }
            }

            public static bool ForceCOG
            {
                get { return Memory.ReadBool(0x1384B4 + ba, 0x440604); }
                set { Memory.WriteBool(value, 0x1384B4 + ba, 0x440604); }
            }

            public static bool ForceCastle
            {
                get { return Memory.ReadBool(0x1384B4 + ba, 0x004405F7); }
                set { Memory.WriteBool(value, 0x1384B4 + ba, 0x004405F7); }
            }

            public static bool ForceSpaceship
            {
                get { return Memory.ReadBool(0x1384B4 + ba, 0x440602); }
                set { Memory.WriteBool(value, 0x1384B4 + ba, 0x440602); }
            }

            public static bool ForceWorm
            {
                get { return Memory.ReadBool(0x1384B4 + ba, 0x440606); }
                set { Memory.WriteBool(value, 0x1384B4 + ba, 0x440606); }
            }


            public static int CurrentLevel
            {
                get { return Memory.ReadInt32(0x1384B4 + ba, 0x4405D4); }
                set { Memory.WriteInt(value, 0x1384B4 + ba, 0x4405D4); }
            }

            public static bool JetPack
            {
                get { return Memory.ReadBool(0x1384B4 + ba, 0x440706); }
                set { Memory.WriteBool(value, 0x1384B4 + ba, 0x440706); }
            }

            public static bool Cape
            {
                get { return Memory.ReadBool(0x1384B4 + ba, 0x440712); }
                set { Memory.WriteBool(value, 0x1384B4 + ba, 0x440712); }
            }
            public static bool VladCape
            {
                get { return Memory.ReadBool(0x1384B4 + ba, 0x440713); }
                set { Memory.WriteBool(value, 0x1384B4 + ba, 0x440713); }
            }
        }

        public static class Time
        {
            public static int TotalSeconds
            {
                get { return Memory.ReadInt32(0x1384B4 + ba, 0x445944); }
                set { Memory.WriteInt(value, 0x1384B4 + ba, 0x445944); }
            }

            public static int TotalMinutes
            {
                get { return Memory.ReadInt32(0x138558 + ba, 0x30, 0x280, 0x52B7); }
                set { Memory.WriteInt(value, 0x138558 + ba, 0x30, 0x280, 0x52B7); }
            }
        }

        public static class Player
        {
            public static int Base
            {
                get { return Memory.ReadInt32(0x138558 + ba, 0x30); }
            }

            public static int HP
            {
                get { return Memory.ReadInt32(Base + 0x140); }
                set { Memory.WriteInt(value, Base + 0x140); }
            }

            public static int Ropes
            {
                get { return Memory.ReadInt32(0x138558 + ba, 0x30, 0x280, 0x14); }
                set { Memory.WriteInt(value, 0x138558 + ba, 0x30, 0x280, 0x14); }
            } 

            public static int Bombs
            {
                get { return Memory.ReadInt32(0x138558 + ba, 0x30, 0x280, 0x10); }
                set { Memory.WriteInt(value, 0x138558 + ba, 0x30, 0x280, 0x10); }
            }

            public static int HoldItem
            {
                get { return Memory.ReadInt32(0x1384B4 + ba, 0x44071C); }
                set { Memory.WriteInt(value, 0x1384B4 + ba, 0x44071C); }
            }

            public static void EquipItem(Items item)
            {
                Memory.WriteBool(true, 0x138558 + ba, 0x30, 0x280, (int)item);
            }

            public static int JetpackEntityID
            {
                get { return Memory.ReadInt32(0x0138558 + ba, 0x30, 0x238); }
            }
        }
        
    }
}
