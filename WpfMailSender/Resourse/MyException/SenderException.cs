using System;

namespace WpfMailSender.Resourse.MyException
{
    public delegate void Message();

    class SenderException : Exception
    {
        public SenderException(string Msg) : base(Msg)
        {
        }
    }
}
