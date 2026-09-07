namespace Order.Domain
{
    public class UserProfile
    {
        public int Id { get; set; } 
        public string Address { get; set;}



        //Foregin Key
        public int UserId {  get; set; }    

        //navigation properly

        // here each userprofile belong to one user
        public User User { get; set; }
    }
}
