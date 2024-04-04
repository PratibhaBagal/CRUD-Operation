namespace Mytask.Models
{
    public class UpdateUser
    {
        public Guid Id { get; set; }

        public int UserId { get; set; }
        public string Name { get; set; }
        public string Email { get; set; }
        public string Phone { get; set; }
        public string Address { get; set; }

        public long Salary { get; set; }
        public DateTime CreatedDate { get; set; }
        public string Department { get; set; }
        public string Description { get; set; }
    }
}
