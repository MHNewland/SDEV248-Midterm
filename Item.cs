namespace SDEV248Midterm {
    public abstract class Item {
        public string itemName { private set; get; }
        public string description { private set; get; }
        public bool usable { private set; get; }


        public Item(string description, bool usable)
        {
            this.description = description;
            this.usable = usable;
        }

        //each item will set up their own use
        public abstract void Use();

    }
}