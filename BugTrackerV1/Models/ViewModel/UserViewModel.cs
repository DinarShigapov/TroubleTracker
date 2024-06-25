namespace BugTrackerV1.Models.ViewModel
{
    public class UserViewModel
    {
        public UserViewModel(User user) 
        {
            this.User = user;
            Id = user.Id;
        }
        private User User { get; set; }
        public int Id { get; set; }
        public string UserImage { get; set; }
        public string FullNameUser => $"{User.LastName} {User.FirstName} {User.Patronymic}";
        public string ShortNameUser => $"{User.LastName} {User.FirstName.ToCharArray()[0]}. {User.Patronymic.ToCharArray()[0]}.";
    }
}
