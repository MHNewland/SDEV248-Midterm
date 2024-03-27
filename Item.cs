namespace SDEV248Midterm {
    public abstract class Item {
        string description;
        bool usable;

        public Item(string description, bool usable)
        {
            this.description = description;
            this.usable = usable;
        }
    }
}