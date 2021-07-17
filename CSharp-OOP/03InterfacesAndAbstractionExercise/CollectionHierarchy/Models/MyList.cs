using CollectionHierarchy.Contracts;

namespace CollectionHierarchy.Models
{
    public class MyList : Collection, IMyList
    {
        public int Used => this.Data.Count;

        public string Remove()
        {
            string item = this.Data[0];
            this.Data.RemoveAt(0);

            return item;
        }
    }
}
