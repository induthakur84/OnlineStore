namespace Order.Domain
{
    public class OrderTable
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }

       // navigation property
        // each order belongs to only one user

        public int UserId { get; set; }

        public User User { get; set; }

    }
}
