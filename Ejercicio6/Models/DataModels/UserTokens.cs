﻿namespace UniversityApiBackend.Models.DataModels
{
    public class UserTokens
    {
        public int Id { get; set; }
        public string? Token { get; set; }
        public string? Username { get; set; }
        public TimeSpan Validity { get; set; }
        public string? RefreshToken { get; set; }
        public string? EmailId { get; set; }
        public Guid GuidId { get; set; }
        public DateTime ExpiredTime { get; set; }
        public string? Role { get; set; } = "User";
    }
}
