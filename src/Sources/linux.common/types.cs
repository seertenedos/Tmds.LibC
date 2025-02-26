using System;

namespace Tmds.Linux
{
    public partial struct size_t : IEquatable<size_t>
    {
        public static implicit operator ulong(size_t arg) => arg.ToUInt64();
        public static explicit operator uint(size_t arg) => arg.ToUInt32();
        public static explicit operator int(size_t arg) => (int)arg.Value;

        public static implicit operator size_t(uint arg) => new size_t(arg);
        // .NET uses 'int' mostly to for lengths.
        public static implicit operator size_t(int arg) => new size_t((uint)arg);
        // disambiguate between uint and int overloads
        public static implicit operator size_t(ushort arg) => new size_t((uint)arg);
        public static explicit operator size_t(ulong arg) => new size_t(arg);

        public override string ToString() => Value.ToString();

        public override int GetHashCode() => Value.GetHashCode();

        public override bool Equals(object obj)
        {
            if (obj != null && obj is size_t v)
            {
                return this == v;
            }
            else
            {
                return false;
            }
        }

        public bool Equals(size_t v) => this == v;

        public static size_t operator +(size_t v) => new size_t(v.Value);
        public static size_t operator ~(size_t v) => new size_t(~v.Value);
        public static size_t operator ++(size_t v) => new size_t(v.Value + 1);
        public static size_t operator --(size_t v) => new size_t(v.Value - 1);
        public static size_t operator +(size_t v1, size_t v2) => new size_t(v1.Value + v2.Value);
        public static size_t operator -(size_t v1, size_t v2) => new size_t(v1.Value - v2.Value);
        public static size_t operator *(size_t v1, size_t v2) => new size_t(v1.Value * v1.Value);
        public static size_t operator /(size_t v1, size_t v2) => new size_t(v1.Value / v2.Value);
        public static size_t operator %(size_t v1, size_t v2) => new size_t(v1.Value % v2.Value);
        public static size_t operator &(size_t v1, size_t v2) => new size_t(v1.Value & v2.Value);
        public static size_t operator |(size_t v1, size_t v2) => new size_t(v1.Value | v2.Value);
        public static size_t operator ^(size_t v1, size_t v2) => new size_t(v1.Value ^ v2.Value);
        public static size_t operator <<(size_t v, int i) => new size_t(v.Value << i);
        public static size_t operator >>(size_t v, int i) => new size_t(v.Value >> i);
        public static bool operator ==(size_t v1, size_t v2) => v1.Value == v2.Value;
        public static bool operator !=(size_t v1, size_t v2) => v1.Value != v2.Value;
        public static bool operator <(size_t v1, size_t v2) => v1.Value < v2.Value;
        public static bool operator >(size_t v1, size_t v2) => v1.Value > v2.Value;
        public static bool operator <=(size_t v1, size_t v2) => v1.Value <= v2.Value;
        public static bool operator >=(size_t v1, size_t v2) => v1.Value >= v2.Value;
    }

    public partial struct ssize_t : IEquatable<ssize_t>
    {
        public static implicit operator long(ssize_t arg) => arg.ToInt64();
        public static explicit operator int(ssize_t arg) => arg.ToInt32();
        public static explicit operator size_t(ssize_t arg) => new size_t(arg);

        public static implicit operator ssize_t(int arg) => new ssize_t(arg);
        public static explicit operator ssize_t(long arg) => new ssize_t(arg);

        public override string ToString() => Value.ToString();

        public override int GetHashCode() => Value.GetHashCode();

        public override bool Equals(object obj)
        {
            if (obj != null && obj is ssize_t v)
            {
                return this == v;
            }
            else
            {
                return false;
            }
        }

        public bool Equals(ssize_t v) => this == v;

        public static ssize_t operator +(ssize_t v) => new ssize_t(v.Value);
        public static ssize_t operator -(ssize_t v) => new ssize_t(-v.Value);
        public static ssize_t operator ~(ssize_t v) => new ssize_t(~v.Value);
        public static ssize_t operator ++(ssize_t v) => new ssize_t(v.Value + 1);
        public static ssize_t operator --(ssize_t v) => new ssize_t(v.Value - 1);
        public static ssize_t operator +(ssize_t v1, ssize_t v2) => new ssize_t(v1.Value + v2.Value);
        public static ssize_t operator -(ssize_t v1, ssize_t v2) => new ssize_t(v1.Value - v2.Value);
        public static ssize_t operator *(ssize_t v1, ssize_t v2) => new ssize_t(v1.Value * v1.Value);
        public static ssize_t operator /(ssize_t v1, ssize_t v2) => new ssize_t(v1.Value / v2.Value);
        public static ssize_t operator %(ssize_t v1, ssize_t v2) => new ssize_t(v1.Value % v2.Value);
        public static ssize_t operator &(ssize_t v1, ssize_t v2) => new ssize_t(v1.Value & v2.Value);
        public static ssize_t operator |(ssize_t v1, ssize_t v2) => new ssize_t(v1.Value | v2.Value);
        public static ssize_t operator ^(ssize_t v1, ssize_t v2) => new ssize_t(v1.Value ^ v2.Value);
        public static ssize_t operator <<(ssize_t v, int i) => new ssize_t(v.Value << i);
        public static ssize_t operator >>(ssize_t v, int i) => new ssize_t(v.Value >> i);
        public static bool operator ==(ssize_t v1, ssize_t v2) => v1.Value == v2.Value;
        public static bool operator !=(ssize_t v1, ssize_t v2) => v1.Value != v2.Value;
        public static bool operator <(ssize_t v1, ssize_t v2) => v1.Value < v2.Value;
        public static bool operator >(ssize_t v1, ssize_t v2) => v1.Value > v2.Value;
        public static bool operator <=(ssize_t v1, ssize_t v2) => v1.Value <= v2.Value;
        public static bool operator >=(ssize_t v1, ssize_t v2) => v1.Value >= v2.Value;
    }

    public struct syscall_arg
    {
        private ssize_t __value;
        internal ssize_t Value => __value;

        private unsafe syscall_arg(size_t value) => __value = *(ssize_t*)&value;
        private syscall_arg(ssize_t value) => __value = value;

        public static implicit operator syscall_arg(size_t arg) => new syscall_arg(arg);
        public static implicit operator syscall_arg(ssize_t arg) => new syscall_arg(arg);
        public static implicit operator syscall_arg(long_t arg) => new syscall_arg(arg.Value);

        public static implicit operator syscall_arg(uint arg) => new syscall_arg(new size_t(arg));
        public static implicit operator syscall_arg(int arg) => new syscall_arg(new ssize_t(arg));

        public unsafe static implicit operator syscall_arg(void* arg) => new syscall_arg(new size_t(arg));

        public static implicit operator ssize_t(syscall_arg arg) => arg.Value;
        public static explicit operator int(syscall_arg arg) => (int)arg.Value;

        public override string ToString() => Value.ToString();
    }

    public struct sa_family_t : IEquatable<sa_family_t>
    {
        private ushort __value;
        internal ushort Value => __value;

        private sa_family_t(int value) => __value = (ushort)value;
        public override int GetHashCode() => Value.GetHashCode();

        public static implicit operator int(sa_family_t arg) => arg.Value;
        public static implicit operator sa_family_t(int arg) => new sa_family_t(arg);

        public override string ToString() => Value.ToString();

        public override bool Equals(object obj)
        {
            if (obj != null && obj is sa_family_t v)
            {
                return this == v;
            }
            else
            {
                return false;
            }
        }

        public bool Equals(sa_family_t v) => this == v;

        public static bool operator ==(sa_family_t v1, sa_family_t v2) => v1.Value == v2.Value;
        public static bool operator !=(sa_family_t v1, sa_family_t v2) => v1.Value != v2.Value;
    }

    public struct pid_t : IEquatable<pid_t>
    {
        private int __value;
        internal int Value => __value;

        private pid_t(int value) => __value = value;

        public static implicit operator int(pid_t arg) => arg.Value;
        public static implicit operator pid_t(int arg) => new pid_t(arg);

        public override string ToString() => Value.ToString();

        public override int GetHashCode() => Value.GetHashCode();

        public override bool Equals(object obj)
        {
            if (obj != null && obj is pid_t v)
            {
                return this == v;
            }
            else
            {
                return false;
            }
        }

        public bool Equals(pid_t v) => this == v;

        public static pid_t operator -(pid_t v) => new pid_t(-v.Value);
        public static bool operator ==(pid_t v1, pid_t v2) => v1.Value == v2.Value;
        public static bool operator !=(pid_t v1, pid_t v2) => v1.Value != v2.Value;
    }

    public struct uid_t : IEquatable<uid_t>
    {
        private uint __value;
        internal uint Value => __value;

        private uid_t(uint value) => __value = value;

        public static implicit operator uint(uid_t arg) => arg.Value;
        public static implicit operator uid_t(uint arg) => new uid_t(arg);

        public override string ToString() => Value.ToString();

        public override int GetHashCode() => Value.GetHashCode();

        public override bool Equals(object obj)
        {
            if (obj != null && obj is uid_t v)
            {
                return this == v;
            }
            else
            {
                return false;
            }
        }

        public bool Equals(uid_t v) => this == v;

        public static bool operator ==(uid_t v1, uid_t v2) => v1.Value == v2.Value;
        public static bool operator !=(uid_t v1, uid_t v2) => v1.Value != v2.Value;
    }

    public struct gid_t : IEquatable<gid_t>
    {
        private uint __value;
        internal uint Value => __value;

        private gid_t(uint value) => __value = value;

        public static implicit operator uint(gid_t arg) => arg.Value;
        public static implicit operator gid_t(uint arg) => new gid_t(arg);

        public override string ToString() => Value.ToString();

        public override int GetHashCode() => Value.GetHashCode();

        public override bool Equals(object obj)
        {
            if (obj != null && obj is gid_t v)
            {
                return this == v;
            }
            else
            {
                return false;
            }
        }

        public bool Equals(gid_t v) => this == v;

        public static bool operator ==(gid_t v1, gid_t v2) => v1.Value == v2.Value;
        public static bool operator !=(gid_t v1, gid_t v2) => v1.Value != v2.Value;
    }

    public struct socklen_t : IEquatable<socklen_t>
    {
        private uint __value;
        internal uint Value => __value;

        private socklen_t(uint value) => __value = value;

        public static implicit operator uint(socklen_t arg) => arg.Value;
        public static explicit operator int(socklen_t arg) => (int)arg.Value;

        public static implicit operator socklen_t(uint arg) => new socklen_t(arg);
        // .NET uses 'int' mostly to for lengths.
        public static implicit operator socklen_t(int arg) => new socklen_t((uint)arg);
        // Make unambiguous implicit int vs uint
        public static implicit operator socklen_t(ushort arg) => new socklen_t(arg);

        public override string ToString() => Value.ToString();

        public override int GetHashCode() => Value.GetHashCode();

        public override bool Equals(object obj)
        {
            if (obj != null && obj is socklen_t v)
            {
                return this == v;
            }
            else
            {
                return false;
            }
        }

        public bool Equals(socklen_t v) => this == v;

        public static socklen_t operator +(socklen_t v) => new socklen_t(v.Value);
        public static socklen_t operator ~(socklen_t v) => new socklen_t(~v.Value);
        public static socklen_t operator ++(socklen_t v) => new socklen_t(v.Value + 1);
        public static socklen_t operator --(socklen_t v) => new socklen_t(v.Value - 1);
        public static socklen_t operator +(socklen_t v1, socklen_t v2) => new socklen_t(v1.Value + v2.Value);
        public static socklen_t operator -(socklen_t v1, socklen_t v2) => new socklen_t(v1.Value - v2.Value);
        public static socklen_t operator *(socklen_t v1, socklen_t v2) => new socklen_t(v1.Value * v1.Value);
        public static socklen_t operator /(socklen_t v1, socklen_t v2) => new socklen_t(v1.Value / v2.Value);
        public static socklen_t operator %(socklen_t v1, socklen_t v2) => new socklen_t(v1.Value % v2.Value);
        public static socklen_t operator &(socklen_t v1, socklen_t v2) => new socklen_t(v1.Value & v2.Value);
        public static socklen_t operator |(socklen_t v1, socklen_t v2) => new socklen_t(v1.Value | v2.Value);
        public static socklen_t operator ^(socklen_t v1, socklen_t v2) => new socklen_t(v1.Value ^ v2.Value);
        public static socklen_t operator <<(socklen_t v, int i) => new socklen_t(v.Value << i);
        public static socklen_t operator >>(socklen_t v, int i) => new socklen_t(v.Value >> i);
        public static bool operator ==(socklen_t v1, socklen_t v2) => v1.Value == v2.Value;
        public static bool operator !=(socklen_t v1, socklen_t v2) => v1.Value != v2.Value;
        public static bool operator <(socklen_t v1, socklen_t v2) => v1.Value < v2.Value;
        public static bool operator >(socklen_t v1, socklen_t v2) => v1.Value > v2.Value;
        public static bool operator <=(socklen_t v1, socklen_t v2) => v1.Value <= v2.Value;
        public static bool operator >=(socklen_t v1, socklen_t v2) => v1.Value >= v2.Value;
    }

    public struct off_t : IEquatable<off_t>
    {
        // always use 64-bit (-D_FILE_OFFSET_BITS=64 on 32-bit)
        private long __value;
        internal long Value => __value;

        private off_t(long value) => __value = value;

        public static implicit operator long(off_t arg) => arg.Value;
        public static implicit operator off_t(long arg) => new off_t(arg);

        public override string ToString() => Value.ToString();

        public override int GetHashCode() => Value.GetHashCode();

        public override bool Equals(object obj)
        {
            if (obj != null && obj is off_t v)
            {
                return this == v;
            }
            else
            {
                return false;
            }
        }

        public bool Equals(off_t v) => this == v;

        public static off_t operator +(off_t v) => new off_t(v.Value);
        public static off_t operator -(off_t v) => new off_t(-v.Value);
        public static off_t operator ~(off_t v) => new off_t(~v.Value);
        public static off_t operator ++(off_t v) => new off_t(v.Value + 1);
        public static off_t operator --(off_t v) => new off_t(v.Value - 1);
        public static off_t operator +(off_t v1, off_t v2) => new off_t(v1.Value + v2.Value);
        public static off_t operator -(off_t v1, off_t v2) => new off_t(v1.Value - v2.Value);
        public static off_t operator *(off_t v1, off_t v2) => new off_t(v1.Value * v1.Value);
        public static off_t operator /(off_t v1, off_t v2) => new off_t(v1.Value / v2.Value);
        public static off_t operator %(off_t v1, off_t v2) => new off_t(v1.Value % v2.Value);
        public static off_t operator &(off_t v1, off_t v2) => new off_t(v1.Value & v2.Value);
        public static off_t operator |(off_t v1, off_t v2) => new off_t(v1.Value | v2.Value);
        public static off_t operator ^(off_t v1, off_t v2) => new off_t(v1.Value ^ v2.Value);
        public static off_t operator <<(off_t v, int i) => new off_t(v.Value << i);
        public static off_t operator >>(off_t v, int i) => new off_t(v.Value >> i);
        public static bool operator ==(off_t v1, off_t v2) => v1.Value == v2.Value;
        public static bool operator !=(off_t v1, off_t v2) => v1.Value != v2.Value;
        public static bool operator <(off_t v1, off_t v2) => v1.Value < v2.Value;
        public static bool operator >(off_t v1, off_t v2) => v1.Value > v2.Value;
        public static bool operator <=(off_t v1, off_t v2) => v1.Value <= v2.Value;
        public static bool operator >=(off_t v1, off_t v2) => v1.Value >= v2.Value;
    }

    public struct time_t : IEquatable<time_t>
    {
        // 32-bit values overflow in 2038: https://sourceware.org/glibc/wiki/Y2038ProofnessDesign
        private ssize_t __value;
        internal ssize_t Value => __value;

        internal time_t(long arg) => __value = new ssize_t(arg);

        public static implicit operator long(time_t arg) => arg.Value;
        public static implicit operator time_t(long arg) => new time_t(arg);

        public override string ToString() => Value.ToString();

        public override int GetHashCode() => Value.GetHashCode();

        public override bool Equals(object obj)
        {
            if (obj != null && obj is time_t v)
            {
                return this == v;
            }
            else
            {
                return false;
            }
        }

        public bool Equals(time_t v) => this == v;

        public static time_t operator +(time_t v) => new time_t(v.Value);
        public static time_t operator -(time_t v) => new time_t(-v.Value);
        public static time_t operator ~(time_t v) => new time_t(~v.Value);
        public static time_t operator ++(time_t v) => new time_t(v.Value + 1);
        public static time_t operator --(time_t v) => new time_t(v.Value - 1);
        public static time_t operator +(time_t v1, time_t v2) => new time_t(v1.Value + v2.Value);
        public static time_t operator -(time_t v1, time_t v2) => new time_t(v1.Value - v2.Value);
        public static time_t operator *(time_t v1, time_t v2) => new time_t(v1.Value * v1.Value);
        public static time_t operator /(time_t v1, time_t v2) => new time_t(v1.Value / v2.Value);
        public static time_t operator %(time_t v1, time_t v2) => new time_t(v1.Value % v2.Value);
        public static time_t operator &(time_t v1, time_t v2) => new time_t(v1.Value & v2.Value);
        public static time_t operator |(time_t v1, time_t v2) => new time_t(v1.Value | v2.Value);
        public static time_t operator ^(time_t v1, time_t v2) => new time_t(v1.Value ^ v2.Value);
        public static time_t operator <<(time_t v, int i) => new time_t(v.Value << i);
        public static time_t operator >>(time_t v, int i) => new time_t(v.Value >> i);
        public static bool operator ==(time_t v1, time_t v2) => v1.Value == v2.Value;
        public static bool operator !=(time_t v1, time_t v2) => v1.Value != v2.Value;
        public static bool operator <(time_t v1, time_t v2) => v1.Value < v2.Value;
        public static bool operator >(time_t v1, time_t v2) => v1.Value > v2.Value;
        public static bool operator <=(time_t v1, time_t v2) => v1.Value <= v2.Value;
        public static bool operator >=(time_t v1, time_t v2) => v1.Value >= v2.Value;
    }

    public struct timespec : IEquatable<timespec>
    {
        public time_t tv_sec;
        public long_t tv_nsec;

        public static bool operator ==(timespec v1, timespec v2) => v1.tv_sec == v2.tv_sec && v1.tv_nsec == v2.tv_nsec;
        public static bool operator !=(timespec v1, timespec v2) => !(v1 == v2);

        public override int GetHashCode() => tv_sec.GetHashCode() ^ tv_nsec.GetHashCode();

        public override bool Equals(object obj)
        {
            if (obj != null && obj is timespec v)
            {
                return this == v;
            }
            else
            {
                return false;
            }
        }

        public bool Equals(timespec v) => this == v;
    }

    public struct long_t : IEquatable<long_t>
    {
        internal ssize_t __value;
        internal ssize_t Value => __value;

        private long_t(ssize_t value) => __value = value;

        public static implicit operator long(long_t arg) => arg.Value;
        public static explicit operator int(long_t arg) => (int)arg.Value;

        public static explicit operator long_t(long arg) => new long_t(new ssize_t(arg));
        public static implicit operator long_t(int arg) => new long_t(arg);

        public override string ToString() => Value.ToString();

        public override int GetHashCode() => Value.GetHashCode();

        public override bool Equals(object obj)
        {
            if (obj != null && obj is long_t v)
            {
                return this == v;
            }
            else
            {
                return false;
            }
        }

        public bool Equals(long_t v) => this == v;

        public static long_t operator +(long_t v) => new long_t(v.Value);
        public static long_t operator -(long_t v) => new long_t(-v.Value);
        public static long_t operator ~(long_t v) => new long_t(~v.Value);
        public static long_t operator ++(long_t v) => new long_t(v.Value + 1);
        public static long_t operator --(long_t v) => new long_t(v.Value - 1);
        public static long_t operator +(long_t v1, long_t v2) => new long_t(v1.Value + v2.Value);
        public static long_t operator -(long_t v1, long_t v2) => new long_t(v1.Value - v2.Value);
        public static long_t operator *(long_t v1, long_t v2) => new long_t(v1.Value * v1.Value);
        public static long_t operator /(long_t v1, long_t v2) => new long_t(v1.Value / v2.Value);
        public static long_t operator %(long_t v1, long_t v2) => new long_t(v1.Value % v2.Value);
        public static long_t operator &(long_t v1, long_t v2) => new long_t(v1.Value & v2.Value);
        public static long_t operator |(long_t v1, long_t v2) => new long_t(v1.Value | v2.Value);
        public static long_t operator ^(long_t v1, long_t v2) => new long_t(v1.Value ^ v2.Value);
        public static long_t operator <<(long_t v, int i) => new long_t(v.Value << i);
        public static long_t operator >>(long_t v, int i) => new long_t(v.Value >> i);
        public static bool operator ==(long_t v1, long_t v2) => v1.Value == v2.Value;
        public static bool operator !=(long_t v1, long_t v2) => v1.Value != v2.Value;
        public static bool operator <(long_t v1, long_t v2) => v1.Value < v2.Value;
        public static bool operator >(long_t v1, long_t v2) => v1.Value > v2.Value;
        public static bool operator <=(long_t v1, long_t v2) => v1.Value <= v2.Value;
        public static bool operator >=(long_t v1, long_t v2) => v1.Value >= v2.Value;
    }

    public struct mode_t : IEquatable<mode_t>
    {
        private uint __value;
        internal uint Value => __value;

        private mode_t(uint value) => __value = value;

        public static implicit operator ushort(mode_t mode_t)=>(ushort)mode_t.Value;
        public static implicit operator mode_t(ushort value) => new mode_t(value);

        public override string ToString() => Value.ToString();

        public override int GetHashCode() => Value.GetHashCode();

        public override bool Equals(object obj)
        {
            if (obj != null && obj is mode_t v)
            {
                return this == v;
            }
            else
            {
                return false;
            }
        }

        public bool Equals(mode_t v) => this == v;

        public static mode_t operator ~(mode_t v) => new mode_t(~v.Value);
        public static mode_t operator &(mode_t v1, mode_t v2) => new mode_t(v1.Value & v2.Value);
        public static mode_t operator |(mode_t v1, mode_t v2) => new mode_t(v1.Value | v2.Value);
        public static bool operator ==(mode_t v1, mode_t v2) => v1.Value == v2.Value;
        public static bool operator !=(mode_t v1, mode_t v2) => v1.Value != v2.Value;
    }

    public struct clock_t : IEquatable<clock_t>
    {
        // 32-bit systems: values could overflow
        private ssize_t __value;
        internal ssize_t Value => __value;

        internal clock_t(long arg) => __value = new ssize_t(arg);

        public static implicit operator long(clock_t arg) => arg.Value;
        public static implicit operator clock_t(long arg) => new clock_t(arg);

        public override string ToString() => Value.ToString();

        public override int GetHashCode() => Value.GetHashCode();

        public override bool Equals(object obj)
        {
            if (obj != null && obj is clock_t v)
            {
                return this == v;
            }
            else
            {
                return false;
            }
        }

        public bool Equals(clock_t v) => this == v;

        public static clock_t operator +(clock_t v) => new clock_t(v.Value);
        public static clock_t operator -(clock_t v) => new clock_t(-v.Value);
        public static clock_t operator ~(clock_t v) => new clock_t(~v.Value);
        public static clock_t operator ++(clock_t v) => new clock_t(v.Value + 1);
        public static clock_t operator --(clock_t v) => new clock_t(v.Value - 1);
        public static clock_t operator +(clock_t v1, clock_t v2) => new clock_t(v1.Value + v2.Value);
        public static clock_t operator -(clock_t v1, clock_t v2) => new clock_t(v1.Value - v2.Value);
        public static clock_t operator *(clock_t v1, clock_t v2) => new clock_t(v1.Value * v1.Value);
        public static clock_t operator /(clock_t v1, clock_t v2) => new clock_t(v1.Value / v2.Value);
        public static clock_t operator %(clock_t v1, clock_t v2) => new clock_t(v1.Value % v2.Value);
        public static clock_t operator &(clock_t v1, clock_t v2) => new clock_t(v1.Value & v2.Value);
        public static clock_t operator |(clock_t v1, clock_t v2) => new clock_t(v1.Value | v2.Value);
        public static clock_t operator ^(clock_t v1, clock_t v2) => new clock_t(v1.Value ^ v2.Value);
        public static clock_t operator <<(clock_t v, int i) => new clock_t(v.Value << i);
        public static clock_t operator >>(clock_t v, int i) => new clock_t(v.Value >> i);
        public static bool operator ==(clock_t v1, clock_t v2) => v1.Value == v2.Value;
        public static bool operator !=(clock_t v1, clock_t v2) => v1.Value != v2.Value;
        public static bool operator <(clock_t v1, clock_t v2) => v1.Value < v2.Value;
        public static bool operator >(clock_t v1, clock_t v2) => v1.Value > v2.Value;
        public static bool operator <=(clock_t v1, clock_t v2) => v1.Value <= v2.Value;
        public static bool operator >=(clock_t v1, clock_t v2) => v1.Value >= v2.Value;
    }

    public unsafe struct pthread_t : IEquatable<pthread_t>
    {
        private void* __value;
        internal void* Value => __value;

        internal pthread_t(void* arg) => __value = arg;

        public override string ToString() => ((ulong)__value).ToString();

        public override int GetHashCode() => ((ulong)__value).GetHashCode();

        public override bool Equals(object obj)
        {
            if (obj != null && obj is pthread_t v)
            {
                return this == v;
            }
            else
            {
                return false;
            }
        }

        public bool Equals(pthread_t v) => this == v;

        public static bool operator ==(pthread_t v1, pthread_t v2) => v1.Value == v2.Value;
        public static bool operator !=(pthread_t v1, pthread_t v2) => v1.Value != v2.Value;
    }

    public struct dev_t
    {
        private ulong __value;
        internal ulong Value => __value;

        private dev_t(ulong value) => __value = value;

        public static implicit operator ulong(dev_t arg) => arg.Value;
        public static implicit operator dev_t(ulong arg) => new dev_t(arg);

        public override string ToString() => Value.ToString();

        public override int GetHashCode() => Value.GetHashCode();

        public override bool Equals(object obj)
        {
            if (obj != null && obj is dev_t v)
            {
                return this == v;
            }
            else
            {
                return false;
            }
        }

        public bool Equals(dev_t v) => this == v;

        public static bool operator ==(dev_t v1, dev_t v2) => v1.Value == v2.Value;
        public static bool operator !=(dev_t v1, dev_t v2) => v1.Value != v2.Value;
    }

    public struct ino_t
    {
        private ulong __value;
        internal ulong Value => __value;

        private ino_t(ulong value) => __value = value;

        public static implicit operator ulong(ino_t arg) => arg.Value;
        public static implicit operator ino_t(ulong arg) => new ino_t(arg);

        public override string ToString() => Value.ToString();

        public override int GetHashCode() => Value.GetHashCode();

        public override bool Equals(object obj)
        {
            if (obj != null && obj is ino_t v)
            {
                return this == v;
            }
            else
            {
                return false;
            }
        }

        public bool Equals(ino_t v) => this == v;

        public static bool operator ==(ino_t v1, ino_t v2) => v1.Value == v2.Value;
        public static bool operator !=(ino_t v1, ino_t v2) => v1.Value != v2.Value;
    }

    public struct blkcnt_t
    {
        private long __value;
        internal long Value => __value;

        private blkcnt_t(long value) => __value = value;

        public static implicit operator long(blkcnt_t arg) => arg.Value;
        public static implicit operator blkcnt_t(long arg) => new blkcnt_t(arg);

        public override string ToString() => Value.ToString();

        public override int GetHashCode() => Value.GetHashCode();

        public override bool Equals(object obj)
        {
            if (obj != null && obj is blkcnt_t v)
            {
                return this == v;
            }
            else
            {
                return false;
            }
        }

        public bool Equals(blkcnt_t v) => this == v;

        public static blkcnt_t operator +(blkcnt_t v) => new blkcnt_t(v.Value);
        public static blkcnt_t operator -(blkcnt_t v) => new blkcnt_t(-v.Value);
        public static blkcnt_t operator ~(blkcnt_t v) => new blkcnt_t(~v.Value);
        public static blkcnt_t operator ++(blkcnt_t v) => new blkcnt_t(v.Value + 1);
        public static blkcnt_t operator --(blkcnt_t v) => new blkcnt_t(v.Value - 1);
        public static blkcnt_t operator +(blkcnt_t v1, blkcnt_t v2) => new blkcnt_t(v1.Value + v2.Value);
        public static blkcnt_t operator -(blkcnt_t v1, blkcnt_t v2) => new blkcnt_t(v1.Value - v2.Value);
        public static blkcnt_t operator *(blkcnt_t v1, blkcnt_t v2) => new blkcnt_t(v1.Value * v1.Value);
        public static blkcnt_t operator /(blkcnt_t v1, blkcnt_t v2) => new blkcnt_t(v1.Value / v2.Value);
        public static blkcnt_t operator %(blkcnt_t v1, blkcnt_t v2) => new blkcnt_t(v1.Value % v2.Value);
        public static blkcnt_t operator &(blkcnt_t v1, blkcnt_t v2) => new blkcnt_t(v1.Value & v2.Value);
        public static blkcnt_t operator |(blkcnt_t v1, blkcnt_t v2) => new blkcnt_t(v1.Value | v2.Value);
        public static blkcnt_t operator ^(blkcnt_t v1, blkcnt_t v2) => new blkcnt_t(v1.Value ^ v2.Value);
        public static blkcnt_t operator <<(blkcnt_t v, int i) => new blkcnt_t(v.Value << i);
        public static blkcnt_t operator >>(blkcnt_t v, int i) => new blkcnt_t(v.Value >> i);
        public static bool operator ==(blkcnt_t v1, blkcnt_t v2) => v1.Value == v2.Value;
        public static bool operator !=(blkcnt_t v1, blkcnt_t v2) => v1.Value != v2.Value;
        public static bool operator <(blkcnt_t v1, blkcnt_t v2) => v1.Value < v2.Value;
        public static bool operator >(blkcnt_t v1, blkcnt_t v2) => v1.Value > v2.Value;
        public static bool operator <=(blkcnt_t v1, blkcnt_t v2) => v1.Value <= v2.Value;
        public static bool operator >=(blkcnt_t v1, blkcnt_t v2) => v1.Value >= v2.Value;
    }

    public partial struct nlink_t
    {
        public static implicit operator ulong(nlink_t arg) => arg.Value;
        public static implicit operator nlink_t(ulong arg) => new nlink_t(arg);

        public override string ToString() => Value.ToString();

        public override int GetHashCode() => Value.GetHashCode();

        public override bool Equals(object obj)
        {
            if (obj != null && obj is nlink_t v)
            {
                return this == v;
            }
            else
            {
                return false;
            }
        }

        public bool Equals(nlink_t v) => this == v;

        public static nlink_t operator +(nlink_t v) => new nlink_t(v.Value);
        public static nlink_t operator ~(nlink_t v) => new nlink_t(~v.Value);
        public static nlink_t operator ++(nlink_t v) => new nlink_t(v.Value + 1);
        public static nlink_t operator --(nlink_t v) => new nlink_t(v.Value - 1);
        public static nlink_t operator +(nlink_t v1, nlink_t v2) => new nlink_t(v1.Value + v2.Value);
        public static nlink_t operator -(nlink_t v1, nlink_t v2) => new nlink_t(v1.Value - v2.Value);
        public static nlink_t operator *(nlink_t v1, nlink_t v2) => new nlink_t(v1.Value * v1.Value);
        public static nlink_t operator /(nlink_t v1, nlink_t v2) => new nlink_t(v1.Value / v2.Value);
        public static nlink_t operator %(nlink_t v1, nlink_t v2) => new nlink_t(v1.Value % v2.Value);
        public static nlink_t operator &(nlink_t v1, nlink_t v2) => new nlink_t(v1.Value & v2.Value);
        public static nlink_t operator |(nlink_t v1, nlink_t v2) => new nlink_t(v1.Value | v2.Value);
        public static nlink_t operator ^(nlink_t v1, nlink_t v2) => new nlink_t(v1.Value ^ v2.Value);
        public static nlink_t operator <<(nlink_t v, int i) => new nlink_t(v.Value << i);
        public static nlink_t operator >>(nlink_t v, int i) => new nlink_t(v.Value >> i);
        public static bool operator ==(nlink_t v1, nlink_t v2) => v1.Value == v2.Value;
        public static bool operator !=(nlink_t v1, nlink_t v2) => v1.Value != v2.Value;
        public static bool operator <(nlink_t v1, nlink_t v2) => v1.Value < v2.Value;
        public static bool operator >(nlink_t v1, nlink_t v2) => v1.Value > v2.Value;
        public static bool operator <=(nlink_t v1, nlink_t v2) => v1.Value <= v2.Value;
        public static bool operator >=(nlink_t v1, nlink_t v2) => v1.Value >= v2.Value;
    }

    public partial struct blksize_t
    {
        public static implicit operator long(blksize_t arg) => arg.Value;
        public static implicit operator blksize_t(long arg) => new blksize_t(arg);

        public override string ToString() => Value.ToString();

        public override int GetHashCode() => Value.GetHashCode();

        public override bool Equals(object obj)
        {
            if (obj != null && obj is blksize_t v)
            {
                return this == v;
            }
            else
            {
                return false;
            }
        }

        public bool Equals(blksize_t v) => this == v;

        public static blksize_t operator +(blksize_t v) => new blksize_t(v.Value);
        public static blksize_t operator -(blksize_t v) => new blksize_t(-v.Value);
        public static blksize_t operator ~(blksize_t v) => new blksize_t(~v.Value);
        public static blksize_t operator ++(blksize_t v) => new blksize_t(v.Value + 1);
        public static blksize_t operator --(blksize_t v) => new blksize_t(v.Value - 1);
        public static blksize_t operator +(blksize_t v1, blksize_t v2) => new blksize_t(v1.Value + v2.Value);
        public static blksize_t operator -(blksize_t v1, blksize_t v2) => new blksize_t(v1.Value - v2.Value);
        public static blksize_t operator *(blksize_t v1, blksize_t v2) => new blksize_t(v1.Value * v1.Value);
        public static blksize_t operator /(blksize_t v1, blksize_t v2) => new blksize_t(v1.Value / v2.Value);
        public static blksize_t operator %(blksize_t v1, blksize_t v2) => new blksize_t(v1.Value % v2.Value);
        public static blksize_t operator &(blksize_t v1, blksize_t v2) => new blksize_t(v1.Value & v2.Value);
        public static blksize_t operator |(blksize_t v1, blksize_t v2) => new blksize_t(v1.Value | v2.Value);
        public static blksize_t operator ^(blksize_t v1, blksize_t v2) => new blksize_t(v1.Value ^ v2.Value);
        public static blksize_t operator <<(blksize_t v, int i) => new blksize_t(v.Value << i);
        public static blksize_t operator >>(blksize_t v, int i) => new blksize_t(v.Value >> i);
        public static bool operator ==(blksize_t v1, blksize_t v2) => v1.Value == v2.Value;
        public static bool operator !=(blksize_t v1, blksize_t v2) => v1.Value != v2.Value;
        public static bool operator <(blksize_t v1, blksize_t v2) => v1.Value < v2.Value;
        public static bool operator >(blksize_t v1, blksize_t v2) => v1.Value > v2.Value;
        public static bool operator <=(blksize_t v1, blksize_t v2) => v1.Value <= v2.Value;
        public static bool operator >=(blksize_t v1, blksize_t v2) => v1.Value >= v2.Value;
    }

    public struct ulong_t : IEquatable<ulong_t>
    {
        internal size_t __value;
        internal size_t Value => __value;

        private ulong_t(size_t value) => __value = value;

        public static implicit operator ulong(ulong_t arg) => arg.Value;
        public static explicit operator uint(ulong_t arg) => (uint)arg.Value;

        public static explicit operator ulong_t(ulong arg) => new ulong_t(new size_t(arg));
        public static implicit operator ulong_t(uint arg) => new ulong_t(arg);

        public override string ToString() => Value.ToString();

        public override int GetHashCode() => Value.GetHashCode();

        public override bool Equals(object obj)
        {
            if (obj != null && obj is ulong_t v)
            {
                return this == v;
            }
            else
            {
                return false;
            }
        }

        public bool Equals(ulong_t v) => this == v;

        public static ulong_t operator +(ulong_t v) => new ulong_t(v.Value);
        public static ulong_t operator ~(ulong_t v) => new ulong_t(~v.Value);
        public static ulong_t operator ++(ulong_t v) => new ulong_t(v.Value + 1);
        public static ulong_t operator --(ulong_t v) => new ulong_t(v.Value - 1);
        public static ulong_t operator +(ulong_t v1, ulong_t v2) => new ulong_t(v1.Value + v2.Value);
        public static ulong_t operator -(ulong_t v1, ulong_t v2) => new ulong_t(v1.Value - v2.Value);
        public static ulong_t operator *(ulong_t v1, ulong_t v2) => new ulong_t(v1.Value * v1.Value);
        public static ulong_t operator /(ulong_t v1, ulong_t v2) => new ulong_t(v1.Value / v2.Value);
        public static ulong_t operator %(ulong_t v1, ulong_t v2) => new ulong_t(v1.Value % v2.Value);
        public static ulong_t operator &(ulong_t v1, ulong_t v2) => new ulong_t(v1.Value & v2.Value);
        public static ulong_t operator |(ulong_t v1, ulong_t v2) => new ulong_t(v1.Value | v2.Value);
        public static ulong_t operator ^(ulong_t v1, ulong_t v2) => new ulong_t(v1.Value ^ v2.Value);
        public static ulong_t operator <<(ulong_t v, int i) => new ulong_t(v.Value << i);
        public static ulong_t operator >>(ulong_t v, int i) => new ulong_t(v.Value >> i);
        public static bool operator ==(ulong_t v1, ulong_t v2) => v1.Value == v2.Value;
        public static bool operator !=(ulong_t v1, ulong_t v2) => v1.Value != v2.Value;
        public static bool operator <(ulong_t v1, ulong_t v2) => v1.Value < v2.Value;
        public static bool operator >(ulong_t v1, ulong_t v2) => v1.Value > v2.Value;
        public static bool operator <=(ulong_t v1, ulong_t v2) => v1.Value <= v2.Value;
        public static bool operator >=(ulong_t v1, ulong_t v2) => v1.Value >= v2.Value;
    }

    public struct fsblkcnt_t
    {
        private ulong __value;
        internal ulong Value => __value;

        private fsblkcnt_t(ulong value) => __value = value;

        public static implicit operator ulong(fsblkcnt_t arg) => arg.Value;
        public static implicit operator fsblkcnt_t(ulong arg) => new fsblkcnt_t(arg);

        public override string ToString() => Value.ToString();

        public override int GetHashCode() => Value.GetHashCode();

        public override bool Equals(object obj)
        {
            if (obj != null && obj is fsblkcnt_t v)
            {
                return this == v;
            }
            else
            {
                return false;
            }
        }

        public bool Equals(fsblkcnt_t v) => this == v;

        public static fsblkcnt_t operator +(fsblkcnt_t v) => new fsblkcnt_t(v.Value);
        public static fsblkcnt_t operator ~(fsblkcnt_t v) => new fsblkcnt_t(~v.Value);
        public static fsblkcnt_t operator ++(fsblkcnt_t v) => new fsblkcnt_t(v.Value + 1);
        public static fsblkcnt_t operator --(fsblkcnt_t v) => new fsblkcnt_t(v.Value - 1);
        public static fsblkcnt_t operator +(fsblkcnt_t v1, fsblkcnt_t v2) => new fsblkcnt_t(v1.Value + v2.Value);
        public static fsblkcnt_t operator -(fsblkcnt_t v1, fsblkcnt_t v2) => new fsblkcnt_t(v1.Value - v2.Value);
        public static fsblkcnt_t operator *(fsblkcnt_t v1, fsblkcnt_t v2) => new fsblkcnt_t(v1.Value * v1.Value);
        public static fsblkcnt_t operator /(fsblkcnt_t v1, fsblkcnt_t v2) => new fsblkcnt_t(v1.Value / v2.Value);
        public static fsblkcnt_t operator %(fsblkcnt_t v1, fsblkcnt_t v2) => new fsblkcnt_t(v1.Value % v2.Value);
        public static fsblkcnt_t operator &(fsblkcnt_t v1, fsblkcnt_t v2) => new fsblkcnt_t(v1.Value & v2.Value);
        public static fsblkcnt_t operator |(fsblkcnt_t v1, fsblkcnt_t v2) => new fsblkcnt_t(v1.Value | v2.Value);
        public static fsblkcnt_t operator ^(fsblkcnt_t v1, fsblkcnt_t v2) => new fsblkcnt_t(v1.Value ^ v2.Value);
        public static fsblkcnt_t operator <<(fsblkcnt_t v, int i) => new fsblkcnt_t(v.Value << i);
        public static fsblkcnt_t operator >>(fsblkcnt_t v, int i) => new fsblkcnt_t(v.Value >> i);
        public static bool operator ==(fsblkcnt_t v1, fsblkcnt_t v2) => v1.Value == v2.Value;
        public static bool operator !=(fsblkcnt_t v1, fsblkcnt_t v2) => v1.Value != v2.Value;
        public static bool operator <(fsblkcnt_t v1, fsblkcnt_t v2) => v1.Value < v2.Value;
        public static bool operator >(fsblkcnt_t v1, fsblkcnt_t v2) => v1.Value > v2.Value;
        public static bool operator <=(fsblkcnt_t v1, fsblkcnt_t v2) => v1.Value <= v2.Value;
        public static bool operator >=(fsblkcnt_t v1, fsblkcnt_t v2) => v1.Value >= v2.Value;
    }

    public struct fsfilcnt_t
    {
        private ulong __value;
        internal ulong Value => __value;

        private fsfilcnt_t(ulong value) => __value = value;

        public static implicit operator ulong(fsfilcnt_t arg) => arg.Value;
        public static implicit operator fsfilcnt_t(ulong arg) => new fsfilcnt_t(arg);

        public override string ToString() => Value.ToString();

        public override int GetHashCode() => Value.GetHashCode();

        public override bool Equals(object obj)
        {
            if (obj != null && obj is fsfilcnt_t v)
            {
                return this == v;
            }
            else
            {
                return false;
            }
        }

        public bool Equals(fsfilcnt_t v) => this == v;

        public static fsfilcnt_t operator +(fsfilcnt_t v) => new fsfilcnt_t(v.Value);
        public static fsfilcnt_t operator ~(fsfilcnt_t v) => new fsfilcnt_t(~v.Value);
        public static fsfilcnt_t operator ++(fsfilcnt_t v) => new fsfilcnt_t(v.Value + 1);
        public static fsfilcnt_t operator --(fsfilcnt_t v) => new fsfilcnt_t(v.Value - 1);
        public static fsfilcnt_t operator +(fsfilcnt_t v1, fsfilcnt_t v2) => new fsfilcnt_t(v1.Value + v2.Value);
        public static fsfilcnt_t operator -(fsfilcnt_t v1, fsfilcnt_t v2) => new fsfilcnt_t(v1.Value - v2.Value);
        public static fsfilcnt_t operator *(fsfilcnt_t v1, fsfilcnt_t v2) => new fsfilcnt_t(v1.Value * v1.Value);
        public static fsfilcnt_t operator /(fsfilcnt_t v1, fsfilcnt_t v2) => new fsfilcnt_t(v1.Value / v2.Value);
        public static fsfilcnt_t operator %(fsfilcnt_t v1, fsfilcnt_t v2) => new fsfilcnt_t(v1.Value % v2.Value);
        public static fsfilcnt_t operator &(fsfilcnt_t v1, fsfilcnt_t v2) => new fsfilcnt_t(v1.Value & v2.Value);
        public static fsfilcnt_t operator |(fsfilcnt_t v1, fsfilcnt_t v2) => new fsfilcnt_t(v1.Value | v2.Value);
        public static fsfilcnt_t operator ^(fsfilcnt_t v1, fsfilcnt_t v2) => new fsfilcnt_t(v1.Value ^ v2.Value);
        public static fsfilcnt_t operator <<(fsfilcnt_t v, int i) => new fsfilcnt_t(v.Value << i);
        public static fsfilcnt_t operator >>(fsfilcnt_t v, int i) => new fsfilcnt_t(v.Value >> i);
        public static bool operator ==(fsfilcnt_t v1, fsfilcnt_t v2) => v1.Value == v2.Value;
        public static bool operator !=(fsfilcnt_t v1, fsfilcnt_t v2) => v1.Value != v2.Value;
        public static bool operator <(fsfilcnt_t v1, fsfilcnt_t v2) => v1.Value < v2.Value;
        public static bool operator >(fsfilcnt_t v1, fsfilcnt_t v2) => v1.Value > v2.Value;
        public static bool operator <=(fsfilcnt_t v1, fsfilcnt_t v2) => v1.Value <= v2.Value;
        public static bool operator >=(fsfilcnt_t v1, fsfilcnt_t v2) => v1.Value >= v2.Value;
    }
}