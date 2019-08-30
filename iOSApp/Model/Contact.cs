namespace iOSApp.Model
{
    public class Contact
    {
        public string Name { get; set; }
        public string Email { get; set; }
        public string PhoneNumber { get; set; }

        public Contact(string n, string e, string pN)
        {
            Name = n;
            Email = e;
            PhoneNumber = pN;
        }
    }
}