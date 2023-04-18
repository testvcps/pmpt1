using System.Collections.Generic;
using System;
using System.Text;


public class ByteBuffer 
{
    private List<byte> Buff;
    private byte[] readBuff;
    private int readpos;
    private bool buffUpdated = false;

    public ByteBuffer()
    {
        Buff = new List<byte>();
        readpos = 0;
    }

    public long GetReadPos()
    {
        return readpos;
    }

    public byte[] ToArray()
    {
        return Buff.ToArray();
    }

    public int Count()
    {
        return Buff.Count;
    }

    public int Length()
    {
        return Count() -readpos;
    }

    public void Clear()
    {
        Buff.Clear();
        readpos = 0;
    }


    public void WriteBytes(byte[] Input)
    {
        Buff.AddRange(Input);
        buffUpdated = true;
    }

    public void WriteShort(short Input)
    {
        Buff.AddRange(BitConverter.GetBytes(Input));
        buffUpdated = true;
    }

    public void WriteInteger(int Input)
    {
        Buff.AddRange(BitConverter.GetBytes(Input));
        buffUpdated = true;
    }

    public void WriteFloat(float Input)
    {
        Buff.AddRange(BitConverter.GetBytes(Input));
        buffUpdated = true;
    }

    public void WriteLong(long Input)
    {
        Buff.AddRange(BitConverter.GetBytes(Input));
        buffUpdated = true;
    }

    public void WriteString(string Input)
    {
        Buff.AddRange(BitConverter.GetBytes(Input.Length));
        Buff.AddRange(Encoding.ASCII.GetBytes(Input));
        buffUpdated = true;
    }

    public int ReadInteger(bool Peek = true)
    {
        if (Buff.Count > readpos)
        {
            if (buffUpdated)
            {
                readBuff = Buff.ToArray();
                buffUpdated = false;
            }
            int ret = BitConverter.ToInt32(readBuff, readpos);
            if (Peek & Buff.Count > readpos)
                readpos += 4;
            return ret;
        }
        else
            throw new Exception("Byte Buffer is Past Limit!");
    }

    public byte[] ReadBytes(int Length, bool Peek = true)
    {

        if (buffUpdated)
        {
            readBuff = Buff.ToArray();
            buffUpdated = false;
        }
        byte[] ret = Buff.GetRange(readpos, Length).ToArray();
        if (Peek)
            readpos += Length;
        return ret;
    }

    public string ReadString(bool Peek = true)
    {
        int Len = ReadInteger(true);
        if (buffUpdated)
        {
            readBuff = Buff.ToArray();
            buffUpdated = false;
        }
        string ret = Encoding.ASCII.GetString(readBuff, readpos, Len);
        if (Peek & Buff.Count > readpos)
        {
            if (ret.Length > 0)
                readpos += Len;
        }
        return ret;
    }

    public short ReadShort(bool Peek = true)
    {
        if (Buff.Count > readpos)
        {
            if (buffUpdated)
            {
                readBuff = Buff.ToArray();
                buffUpdated = false;
            }
            int ret = BitConverter.ToInt16(readBuff, readpos);
            if (Peek & Buff.Count > readpos)
                readpos += 2;
            return (short)ret;
        }
        else
            throw new Exception("Byte Buffer is Past Limit!");
    }

    public float ReadFloat(bool Peek = true)
    {
        if (Buff.Count > readpos)
        {
            if (buffUpdated)
            {
                readBuff = Buff.ToArray();
                buffUpdated = false;
            }
            int ret = (int)BitConverter.ToSingle(readBuff, readpos);
            if (Peek & Buff.Count > readpos)
                readpos += 4;
            return ret;
        }
        else
            throw new Exception("Byte Buffer is Past Limit!");
    }

    public long Readlong(bool Peek = true)
    {
        if (Buff.Count > readpos)
        {
            if (buffUpdated)
            {
                readBuff = Buff.ToArray();
                buffUpdated = false;
            }
            long ret = BitConverter.ToInt64(readBuff, readpos);
            if (Peek & Buff.Count > readpos)
                readpos += 8;
            return ret;
        }
        else
            throw new Exception("Byte Buffer is Past Limit!");
    }

    private bool diposedValue = false; //to detect redudant calls

    protected virtual void Dipose(bool disposing)
    {
        if (!diposedValue)
        {
            if (disposing)
                Buff.Clear();
            readpos = 0;
        }
        diposedValue = true;
    }

    public void Dipose()
    {
        Dipose(true);
        GC.SuppressFinalize(this);
    }
}
