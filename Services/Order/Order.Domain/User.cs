namespace Order.Domain
{
    public class User
    {
       public int Id { get; set; }  
       public string Name { get; set; }
        public string Email { get; set; }


        //one to one relationships between user and user profile table
        //one user have only one user profile

        public UserProfile UserProfile { get; set; }

        //one to many relationships

        // one user can have multiple order

        // and each order belongs only one user


        public ICollection<OrderTable> Orders { get; set; } = new List<OrderTable>();
    }
}
