namespace LoginWebApi
{
    public class MemberDto
    {
        public int MemberId { get; set; }
        public string Email { get; set; } =String.Empty;
        public string Password { get; set; } = String.Empty;
    }
}
