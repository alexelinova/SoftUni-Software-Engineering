namespace P01.Stream_Progress
{
    public class StreamProgressInfo
    {
        private readonly IProgressable stream;
        
        public StreamProgressInfo(IProgressable progressable )
        {
            this.stream = progressable;
        }

        public int CalculateCurrentPercent()
        {
            return (this.stream.BytesSent * 100) / this.stream.Length;
        }
    }
}
