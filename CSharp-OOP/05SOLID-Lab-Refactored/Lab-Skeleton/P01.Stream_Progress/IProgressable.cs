﻿namespace P01.Stream_Progress
{
    public interface IProgressable
    {
        public int Length { get;}

        public int BytesSent { get;}
    }
}
