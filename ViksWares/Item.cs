namespace csharp
{ 
    public class Item
    {
        public string Name { get; set; }
        public int SellBy { get; set; }
        public int Value { get; set; }

        public override string ToString()
        {
            return this.Name + ", " + this.SellBy + ", " + this.Value;
        }  
    }
}
