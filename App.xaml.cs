using odiazTS5A.Repository;

namespace odiazTS5A
{
    public partial class App : Application
    {
        public static PersonRepository personRepo {  get; set; }
        public App(PersonRepository personRepository)
        {
            InitializeComponent();

            MainPage = new NavigationPage(new Views.Register());
            personRepo = personRepository;
        }
    }
}
