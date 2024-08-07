using Microsoft.EntityFrameworkCore;
using SurveyApp.Data;

namespace SurveyApp
{
    public partial class App : Application
    {
        private readonly ApplicationDbContext _context;

        public App(ApplicationDbContext context)
        {
            InitializeComponent();

            _context = context;
            _context.Database.Migrate();
            MainPage = new MainPage();
            

        }

        
    }
}
