namespace SDEV248Midterm {
    public abstract class Item {
        public string itemName { private set; get; }
        public string description { private set; get; }
        public string effect { private set; get; }
        public bool usable { private set; get; }


        public Item(string name, string description, string effect, bool usable)
        {
            itemName = name;
            this.description = description;
            this.usable = usable;
            this.effect = effect;
        }

        //each item will set up their own use
        public abstract void Use(Player player);

        public override string ToString()
        {
            return description;
        }

    }
}